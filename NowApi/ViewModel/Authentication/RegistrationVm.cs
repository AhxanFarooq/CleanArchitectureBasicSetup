using System.ComponentModel.DataAnnotations;

namespace NowApi.ViewModel.Authentication
{
    public class RegistrationVm
    {
        [Required(ErrorMessage ="Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "User Name is required")]
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Mobile_Phone { get; set; }
        public string? User_Role { get; set; }
    }
}
