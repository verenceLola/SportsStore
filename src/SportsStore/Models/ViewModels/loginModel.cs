using System.ComponentModel.DataAnnotations;
namespace SportsStore.Models.ViewModels {
    public class LoginModel {
        [Required]
        public string Name {set; get;}
        [Required]
        [UIHint("password")]
        public string Password {get; set;}
        public string ReturnUrl {get; set;} = "/";
    }
}
