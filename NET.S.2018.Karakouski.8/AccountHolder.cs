using Newtonsoft.Json;
using System;

namespace NET.S._2018.Karakouski._8
{
    /// <summary>
    /// Describes account holder
    /// </summary>
    public class AccountHolder
    {
        public string LastName { get; }
        public string FirstName { get; }
        public DateTime DateOfBirth { get; }

        /// <summary>
        /// Contructor for account holder
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="dateOfbirth"></param>
        public AccountHolder(string firstName, string lastName, DateTime dateOfbirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfbirth;
        }

        /// <summary>
        /// Returns deep copy of account holder
        /// </summary>
        /// <returns></returns>
        public AccountHolder Clone()
        {
            var serialized = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<AccountHolder>(serialized);
        }

    }
}
