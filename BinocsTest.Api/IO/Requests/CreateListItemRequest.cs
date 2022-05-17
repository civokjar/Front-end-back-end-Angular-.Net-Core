using System.ComponentModel.DataAnnotations;

namespace BinocsTest.Api.IO.Requests
{
    public class CreateListItemRequest {

        /// <summary>
        /// Id of list
        /// </summary>
        public Guid ListId { get; set; }
        /// <summary>
        /// List item description
        /// </summary>
        /// <example>List item no 1</example>
        [Required]
        public string Content { get; set; }


    }
}
