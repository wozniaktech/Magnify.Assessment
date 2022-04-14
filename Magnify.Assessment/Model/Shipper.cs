namespace Magnify.Assessment
{
    public class Shipper
    {
        public ShipmentRequest CreateShipmentRequest(string pickupAddress, string destinationAddress, decimal budgetAmount, string additionalInformation)
        {
            return new ShipmentRequest
            {
                PickupAddress = pickupAddress,
                DestinationAddress = destinationAddress,
                BudgetAmount = budgetAmount,
                AdditionalInformations = additionalInformation,
                IsBooked = false
            };
        }

        public void AcceptOffer(ShipmentOffer shipmentOffer, bool isOfferAccepted)
        {
            if (isOfferAccepted && !shipmentOffer.Shipment.IsBooked)
            {
                shipmentOffer.Shipment.BudgetAmount = shipmentOffer.OfferedPrice;
                shipmentOffer.Shipment.IsBooked = true;
                shipmentOffer.Shipment.TimeStamp = DateTime.Now.ToFileTime();
            }
        }
    }
}
