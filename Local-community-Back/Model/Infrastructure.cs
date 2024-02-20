namespace Local_community_Back.Model
{
    public class Infrastructure
    {
        public enum InfrastructureType
        {
            NewProject,
            Excursion,
            All
        }
        public int Id { get; set; }
        public InfrastructureType Type { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }
        public string? ImageName { get; set; }
    }
}
