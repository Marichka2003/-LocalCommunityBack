namespace Local_community_Back.Model
{
    public class Finances
    {
        public int Id { get; set; }
        public string SocialPrograms { get; set; }    
        public int BudgetData { get; set; }
        public string IncomeInformation { get; set; }
        public ICollection<Appeal> AppealId { get; set; }
        public int AmountOfAllocated { get; set; }
        public int Balance { get; set; }    }
}
