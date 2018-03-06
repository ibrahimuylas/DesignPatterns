using System;
namespace DesignPatterns.Builder
{
    public class Customer
    {
        public string Name;
        // address
        public string StreetAddress, Postcode, City;

        // employment
        public string CompanyName, Position;

        public int AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }

    public class CustomerBuilder // facade 
    {
        // the object we're going to build
        protected Customer Customer = new Customer(); // this is a reference!

        public CustomerBuilder(string name)
        {
            this.Customer.Name = name;
        }

        public CustomerAddressBuilder Lives => new CustomerAddressBuilder(Customer);
        public CustomerJobBuilder Works => new CustomerJobBuilder(Customer);

        public static implicit operator Customer(CustomerBuilder cb)
        {
            return cb.Customer;
        }
    }

    public class CustomerJobBuilder : CustomerBuilder
    {
        public CustomerJobBuilder(Customer Customer): base(Customer.Name)
        {
            this.Customer = Customer;
        }

        public CustomerJobBuilder At(string companyName)
        {
            Customer.CompanyName = companyName;
            return this;
        }

        public CustomerJobBuilder AsA(string position)
        {
            Customer.Position = position;
            return this;
        }

        public CustomerJobBuilder Earning(int annualIncome)
        {
            Customer.AnnualIncome = annualIncome;
            return this;
        }
    }

    public class CustomerAddressBuilder : CustomerBuilder
    {
        // might not work with a value type!
        public CustomerAddressBuilder(Customer Customer): base(Customer.Name)
        {
            this.Customer = Customer;
        }

        public CustomerAddressBuilder At(string streetAddress)
        {
            Customer.StreetAddress = streetAddress;
            return this;
        }

        public CustomerAddressBuilder WithPostcode(string postcode)
        {
            Customer.Postcode = postcode;
            return this;
        }

        public CustomerAddressBuilder In(string city)
        {
            Customer.City = city;
            return this;
        }

    }

    public class CustomerBuilderDemo
    {
        public void Run()
        {
            var cb = new CustomerBuilder("İbrahim");
            Customer c = cb.Lives.At("Central").In("London").WithPostcode("W1 QWE")
                           .Works.At("Dunia Consultancy").AsA("Director").Earning(100); 

            Console.WriteLine(c);
        }
    }
}
