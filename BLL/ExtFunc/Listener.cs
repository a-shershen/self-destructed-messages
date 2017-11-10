using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ExtFunc
{
    //Listen DB for time over messages
    public static class Listener
    {
        //Timer
        private static System.Timers.Timer timer;
        //DAL repository
        private static DAL.IRepositiry<DAL.Message> mesRep = null;

        //Start Timer
        public static void StartTimer(DAL.IRepositiry<DAL.Message> rep)
        {
            mesRep = rep;

            //in milliseconds
            timer = new System.Timers.Timer(1000 * 60);
                        
            timer.AutoReset = true;

            timer.Elapsed += RemoverOverTime;

            timer.Start();
        }

        //Remove time over messages
        public static void RemoverOverTime(object obj, EventArgs args)
        {
            try
            {
                //DAL delete all time over messages
                mesRep.DeleteAllOverTimeMessages();
            }
            catch
            {
                ;
            }
        }

    }
}
