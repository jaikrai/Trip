using System;

namespace Trip{
    public class PaymentCard : Payment
    {
        public PaymentCard(TripContext context) : base(context)
        {
        }

         public int CardNumber { get; private set;}

         public int CardExpiration{get; set; }
        public override void Describe()
	    {
            base.Describe();
            while (true)
            {
                Console.WriteLine("Enter card number: (greater than 100)");
                int cardnum = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter card expiration date: (greater than 10)");
                int cardExp = int.Parse(Console.ReadLine());

                if (cardnum > 100 || cardExp > 10)
                {
                    Console.WriteLine($"Check {cardnum} {cardExp}accepted.");
                    CardNumber = cardnum;
                    CardExpiration = cardExp;

                    break;
                }
                else
                {
                    Console.WriteLine("ERROR: Check number must be greater than 100. Try again.");
                }
            }
        }

        public override string ToString(){
             return  $"{base.ToString()}, CardNumber # {CardNumber} Expiration Date # {CardExpiration}";
         }
    }
}