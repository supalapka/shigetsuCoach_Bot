using System;
using System.Collections.Generic;
using System.Text;

namespace shigetsuCoach_Bot.Data.Files
{
    class BoostParticipant
    {
        public int Id { get; set; }
        public int currentMmr { get; set; }
        public int finalMmr { get; set; }
        public long telegramUserId { get; set; }
    }
}
