using static Local_community_Back.Model.Infrastructure;

namespace Local_community_Back.Model
{
    public class ProjectInfrasrtructure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageName { get; set; }
        public int Votes { get; set; }
    }
}
