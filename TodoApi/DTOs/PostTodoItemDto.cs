using System.ComponentModel.DataAnnotations;

namespace TodoApi.DTOs
{
    public class PostTodoItemDto
    {
        public string Title { get; set; } = null!;

        public bool Done { get; set; }
    }
}
