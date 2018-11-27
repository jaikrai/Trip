using System;

namespace Trip
{
    /// <summary>
    ///     Concrete TripState class to accept cash payment.
    ///     This is obviously not complete - doesn't actually accept
    ///     payment - that's hardcoded in this example.
    /// </summary>
    public class TripStatePayCash : TripState
    {
        public TripStatePayCash(TripContext context) :
            base(context, TripState.Status.PayCash)
        {
        }

        public override TripStateLoop.Status Execute
        {
            get
            {
                
                Console.WriteLine(Environment.NewLine + "*** ACCEPT CASH PAYMENT ***");
                // Console.WriteLine();
                // Console.WriteLine("- COMMAND: [later] to return later or amount");
                // Console.WriteLine();

                //fake
                TripContext.Trip.Payment = new PaymentCash(TripContext);
                TripContext.Trip.Payment.Describe();

                TripContext.ChangeState(new TripStateAddThankYou(TripContext));
                return TripStateLoop.Status.Continue;
            }
        }
    }
}