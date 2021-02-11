using System;

namespace Interfaces
{
    public abstract class Deposit: IComparable<Deposit>
    {
        public decimal Amount { get; }
        public int Period { get; }

        protected Deposit(decimal amount, int period)
        {
            Amount = amount;
            Period = period;
        }

        public abstract decimal Income();

        public int CompareTo(Deposit other)
        {
            var totalSum = Amount + Income();
            var totalSumOther = other?.Amount + other?.Income();

            if (totalSum > totalSumOther)
                return 1;

            if (totalSum < totalSumOther)
                return -1;
            
            return 0;
        }

        public static int Compare(Deposit left, Deposit right)
        {
            if (object.ReferenceEquals(left, right))
                return 0;

            if (left is null)
                return -1;
            
            return left.CompareTo(right);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Deposit other))
                return false;

            return this.CompareTo(other) == 0;
        }

        public override int GetHashCode()
        {
            var totalSum = Amount + Income();
            return (totalSum).GetHashCode();
        }

        public static bool operator ==(Deposit left, Deposit right)
        {
            if (left is null)
                return right is null;

            return left.Equals(right);
        }

        public static bool operator !=(Deposit left, Deposit right)
        {
            return !(left == right);
        }

        public static bool operator <(Deposit left, Deposit right)
        {
            return (Compare(left, right) < 0);
        }

        public static bool operator <=(Deposit left, Deposit right)
        {
            return (Compare(left, right) <= 0);
        }

        public static bool operator >(Deposit left, Deposit right)
        {
            return (Compare(left, right) > 0);
        }

        public static bool operator >=(Deposit left, Deposit right)
        {
            return (Compare(left, right) >= 0);
        }
    }
}
