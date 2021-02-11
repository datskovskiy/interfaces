using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Interfaces
{
    public class Client : IEnumerable<Deposit>
    {
        private readonly Deposit[] deposits;

        public Client()
        {
            deposits = new Deposit[10];
        }

        public bool AddDeposit(Deposit deposit)
        {
            var added = false;

            for (int i = 0; i < deposits.Length; i++)
            {
                if (deposits[i] != default) continue;

                deposits[i] = deposit;
                added = true;
                break;
            }

            return added;
        }

        public decimal TotalIncome()
        {
            return deposits.Where(dep => dep != null).Sum(dep => dep.Income());
        }

        public decimal MaxIncome()
        {
            return deposits.Where(dep => dep != null).Max(dep => dep.Income());
        }

        public decimal GetIncomeByNumber(int number)
        {
            if (number < 1 || deposits[number - 1] == default) return 0;

            return deposits[number - 1].Income();
        }

        public IEnumerator<Deposit> GetEnumerator()
        {
            foreach (var dep in deposits)
            {
                yield return dep;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void SortDeposits()
        {
            Array.Sort(deposits, (dep1, dep2) => dep2.CompareTo(dep1));
        }

        public int CountPossibleToProlongDeposit()
        {
            var count = 0;
            foreach (var deposit in deposits)
            {
                IProlongable depositProlong = deposit as IProlongable;
                if (depositProlong == null) continue;

                if (depositProlong.CanToProlong()) count++;
            }
            return count;
        }

    }
}
