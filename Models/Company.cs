using System;
using System.Collections.Generic;
using Diana.Code.Challenge;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Diana.Code.Chaallenge
{
    /// <summary>
    /// Company class that contains information about the company and its employees.
    /// </summary>
    public class Company : ICachedObject
    {
        [BsonId]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Decimal Profit_1 { get; set; }

        public Double Profit_2 { get; set; }

        /// <question>
        /// What issues can you see with using string as the key for the dictionary?
        /// What suggestions do you have to resolve this?
        /// </question>
        /// <answer>
        /// Using string as the key for the dictionary might lead to issues related to case sensitivity,
        /// string comparisons, and potential collisions if the keys are not unique. To resolve this,
        /// we can consider using a unique identifier such as Guid for the dictionary keys. Guids ensure
        /// uniqueness and are efficient for dictionary lookups.
        /// </answer>
        public Dictionary<string, Employee> Employees { get; set; } = new Dictionary<string, Employee>();

        /// <summary>
        /// Refactored the function 'CompareTo'
        /// </summary>
        public int CompareTo(object obj)
        {
            // Commented out this statement to refactor it
            // return this.Id.CompareTo(((employee)obj).Id);

            if (obj == null) return 1;

            if (obj is Company otherCompany)
            {
                return this.Id.CompareTo(otherCompany.Id);
            }
            else
            {
                throw new ArgumentException("Object is not an Company");
            }
        }
    }
}
