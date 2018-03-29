using System;

namespace NET.S._2018.Karakouski._8
{
    /// <summary>
    /// Bank account classe
    /// </summary>
    public class Account
    {
        private static int theLatUsedId;
        public readonly int id;
        public bool Active { get; private set; }
        public AccountHolder AccountHolder { get { return AccountHolder.Clone(); } private set { AccountHolder = value; } }
        public decimal Balance { get; private set; }
        public decimal Bonuses { get; private set; }
        public AccountType AccountType { get; set; }

        /// <summary>
        /// Account cpntructer
        /// </summary>
        /// <param name="accountHolder"></param>
        /// <param name="accountType"></param>
        public Account(AccountHolder accountHolder, AccountType accountType)
        {
            id = theLatUsedId++;
            AccountHolder = accountHolder;
            AccountType = accountType;
            Active = true;
        }

        /// <summary>
        /// Closing of the account
        /// </summary>
        public void Close()
        {
            if (!Active)
                throw new InvalidOperationException("Account is alreay closed");
            Active = false;
        }

        /// <summary>
        /// Adding a deposit to the account
        /// </summary>
        /// <param name="sum"></param>
        public void AddDeposit(decimal sum)
        {
            if (!Active)
                throw new InvalidOperationException("Account is closed");
            Balance += sum;
            Bonuses += GetAddDepositBonuses(AccountType);
        }

        /// <summary>
        /// Charngin a depost from the account
        /// </summary>
        /// <param name="sum"></param>
        /// <returns></returns>
        public bool ChargeDeposit(decimal sum)
        {
            if (!Active)
                throw new InvalidOperationException("Account is closed");
            if (Balance < sum)
                return false;
            Balance -= sum;
            Bonuses -= GetAddDepositBonuses(AccountType);
            return true;
        }

        /// <summary>
        /// Calulate bonuses for account adding deposit
        /// </summary>
        /// <param name="accountType"></param>
        /// <returns></returns>
        private static decimal GetAddDepositBonuses(AccountType accountType)
        {
            switch (accountType)
            {
                case (AccountType.Base):
                    return 1;
                case (AccountType.Silver):
                    return 2;
                case (AccountType.Gold):
                    return 3;
                case (AccountType.Platinum):
                    return 4;
                default:
                    throw new ArgumentException(nameof(accountType));
            }
        }


        /// <summary>
        /// Calulate bones for account charge
        /// </summary>
        /// <param name="accountType"></param>
        /// <returns></returns>
        private static decimal GetChargeDepositBonuses(AccountType accountType)
        {
            switch (accountType)
            {
                case (AccountType.Base):
                    return 1;
                case (AccountType.Silver):
                    return 2;
                case (AccountType.Gold):
                    return 3;
                case (AccountType.Platinum):
                    return 4;
                default:
                    throw new ArgumentException(nameof(accountType));
            }
        }

    }

    /// <summary>
    /// Enum for account types
    /// </summary>
    public enum AccountType
    {
        Base,
        Silver,
        Gold,
        Platinum
    }

   
}
