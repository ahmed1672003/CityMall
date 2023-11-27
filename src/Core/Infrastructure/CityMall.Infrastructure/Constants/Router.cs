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

    public static class Address
    {
        private const string AddressPrefix = ApiPrefix + "address/";
        public const string AddAddress = AddressPrefix + "add";
        public const string UpdateAddress = AddressPrefix + "update";
        public const string DeleteAddress = AddressPrefix + "delete-byid";
    }

    public static class Customer
    {
        private const string CustomerPrefix = ApiPrefix + "customer/";
        public const string AddCustomer = CustomerPrefix + "add";
        public const string UpdateCustomer = CustomerPrefix + "update";
        public const string DeleteCustomer = CustomerPrefix + "delete";
        public const string GetAll = CustomerPrefix + "get-all";
        public const string GetById = CustomerPrefix + "get-byid";
        public const string GetAllUnDeleted = CustomerPrefix + "get-all-undeleted";
        public const string GetAllDeleted = CustomerPrefix + "get-all-deleted";
    }

    public static class Stocks
    {
        private const string StockPrefix = ApiPrefix + "stocks/";
        public const string AddStock = StockPrefix + "add";
        public const string UpdateStock = StockPrefix + "update";
        public const string DeleteStockById = StockPrefix + "delete-byid";
        public const string GetStockById = StockPrefix + "get-byid";
        public const string GetAllStocks = StockPrefix + "get-all";
        public const string GetAllUnDeletedStocks = StockPrefix + "get-all-undeleted";
    }
    public static class Categories
    {
        private const string CategoryPrefix = ApiPrefix + "categories/";
        public const string AddCategory = CategoryPrefix + "add";
        public const string UpdateCategory = CategoryPrefix + "update";
        public const string DeleteCategoryById = CategoryPrefix + "delete-byid";
        public const string GetCategoryById = CategoryPrefix + "get-byid";
        public const string GetAllCategories = CategoryPrefix + "get-all";
        public const string GetAllUnDeletedCategories = CategoryPrefix + "get-all-undeleted";
        public const string GetAllDeletedCategories = CategoryPrefix + "get-all-deleted";
    }

    public static class Emails
    {
        private const string EmailPrefix = ApiPrefix + "emails/";
        public const string SendEmailsToAllUsers = EmailPrefix + "send-emails-to-all-users";
    }

    public static class SubCategories
    {
        private const string SubCategoryPrefix = ApiPrefix + "subcategories/";
        public const string AddSubCategory = SubCategoryPrefix + "add";
        public const string UpdateSubCategory = SubCategoryPrefix + "update";
        public const string DeleteSubCategoryById = SubCategoryPrefix + "delete-byid";
        public const string GetSubCategoryById = SubCategoryPrefix + "get-byid";
        public const string GetAllSubCategories = SubCategoryPrefix + "get-all";
        public const string GetAllUnDeletedSubCategories = SubCategoryPrefix + "get-all-undeleted";
        public const string GetAllDeletedSubCategories = SubCategoryPrefix + "get-all-deleted";
    }
}
