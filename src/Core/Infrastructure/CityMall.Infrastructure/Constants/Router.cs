namespace CityMall.Infrastructure.Constants;
public static class Router
{
    private const string Api = "api/";
    private const string ApiVersion = "v1/";
    private const string ApiPrefix = Api + ApiVersion;
    public static class User
    {
        private const string UserPrefix = ApiPrefix + "users/";
        public const string AddUser = UserPrefix + "add-user";
        public const string UpdateUser = UserPrefix + "update-user";
        public const string DeleteUserById = UserPrefix + "delete-user-by-id";
        public const string UndoDeleteUserById = UserPrefix + "undo-delete-user-by-id";
        public const string LoginUser = UserPrefix + "login";
        public const string LogOutUser = UserPrefix + "logout";
        public const string RefreshjWT = UserPrefix + "refresh-jWT";
        public const string ConfirmeEmail = UserPrefix + "confirme-email";
        public const string ChangePassword = UserPrefix + "change-password";
        public const string SendResetPasswordToken = UserPrefix + "send-reset-password-token";
        public const string ResetPassword = UserPrefix + "reset-password";
        public const string GetAll = UserPrefix + "get-all";
        public const string GetAllUnDeleted = UserPrefix + "get-all-undeleted";
        public const string GetAllDeleted = UserPrefix + "get-all-deleted";
        public const string PaginateAll = UserPrefix + "paginate-all";
        public const string PaginateAllUnDeleted = UserPrefix + "paginate-all-undeleted";
        public const string PaginateAllDeleted = UserPrefix + "paginate-all-deleted";
    }

    public static class Emails
    {
        private const string EmailPrefix = ApiPrefix + "emails";
        public const string SendEmailsToAllUsers = EmailPrefix + "send-emails-to-all-users";
    }
}
