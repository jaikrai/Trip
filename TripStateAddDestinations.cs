using System;
using System.Linq;

namespace Trip
{
    /// <summary>
    ///     Concrete TripState class to add destinations.
    ///     Technically, validation and input should be
    ///     performed in other classes to keep responsibilities
    ///     single, but this will demonstrate the basic idea.
    /// </summary>
    public class TripStateAddDestinations : TripState
    {
        private TripContext context;

        public TripStateAddDestinations(TripContext context) : base(context, TripState.Status.AddDestinations)
        {
        }


        // public TripStateAddDestinations(TripContext context) :
        //     base(context, TripState.Status.AddDestinations)
        // {
        // }

        // private bool IsDestinationListValid()
        // {
        //     if (TripContext.Trip.Destinations.Any()) return true;
        //     Console.WriteLine("ERROR: At least ONE destination is required");
        //     return false;
        // }

        // private bool IsDestinationValid(string newDestination)
        // {
        //     if (string.IsNullOrWhiteSpace(newDestination))
        //     {
        //         Console.WriteLine("ERROR: Blank destinations are prohibited!");
        //         return false;
        //     }

        //     var isDuplicate = TripContext.Trip.Destinations.Contains(newDestination);
        //     if (isDuplicate) Console.WriteLine("ERROR: Unique destinations only!");
        //     return !isDuplicate;
        // }

        // private bool ContinueEnteringDestinations(string newDestination)
        // {
        //     var done = newDestination.ToLower() == "done";
        //     if (done && TripContext.Trip.Destinations.Any())
        //     {
        //         Console.WriteLine();
        //         Console.WriteLine("*** DESTINATIONS FINISHED: " +
        //                           $"{TripContext.Trip.Destinations.Count} entered ***");
        //     }

        //     return !done;
        // }

        // private void ShowCurrentDestinations()
        // {
        //     if (!TripContext.Trip.Destinations.Any()) return;

        //     Console.WriteLine($"- Currently {TripContext.Trip.Destinations.Count} in trip");
        //     for (var dest = 0; dest < TripContext.Trip.Destinations.Count; dest++)
        //         Console.WriteLine($"  {dest + 1}. {TripContext.Trip.Destinations[dest]}");
        //     Console.WriteLine();
        // }

        public override TripStateLoop.Status Execute
        {
            get
            {
                int itemNum = TripContext.Trip.Destinations.Count +1;
                Console.WriteLine(Environment.NewLine + "*** ADD DESTINATIONS ***");
                Console.WriteLine(
                    "- COMMAND: [later] to return later or enter start destination");
                string name = Console.ReadLine();
                Console.WriteLine(
                    "- COMMAND: [later] to return later, or enter end destination");
                string name2 = Console.ReadLine();

                //are we done? ensure there is at least 1 item in cart if attempted
			if (name.Equals("done", StringComparison.CurrentCultureIgnoreCase))
			{
				if (TripContext.Trip.Destinations.Count > 0)
				{
					//done... change state
					TripContextStateFactory.Get(TripState.Status.ChoosePaymentType,TripContext);
				}
                
				Console.WriteLine("ERROR: You must place at least 1 Start and 1 end destination in the Trip. Try again.");
			}

            //get price
			Console.WriteLine($"Enter price for {name}, {name2} (greater than 0):");
			decimal price = decimal.Parse(Console.ReadLine());

            //get quantity
			Console.WriteLine($"Enter quantity for {name},{name2} (greater than 0):");
			int hrsOfTrvl = int.Parse(Console.ReadLine());

                // var getDestinations = true;
                // while (getDestinations)
                // {
                //     var newDestination = (Console.ReadLine() ?? "").Trim();

                //     //come back later?
                //     if (ReturnLater(newDestination)) return TripStateLoop.Status.Stop;

                //     //check unique and continue entering
                //     if (ContinueEnteringDestinations(newDestination))
                //     {
                //         if (IsDestinationValid(newDestination))
                //         {
                //             TripContext.Trip.Destinations.Add(newDestination);
                //             Console.WriteLine($"- Added destination [{newDestination}]");
                //         }
                //     }
                //     else
                //     {
                //         //stop if we can change state
                //         getDestinations = !IsDestinationListValid();
                //     }
                // }
                //validate input
			if (name.Length < 3 || name2.Length < 3 || price <= 0.0m || hrsOfTrvl < 1)
			{
				Console.WriteLine("ERROR: Name must be at least 3 characters, price must be greater than 0, and quantity must be at least 1. Try again.");
				 return	TripStateLoop.Status.Continue;		
			}
            TripPackages tripPackages = new TripPackages(name, name2, price, hrsOfTrvl);
            TripContext.Trip.Destinations.Add(tripPackages);
            Console.WriteLine($"Added packages {itemNum:##} to trip:");
            TripContext.ChangeState(new TripStateChoosePaymentType(TripContext));
                return TripStateLoop.Status.Continue;
            }
        }
    }
}