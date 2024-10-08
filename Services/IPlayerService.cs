﻿using Microsoft.AspNetCore.Mvc;
using RoosterLottery.Models;
using RoosterLottery.ViewModels;
using System.Collections.Generic;
using Player = RoosterLottery.Models.Player;
using System.Threading.Tasks;

namespace RoosterLottery.Services
{
    public interface IPlayerService
    {
        /// <summary>
        /// Load all player
        /// </summary>
        /// <returns></returns>
        List<Player> Load();

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Player GetById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        Player SearchPlayerByPhoneNumber(string phoneNumber);
        
        /// <summary>
        ///  add edit player
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResponseModel Save(Player model);

        /// <summary>
        /// delete player
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResponseModel Delete(int id);
    }
}
