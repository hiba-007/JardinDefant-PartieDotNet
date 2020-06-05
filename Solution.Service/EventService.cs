﻿using Service.Pattern;
using Solution.Data.Infrastructure;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public class EventService : Service<Event>, IServiceEvent
    {
        static IDataBaseFactory Factory = new DataBaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);
        public EventService() : base(utk)
        {
        }

        public Event FindEventByQrCode(string qrcode)
        {
            Event @event;
            @event = GetMany().Where(e => e.qrCode == qrcode).FirstOrDefault();
            return @event;
        }

        public IEnumerable<Event> FindEventsByCtegory(string eventcategory)
        {
            IEnumerable<Event> EventDomain = GetMany(e=>e.Category.ToString()==eventcategory);
            return EventDomain;
        }

        public IEnumerable<Event> FindEventsByName(string eventname)
        {
            IEnumerable<Event> EventDomain = GetMany();
            if (!String.IsNullOrEmpty(eventname))
            {
                EventDomain = GetMany(x => x.Name.Contains(eventname));
            }
            return EventDomain;
        }
    }
}
