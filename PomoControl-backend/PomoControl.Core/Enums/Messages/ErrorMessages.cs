using System;
using System.Collections.Generic;
using System.Text;

namespace PomoControl.Core.Enums.Messages
{
    //public static class ErrorMessagesEntity<T> where T : class
        //private const string EntityName = nameof(T);
    public static class ErrorMessagesStatic
    {
        //Empty
        public const string Empty = "This don't can is Empty!";
        public const string EmptyName = "The Name don't can is Empty!";  
        public const string EmptyEmail = "The Email don't can is Empty!";
        public const string EmptyPassword = "The Password don't can is Empty!";
        public const string EmptyPasswordVerify = "The Password Verify don't can is Empty!";
        //public const string Empty = "The Email don't can is Empty!";
        //public const string Empty = "The Email don't can is Empty!";
        //public const string Empty = "The Email don't can is Empty!";

        //Null
        public const string Null = "This don't can is Null!";
        public const string NullName = "The Name don't can is Null!";
        public const string NullEmail = "The Email don't can is Null!";
        public const string NullPassword = "The Password don't can is Null!";
        public const string NullPasswordVerify = "The Password Verify don't can is Null!";
        //public const string Null = "don't can is Null!";
        //public const string Null = "don't can is Null!";

        //Required
        public const string Required = "This is Required!";
        public const string RequiredName = "The Name is Required!";
        public const string RequiredEmail = "The Email is Required!";
        public const string RequiredPassword = "The Password is Required!";
        public const string RequiredPasswordVerify = "The Password Verify is Required!";
        //public const string Required = "is Required!";

    }

    public class ErrorMessages
    {
        public string Property { get; private set; }
        public ErrorMessages(string property)
        {
            Property = property;
        }
        public string NotEmpty { get { return $"{Property} don't can is Empty!"; } }
        public string NotNull { get { return $"{Property} don't can is Null!"; } }
        public string IsRequerid { get { return $"{Property} is Requerid!"; } }
        public string NotValid { get { return $"{Property} don't is valid!"; } }


        //With methods
        public static string WriteType<T>() where T : class =>(typeof(T).Name);
        public virtual string EmptyMethod()
        {
            return $"{Property} don't can is Empty";
        }
        public virtual string NullMethod()
        {
            return $"{Property} don't can is Null.";
        }
        public static string RequeridMethod(string prop)
        {
            return $"The {prop} is Requerid.";
        }
        public virtual string MinimumLength(int quantity)
        {
            return $"The minimum length for {Property} is {quantity} characters.";
        }
        public virtual string MaximumLength(int quantity)
        {
            return $"The maximum length for {Property} is {quantity} characters.";
        }
    }
}
