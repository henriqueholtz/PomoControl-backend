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
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string PasswordVerify { get; private set; }
        public bool Active { get; private set; }
        public DateTime RegisteredDate { get; private set; }

        public User()
        {
            _errors = new List<string>();
            RegisteredDate = DateTime.Now;
            Active = true;
        }

        public User(string email, string password, string passwordVerify, DateTime registeredDate, bool active = true)
        {
            Email = email;
            Password = password;
            PasswordVerify = passwordVerify;
            Active = active;
            RegisteredDate = registeredDate;

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
                    _errors.Add(error.ErrorMessage);
                }
                throw new DomainException("Some properties are not valid", _errors);
            }
            return true;
        }

        public bool ValidatePassword(string password)
        {
            if (String.IsNullOrWhiteSpace(password))
                return false;

            var base64Password = ConvertPassword(password);
            if (base64Password.Equals(Password))
                return true;

            return false;
        }

        private string ConvertPassword(string password)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(password.Trim()));
        }

        public bool PasswordTransform()
        {
            if (_errors == null)
                _errors = new List<string>();

            if (String.IsNullOrWhiteSpace(Password) || !Password.Equals(PasswordVerify))
            {
                _errors.Add("Password and Password Verify are different.");
                throw new DomainException("Some properties are not valid", _errors);
            }

            var base64Password = ConvertPassword(Password);
            Password = base64Password;
            PasswordVerify = base64Password;

            return _errors.Count == 0;
        }
    }
}
