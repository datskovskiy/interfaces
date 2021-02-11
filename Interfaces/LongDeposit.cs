namespace Interfaces
{
    public class LongDeposit : Deposit, IProlongable
    {
        public LongDeposit(decimal amount, int period) : base(amount, period)
        {
        }

        public override decimal Income()
        {
            var baseAmount = Amount;
            const decimal interest = 0.15M;

            for (int i = 6; i < Period; i++)
            {
                baseAmount += baseAmount * interest;
            }

            return baseAmount - Amount;
        }

        public bool CanToProlong()
        {
            return Period <= 12 * 3;
        }
    }
}
