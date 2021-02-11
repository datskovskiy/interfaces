namespace Interfaces
{
    public class BaseDeposit : Deposit
    {
        public BaseDeposit(decimal amount, int period) : base(amount, period)
        {
        }

        public override decimal Income()
        {
            var baseAmount = Amount;
            const decimal interest = 0.05M;

            for (int i = 0; i < Period; i++)
            {
                baseAmount += baseAmount * interest;
            }

            return baseAmount - Amount;
        }
    }
}
