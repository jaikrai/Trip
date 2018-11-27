using System;

namespace Trip
{
    /// <summary>
    ///     Concrete TripState class to create a new trip.
    /// </summary>
    public class TripStateCreate : TripState
    {
        public TripStateCreate(TripContext context) :
            base(context, TripState.Status.Create)
        {
            TripContext.Trip = new Trip
            {
                BookedOn = DateTime.Now,
                OrderId = DateTime.Now.Ticks,
                TripStateStatus = TripState.Status.Create
            };
        }

        public override TripStateLoop.Status Execute
        {
            get
            {
                Console.WriteLine();
                Console.WriteLine("*** NEW TRIP CREATED ***");
                TripContext.ChangeState(new TripStateAddTravellers(TripContext));
                return TripStateLoop.Status.Continue;
            }
        }
    }
}