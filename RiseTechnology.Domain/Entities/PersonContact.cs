namespace RiseTechnology.Domain.Entities
{
    public class PersonContact : BaseEntity
    {
        public int PersonId { get; set; }
        public ContactType ContactType { get; set; }
        public string? ContactDescription { get; set; }
        public virtual Person Person { get; set; } = null!;
    }

    public enum ContactType
    {
        Email,
        Location,
        PhoneNumber
    }

}
