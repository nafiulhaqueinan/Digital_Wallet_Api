using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class NotificationService
    {
        public static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Notification, NotificationDTO>().ReverseMap();
            });
            return new Mapper(cfg);

        }

        public static bool Create(NotificationDTO notification)
        {
            var mapper = GetMapper();
            var mappedNotification = mapper.Map<DAL.Models.Notification>(notification);
            var createdNotification = DataAccessFactory.NotificationData().Create(mappedNotification);
            return createdNotification != null;
        }
        public static List<NotificationDTO> Get()
        {
            var data = DataAccessFactory.NotificationData().Read();
            return GetMapper().Map<List<NotificationDTO>>(data);
        }
        public static NotificationDTO Get(int id)
        {
            var data = DataAccessFactory.NotificationData().Read(id);
            var mapped = GetMapper().Map<NotificationDTO>(data);
            return mapped;
        }
        public static bool Delete(int id)
        {
            var data = DataAccessFactory.NotificationData().Delete(id);
            return data != null;
        }
        public static bool Update(NotificationDTO notification)
        {
            var mapper = GetMapper();
            var mappedNotification = mapper.Map<DAL.Models.Notification>(notification);
            var updatedNotification = DataAccessFactory.NotificationData().Update(mappedNotification);
            return updatedNotification != null;
        }

    }
}
