using PomoControl.Core.Exceptions;
using PomoControl.Domain.Validators;
using System.Collections.Generic;

namespace PomoControl.Domain
{
    public class User : Base
    {
        public string Name { get; private set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordVerify { get; set; }
        public bool Active { get; set; }

        public User()
        { }

        public User(string email, string password, string passwordVerify, bool active)
        {
            Email = email;
            Password = password;
            PasswordVerify = passwordVerify;
            Active = active;

            _errors = new List<string>();
            Validate();
        }

        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                {
                    _errors.Add($"{error.ErrorCode.ToString()} - {error.ErrorMessage}");

                    throw new DomainException("Some properties are not valid", _errors);
                }
            }
            return true;
        }
    }
}
