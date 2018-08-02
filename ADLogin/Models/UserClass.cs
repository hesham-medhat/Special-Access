namespace ADLogin.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class user
    {

        [DisplayName("Username")]
        [Required(ErrorMessage = "Username is required.")]
        public string username { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string password { get; set; }

    }
}
