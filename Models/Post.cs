using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models;

public class Post
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Заголовок обязателен")]
    [StringLength(200, MinimumLength = 3, ErrorMessage = "Заголовок должен быть от 3 до 200 символов")]
    public string Title { get; set; }
    [Required(ErrorMessage = "Контент обязателен")]
    [MinLength(10, ErrorMessage = "Контент должен содержать минимум 10 символов")]
    public string Content { get; set; }
    [Required(ErrorMessage = "Автор обязателен")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Имя автора должно быть от 2 до 100 символов")]
    public string Author { get; set; }
    public DateTime CreatedAt { get; set; }
}