using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FileUploadPractice.Models;

namespace FileUploadPractice.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private MyContext _context; 

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }
    [HttpGet("Userdisplay")]
    public IActionResult Index(int id, User? user)
    {
        if(User is not null)
        {
            var User = _context.Users.SingleOrDefault(user => user.Id == id);
            var viewModel = new UserDisplayViewModel {Name = user.Name};
            viewModel.Picture = Convert.ToBase64String(user.Picture);
            viewModel.PictureFormat = user.PictureFormat;
            return View(viewModel);
        }
        else {
            return View("Index");
        }
    }
    
    [HttpGet("/")]
    public  IActionResult Profile()
    {
        return View();
    }

    [HttpPost ("create/profile")]
    [ValidateAntiForgeryToken]
    public IActionResult Profile(UserViewModel userViewModel)
    {
        if (userViewModel is null)
        {
            throw new ArgumentNullException(nameof(userViewModel));
        }
        if(!ModelState.IsValid)
        {
            return View();
        }
        var user = new User
        {
            Name = userViewModel.Name,
            PictureFormat = userViewModel.Picture.ContentType
        };
        var memoryStream = new MemoryStream();
        userViewModel.Picture.CopyTo(memoryStream);
        user.Picture = memoryStream.ToArray();
        

        _context.Add(user);
        _context.SaveChanges();

        return RedirectToAction("Userdisplay", new { Id = user.Id});

    }
}
