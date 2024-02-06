using Local_community_Back.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Local_community_Back.Model;

namespace Local_community_Back.Model
{
    public class CommunitySearch
    {
        private readonly CommunityContext _context;

        public CommunitySearch(CommunityContext context)
        {
            _context = context;
        }

        public async Task<List<Appeal>> SearchAppeals(string query)
        {
            // Логіка пошуку для моделі Appeal
            return await _context.Appeal
                .Where(a => EF.Functions.Like(a.FullName, $"%{query}%") || EF.Functions.Like(a.Description, $"%{query}%"))
                .ToListAsync();
        }

        public async Task<List<Departments>> SearchDepartments(string query)
        {
            // Логіка пошуку для моделі Departments
            return await _context.Departments
                .Where(d => EF.Functions.Like(d.Name, $"%{query}%") || EF.Functions.Like(d.Description, $"%{query}%"))
                .ToListAsync();
        }

        public async Task<List<Finances>> SearchFinances(string query)
        {
            // Логіка пошуку для моделі Finances
            return await _context.Finances
                .Where(f => EF.Functions.Like(f.SocialPrograms, $"%{query}%") || EF.Functions.Like(f.IncomeInformation, $"%{query}%"))
                .ToListAsync();
        }

        // Додайте аналогічні методи для інших моделей (Infrastructure, Map і т.д.)
    }
}
