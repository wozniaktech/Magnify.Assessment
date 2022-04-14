namespace Magnify.Assessment
{
    public class ShipmentRequest
    {
        public bool IsBooked { get; set; }
        public long TimeStamp { get; set; }
        public string? PickupAddress { get; set; }
        public string? DestinationAddress { get; set; }
        public decimal BudgetAmount { get; set; }
        public string? AdditionalInformations { get; set; }
    }
}
