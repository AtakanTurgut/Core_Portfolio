using System.ComponentModel.DataAnnotations;

namespace CoreProject.Areas.User.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı zorunludur!")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Lütfen adınızı girin.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Lütfen soyadınızı girin.")]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Mail alanı zorunludur!")]
        public string? Mail { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur!")]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler uyumlu değil!")]
        public string? ConfirmPassword { get; set; }

        public string? ImageUrl { get; set; }
    }
}
