using System;

namespace Trip
{
    /// <summary>
    ///     Abstract base class that holds Amount
    /// </summary>
    public abstract class Payment
    {
        protected TripContext tripContext;
        protected Payment(TripContext context)
        {
            tripContext = context;
        }

        public decimal Amount { get; set;}

        public virtual void Describe()
        {
            while (true)
		{
			Console.WriteLine($"The  packages in your trip cost {tripContext.Trip.GrandTotal:C}.");
			Console.WriteLine($"Please pay {tripContext.Trip.GrandTotal:C}:");
			decimal amountPaid = decimal.Parse(Console.ReadLine());
			if (amountPaid == tripContext.Trip.GrandTotal)
			{
				Console.WriteLine($"{amountPaid:C} payment accepted.");
				Amount = amountPaid;
				break;
			} else {
				Console.WriteLine($"ERROR: Payment must be equal to {tripContext.Trip.GrandTotal:C}. Try again.");
			}
		}
        }
        public override string ToString()
        {
            return $"Payment = {Amount:C}";
        }
    }
}
