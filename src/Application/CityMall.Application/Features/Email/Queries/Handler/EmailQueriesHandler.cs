namespace CityMall.Application.Features.Email.Queries.Handler;
public sealed class EmailQueriesHandler : IRequestHandler<SendEmailsQuery, ResponseModel<string>>
{
    private readonly IUnitOfServices _servies;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IUnitOfWork _context;

    public EmailQueriesHandler(IUnitOfServices servies, ISpecificationsFactory specificationsFactory, IUnitOfWork context)
    {
        _servies = servies;
        _context = context;
        _specificationsFactory = specificationsFactory;
    }
    public async Task<ResponseModel<string>> Handle(SendEmailsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            // sub // body
            ISpecification<User> asNoTrackingGetAllUnDeletedUsersSpec = _specificationsFactory.CreateUserSpecifications(
                typeof(AsNoTrackingGetAllUnDeletedUsersSpecification));

            IQueryable<User> query = await _context.Users.RetrieveAllAsync(asNoTrackingGetAllUnDeletedUsersSpec, cancellationToken);
            List<string> emails = await query.Select(x => x.Email).ToListAsync();

            emails.ForEach(async email =>
            {
                await _servies.EmailService.SendEmailAsync(email, request.Subject, request.Body, request.Files.ToList());
            });

            return ResponseResult.Success(data: "emails sended ");
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<string>(errors: ex.Message);
        }
    }
}
