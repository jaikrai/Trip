namespace Trip{
    public class TripStatePayCard : TripState
    {

        public TripStatePayCard(TripContext context) : 
        base(context, TripState.Status.PayCard)
        {
        }

        public override TripStateLoop.Status Execute
        {
            get
            {
                TripContext.Trip.Payment = new PaymentCard(TripContext);
                TripContext.Trip.Payment.Describe();

                TripContext.ChangeState(new TripStateAddThankYou(TripContext));
                return TripStateLoop.Status.Continue;
            }
        }
    }
}