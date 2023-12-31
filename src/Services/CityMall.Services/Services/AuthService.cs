﻿using CityMall.Dtos.Dtos.Auth;
using CityMall.Infrastructure.Repositories.Contracts;
using CityMall.Specifications.Contracts;
using CityMall.Specifications.Specifications.Roles;

namespace CityMall.Services.Services;
public sealed class AuthService : IAuthService
{
    private readonly IUnitOfWork _context;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly JwtSettings _jWTSettings;
    public AuthService(IUnitOfWork context, IOptions<JwtSettings> options, ISpecificationsFactory specificationsFactory)
    {
        _context = context;
        _jWTSettings = options.Value;
        _specificationsFactory = specificationsFactory;
    }
    /// <summary>
    /// Delegate which pointer at result of JWT Validation (Parameraters Validation) && (Algorithm Validation)
    /// </summary>
    public Func<string, JwtSecurityToken, Task<bool>> IsJWTValid
        => async (jwt, jwtSecurityToken) =>
        await IsJWTParametersValidAsync(jwt) && await IsJWTAlgorithmValidAsync(jwtSecurityToken);

    /// <summary>
    /// get JWT for specific user and if user does't have a jwt in data base, will get a new jwt after save in data base 
    /// </summary>
    /// <param name="user">User that you need to get JWT for him</param>
    /// <returns>Task of AuthDto</returns>
    public async Task<AuthDto> GetJWTAsync(User user)
    {
        var authDto = new AuthDto();

        if (user.UserJWTs.Count > 0 && user.UserJWTs.Any(jwt => jwt.IsRefreshJWTActive))
        {
            var activeUserJWT = user.UserJWTs.Where(jwt => jwt.IsRefreshJWTActive).FirstOrDefault();

            authDto.JwtDto = new()
            {
                JWT = activeUserJWT?.JWT,
                JWTExpirationDate = activeUserJWT.JWTExpirationDate,
            };

            authDto.RefreshJwtDto = new()
            {
                RefreshJWT = activeUserJWT.RefreshJWT,
                RefreshJWTExpirationDate = activeUserJWT.RefreshJWTExpirtionDate
            };
        }
        else
        {
            var accessToken = await GenerateJWTAsync(user, GetClaimsAsync);

            var refreshJwtDto = GetRefreshToken();

            var userJWT = new UserJWT
            {
                JWT = accessToken,
                RefreshJWT = refreshJwtDto.RefreshJWT,
                IsRefreshJWTUsed = true,
                UserId = user.Id,
                JWTExpirationDate = DateTime.Now.AddDays(_jWTSettings.AccessTokenExpireDate),
                RefreshJWTExpirtionDate = DateTime.Now.AddDays(_jWTSettings.RefreshTokenExpireDate),
            };

            try
            {
                user.UserJWTs.Add(userJWT);
                // await _context.Users.UpdateAsync(user);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return null;
            }

            authDto.JwtDto = new()
            {
                JWT = userJWT.JWT,
                JWTExpirationDate = userJWT.JWTExpirationDate
            };

            authDto.RefreshJwtDto = new()
            {
                RefreshJWT = userJWT.RefreshJWT,
                RefreshJWTExpirationDate = userJWT.RefreshJWTExpirtionDate
            };
        }
        return authDto;
    }


    /// <summary>
    /// Read given JWT
    /// </summary>
    /// <param name="jwt">Specific JWT for reading</param>
    /// <returns>Task of JwtSecurityToken</returns>
    public Task<JwtSecurityToken> ReadJWTAsync(string jwt)
    {
        if (string.IsNullOrEmpty(jwt) || string.IsNullOrWhiteSpace(jwt))
            return null;

        return Task.FromResult(new JwtSecurityTokenHandler().ReadJwtToken(jwt));
    }

    /// <summary>
    /// [ Refresh For given user ] 
    /// [1] step one: Get user jwt
    /// [2] step two: If user jwt is null <see cref="null"/>
    /// [3] step three: Revoke Old refreshJWT
    /// [4 , 5] step four: Generate new JWT & Generate new RefreshJWT 
    /// [6] step five: Create new UserJWT instance and add save it in data base & if saving in data base is fail , will return <see cref="null"/> 
    /// [7] step seven: Create AuthDto instance and return it after fill his Props
    /// </summary>
    /// <param name="user">specific user need to refresh token</param>
    /// <returns>Task of AuthDto</returns>
    public async Task<AuthDto> RefreshJWTAsync(UserJWT userjWT)
    {
        // revoke refresh JWT
        userjWT.RefreshJWTRevokedDate = DateTime.Now;
        userjWT.IsRefreshJWTUsed = false;

        var jwt = await GenerateJWTAsync(userjWT.User, GetClaimsAsync);
        var refreshJWT = GenerateRefreshToken();

        // add new refresh token to user
        var newUserJWT = new UserJWT()
        {
            UserId = userjWT.User.Id,
            JWT = jwt,
            JWTExpirationDate = DateTime.Now.AddDays(_jWTSettings.AccessTokenExpireDate),
            RefreshJWT = refreshJWT,
            RefreshJWTExpirtionDate = DateTime.Now.AddDays(_jWTSettings.RefreshTokenExpireDate),
            IsRefreshJWTUsed = true,
        };
        using (var transaction = await _context.BeginTransactionAsync())
        {
            try
            {
                await _context.UserJWTs.UpdateAsync(userjWT);
                await _context.UserJWTs.CreateAsync(newUserJWT);
                await _context.SaveChangesAsync();
                await _context.CommitTransactionAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
            }
        }


        //var identityResult = await _context.Identity.UserManager.UpdateAsync(user);

        //if (!identityResult.Succeeded)
        //    return null;

        return new AuthDto()
        {
            JwtDto = new()
            {
                JWT = newUserJWT.JWT,
                JWTExpirationDate = newUserJWT.JWTExpirationDate
            },
            RefreshJwtDto = new()
            {
                RefreshJWT = newUserJWT.RefreshJWT,
                RefreshJWTExpirationDate = newUserJWT.RefreshJWTExpirtionDate
            }
        };
    }

