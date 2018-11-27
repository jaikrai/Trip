using System;

namespace Trip
{
    /// <summary>
    ///     Concrete Check Payment instance
    /// </summary>
    public class PaymentCheck : Payment
    {
        public PaymentCheck(TripContext context) : base(context)
        {
        }

        public int CheckNumber { get; private set;}

        public override void Describe()
        {
            base.Describe();
            while (true)
            {
                Console.WriteLine("Enter check number: (greater than 100)");
                int checknum = int.Parse(Console.ReadLine());
                if (checknum > 100)
                {
                    Console.WriteLine($"Check {checknum} accepted.");
                    CheckNumber = checknum;
                    break;
                }
                else
                {
                    Console.WriteLine("ERROR: Check number must be greater than 100. Try again.");
                }
            }
        }
         public override string ToString(){
             return  $"{base.ToString()}, Check # {CheckNumber}";
         }
    }
}