using System;

namespace PersonInfo;

public class Person
{
    private string _firstName;

    private string _lastName;

    private int _age;

    private const int MIN_NAME_LENGTH = 3;

    public Person(string firstName, string lastName, int age)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
    }

    public string FirstName
    {
        get 
        {
            return _firstName;
        }

        private set
        {
            if (value.Length < MIN_NAME_LENGTH)
            {
                throw new ArgumentException($"First name cannot contain fewer than {MIN_NAME_LENGTH} symbols!");
            }

            _firstName = value; 
        }
    }

    public string LastName
    {
        get
        {
            return _lastName;
        }

        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException($"Last name cannot contain fewer than {MIN_NAME_LENGTH} symbols!");
            }

            _lastName = value;
        }
    }

    public int Age
    {
        get
        {
            return _age;
        }

        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }

            _age = value;
        }
    }

    public override string ToString() // Tomas Anderson is 20 years old.
    {
        return $"{this.FirstName} {this.LastName} is {this.Age} years old";
    }
}
