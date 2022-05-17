using AutoMapper;
using BinocsTest.Api.IO.Responses;
using BinocsTest.Core.Handlers.CommandHandlers.Results;
using BinocsTest.Core.Handlers.RequestHandlers.Results;
using BinocsTest.Core.Model.Entities;

namespace BinocsTest.Api.Mappers
{
    public class BinocsTestApiProfile : Profile
    {
        public BinocsTestApiProfile()
        {
            CreateMap<GetAllListsResult, GetAllListsResponse>().ForMember(t => t.AllLists, opt => opt.MapFrom(src => src.AllLists));
            CreateMap<ListEntity, ListResponse>();
            CreateMap<CreateListResult, CreateListResponse>();
            CreateMap<GetTotalCountResult, GetTotalCountResponse>();
            CreateMap<GetListItemsResult, GetListItemsResponse>().ForMember(t=>t.ListItems, opt => opt.MapFrom(src => src.ListItems));
            CreateMap<ListItemEntity, ListItem>();
        }
    }
}
