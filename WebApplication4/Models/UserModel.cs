using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Localization.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [DisplayName("UserName")]
        [Required(ErrorMessage = "UserNameErorr")]
        public string UserName { get; set; }
    }
}
