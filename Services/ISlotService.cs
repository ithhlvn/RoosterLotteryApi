using Microsoft.AspNetCore.Mvc;
using RoosterLottery.Models;
using RoosterLottery.ViewModels;
using System.Collections.Generic;
using Slot = RoosterLottery.Models.Slot;
using System.Threading.Tasks;

namespace RoosterLottery.Services
{
    public interface ISlotService
    {
        /// <summary>
        /// get list of all Slot
        /// </summary>
        /// <returns></returns>
        List<Slot> Load();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Slot GetById(int id);

        /// <summary>
        ///  add edit Slot
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResponseModel Save(Slot model);

        /// <summary>
        /// delete Slot
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResponseModel Delete(int id);
    }
}
