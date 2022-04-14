using NUnit.Framework;

namespace Magnify.Assessment.Test
{
    [TestFixture]
    public class Tests
    {
        private Shipper? _shipper;
        private ShipmentRequest? _shipmentRequest;
        private Carrier? _carrier;

        [SetUp]
        public void Setup()
        {
            _shipper = new Shipper();
            _shipmentRequest = _shipper.CreateShipmentRequest("Pickup address", "Destination address", 1000M, "Comment");
            _carrier = new Carrier();
        }

        [Test]
        //First scenario shipment was not booked before. Booking is successfull.
        public void BookShipment_WasNotBookedBefore_BookingSuccess()
        {
            _carrier.BookShipment(_shipmentRequest);
            Assert.AreEqual(_shipmentRequest.IsBooked, true);
        }   

        [Test]
        //Second scenario shipment was not booked before. Carrier creates shipment offer and shipper accepts offer.
        public void AcceptOffer_WasNotBooked_OfferIsAccepted() 
        {
            var _shipmentOffer = _carrier.CreateShipmentOffer(_shipmentRequest, 850M);
            _shipper.AcceptOffer(_shipmentOffer, true);
            Assert.AreEqual(_shipmentRequest.BudgetAmount, 850M);
        }

        [Test]
        //Third scenario shipment was booked before and shipper can't accept any offer. The price is not accepted.
        public void AcceptOffer_WasBooked_OfferWasNotAccepted()
        {
            var _shipmentOffer = _carrier.CreateShipmentOffer(_shipmentRequest, 850M);
            _shipmentOffer.Shipment.IsBooked = true;
            _shipper.AcceptOffer(_shipmentOffer, true);
            Assert.AreNotEqual(_shipmentRequest.BudgetAmount, 850M);
        }

        [Test]
        //Fourth scenario shipment was not booked before. Carrier creates shipment offer and shipper rejects offer.
        public void AcceptOffer_WasNotBooked_ShiperRejectsOffer()
        {
            var _shipmentOffer = _carrier.CreateShipmentOffer(_shipmentRequest, 850M);
            _shipper.AcceptOffer(_shipmentOffer, false);
            Assert.AreNotEqual(_shipmentRequest.BudgetAmount, 850M);
        }
    }
}