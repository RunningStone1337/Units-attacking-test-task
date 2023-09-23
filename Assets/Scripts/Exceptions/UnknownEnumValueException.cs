using System;

namespace Gameplay
{
    public class UnknownEnumValueException<TEnum> : Exception
        where TEnum : Enum
    {
        public UnknownEnumValueException(TEnum enumValue) : base($"Unknown enum value {enumValue} of type {typeof(TEnum)}.")
        {
        }
    }
}