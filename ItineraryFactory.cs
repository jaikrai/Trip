using System;
using System.Diagnostics;

namespace Trip
{
    /// <summary>
    ///     Static factory to generate itinerary output
    ///     Will not generate if trip is not in Complete state
    /// </summary>
    public class ItineraryFactory
    {
        public static string Get(Trip trip)
        {
            //exception if trip not in valid state
            ValidateTripCanProduceItinerary(trip);

            //decorate the itinerary with various sections and
            //return output
            IItineraryComponent itinerary = new Itinerary(trip);
            itinerary = new ItineraryAppendSeparator(itinerary);
            itinerary = new ItineraryAppendBookingDetails(itinerary);
            itinerary = new ItineraryAppendSeparator(itinerary);
            itinerary = new ItineraryAppendTravellers(itinerary);
            itinerary = new ItineraryAppendSeparator(itinerary);
            itinerary = new ItineraryAppendDestinations(itinerary);
            itinerary = new ItineraryAppendSeparator(itinerary);
            itinerary = new ItineraryAppendThanks(itinerary);
            itinerary = new ItineraryAppendSeparator(itinerary);
            return itinerary.Output();
        }

        /// <summary>
        ///     Used to verify the factory will produce an itinerary
        ///     If not checked prior to calling factory, exception can occur
        /// </summary>
        /// <param name="trip"></param>
        /// <returns></returns>
        public static bool TripCanProduceItinerary(Trip trip)
        {
            Debug.Assert(trip != null, nameof(trip) + " != null");
            return trip.TripStateStatus == TripState.Status.Complete;
        }

        private static void ValidateTripCanProduceItinerary(Trip trip)
        {
            Debug.Assert(trip != null, nameof(trip) + " != null");

            if (!TripCanProduceItinerary(trip))
                throw new ApplicationException("trip must be in complete state to generate" +
                                               $"itinerary. currently in {trip.TripStateStatus}");
        }
    }
}