    public async Task<bool> RevokeJWTAsync(UserJWT userJWT)
    {
        try
        {
            userJWT.IsRefreshJWTUsed = false;
            userJWT.RefreshJWTRevokedDate = DateTime.Now;
            await _context.UserJWTs.UpdateAsync(userJWT);
            int result = await _context.SaveChangesAsync();
            return result != 0 ? true : false;
        }
        catch
        {
            return false;
        }
    }


    /// <summary>
    /// Check validation at given jwt parameters 
    /// </summary>
    /// <param name="jwt">Specific JWT</param>
    /// <returns>Task of boolean (<see langword="true"/> or <see langword="false"/>)</returns>
    private Task<bool> IsJWTParametersValidAsync(string jwt)
    {
        var handler = new JwtSecurityTokenHandler();
        var parameters = new TokenValidationParameters
        {
            ValidateIssuer = _jWTSettings.ValidateIssuer,
            ValidIssuers = new[] { _jWTSettings.Issuer },
            ValidateIssuerSigningKey = _jWTSettings.ValidateIssuerSigningKey,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jWTSettings.Secret)),
            ValidAudience = _jWTSettings.Audience,
            ValidateAudience = _jWTSettings.ValidateAudience,
            ValidateLifetime = _jWTSettings.ValidateLifeTime,
        };
        try
        {
            var validator = handler.ValidateToken(jwt, parameters, out SecurityToken validatedToken);

            if (validatedToken == null)
                return Task.FromResult(false);
        }
        catch
        {
            return Task.FromResult(false);
        }
        return Task.FromResult(true);
    }

    /// <summary>
    /// Check validation at given jwt algorithm 
    /// </summary>
    /// <param name="jwtSecurityToken">Specific jwtSecurityToken</param>
    /// <returns>Task of boolean (<see langword="true"/> or <see langword="false"/>)</returns>
    private async Task<bool> IsJWTAlgorithmValidAsync(JwtSecurityToken jwtSecurityToken) =>
         await Task.FromResult(jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature));

    /// <summary>
    /// Get refresh token
    /// </summary>
    /// <returns>RefreshJwtDto</returns>
    private GetRefreshJwtDto GetRefreshToken()
    {
        var refreshToken = new GetRefreshJwtDto
        {
            RefreshJWTExpirationDate = DateTime.Now.AddDays(_jWTSettings.RefreshTokenExpireDate),
            RefreshJWT = GenerateRefreshToken()
        };
        return refreshToken;
    }

    /// <summary>
    /// Generate refresh token
    /// </summary>
    /// <returns>refresh token string</returns>
    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        var randomNumberGenerate = RandomNumberGenerator.Create();
        randomNumberGenerate.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    /// <summary>
    /// Generate JWT for specific user
    /// </summary>
    /// <param name="user">User that you need to get JWT for him</param>
    /// <param name="getClaims">Delegate that pointer get claims for specific user</param>
    /// <returns>Task of new token string</returns>
    private async Task<string> GenerateJWTAsync(User user, Func<User, Task<List<Claim>>> getClaims)
    {
        var claims = await getClaims.Invoke(user);
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jWTSettings.Secret));
        var jwtToken = new JwtSecurityToken(issuer: _jWTSettings.Issuer, audience: _jWTSettings.Audience, claims: claims, expires: DateTime.Now.AddDays(_jWTSettings.AccessTokenExpireDate), signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature));
        var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

        return accessToken;
    }

    private async Task<List<Claim>> GetClaimsAsync(User user)
    {
        var userRolesNames = await _context.Identity.UserManager.GetRolesAsync(user);
        var userClaims = await _context.Identity.UserManager.GetClaimsAsync(user);

        #region Get Permissions

        // get user roles
        //GetRolesByNameSpecification getRolesByNameSpec = new(userRolesNames);
        var getRolesByNameSpec = _specificationsFactory.CreateRoleSpecifications(typeof(AsNoTrackingGetAllRoleByRoleNamesSpecification), userRolesNames);

        var userRoles = (await _context.Roles.RetrieveAllAsync(getRolesByNameSpec)).ToList();

        // get role claims
        var permissions = new List<Claim>();
        foreach (var role in userRoles)
        {
            var roleClams = await _context.Identity.RoleManager.GetClaimsAsync(role);
            permissions.AddRange(roleClams);
        }

        #endregion

        var claims = new List<Claim>()
        {
            new (ClaimTypes.PrimarySid, user.Id),
            new (ClaimTypes.Name,user.UserName),
            new (ClaimTypes.Email,user.Email),
        };

        foreach (var role in userRolesNames)
            claims.Add(new(ClaimTypes.Role, role));

        claims.AddRange(userClaims);
        claims.AddRange(permissions);

        return claims;
        throw new NotImplementedException();
    }

}
