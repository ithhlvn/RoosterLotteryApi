using Microsoft.AspNetCore.Mvc;
using RoosterLottery.Models;
using RoosterLottery.ViewModels;
using System.Collections.Generic;
using Bet = RoosterLottery.Models.Bet;
using System.Threading.Tasks;

namespace RoosterLottery.Services
{
    public interface IBetService
    {
        /// <summary>
        /// Lottery
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Lottery(byte value);

        /// <summary>
        /// Load
        /// </summary>
        /// <returns></returns>
        List<Bet> Load();

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Bet GetById(int id);

        /// <summary>
        /// GetByPlayerId.
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        List<Bet> GetByPlayerId(int playerId);

        /// <summary>
        /// add edit Bet
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResponseModel Save(Bet model);

        /// <summary>
        /// delete Bet
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResponseModel Delete(int id);
    }
}
