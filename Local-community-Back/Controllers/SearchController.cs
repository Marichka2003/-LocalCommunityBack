using Local_community_Back.Data;
using Local_community_Back.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Local_community_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly CommunitySearch _communitySearch;

        public SearchController(CommunitySearch communitySearch)
        {
            _communitySearch = communitySearch;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            var appealResults = await _communitySearch.SearchAppeals(query);
            var departmentResults = await _communitySearch.SearchDepartments(query);
            var financeResults = await _communitySearch.SearchFinances(query);
            var newsResults = await _communitySearch.SearchNews(query);
            var mapResults = await _communitySearch.SearchMaps(query);
            var infrastructureResults = await _communitySearch.SearchInfrastructures(query);
         
            var combinedResults = new
            {
                AppealResults = appealResults,
                DepartmentResults = departmentResults,
                FinanceResults = financeResults,
                NewsResults = newsResults,
                MapResults = mapResults,
                InfrastructureResults = infrastructureResults
            };

            return Ok(combinedResults);
        }
    }
}
