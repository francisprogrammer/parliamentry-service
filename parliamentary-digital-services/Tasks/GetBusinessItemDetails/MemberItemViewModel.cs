namespace PD.Services.Tasks.GetBusinessItemDetails
{
    public class MemberItemViewModel
    {
        public int Id { get; }
        public string Name { get; }

        public MemberItemViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}