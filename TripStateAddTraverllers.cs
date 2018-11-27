using System;
using System.Linq;

namespace Trip {
    // <summary>
    ///     Concrete TripState class to add destinations.
    ///     Technically, validation and input should be
    ///     performed in other classes to keep responsibilities
    ///     single, but this will demonstrate the basic idea.
    /// </summary>
    public class TripStateAddTravellers : TripState
    {
        // private TripContext context;

    
        public TripStateAddTravellers(TripContext context) : 
        base(context, TripState.Status.AddTravellers)
        {
        }
        private bool IsnewTravellerListValid()
        {
            if (TripContext.Trip.Travellers.Any()) return true;
            Console.WriteLine("ERROR: At least ONE Travellers is required");
            return false;
        }

        private bool IsTravellerValid(string newTravellers)
        {
            if (string.IsNullOrWhiteSpace(newTravellers))
            {
                Console.WriteLine("ERROR: Blank travellers are prohibited!");
                return false;
            }

            var isDuplicate = TripContext.Trip.Travellers.Contains(newTravellers);
            if (isDuplicate) Console.WriteLine("ERROR: Unique destinations only!");
            return !isDuplicate;
        }

        private bool ContinueEnteringTravellers(string newTraveller)
        {
            var done = newTraveller.ToLower() == "done";
            if (done && TripContext.Trip.Travellers.Any())
            {
                Console.WriteLine();
                Console.WriteLine("*** TRAVELLER FINISHED: " +
                                  $"{TripContext.Trip.Travellers.Count} entered ***");
            }

            return !done;
        }

        private void ShowCurrentDestinations()
        {
            if (!TripContext.Trip.Travellers.Any()) return;

            Console.WriteLine($"- Currently {TripContext.Trip.Travellers.Count} in trip");
            for (var dest = 0; dest < TripContext.Trip.Travellers.Count; dest++)
                Console.WriteLine($"  {dest + 1}. {TripContext.Trip.Travellers[dest]}");
            Console.WriteLine();
        }

        public override TripStateLoop.Status Execute
        {
            get
            {
                Console.WriteLine();
                Console.WriteLine(Environment.NewLine + "*** ADD TRAVELERS ***");
                Console.WriteLine(
                    "- COMMAND: [later] to return later, [done] to  finish adding travellers, or enter travellers");

                var getTravellers = true;
                while (getTravellers)
                {
                    var newTravellers = (Console.ReadLine() ?? "").Trim();

                    //come back later?
                    if (ReturnLater(newTravellers)) return TripStateLoop.Status.Stop;

                    //check unique and continue entering
                    if (ContinueEnteringTravellers(newTravellers))
                    {
                        if (IsTravellerValid(newTravellers))
                        {
                            TripContext.Trip.Travellers.Add(newTravellers);
                            Console.WriteLine($"- Added Travellers [{newTravellers}]");
                        }
                    }
                    else
                    {
                        //stop if we can change state
                        getTravellers = !IsnewTravellerListValid();
                    }

                }
                TripContext.ChangeState(newState: new TripStateAddDestinations(TripContext));
                return TripStateLoop.Status.Continue;
            }
        }
    }

}