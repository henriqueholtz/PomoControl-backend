﻿using PomoControl.Core.Exceptions;
using PomoControl.Domain.Validators;
using System;
using System.Collections.Generic;

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
        private User()
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

        public void ChangeStatus(bool active)
        {
            Active = active;
        }
    }
}
