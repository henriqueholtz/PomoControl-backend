using PomoControl.Core.Exceptions;
using PomoControl.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Text;

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
