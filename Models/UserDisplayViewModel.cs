#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace FileUploadPractice.Models;

public class UserDisplayViewModel
{
    public string Name {get;set;}
    public string Picture {get;set;}
    public string PictureFormat {get;set;}
}