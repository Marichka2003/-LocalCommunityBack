using static Local_community_Back.Model.Infrastructure;

namespace Local_community_Back.ModelDto
{
    public class InfrastructureDto
    {
        public InfrastructureType Type { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }
        public string? ImageName { get; set; }
    }
}
