namespace BinocsTest.Core.Model.Entities
{
    public class ListItemEntity
    {
        public Guid Id { get; set; }
        public Guid ListId { get; set; }
        public string? Content { get; set; }
    }
}
