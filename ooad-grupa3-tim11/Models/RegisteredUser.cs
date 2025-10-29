using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ooad_grupa3_tim11.Models
{
    public class RegisteredUser:IdentityUser
    {
        public String fullName { get; set; }
        public RegisteredUser() : base() { }

        public RegisteredUser(string userName, string name) : base(userName) { fullName = name; }

    }
}
