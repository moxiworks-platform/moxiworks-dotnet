using System.Collections.Generic;
using MoxiWorks.Platform.Interfaces;
using System.Threading.Tasks;
namespace MoxiWorks.Platform
{
    public class TeamService: ITeamService 
    {
        public IMoxiWorksClient Client { get; set; }
        
        public TeamService(IMoxiWorksClient client)
        {
            Client = client; 
        }
        
        /// <summary>
        /// Get a Team in a company. 
        /// </summary>
        /// <param name="moxiWorksTeamId">A valid Moxi Works Team ID. Use Team Index Endpoint for a list of all Team objects associated with a Company or use the moxi_works_team_id attribute returned in an Agent response.</param>
        /// <param name="moxiWorksCompanyId">A valid Moxi Works Company ID. Use Company Endpoint to determine what moxi_works_company_id you can use.
        ///</param>
        /// <returns>Returns the team in the compang if it exists.</returns>
        public async Task<Response<Team>> GetTeamAsync(string moxiWorksTeamId)
        {
            var builder = new UriBuilder($"teams/{moxiWorksTeamId}");
            return await Client.GetRequestAsync<Team>(builder.GetUrl());
        }

        /// <summary>
        /// Get a List of Teams in a company. 
        /// </summary>
        /// <param name="moxiWorksCompanyId"></param>
        /// <returns>Response of Teams</returns>
        public async Task<Response<List<Team>>>GetCompanyTeamsAync(string moxiWorksCompanyId)
        {
            var builder = new UriBuilder("teams")
                .AddQueryParameter("moxi_works_company_id", moxiWorksCompanyId);
         
           var results =  await Client.GetRequestAsync<List<Team>>(builder.GetUrl());
            
            return new Response<List<Team>>
            {
                Errors = results.Errors,
                Item = results.Item
            };
        }
      
        
    }
}