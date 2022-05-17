using System.ComponentModel.DataAnnotations;

namespace BinocsTest.Api.IO.Requests
{
    /// <summary>
    /// Creates a new list with provided name
    /// </summary>
    public class CreateListRequest
    {
        /// <example>List of to do items 1</example>
        [Required]
        public string Name { get; set; }
    }
}
