using System.ComponentModel.DataAnnotations;

using CityMall.Specifications.Specifications.Jwts;

namespace CityMall.Application.Features.Users.Commands.Handler;
public sealed class UserCommandsHandler :
    IRequestHandler<AddUserCommand, ResponseModel<AuthDto>>,
    IRequestHandler<UpdateUserByIdCommand, ResponseModel<GetUserDto>>,
    IRequestHandler<DeleteUserByIdCoammnd, ResponseModel<GetUserDto>>,
    IRequestHandler<UndoDeleteUserByIdCommand, ResponseModel<GetUserDto>>,
    IRequestHandler<LoginUserCommand, ResponseModel<AuthDto>>,
    IRequestHandler<LogOutUserCommand, ResponseModel<string>>
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
    public async Task<ResponseModel<AuthDto>> Handle(AddUserCommand request, CancellationToken cancellationToken)

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
            IdentityResult result = await _context.Identity.UserManager.CreateAsync(user);

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
                {"Token",token},
                { "UserId" , user.Id}
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
    public async Task<ResponseModel<GetUserDto>> Handle(UpdateUserByIdCommand request, CancellationToken cancellationToken)
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
            user.FirstName = user.FirstName;
            user.LastName = user.LastName;
            user.PhoneNumber = user.PhoneNumber;
            user.WhatsAppNumber = user.WhatsAppNumber;
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
    public async Task<ResponseModel<GetUserDto>> Handle(DeleteUserByIdCoammnd request, CancellationToken cancellationToken)
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
    public async Task<ResponseModel<GetUserDto>> Handle(UndoDeleteUserByIdCommand request, CancellationToken cancellationToken)
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
    public async Task<ResponseModel<AuthDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
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

            ISpecification<User> asTrackingGetUnDeletedUserByUserNameSpec =
                _specificationsFactory.CreateUserSpecifications(
                    typeof(AsTrackingGetUnDeletedUserByUserNameSpecification), request.Dto.EmailOrUserName);

            ISpecification<User> asTrackingGetUnDeletedUserByEmailSpec =
                _specificationsFactory.CreateUserSpecifications(
                    typeof(AsTrackingGetUnDeletedUserByEmailSpecification), request.Dto.EmailOrUserName);

            User user = await _context.Users.RetrieveAsync(new EmailAddressAttribute()
                .IsValid(request.Dto.EmailOrUserName) ?
                    asTrackingGetUnDeletedUserByEmailSpec :
                    asTrackingGetUnDeletedUserByUserNameSpec, cancellationToken);

            SignInResult result = await _context.Identity.SignInManager.CheckPasswordSignInAsync(user, request.Dto.Password, false);

            if (!result.Succeeded)
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
    public async Task<ResponseModel<string>> Handle(LogOutUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<UserJWT> asNoTrackingGetUserJwtByJWTWithRefreshJWTSpec =
                _specificationsFactory.CreateUserJwtsSpecifications(
                    typeof(AsNoTrackingGetUserJwtByJWTWithRefreshJWTSpecification), request.Dto.Jwt, request.Dto.RefrestToken);

            if (!await _context.UserJWTs.AnyAsync(asNoTrackingGetUserJwtByJWTWithRefreshJWTSpec, cancellationToken))
                return ResponseResult.NotFound<string>();


            ISpecification<UserJWT> asNoTrackingGetUserJwtByJWTWithRefreshJWT_User_Spec =
                _specificationsFactory.CreateUserJwtsSpecifications(
                    typeof(AsNoTrackingGetUserJwtByJWTWithRefreshJWT_User_Specification), request.Dto.Jwt, request.Dto.RefrestToken);

            UserJWT userjWT = await _context.UserJWTs.RetrieveAsync(asNoTrackingGetUserJwtByJWTWithRefreshJWT_User_Spec, cancellationToken);

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


    #endregion
}
