using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

public class BlogController : Controller
{
    [HttpGet]
    public IActionResult AddPost()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddPost(string title, string content, string author)
    {
        var post = new Post
        {
            Title = title,
            Author = author,
            Content = content,
            CreatedAt = DateTime.Now
        };

        Console.WriteLine("===Добавлен новый пост===");
        Console.WriteLine($"Заголовок: {post.Title}");
        Console.WriteLine($"Контент: {post.Content}");
        Console.WriteLine($"Автор: {post.Author}");
        Console.WriteLine("========================");;
        
        return Content("Пост добвлен");

    }
}