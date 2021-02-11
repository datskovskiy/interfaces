namespace Interfaces
{
    public class SpecialDeposit : Deposit, IProlongable
    {
        public SpecialDeposit(decimal amount, int period) : base(amount, period)
        {
        }

        public override decimal Income()
        {
            var baseAmount = Amount;

            for (decimal i = 0; i < Period; i++)
            {
                var interest = (i + 1) / 100;
                baseAmount += baseAmount * interest;
            }

            return baseAmount - Amount;
        }

        public bool CanToProlong()
        {
            return Amount > 1000;
        }
    }
}
