﻿namespace Local_community_Back.Model
{
    public class Departments
    {
        public enum CouncilApparatus
        {
            Head,
            VillageElder,
            AccountingMember,
            FinancialMember,
            LegalDepartment,
            DepartmentOfEducation,
            DepartmentOfOrganizational,
            DepartmentOfLandRelations,
            DepartmentOfLaborAndSocialProtection,
            SectorOfCivilProtection,
            ChildrensService,
            AdministrativeServices
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public CouncilApparatus Type { get; set; }
        public string Description { get; set; }
    }
}
