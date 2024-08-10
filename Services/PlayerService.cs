using RoosterLottery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using RoosterLottery.ViewModels;

namespace RoosterLottery.Services
{
    public class PlayerService : IPlayerService
    {
        private PlayerContext _context;
        public PlayerService(PlayerContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GetPlayerList
        /// </summary>
        /// <returns></returns>
        public List<Player> GetPlayerList()
        {
            List<Player> playerList;
            try
            {
                playerList = _context.Set<Player>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return playerList;
        }


        /// <summary>
        /// GetPlayerDetailsById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Player GetPlayerDetailsById(int id)
        {
            Player player;
            try
            {
                player = _context.Find<Player>(id);
            }
            catch (Exception)
            {
                throw;
            }
            return player;
        }


        /// <summary>
        ///  add edit playerModel
        /// </summary>
        /// <param name="playerModel"></param>
        /// <returns></returns>
        public ResponseModel SavePlayer(Player playerModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Player _temp = GetPlayerDetailsById(playerModel.Id);
                if (_temp != null)
                {
                    _temp.FullName = playerModel.FullName;
                    _temp.DoB = playerModel.DoB;
                    _context.Update<Player>(_temp);
                    model.Messsage = "Player Update Successfully";
                }
                else
                {
                    _context.Add<Player>(playerModel);
                    model.Messsage = "Player Inserted Successfully";
                }
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        /// <summary>
        /// delete player by id
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public ResponseModel DeletePlayer(int playerId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Player _temp = GetPlayerDetailsById(playerId);
                if (_temp != null)
                {
                    _context.Remove<Player>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Player Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Player Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
    }
}
