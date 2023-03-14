#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace FileUploadPractice.Models;

public class User
{
    [Key]
    public int Id {get;set;}
    [Required]
    public string Name {get;set;}
    [Required]
    public byte[] Picture {get;set;}
    [Required]
    public string PictureFormat {get;set;}
}
