using System;
using Marketplace.EventSourcing;

namespace Marketplace.PaidServices.Domain.ClassifiedAds
{
    public class ClassifiedAdId : Value<ClassifiedAdId>
    {
        protected ClassifiedAdId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(
                    nameof(value), 
                    "The Id cannot be empty");
            
            Value = value;
        }
        
        public static implicit operator ClassifiedAdId(string value)
            => new ClassifiedAdId(Guid.Parse(value));

        public Guid Value { get; }
        
        public static implicit operator Guid(ClassifiedAdId self) 
            => self.Value;

        public override string ToString() => Value.ToString();
    }
}