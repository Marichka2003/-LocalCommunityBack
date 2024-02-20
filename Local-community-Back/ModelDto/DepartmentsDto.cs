using static Local_community_Back.Model.Departments;

namespace Local_community_Back.ModelDto
{
    public class DepartmentsDto
    {
        public string Name { get; set; }
        public CouncilApparatus Type { get; set; }
        public string Description { get; set; }
    }
}
