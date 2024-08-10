using RoosterLottery.Models;
using RoosterLottery.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoosterLottery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        IPlayerService _playerService;
        public PlayerController(IPlayerService service) => _playerService = service;

        /// <summary>
        /// get all player
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllPlayer()
        {
            try
            {
                var player = _playerService.GetPlayerList();
                if (player == null)
                    return NotFound();
                return Ok(player);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// get player details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetPlayerById(int id)
        {
            try
            {
                var player = _playerService.GetPlayerDetailsById(id);
                if (player == null)
                    return NotFound();
                return Ok(player);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// save player
        /// </summary>
        /// <param name="playerModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult SavePlayer(Player playerModel)
        {
            try
            {
                var model = _playerService.SavePlayer(playerModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// delete player  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeletePlayer(int id)
        {
            try
            {
                var model = _playerService.DeletePlayer(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
