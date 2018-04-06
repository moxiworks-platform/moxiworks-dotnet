using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoxiWorks.Platform.Interfaces
{
    public interface ITeamService
    {

        Task<Response<List<Team>>> GetCompanyTeamsAync(string moxiWorksCompanyId);

        Task<Response<Team>> GetTeamAsync(string moxiWorksTeamId);

    }

  
}