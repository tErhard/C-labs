using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace arch_modul
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Telinher E.M.Zh.", 12345678, 980);
            FinantialMonitoring finantialMonitoring = new FinantialMonitoring();
            Console.WriteLine(user);
            user.Pay(500);
            user.Accept(finantialMonitoring);
            user.Pay(14);
            user.Accept(finantialMonitoring);
        }
    }
    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }

    public class User : IVisitable
    {
        public string fullName;
        public int ipn;
        public float sum;

        public User(string fullName, int ipn, float sum)
        {
            this.fullName = fullName;
            this.ipn = ipn;
            this.sum = sum;
        }
        public void Pay(float cash)
        {
            sum -= cash;
        }
        public void Accept(IVisitor visitor)
        {
            visitor.VisitUser(this);
        }
        public override string ToString()
        {
            return $"Full name: {fullName}; IPN: {ipn}; Cash on the card: {sum} usd.";
        }
    }

    public interface IVisitor
    {
        void VisitUser(User user);
    }

    public class FinantialMonitoring : IVisitor
    {
        public void VisitUser(User user)
        {
            if (user.sum >= 17)
            {
                Console.WriteLine($"{user.fullName} the payment was successful");
            }
            else
            {
                Console.WriteLine($"Succesful");
            }
        }
    }
}
