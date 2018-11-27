using System;

namespace Trip
{
    /// <summary>
    ///     Destinations itinerary decorator
    /// </summary>
    public class ItineraryAppendTravellers : ItineraryDecorator
    {
        public ItineraryAppendTravellers(IItineraryComponent componentToDecorate) : base(componentToDecorate)
        {
        }

        public override string Output()
        {
            var toOutput = base.Output();
            toOutput += "TRAVELLERS" + Environment.NewLine;
            toOutput += Environment.NewLine;
            for (var traveller = 0; traveller < Trip.Travellers.Count; traveller++)
                toOutput += $"{traveller + 1,2}. {Trip.Travellers[traveller]}" + Environment.NewLine;
            return toOutput;
        }
    }
}