using RoosterLottery.Models;
using RoosterLottery.ViewModels;
using System.Collections.Generic;

namespace RoosterLottery.Services
{
    public interface IPlayerService
    {
        /// <summary>
        /// get list of all player
        /// </summary>
        /// <returns></returns>
        List<Player> GetPlayerList();

        /// <summary>
        /// get player details by playerId
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        Player GetPlayerDetailsById(int playerId);

        /// <summary>
        ///  add edit player
        /// </summary>
        /// <param name="playerModel"></param>
        /// <returns></returns>
        ResponseModel SavePlayer(Player playerModel);


        /// <summary>
        /// delete player
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        ResponseModel DeletePlayer(int playerId);
    }
}
