using System.ComponentModel.DataAnnotations;

namespace CoreProject_Api.DAL.Entities
{

    public class TodoListApi
    {
        [Key]
        public int TodoId { get; set; }
        public string? Content { get; set; }
        public bool Status { get; set; }

    }
}
