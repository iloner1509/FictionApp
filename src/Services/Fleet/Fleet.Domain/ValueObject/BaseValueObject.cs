using System;

namespace Fleet.Domain.ValueObject
{
    public abstract class BaseValueObject<TValue> : IEquatable<TValue>
        where TValue : BaseValueObject<TValue>
    {
        protected abstract bool ObjectIsEquals(TValue other);

        public override bool Equals(object obj)
        {
            if (!(obj is TValue))
            {
                return false;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            return ObjectIsEquals((TValue)obj);
        }

        protected abstract int ObjectGetHashCode();

        public override int GetHashCode()
        {
            return ObjectGetHashCode();
        }

        public bool Equals(TValue other)
        {
            return this == other;
        }

        public static bool operator ==(BaseValueObject<TValue> left, BaseValueObject<TValue> right)
        {
            if (left is null && right is null)
            {
                return true;
            }

            if (left is null || right is null)
            {
                return false;
            }

            return left.Equals(right);
        }

        public static bool operator !=(BaseValueObject<TValue> left, BaseValueObject<TValue> right)
        {
            return !(left == right);
        }
    }
}