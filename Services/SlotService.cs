using RoosterLottery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using RoosterLottery.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Slot = RoosterLottery.Models.Slot;
using Microsoft.AspNetCore.Http.HttpResults;

namespace RoosterLottery.Services
{
    public class SlotService : ISlotService
    {
        private RoosterLotteryContext _context;
        public SlotService(RoosterLotteryContext context) => _context = context;

        /// <summary>
        /// GetPlayerList
        /// </summary>
        /// <returns></returns>
        public List<Slot> Load()
        {
            List<Slot> slots;
            try
            {
                slots = _context.Set<Slot>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return slots;
        }

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Slot GetById(int id)
        {
            Models.Slot slot;
            try
            {
                slot = _context.Find<Slot>(id);
            }
            catch (Exception)
            {
                throw;
            }
            return slot;
        }

        /// <summary>
        /// Add edit playerModel
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ResponseModel Save(Slot model)
        {
            ResponseModel response = new();
            try
            {
                Slot _temp = GetById(model.Id);
                if (_temp != null)
                {
                    _temp.FrTime = model.FrTime;
                    _temp.ToTime = model.ToTime;
                    _context.Update<Slot>(_temp);
                    response.Messsage = "Slot Update Successfully";
                }
                else
                {
                    _context.Add<Slot>(model);
                    response.Messsage = "Slot Inserted Successfully";
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
                Slot _temp = GetById(id);
                if (_temp != null)
                {
                    _context.Remove<Slot>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Slot Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Slot Not Found";
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
