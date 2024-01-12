using static System.Net.Mime.MediaTypeNames;

namespace Local_community_Back.Model
{
    public class Appeal
    {
        public enum AppealType
        {
            Appeal,
            Complaints,
            Statements
        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public AppealType Type { get; set; }
        public string Adress { get; set; }
        public int PhoneNumber { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
    }
}
