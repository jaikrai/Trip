using System;

namespace Trip
{
    /// <summary>
    ///     Booking detail itinerary decorator
    /// </summary>
    public class ItineraryAppendBookingDetails : ItineraryDecorator
    {
        public ItineraryAppendBookingDetails(IItineraryComponent componentToDecorate) : base(componentToDecorate)
        {
        }

        public override string Output()
        {
            var toOutput = base.Output();
            toOutput += $"Agent   : John " + Environment.NewLine;
            toOutput += $"Order # : {Trip.OrderId}" + Environment.NewLine;
            toOutput += $"Booked  : {Trip.BookedOn}" + Environment.NewLine;
            toOutput += $"Payment : {Trip.Payment}" + Environment.NewLine;
            return toOutput;
        }
    }
}