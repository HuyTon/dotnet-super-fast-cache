using System;
using System.Collections.Generic;
using Diana.Code.Challenge;
using MongoDB.Bson.Serialization.Attributes;

namespace Diana.Code.Chaallenge
{
    /// <question>
    /// Please refactor this class and related interfaces as required to meet your
    /// minimum coding standards.
    /// </question>
    public class Employee : ICachedObject
    {
        /// <question>
        /// What is the purpose of this attribute?
        /// </question>
        /// <answer>
        /// The [BsonId] attribute is used in MongoDB to specify that the annotated property should be 
        /// mapped to the _id field in the corresponding MongoDB document. This attribute designates 
        /// the property as the primary identifier for the document. In the provided code snippet, 
        /// it is applied to the Id property of the Employee class, indicating that the Id property serves 
        /// as the primary identifier for instances of the Employee class when stored in a MongoDB collection.
        /// </answer>
        [BsonId]
        public Guid Id { get; set; }

        /// <summary>
        /// Refactored property name with PascalCase
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Refactored property name with PascalCase
        /// </summary>
        public string Description { get; set; }

        /// <question>
        /// Review the next two properties, what suggestions do you have
        /// for these?
        /// </question>
        /// <answer>
        /// The property names `PHP_Salary_1` and `US_Salary_2` are not descriptive and could be improved
        /// for clarity. It's also advisable to use PascalCase for property names in C#. Additionally, 
        /// calculating the US salary in the getter of `US_Salary_2` might not be ideal, as it could lead
        /// to unexpected behavior. It's better to keep the calculation separate or refactor it to a method.
        /// </answer>        
        public Double PHP_Salary_1 { get; set; }

        public decimal US_Salary_2
        {
            get
            {
                return ((decimal)PHP_Salary_1) * ((decimal)51.6932);
            }
        }

        /// <summary>
        /// Refactored property name 'PHP_Salary_1'
        /// </summary>
        public double PHPSalary { get; set; }

        /// <summary>
        /// Refactored property name 'US_Salary_2'
        /// </summary>
        public decimal USSalary => CalculateUSSalary(PHPSalary);

        // Calculate US Salary method
        private decimal CalculateUSSalary(double phpSalary)
        {
            return (decimal)phpSalary * (decimal)51.6932;
        }

        public string Email { get; set; }

        /// <summary>
        /// Refactored the function 'CompareTo'
        /// </summary>
        public int CompareTo(object obj)
        {
            // Commented out this statement to refactor it
            // return this.Id.CompareTo(((employee)obj).Id);

            if (obj == null) return 1;

            if (obj is Employee otherEmployee)
            {
                return this.Id.CompareTo(otherEmployee.Id);
            }
            else
            {
                throw new ArgumentException("Object is not an Employee");
            }
        }
    }
}
