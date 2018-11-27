using System;

namespace Trip
{
    /// <summary>
    ///     Concrete TripState class to accept check payment.
    ///     This is obviously not complete - doesn't actually accept
    ///     payment - that's hardcoded in this example.
    /// </summary>
    public class TripStatePayCheck : TripState
    {
        public TripStatePayCheck(TripContext context) :
            base(context, TripState.Status.PayCheck)
        {
        }

        public override TripStateLoop.Status Execute
        {
            get
            {
                TripContext.Trip.Payment = new PaymentCheck(TripContext);
                TripContext.Trip.Payment.Describe();

                TripContext.ChangeState(new TripStateAddThankYou(TripContext));
                return TripStateLoop.Status.Continue;
            }
        }
    }
}