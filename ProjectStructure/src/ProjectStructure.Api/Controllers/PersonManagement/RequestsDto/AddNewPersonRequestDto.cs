namespace ProjectStructure.Api.Controllers.PersonManagement.RequestsDto
{
    public sealed class AddNewPersonRequestDto
    {
        public string Name { get; set; }
        public string AddressLine { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
    }
}
