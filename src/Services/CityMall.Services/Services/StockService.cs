using CityMall.Dtos.Dtos.Stocks;
using CityMall.Services.Exceptions.Categories;
using CityMall.Specifications.Specifications.Stocks;

namespace CityMall.Services.Services;
public sealed class StockService : IStockService
{
    private readonly IUnitOfWork _context;
    private readonly IMapper _mapper;
    private readonly ISpecificationsFactory _specificationsFactory;

    public StockService(IUnitOfWork context, IMapper mapper, ISpecificationsFactory specificationsFactory)
    {
        _context = context;
        _mapper = mapper;
        _specificationsFactory = specificationsFactory;
    }

    public async Task AddAsync(AddStockDto Dto, CancellationToken cancellationToken = default)
    {
        try
        {
            Stock model = _mapper.Map<Stock>(Dto);
            await _context.Stocks.CreateAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new StockCommandException($"Error From {nameof(StockService)}.{nameof(AddAsync)}", ex);
        }
    }
    public async Task UpdateAsync(UpdateStockDto Dto, CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<Stock> asNoTrackingGetStockByIdSpec = _specificationsFactory
                        .CreateStockSpecifications(typeof(AsNoTrackingGetUnDeletedStockByIdSpecification), Dto.Id);

            Stock model = await _context.Stocks.RetrieveAsync(asNoTrackingGetStockByIdSpec, cancellationToken);

            model = _mapper.Map<Stock>(Dto);
            await _context.Stocks.UpdateAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new StockCommandException($"Error From {nameof(StockService)}.{nameof(UpdateAsync)}", ex);
        }
    }

    public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Stock> asNoTrackingGetStockByIdSpec = _specificationsFactory
                       .CreateStockSpecifications(typeof(AsNoTrackingGetUnDeletedStockByIdSpecification), id);
            Stock model = await _context.Stocks.RetrieveAsync(asNoTrackingGetStockByIdSpec, cancellationToken);
            await _context.Stocks.DeleteAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new StockCommandException($"Error From {nameof(StockService)}.{nameof(UpdateAsync)}", ex);
        }
    }

    public async Task<GetStockDto> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<Stock> asNoTrackingGetStockByIdSpec = _specificationsFactory
                      .CreateStockSpecifications(typeof(AsNoTrackingGetUnDeletedStockByIdSpecification), id);
            return _mapper.Map<GetStockDto>(await _context.Stocks.RetrieveAsync(asNoTrackingGetStockByIdSpec, cancellationToken));
        }
        catch (Exception ex)
        {
            throw new StockQueryException($"Error From {nameof(StockService)}.{nameof(GetByIdAsync)}", ex);
        }
    }


    public async Task<IEnumerable<GetStockDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<Stock> asNoTrackingGetAllStocksSpec = _specificationsFactory
                            .CreateStockSpecifications(typeof(AsNoTrackingGetAllStocksSpecification));
            return _mapper.Map<IEnumerable<GetStockDto>>(await _context.Stocks.RetrieveAllAsync(asNoTrackingGetAllStocksSpec, cancellationToken));
        }
        catch (Exception ex)
        {
            throw new StockQueryException($"Error From {nameof(StockService)}.{nameof(GetAllAsync)}", ex);
        }
    }

    public async Task<IEnumerable<GetStockDto>> GetAllUnDeletedAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<Stock> asNoTrackingGetAllUnDeletedStocksSpec = _specificationsFactory
                            .CreateStockSpecifications(typeof(AsNoTrackingGetAllUnDeletedStocksSpecification));
            return _mapper.Map<IEnumerable<GetStockDto>>(await _context.Stocks.RetrieveAllAsync(asNoTrackingGetAllUnDeletedStocksSpec, cancellationToken));
        }
        catch (Exception ex)
        {
            throw new StockQueryException($"Error From {nameof(StockService)}.{nameof(GetAllUnDeletedAsync)}", ex);
        }
    }

    public async Task<bool> AnyAsync(CancellationToken cancellationToken = default) => await _context.Stocks.AnyAsync(cancellationToken: cancellationToken);

    public async Task<bool> AnyByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        ISpecification<Stock> asNoTrackingGetStockByIdSpec = _specificationsFactory
                    .CreateStockSpecifications(typeof(AsNoTrackingGetUnDeletedStockByIdSpecification), id);

        return await _context.Stocks.AnyAsync(asNoTrackingGetStockByIdSpec, cancellationToken);
    }
}