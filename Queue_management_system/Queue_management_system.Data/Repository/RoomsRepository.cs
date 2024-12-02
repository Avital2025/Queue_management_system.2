﻿using Queue_management_system.Core.Iservice;
using Queue_management_system.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue_management_system.Data.Repository
{
    public class RoomsRepository:IRoomsService
    {
        readonly DataContext _dataContext;


        public RoomsRepository(DataContext datacontext)
        {
            _dataContext = datacontext;
        }


        public IEnumerable<RoomsEntity> GetAllData()
        {
            return _dataContext.roomsList;

        }


        public RoomsEntity GetById(int id)
        {
            var data = _dataContext.roomsList;
            if (data == null)
                return null;
            return data.Where(c => c.RoomId == id).FirstOrDefault();
        }


        public bool AddData(RoomsEntity room)
        {
            try
            {
                _dataContext.queuesList.Add(room);
                _dataContext.SaveChange();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteData(int id)
        {
            var data = _dataContext.roomsList;
            if (data == null) return false;
            int index = data.FindIndex(x => x.RoomId == id);
            if (index != -1)
            {
                data.Remove(data.Find(x => x.RoomId == id));
                _dataContext.SaveChange();
                return true;
            }
            return false;
        }
        public bool UpdateData(int id, RoomsEntity room)
        {
            var data = _dataContext.roomsList;
            if (data == null) return false;
            int index = data.FindIndex(x => x.RoomId == id);
            if (index != -1)
            {
                data.RemoveAt(index);
                data.Insert(index, room);
                _dataContext.SaveChange();
                return true;
            }
            return false;
        }
    }
}
