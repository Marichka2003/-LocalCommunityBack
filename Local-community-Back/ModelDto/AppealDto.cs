using static Local_community_Back.Model.Appeal;

namespace Local_community_Back.ModelDto
{
    public class AppealDto
    {
        public string FullName { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int PhoneNumber { get; set; }
        public string ImageName { get; set; }
    }
}
