using Magnify.Assessment;

//create a new shipper
var shipper = new Shipper();

//create a new shipment requests
var shipmentRequest = shipper.CreateShipmentRequest("address", "addresss2", 1000M, "no comment");
var shipmentRequest2 = shipper.CreateShipmentRequest("address", "addresss2", 2000M, "no comment");

//create a new carrier
var carrier = new Carrier();

//book a shipmentRequest
carrier.BookShipment(shipmentRequest);

//create shipmentRequest offer
var shipmentOffer = carrier.CreateShipmentOffer(shipmentRequest2, 850M);

//reject offer
shipper.AcceptOffer(shipmentOffer, false);

//accept offer
shipper.AcceptOffer(shipmentOffer, true);

Console.WriteLine("Press [Enter] to exit.");
Console.ReadLine();
