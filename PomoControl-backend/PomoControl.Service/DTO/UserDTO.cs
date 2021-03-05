using System;
using System.Collections.Generic;
using System.Text;

namespace PomoControl.Service.DTO
{
    public class UserDTO
    {
        public int Code { get; set; }
        public string Name { get; private set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordVerify { get; set; }
        public bool Active { get; set; }

        public UserDTO()
        { }

        public UserDTO(int code, string name, string email, string password, string passwordVerify, bool active)
        {
            Code = code;
            Name = name;
            Email = email;
            Password = password;
            PasswordVerify = passwordVerify;
            Active = active;
        }
    }
}
