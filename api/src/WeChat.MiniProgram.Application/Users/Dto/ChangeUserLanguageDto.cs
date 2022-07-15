using System.ComponentModel.DataAnnotations;

namespace WeChat.MiniProgram.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}