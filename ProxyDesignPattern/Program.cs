using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer c1 = new Customer();
            c1.pinCode = "1111";

            Customer c2 = new Customer();
            c2.pinCode = "1234";

            BankATMProxy proxy = new BankATMProxy(c1);
            proxy.withdrawMoney(500);

             proxy = new BankATMProxy(c2);
            proxy.withdrawMoney(800);

            Console.Read();

        }
    }

    interface IATM
    {
        void withdrawMoney(decimal sum);
    }

    class ATM : IATM
    {
        public void withdrawMoney(decimal sum)
        {
            Console.WriteLine($"Money withdraw operation of {sum} $ success. Take your Card");
        }
    }

    class Customer
    {
        public string pinCode { get; set; }
    }

    class BankATMProxy : IATM
    {
        IATM IAtm;
        Customer Customer;
        public BankATMProxy( Customer customer)
        {
            this.Customer = customer;
        }
        public void withdrawMoney(decimal sum)
        {
            if (Customer.pinCode == "1111")
            {
                IAtm = new ATM();
                IAtm.withdrawMoney(sum);
            }

            else
                Console.WriteLine("Operation failed.");
        }
    }


}
