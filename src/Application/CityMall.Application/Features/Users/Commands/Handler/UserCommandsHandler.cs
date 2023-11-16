using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;

using CityMall.Specifications.Specifications.Jwts;

using Microsoft.EntityFrameworkCore.Storage;

namespace CityMall.Application.Features.Users.Commands.Handler;
public sealed class UserCommandsHandler :
    IRequestHandler<AddUserCommand, ResponseModel<AuthDto>>,
    IRequestHandler<UpdateUserByIdCommand, ResponseModel<GetUserDto>>,
    IRequestHandler<DeleteUserByIdCoammnd, ResponseModel<GetUserDto>>,
    IRequestHandler<UndoDeleteUserByIdCommand, ResponseModel<GetUserDto>>,
    IRequestHandler<LoginUserCommand, ResponseModel<AuthDto>>,
    IRequestHandler<RefreshjWTCommand, ResponseModel<AuthDto>>,
    IRequestHandler<LogOutUserCommand, ResponseModel<string>>,
    IRequestHandler<ConfirmeEmailCommand, ResponseModel<string>>,
    IRequestHandler<ChangePasswordCommand, ResponseModel<string>>,
    IRequestHandler<SendResetPasswordTokenCommand, ResponseModel<SendEmailDto>>,
    IRequestHandler<ResetPasswordCommand, ResponseModel<string>>
{
    #region Fields
    private readonly IUnitOfWork _context;
    private readonly IUnitOfServices _services;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    #endregion

    #region Ctor
    public UserCommandsHandler(IUnitOfWork context, IUnitOfServices services, ISpecificationsFactory specificationsFactory, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _services = services;
        _specificationsFactory = specificationsFactory;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }
    #endregion

    #region Add User
    public async Task<ResponseModel<AuthDto>>
            Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // check user email
            ISpecification<User> asNoTrackingGetUserByEmailSpec =
                _specificationsFactory.CreateUserSpecifications(
                    typeof(AsNoTrackingGetUserByEmailSpecification),
                        request.Dto.Email);

            if (await _context.Users.AnyAsync(
                        asNoTrackingGetUserByEmailSpec, cancellationToken))
                return ResponseResult.Conflict<AuthDto>();

            // check user name
            ISpecification<User> asNoTrackingGetUserByUserNameSpec =
                _specificationsFactory.CreateUserSpecifications(
                    typeof(AsNoTrackingGetUserByUserNameSpecification), request.Dto.UserName);

            if (await _context.Users.AnyAsync(
                        asNoTrackingGetUserByUserNameSpec, cancellationToken))
                return ResponseResult.Conflict<AuthDto>();

            // add user
            User user = _mapper.Map<User>(request.Dto);

            // add user photo if exist
            if (request.Dto.Image is not null)
            {
                _services.FileService.EnsureFileSize(request.Dto.Image);
                _services.FileService.EnsureFileExctension(request.Dto.Image);

                UploadFileResultDto uploadFileResult = await _services.FileService.UploadFileAsync(request.Dto.Image, FilesStores.UserProfilePhoto);
                if (!uploadFileResult.Success)
                    return ResponseResult.BadRequest<AuthDto>();

                user.FileName = uploadFileResult.FileName;
                user.FilePath = uploadFileResult.FilePath;
            }
            IdentityResult result = await _context.Identity.UserManager.CreateAsync(user, request.Dto.Password);

            if (!result.Succeeded)
                return ResponseResult.BadRequest<AuthDto>();

            // generate confirme email token
            string token = await _context.Identity.UserManager.GenerateEmailConfirmationTokenAsync(user);
            HttpRequest httpRequest = _httpContextAccessor.HttpContext.Request;

            // redirect url
            string redirectUrl = $"{httpRequest.Scheme.Trim()}://{httpRequest.Host.ToUriComponent().Trim().ToLower()}/{Router.User.ConfirmeEmail}";

            // set confirme email parameters
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "userId" , user.Id},
                {"token",token}
            };

            // create uri
            Uri url = new Uri(QueryHelpers.AddQueryString(redirectUrl, parameters));

            // send email
            SendEmailDto sendEmailDto = await _services.EmailService.SendEmailAsync(user.Email, "Confirm Your Email", url.ToString());

            if (!sendEmailDto.IsSendSuccess)
                return ResponseResult.BadRequest<AuthDto>();

            // add jwt token for user
            AuthDto authDto = await _services.AuthService.GetJWTAsync(user);

            if (authDto is null)
                return ResponseResult.BadRequest<AuthDto>();

            return ResponseResult.Created(authDto);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<AuthDto>(errors: ex.Message);
        }
    }

    #endregion

    #region Update User Data
    public async Task<ResponseModel<GetUserDto>>
            Handle(UpdateUserByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<User> asNoTrackingGetUnDeletedUserByIdSpec =
                    _specificationsFactory.CreateUserSpecifications(
              typeof(AsNoTrackingGetUnDeletedUserByIdSpecification), request.Dto.UserId);

            if (!await _context.Users.AnyAsync(asNoTrackingGetUnDeletedUserByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetUserDto>();

            ISpecification<User> asTrackingGetUnDeletedUserByIdSpec =
                _specificationsFactory.CreateUserSpecifications(
                    typeof(AsTrackingGetUnDeletedUserByIdSpecification), request.Dto.UserId);

            User user = await _context.Users.RetrieveAsync(asTrackingGetUnDeletedUserByIdSpec, cancellationToken);
            user.FirstName = request.Dto.FirstName;
            user.LastName = request.Dto.LastName;
            user.PhoneNumber = request.Dto.PhoneNumber;
            user.WhatsAppNumber = request.Dto.WhatsAppNumber;
            await _context.SaveChangesAsync(cancellationToken);
            GetUserDto Dto = _mapper.Map<GetUserDto>(user);
            return ResponseResult.Success(Dto);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetUserDto>(errors: ex.Message);

        }
    }
    #endregion

    #region Delete User By Id
    public async Task<ResponseModel<GetUserDto>>
            Handle(DeleteUserByIdCoammnd request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<User> asNoTrackingGetUnDeletedUserByIdSpec =
                    _specificationsFactory.CreateUserSpecifications(
                         typeof(AsNoTrackingGetUnDeletedUserByIdSpecification), request.UserId);

            if (!await _context.Users.AnyAsync(asNoTrackingGetUnDeletedUserByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetUserDto>();

            await _context.Users.ExecuteDeleteAsync(asNoTrackingGetUnDeletedUserByIdSpec, cancellationToken);
            return ResponseResult.Success<GetUserDto>();
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetUserDto>(errors: ex.Message);
        }
    }
    #endregion

    #region Undo Delete User By Id
    public async Task<ResponseModel<GetUserDto>>
            Handle(UndoDeleteUserByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<User> asNoTrackingGetDeletedUserByIdSpec =
                _specificationsFactory.CreateUserSpecifications(
                    typeof(AsNoTrackingGetDeletedUserByIdSpecification), request.UserId);

            if (!await _context.Users.AnyAsync(asNoTrackingGetDeletedUserByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetUserDto>();

            ISpecification<User> asTrackingGetDeletedUserByIdSpec =
                _specificationsFactory.CreateUserSpecifications(typeof(AsTrackingGetDeletedUserByIdSpecification), request.UserId);

            User user = await _context.Users.RetrieveAsync(asTrackingGetDeletedUserByIdSpec, cancellationToken);
            _context.UndoDeleted(ref user);
            await _context.SaveChangesAsync(cancellationToken);

            return ResponseResult.Success<GetUserDto>();
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetUserDto>(errors: ex.Message);
        }
    }
    #endregion

    #region Login User
    public async Task<ResponseModel<AuthDto>>
            Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<User> asNoTrackingGetUnDeletedUserByEmailSpec =
                _specificationsFactory.CreateUserSpecifications(
                    typeof(AsNoTrackingGetUnDeletedUserByEmailSpecification), request.Dto.EmailOrUserName);

            ISpecification<User> asNoTrackingGetUnDeletedUserByUserNameSpec =
                _specificationsFactory.CreateUserSpecifications(
                    typeof(AsNoTrackingGetUnDeletedUserByUserNameSpecification), request.Dto.EmailOrUserName);

            if (!await _context.Users.AnyAsync(new EmailAddressAttribute().
                    IsValid(request.Dto.EmailOrUserName) ?
                        asNoTrackingGetUnDeletedUserByEmailSpec :
                        asNoTrackingGetUnDeletedUserByUserNameSpec, cancellationToken))
                return ResponseResult.NotFound<AuthDto>();

            ISpecification<User> asTrackingGetUnDeletedUserByUserName_UserjWTs_Spec =
                _specificationsFactory.CreateUserSpecifications(
                    typeof(AsTrackingGetUnDeletedUserByUserName_UserjWTs_Specification), request.Dto.EmailOrUserName);

            ISpecification<User> asTrackingGetUnDeletedUserByEmail_UserjWTs_Spec =
                _specificationsFactory.CreateUserSpecifications(
                    typeof(AsTrackingGetUnDeletedUserByEmail_UserjWTs_Specification), request.Dto.EmailOrUserName);

            User user = await _context.Users.RetrieveAsync(new EmailAddressAttribute()
                .IsValid(request.Dto.EmailOrUserName) ?
                    asTrackingGetUnDeletedUserByEmail_UserjWTs_Spec :
                    asTrackingGetUnDeletedUserByUserName_UserjWTs_Spec, cancellationToken);

            if (!user.EmailConfirmed)
                return ResponseResult.UnAuthorized<AuthDto>();

            if (!await _context.Identity.UserManager.CheckPasswordAsync(user, request.Dto.Password))
                return ResponseResult.UnAuthorized<AuthDto>();

            AuthDto Dto = await _services.AuthService.GetJWTAsync(user);

            if (Dto is null)
                return ResponseResult.UnAuthorized<AuthDto>();

            return ResponseResult.Success(Dto);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<AuthDto>(errors: ex.Message);
        }
    }
    #endregion

    #region LogOut User
    public async Task<ResponseModel<string>>
            Handle(LogOutUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<UserJWT> asNoTrackingGetUserJwtByJWTWithRefreshJWTSpec =
                _specificationsFactory.CreateUserJwtsSpecifications(
                    typeof(AsNoTrackingGetUserJwtByJWTWithRefreshJWTSpecification),
                        request.Dto.Jwt, request.Dto.RefrestToken);

            if (!await _context.UserJWTs.AnyAsync(asNoTrackingGetUserJwtByJWTWithRefreshJWTSpec, cancellationToken))
                return ResponseResult.NotFound<string>();

            ISpecification<UserJWT> asNoTrackingGetUserJwtByJWTWithRefreshJWT_User_Spec =
                    _specificationsFactory.CreateUserJwtsSpecifications(
                        typeof(AsNoTrackingGetUserJwtByJWTWithRefreshJWT_User_Specification),
                            request.Dto.Jwt, request.Dto.RefrestToken);

            UserJWT userjWT = await _context.UserJWTs.RetrieveAsync(
                                asNoTrackingGetUserJwtByJWTWithRefreshJWT_User_Spec,
                                    cancellationToken);

            if (!await _services.AuthService.RevokeJWTAsync(userjWT))
                return ResponseResult.BadRequest<string>();

            return ResponseResult.Success<string>();
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<string>(errors: ex.Message);
        }
    }
    #endregion

    #region Refresh jWT
    public async Task<ResponseModel<AuthDto>>
            Handle(RefreshjWTCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<UserJWT> AsNoTrackingGetUserJwtByJWTWithRefreshJWTSpec =
                _specificationsFactory.CreateUserJwtsSpecifications(
                    typeof(AsNoTrackingGetUserJwtByJWTWithRefreshJWTSpecification),
                         request.Dto.JWT, request.Dto.RefreshToken);

            if (!await _context.UserJWTs.AnyAsync(AsNoTrackingGetUserJwtByJWTWithRefreshJWTSpec, cancellationToken))
                return ResponseResult.NotFound<AuthDto>();

            JwtSecurityToken jwtSecurityToken = await _services.AuthService.ReadJWTAsync(request.Dto.JWT);

            if (!await _services.AuthService.IsJWTValid.Invoke(request.Dto.JWT, jwtSecurityToken))
                return ResponseResult.BadRequest<AuthDto>();

            ISpecification<UserJWT> asNoTrackingGetUserJwtByJWTWithRefreshJWT_User_Spec =
                _specificationsFactory.CreateUserJwtsSpecifications(
                    typeof(AsNoTrackingGetUserJwtByJWTWithRefreshJWT_User_Specification),
                            request.Dto.JWT, request.Dto.RefreshToken);

            UserJWT userjWT = await _context.UserJWTs.RetrieveAsync(asNoTrackingGetUserJwtByJWTWithRefreshJWT_User_Spec, cancellationToken);

            if (userjWT.User is null)
                return ResponseResult.NotFound<AuthDto>();

            AuthDto dto = await _services.AuthService.RefreshJWTAsync(userjWT);

            if (dto is null)
                return ResponseResult.BadRequest<AuthDto>();

            return ResponseResult.Success(dto);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<AuthDto>(errors: ex.Message);
        }
    }
    #endregion

    #region Confirme Email
    public async Task<ResponseModel<string>> Handle(ConfirmeEmailCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _context.Identity.ConfirmEmailAsync(request.UserId, request.Token))
                return ResponseResult.BadRequest<string>();

            return ResponseResult.Success<string>();
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<string>(errors: ex.Message);
        }
    }
    #endregion

    #region Change Password
    public async Task<ResponseModel<string>>
        Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<User> asNoTrackingGetUnDeletedUserByEmailSpec = _specificationsFactory.CreateUserSpecifications(
                    typeof(AsNoTrackingGetUnDeletedUserByEmailSpecification),
                        request.Dto.Email);

            if (!await _context.Users.AnyAsync(asNoTrackingGetUnDeletedUserByEmailSpec, cancellationToken))
                return ResponseResult.NotFound<string>();

            User user = await _context.Users.RetrieveAsync(asNoTrackingGetUnDeletedUserByEmailSpec, cancellationToken);



            //bool checkPasswordSuccess = await _context.Identity.UserManager.CheckPasswordAsync(user, request.Dto.OldPassword);

            //if (!checkPasswordSuccess)
            //    return ResponseResult.BadRequest<string>();


            IdentityResult identityResult = await _context.Identity.UserManager.ChangePasswordAsync(user, request.Dto.CurrentPassord, request.Dto.NewPassword);

            if (!identityResult.Succeeded)
                return ResponseResult.UnAuthorized<string>();

            return ResponseResult.Success<string>();
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<string>(errors: ex.Message);
        }
    }
    #endregion

    #region Send Reset Password Code
    public async Task<ResponseModel<SendEmailDto>>
        Handle(SendResetPasswordTokenCommand request, CancellationToken cancellationToken)
    {

        ISpecification<User> asNoTrackingGetUnDeletedUserByIdSpec = _specificationsFactory.CreateUserSpecifications(
                typeof(AsNoTrackingGetUnDeletedUserByIdSpecification),
                    request.Dto.UserId);

        if (!await _context.Users.AnyAsync(asNoTrackingGetUnDeletedUserByIdSpec, cancellationToken))
            return ResponseResult.NotFound<SendEmailDto>();

        // generate
        ISpecification<User> asTrackingGetUnDeletedUserByIdSpec = _specificationsFactory.CreateUserSpecifications(
            typeof(AsTrackingGetUnDeletedUserByIdSpecification),
                    request.Dto.UserId);

        User user = await _context.Users.RetrieveAsync(asTrackingGetUnDeletedUserByIdSpec, cancellationToken);

        if (user.EmailConfirmed)
            return ResponseResult.BadRequest<SendEmailDto>();

        SendEmailDto sendEmailDto = new SendEmailDto();
        using (IDbContextTransaction transaction = await _context.BeginTransactionAsync(cancellationToken))
        {
            try
            {
                user.ChangePasswordToken = await _context.Identity.UserManager.GeneratePasswordResetTokenAsync(user);
                await _context.SaveChangesAsync(cancellationToken);

                sendEmailDto = await _services.EmailService.SendEmailAsync(
                     request.Dto.Email, "Reset your password", user.ChangePasswordToken);

                if (!sendEmailDto.IsSendSuccess)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    return ResponseResult.BadRequest<SendEmailDto>();
                }
                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
            }
        }
        return ResponseResult.Success(sendEmailDto);
    }
    #endregion

    #region Reset Password 
    public async Task<ResponseModel<string>>
        Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<User> asNoTrackingGetUnDeletedUserByIdSpec = _specificationsFactory.CreateUserSpecifications(
                    typeof(AsNoTrackingGetUnDeletedUserByIdSpecification),
                        request.Dto.UserId);

            if (!await _context.Users.AnyAsync(asNoTrackingGetUnDeletedUserByIdSpec, cancellationToken))
                return ResponseResult.NotFound<string>();

            User user = await _context.Users.RetrieveAsync(asNoTrackingGetUnDeletedUserByIdSpec, cancellationToken);

            IdentityResult resetPasswordResult = await _context.Identity.UserManager.
                                                                    ResetPasswordAsync(
                                                                    user, request.Dto.Token, request.Dto.NewPassword);

            if (!resetPasswordResult.Succeeded)
                return ResponseResult.BadRequest<string>();

            return ResponseResult.Success<string>();
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<string>(errors: ex.Message);
        }
    }
    #endregion
}
