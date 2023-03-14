using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618
namespace FileUploadPractice.Models;

public class UserViewModel
{
    [Required]
    public string Name {get;set;}
    [Required]
    public IFormFile Picture {get;set;}
}

