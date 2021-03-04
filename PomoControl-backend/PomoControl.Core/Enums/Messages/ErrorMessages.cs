using System;
using System.Collections.Generic;
using System.Text;

namespace PomoControl.Core.Enums.Messages
{
    public static class ErrorMessagesEntity<T> where T : class
    {
        private const string EntityName = nameof(T);
        public const string Empty = "This entity don't can is Empty! (" + EntityName + ")";
        public const string Null = "This entity don't can is Null!";
    }

    public class ErrorMessagesProperty
    {
        public string Property { get; private set; }
        public ErrorMessagesProperty(string property)
        {
            Property = property;
        }
        public string Empty { get { return $"{Property} don't can is Empty"; } }
        public string Null { get { return $"{Property} don't can is Null"; } }


        //With methods
        public virtual string EmptyMethod()
        {
            return $"{Property} don't can is Empty";
        }
        public virtual string NullMethod()
        {
            return $"{Property} don't can is Null.";
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
