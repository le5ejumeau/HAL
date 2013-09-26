using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAL.Library.DomainModel
{
    public class Logs : List<Log>
    {
        public event Action<Log> EAddLog; 

        public void Add(LogStat statut, String message)
        {
            Log log = new Log(statut, message);
            this.Add(log);
            if (EAddLog != null)
                EAddLog(log);
        }
    }

    public enum LogStat
    {
        Warning,
        Error,
        Info,
    }

    public class Log
    {
        #region Constructeurs

        public Log(LogStat statut, String message, DateTime date, Int32 id)
        {
            Status = statut;
            Message = message;
            Date = date;
            ID = id;
        }

        public Log(LogStat statut, String message, DateTime date)
            : this(statut, message, date, -1)
        {

        }

        public Log(LogStat statut, String message)
            : this(statut, message, DateTime.Now, -1)
        {

        }

        #endregion


        public LogStat Status { get; set; }
        public String Message { get; set; }
        public DateTime Date { get; set; }
        public Int32 ID { get; set; }

    }
}
