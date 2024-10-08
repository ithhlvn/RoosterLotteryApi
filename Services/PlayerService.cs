﻿using RoosterLottery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using RoosterLottery.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Player = RoosterLottery.Models.Player;
using Microsoft.AspNetCore.Http.HttpResults;

namespace RoosterLottery.Services
{
    public class PlayerService : IPlayerService
    {
        private RoosterLotteryContext _context;
        public PlayerService(RoosterLotteryContext context) => _context = context;

        /// <summary>
        /// Load
        /// </summary>
        /// <returns></returns>
        public List<Player> Load()
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
        /// BetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Player GetById(int id)
        {
            Models.Player player;
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
        /// Method to search for a player by phone number
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public Player SearchPlayerByPhoneNumber(string phoneNumber)
        {
            return _context.Set<Player>()?.ToList()?.FirstOrDefault(p => p.Phone.ToLower().Equals(phoneNumber.ToLower()));
        }

        /// <summary>
        /// Add edit playerModel
        /// </summary>
        /// <param name="playerModel"></param>
        /// <returns></returns>
        public ResponseModel Save(Player model)
        {
            ResponseModel response = new();
            try
            {
                Player _temp = GetById(model.Id);
                if (_temp != null)
                {
                    _temp.FullName = model.FullName;
                    _temp.DoB = model.DoB;
                    _context.Update<Player>(_temp);
                    response.Messsage = "Player Update Successfully";
                }
                else
                {
                    _context.Add<Player>(model);
                    response.Messsage = "Player Inserted Successfully";
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
        /// Delete player by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResponseModel Delete(int id)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Player _temp = GetById(id);
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
