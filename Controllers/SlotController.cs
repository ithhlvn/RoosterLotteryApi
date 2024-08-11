﻿using RoosterLottery.Models;
using RoosterLottery.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace RoosterLottery.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SlotController : ControllerBase
    {
        ISlotService _service;
        public SlotController(ISlotService service) => _service = service;

        /// <summary>
        /// Load
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Load()
        {
            try
            {
                var player = _service.Load();
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
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                var player = _service.GetById(id);
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
        /// Save player
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Save(Slot model)
        {
            try
            {
                var response = _service.Save(model);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete player  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var model = _service.Delete(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
