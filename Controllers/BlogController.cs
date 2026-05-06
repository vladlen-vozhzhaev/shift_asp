using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

public class BlogController : Controller
{
    private readonly BlogDbContext _dbContext;

    public BlogController(BlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    // GET: Blog/ - список всех постов (главная блога)
    [HttpGet]
    public IActionResult Posts()
    {
        var posts = _dbContext.Posts.OrderByDescending(p => p.CreatedAt).ToList();
        return View(posts);
    }

    // GET: Blog/Details/{int id}
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var post = await _dbContext.Posts.FindAsync(id);
        if (post == null)
        {
            return NotFound(); // 404
        }

        return View(post);
    }
    
    [HttpGet]
    public IActionResult AddPost()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Test()
    {
        return Content("TEST!!!");
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
        _dbContext.Posts.Add(post);
        _dbContext.SaveChanges();
        
        
        //return Content("Пост добвлен");
        return RedirectToAction("Posts", "Blog");

    }

    // GET: Blog/Edit/{int id}
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var post = await _dbContext.Posts.FindAsync(id);
        if (post == null)
        {
            return NotFound(); // 404
        }

        return View(post);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Post post)
    {
        if (id != post.Id)
            return NotFound();
        
        if (ModelState.IsValid)
        {
            try
            {
                _dbContext.Update(post);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Posts", "Blog");
            }
            catch (DbUpdateConcurrencyException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        return View(post);
    }
    
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var post = await _dbContext.Posts.FindAsync(id);
        if (post != null)
        {
            _dbContext.Posts.Remove(post);
            await _dbContext.SaveChangesAsync();
        }

        return RedirectToAction("Posts", "Blog");
    }
}