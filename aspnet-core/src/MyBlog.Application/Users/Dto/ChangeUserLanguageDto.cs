using System.ComponentModel.DataAnnotations;

namespace MyBlog.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}