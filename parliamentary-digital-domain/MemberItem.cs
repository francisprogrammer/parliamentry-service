namespace PD.Domain
{
    public class MemberItem
    {
        public int Id { get; }
        public string Name { get; }

        public MemberItem(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}