using AutoMapper;
using BankCreditApp.Application.Features.CreditApplications.Dtos.Responses;
using BankCreditApp.Core.Repositories;
using BankCreditApp.Domain.Entities;

namespace BankCreditApp.Application.Features.CreditApplications.Profiles;

public class CreditApplicationMappingProfile : Profile
{
    public CreditApplicationMappingProfile()
    {
        // Entity to Response mapping
        CreateMap<IndividualCreditApplication, CreditApplicationResponse>();
        CreateMap<CorporateCreditApplication, CreditApplicationResponse>();
    }
}

public interface IPaginatedListConverter
{
    object Convert(object source, object destination, ResolutionContext context, int pageSize);
}

public class PaginatedListConverter<TSource, TDestination> : IPaginatedListConverter
{
    private readonly IMapper _mapper;

    public PaginatedListConverter(IMapper mapper)
    {
        _mapper = mapper;
    }

    public object Convert(object source, object destination, ResolutionContext context, int pageSize)
    {
        var typedSource = (PaginatedList<TSource>)source;
        var items = _mapper.Map<List<TDestination>>(typedSource.Items);
        return new PaginatedList<TDestination>(
            items,
            typedSource.TotalCount,
            typedSource.PageNumber,
            pageSize
        );
    }
}