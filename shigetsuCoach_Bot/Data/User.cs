using System;
using System.Collections.Generic;
using System.Text;

namespace shigetsuCoach_Bot.Data
{
    class User
    {
        public int id { get; set; }
        public long userTelegramId { get; set; }
        //public long userTelegramId {
        //    get { return userTelegramId; }
        //    set {
        //        userTelegramId = Convert.ToInt64(value);
        //            }
        //}
        public string firstName { get; set; }
        public string phoneNumber { get; set; }
    }
}
