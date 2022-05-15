namespace RiseTechnology.Application.Persons.Queries.GetPersonById
{
    public class GetPersonByIdDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Company { get; set; }
        public List<GetPersonByIdContactDTO> PersonContact { get; set; } = new List<GetPersonByIdContactDTO>();
    }

    public class GetPersonByIdContactDTO 
    {
        public string? ContactType { get; set; }
        public string? ContactDescription { get; set; }
    }
}
