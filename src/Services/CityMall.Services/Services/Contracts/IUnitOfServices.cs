namespace CityMall.Services.Services.Contracts;
public interface IUnitOfServices
{
    IAuthService AuthService { get; }
    IEmailService EmailService { get; }
    IFileService FileService { get; }
    IAddressService Addresses { get; }
    ICartService Carts { get; }
    ICartItemService CartItems { get; }
    ICategoryService Categories { get; }
    ISubCategoryService SubCategories { get; }
    ICustomerService Customers { get; }
    IProductAttributeService ProductAttributes { get; }
    IProductImageService ProductImages { get; }
    IProductService Products { get; }
    IShipperService Shippers { get; }
    IStockService Stocks { get; }
    IOrderService Orders { get; }
    IOrderLineService OrderLines { get; }
}
