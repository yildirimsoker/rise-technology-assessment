namespace RiseTechnology.Domain.Entities
{
    public class Person : BaseEntity
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Company { get; set; }
        public IList<PersonContact> PersonContact { get; set; } = new List<PersonContact>();
    }
}
