namespace DataTransferObjects
{
    public record AdditionalServiceDto(int AdditionalServiceId, string AdditionalServiceName, double AdditionalServicePrice);

    public record AdditionalServiceShipmentDto(int AdditionalServiceId, int ShipmentId);

    public record AddressDto(int Id, string City, string Street, string PostalCode);

    public record PersonDto(int Id, string UserName, string Email,  string PhoneNumber, string FirstName, string LastName);

    public record CustomerDto(int Id, string UserName, string Email, string PhoneNumber, string FirstName, string LastName, string Address, string PostalCode) 
        : PersonDto( Id, UserName, Email, PhoneNumber, FirstName, LastName);

    public record DelivererDto(int Id, string UserName, string Email, string PhoneNumber, string FirstName, string LastName, DateTime DateOfEmployment) 
        : PersonDto(Id, UserName, Email, PhoneNumber, FirstName, LastName);

    public record ShipmentDto(int ShipmentId, string ShipmentCode, int ShipmentWeightId, string ShipmentContent, string ContactPersonName, string ContactPersonPhone, int CustomerId, double Price, string Note,
        AddressDto Sending, AddressDto Receiving, List<AdditionalServiceDto> AdditionalServices, List<StatusShipmentDto> ShipmentStatuses);

    public record ShipmentWeightDto(int ShipmentWeightId, string ShipmentWeightDescpription, double ShipmentWeightPrice);

    public record StatusDto(int StatusId, string StatusName);

    public record StatusShipmentDto(int StatusId, int ShipmentId, DateTime StatusTime);

}