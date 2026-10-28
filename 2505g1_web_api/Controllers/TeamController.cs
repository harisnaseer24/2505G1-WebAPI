using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _2505g1_web_api.Models;
using _2505g1_web_api.Models.DTOs;


namespace _2505g1_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {

        private readonly _2505g1WebApiContext db;
        public TeamController(_2505g1WebApiContext _db)
        {
            this.db = _db;
        }

        [HttpGet]
        public IActionResult GetTeams()
        {
            var teams = db.Teams.ToList();
            return Ok(teams);
        }

        [HttpPost]
        public IActionResult AddTeam(TeamDTO teamData)
        {

            // Object Mapping


            Team team = new Team()
            {
                TeamName = teamData.TeamName,
                Slogan = teamData.Slogan,
                Wins = teamData.Wins,
                Losses = teamData.Losses,
                Draw = teamData.Draw,

            };

            var newTeam = db.Teams.Add(team);
            db.SaveChanges();



            return Ok(newTeam.Entity);
        }



        [HttpGet("{id}")]
        public IActionResult GetTeam(int id)
        {
            var team = db.Teams.FirstOrDefault(t => t.TeamId == id);
            if (team == null)
            {
                
            return NotFound("Invalid id, team not found");
            }
            else
            {
            return Ok(team);

            }
        }


        [HttpPut("{id}")]
        public IActionResult EditTeam(TeamDTO teamData,int id)
        {
            var team = db.Teams.FirstOrDefault(t => t.TeamId == id);
            team.TeamName = teamData.TeamName;
            team.Slogan = teamData.Slogan;
            team.Wins = teamData.Wins;
            team.Losses = teamData.Losses;
            team.Draw = teamData.Draw;

           

            var updateTeam = db.Teams.Update(team);
            db.SaveChanges();



            return Ok(updateTeam.Entity);
        }





    }
}
