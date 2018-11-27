namespace Trip
{
    /// <summary>
    ///     Concrete Cash Payment instance
    /// </summary>
    public class PaymentCash : Payment
    {
        public PaymentCash(TripContext context) : base(context)
        {
        }
        public override string ToString()
        {
            return $"{base.ToString()} cash";
        }
    }
}