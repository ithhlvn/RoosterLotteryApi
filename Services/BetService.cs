using RoosterLottery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using RoosterLottery.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bet = RoosterLottery.Models.Bet;
using Microsoft.AspNetCore.Http.HttpResults;

namespace RoosterLottery.Services
{
    public class BetService : IBetService
    {
        private RoosterLotteryContext _context;
        public BetService(RoosterLotteryContext context) => _context = context;

        /// <summary>
        /// Load
        /// </summary>
        /// <returns></returns>
        public List<Bet> Load()
        {
            List<Bet> playerList;
            try
            {
                playerList = _context.Set<Bet>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return playerList;
        }

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Bet GetById(int id)
        {
            Models.Bet bet;
            try
            {
                bet = _context.Find<Bet>(id);
            }
            catch (Exception)
            {
                throw;
            }
            return bet;
        }

        /// <summary>
        /// GetByPlayerId
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public List<Bet> GetByPlayerId(int playerId)
        {
            return _context.Set<Bet>()?.ToList()?.Where(x => x.PlayerId == playerId)?.ToList();
        }
        /// <summary>
        /// Add edit model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ResponseModel Save(Bet model)
        {
            ResponseModel response = new();
            try
            {
                Bet _temp = GetById(model.Id);
                if (_temp != null)
                {
                    _temp.PlayerId = model.PlayerId;
                    _temp.SlotId = model.SlotId;
                    _temp.Value = model.Value;
                    _temp.IsWin = model.IsWin;
                    _context.Update<Bet>(_temp);
                    response.Messsage = "Bet Update Successfully";
                }
                else
                {
                    _context.Add<Bet>(model);
                    response.Messsage = "Bet Inserted Successfully";
                }
                _context.SaveChanges();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Messsage = "Error : " + ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResponseModel Delete(int id)
        {
            ResponseModel model = new();
            try
            {
                Bet _temp = GetById(id);
                if (_temp != null)
                {
                    _context.Remove<Bet>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Bet Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Bet Not Found";
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
