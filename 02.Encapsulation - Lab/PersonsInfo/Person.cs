using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
           private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Tova ne e ime?????????/");
                }

                firstName = value;
            }
        }
        public string LastName {
            get
            {
                return lastName;
            }
         private   set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Tova ne e ime?????????/");
                }

                lastName = value;
            }
        }
        public int Age {
            get
            {
                return age;
            }
           private set
            {
                if (value <=0)
                {
                    throw new ArgumentException("Tova ne sa godini ?????????");
                }

                age = value;
            }
        }
        public decimal Salary {
            get
            {
                return salary;
            }
          private  set
            {
                if (value < 460)
                {
                    throw new ArgumentException("Tova ne e zaplata?????????/");
                }

                salary = value;
            }
        }

        public void IncreaseSalary(decimal persentage)
        {
            if (Age<30)
            {
                persentage /= 2;
            }

            Salary = Salary + Salary * persentage / 100;

        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:F2} leva.";
        }
    }
}
