namespace DataTransferObjects
{
    public record AdditionalServiceDto(int AdditionalServiceId, string AdditionalServiceName, double AdditionalServicePrice);

    public record AdditionalServiceShipmentDto(int AdditionalServiceId, int ShipmentId);

    public record AddressDto(int Id, string City, string Street, string PostalCode);

    public record CustomerDto(string FirstName, string LastName, string Address, string PostalCode);

    public record PersonDto(string FirstName, string LastName);

    public record DelivererDto(string FirstName, string LastName, DateTime DateOfEmpoyment);

    public record ShipmentDto(int ShipmentId, string ShipmentCode, int ShipmentWeightId, string ShipmentContent, string ContactPersonName, string ContactPersonPhone, int CustomerId, int DelivererId, double Price, string Note,
        AddressDto Sending, AddressDto Receiving, List<AdditionalServiceDto> AdditionalServices, List<StatusShipmentDto> ShipmentStatuses);

    public record ShipmentWeightDto(int ShipmentWeightId, string ShipmentWeightDescpription, double ShipmentWeightPrice);

    public record StatusDto(int StatusId, string StatusName);

    public record StatusShipmentDto(int StatusId, int ShipmentId, DateTime StatusTime);

}