namespace BinocsTest.Api.IO.Responses
{
    public class GetAllListsResponse
    {
        public List<ListResponse> AllLists { get; set; }

    }
    public class ListResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }


    }
}
