using System;

namespace DataBindStudy.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class CustomerStringLength: Attribute
    {
        public int MaxLength { get; set; }
        public int MinLength { get; set; }

        public CustomerStringLength(int minLength, int maxLength)
        {
            this.MaxLength = maxLength;
            this.MinLength = minLength;
        }
    }
}