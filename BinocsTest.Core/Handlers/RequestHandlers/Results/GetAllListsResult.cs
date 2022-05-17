using BinocsTest.Core.Model.Entities;
using MediatR;

namespace BinocsTest.Core.Handlers.RequestHandlers.Results
{
    public class GetAllListsResult
    {
       public List<ListEntity> AllLists { get; set; } 

    }
}