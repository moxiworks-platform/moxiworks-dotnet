using System;
using System.Collections.Generic;
using System.Data.Common;
using Xunit;
using MoxiWorks.Platform;
using MoxiWorks.Platform.Interfaces;

namespace MoxiWorks.Test
{
    public class TeamsServiceFixture
    {
        [Fact]
        public void ShouldReturnATeam()
        {
            var taskJson = StubDataLoader.LoadJsonFile("Team.json");  
            ITeamService service = new TeamService(new MoxiWorksClient(new StubContextClient(taskJson)));
            var response = service.GetTeamAsync("some_team_id").Result;
            Assert.IsType<Team>(response.Item);
            Assert.True(response.Item.Actve);
            Assert.True(response.Item.ZipCode == "91820");
            
        }
        
        [Fact]
        public void ShouldReturnCollectionOfTeamsForACompany()
        {
            var taskJson = StubDataLoader.LoadJsonFile("Teams.json");  
            ITeamService service = new TeamService(new MoxiWorksClient(new StubContextClient(taskJson)));
            var response = service.GetCompanyTeamsAync("some_company_id").Result;
            Assert.IsType<List<Team>>(response.Item);
            Assert.True(response.Item.Count == 2);
        }

    }
}