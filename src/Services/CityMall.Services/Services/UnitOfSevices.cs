namespace CityMall.Services.Services;
public sealed class UnitOfSevices : IUnitOfServices
{
    public UnitOfSevices(
        IAuthService authService,
        IEmailService emailService,
        IFileService fileService,
        IAddressService addresses,
        ICartService carts,
        ICartItemService cartItems,
        ICategoryService categories,
        ISubCategoryService subCategories,
        ICustomerService customers,
        IProductAttributeService productAttributes,
        IProductImageService productImages,
        IProductService products,
        IShipperService shippers,
        IStockService stocks,
        IOrderService orders,
        IOrderLineService orderLines)
    {
        AuthService = authService;
        EmailService = emailService;
        FileService = fileService;
        Addresses = addresses;
        Carts = carts;
        CartItems = cartItems;
        Categories = categories;
        SubCategories = subCategories;
        Customers = customers;
        ProductAttributes = productAttributes;
        ProductImages = productImages;
        Products = products;
        Shippers = shippers;
        Stocks = stocks;
        Orders = orders;
        OrderLines = orderLines;
    }
    public IAuthService AuthService { get; }
    public IEmailService EmailService { get; }
    public IFileService FileService { get; }
    public IAddressService Addresses { get; }
    public ICartService Carts { get; }
    public ICartItemService CartItems { get; }
    public ICategoryService Categories { get; }
    public ISubCategoryService SubCategories { get; }
    public ICustomerService Customers { get; }
    public IProductAttributeService ProductAttributes { get; }
    public IProductImageService ProductImages { get; }
    public IProductService Products { get; }
    public IShipperService Shippers { get; }
    public IStockService Stocks { get; }
    public IOrderService Orders { get; }
    public IOrderLineService OrderLines { get; }
}
