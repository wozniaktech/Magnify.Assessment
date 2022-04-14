namespace Magnify.Assessment
{
    public class Carrier
    {
        public void BookShipment(ShipmentRequest shipment)
        {
            if (!shipment.IsBooked)
            {
                shipment.IsBooked = true;
                shipment.TimeStamp = DateTime.Now.ToFileTime();
            }
        }
        public ShipmentOffer CreateShipmentOffer(ShipmentRequest shipment, decimal offeredPrice)
        {
            return new ShipmentOffer
            {
                OfferedPrice = offeredPrice,
                Shipment = shipment
            };
        }
    }
}
