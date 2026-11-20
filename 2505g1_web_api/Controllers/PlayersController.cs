using _2505g1_web_api.Models.DTOs;
using _2505g1_web_api.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _2505g1_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {


        private readonly _2505g1WebApiContext db;
        public PlayersController(_2505g1WebApiContext _db)
        {
            this.db = _db;
        }

        [HttpGet]
        public IActionResult GetPlayers()
        {
            var players = db.Players.ToList();
            return Ok(players);
        }

        [HttpPost]
        public IActionResult AddPlayer(PlayerDTO playerData)
        {

            // Object Mapping


            Player player = new Player()
            {
                Name = playerData.Name,
                Style = playerData.Style,
                Runs = playerData.Runs,
                StrikeRate = playerData.StrikeRate,
                Average = playerData.Average,
                Type = playerData.Type,
                TeamId = playerData.TeamId,

            };

            var newPlayer = db.Players.Add(player);
            db.SaveChanges();
            return Ok(newPlayer.Entity);
        }



        [HttpGet("{id}")]
        public IActionResult GetPlayer(int id)
        {
            var player = db.Players.FirstOrDefault(t => t.PlayerId == id);
            if (player == null)
            {

                return NotFound("Invalid id, player not found");
            }
            else
            {
                return Ok(player);

            }
        }


        [HttpPut("{id}")]
        public IActionResult EditPlayer(PlayerDTO playerData, int id)
        {
            var player = db.Players.FirstOrDefault(t => t.PlayerId == id);
            player.Name = playerData.Name;
            player.Style = playerData.Style;
            player.Type = playerData.Type;
            player.Runs = playerData.Runs;
            player.StrikeRate = playerData.StrikeRate;
            player.Average = playerData.Average;
            player.TeamId = playerData.TeamId;


            var updateplayer = db.Players.Update(player);
            db.SaveChanges();
            return Ok(updateplayer.Entity);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlayer( int id)
        {
            var player = db.Players.FirstOrDefault(t => t.PlayerId == id);
            

            var deleteplayer = db.Players.Remove(player);
            db.SaveChanges();
            return Ok(deleteplayer.Entity);
        }


        // Search Api
        [HttpGet("search/{query}")]
        public IActionResult SearchPlayer(string query)
        {
            // aman   ==> exact match
            // aman   ==> partial  match aman khan, fakhar zaman

            //Exact Match

            var searchResult = db.Players
           //.Where(p => p.Name == query ||p.Style == query || p.Type == query ).ToList();
                                        .Where(p => p.Name.Contains( query) ||p.Style.Contains( query) || p.Type.Contains( query) ).ToList();

            //Partial Match
        

            return Ok(searchResult);

           

        }





        // Search Api
        [HttpGet("pagination/")]
        public IActionResult Pagination(int pageSize=1, int pageNo=1)
        {

            if (pageSize < 1 )
            {
                pageSize = 1;
            }

            if (pageNo < 1)
            {
                pageNo = 1;
            }

            var players = db.Players.Skip(pageNo * pageSize - pageSize).Take(pageSize);

            return Ok(players);



        }







        //[HttpGet("search/{query}")]
        //public IActionResult SearchPlayer2(string query)
        //{
        //    bool isNumeric = double.TryParse(query, out double numericQuery);

        //    var searchResult = db.Players
        //        .Include(p => p.Team)
        //        .Where(p =>
        //            p.Name.Contains(query) ||
        //            p.Style.Contains(query) ||
        //            p.Type.Contains(query) ||

        //            // Search Team Name
        //            p.Team.TeamName.Contains(query) ||

        //            // Search numeric properties
        //            (isNumeric &&
        //                (p.Runs == numericQuery ||
        //                 p.Average == numericQuery ||
        //                 p.StrikeRate == numericQuery))
        //        )
        //        .Select(p => new PlayerDTO
        //        {
        //            Name = p.Name,
        //            Style = p.Style,
        //            Type = p.Type,
        //            Runs = p.Runs,
        //            Average = p.Average,
        //            StrikeRate = p.StrikeRate,
        //            TeamId = p.TeamId
        //        })
        //        .ToList();

        //    return Ok(searchResult);
        //}
        //[HttpGet("pagination")]
        //public IActionResult GetPlayersPagination(int pageNumber = 1, int pageSize = 10)
        //{
        //    if (pageNumber < 1 || pageSize < 1)
        //    {
        //        return BadRequest("Page number and page size must be greater than 0.");
        //    }

        //    var totalRecords = db.Players.Count();

        //    var players = db.Players
        //        .Include(p => p.Team)
        //        .OrderBy(p => p.PlayerId)
        //        .Skip((pageNumber - 1) * pageSize)
        //        .Take(pageSize)
        //        .Select(p => new PlayerDTO
        //        {
        //            Name = p.Name,
        //            Style = p.Style,
        //            Type = p.Type,
        //            Runs = p.Runs,
        //            Average = p.Average,
        //            StrikeRate = p.StrikeRate,
        //            TeamId = p.TeamId
        //        })
        //        .ToList();

        //    var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

        //    var response = new
        //    {
        //        TotalRecords = totalRecords,
        //        PageNumber = pageNumber,
        //        PageSize = pageSize,
        //        TotalPages = totalPages,
        //        HasPreviousPage = pageNumber > 1,
        //        HasNextPage = pageNumber < totalPages,
        //        Data = players
        //    };

        //    return Ok(response);
        //}

    }
}
