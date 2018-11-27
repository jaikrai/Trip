using System;

namespace Trip {
    public class TripPackages {
    
        public TripPackages (string startDes, string endDes, decimal price, int hoursOfTrv) {
            this.StartDes = startDes;
            this.EndDes = endDes;
            this.Price = price;
            this.HoursOfTrv = hoursOfTrv;
        }
        public string StartDes { get; }
        public string EndDes { get; }
        public decimal Price { get; }

        public int HoursOfTrv { get; }
        public decimal TotalPrice => Price;

        public override string ToString()
	    {
            string name = StartDes.Length > 15 ? StartDes.Substring(0, 15) : StartDes;
            string endName = EndDes.Length > 15 ? EndDes.Substring(9, 15) : EndDes;
            return $"Trvelling from:{name,15}\nTo:{endName,31} \nPrice: {Price,30:C2} \nHours of Travel:  {HoursOfTrv, 13}"+Environment.NewLine;
	    }
    }
}