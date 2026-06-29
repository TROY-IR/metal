namespace metal.Domain.Entities.users
{
    public class Role
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Userinrole> Userinrole { get; set; }
    }
}
