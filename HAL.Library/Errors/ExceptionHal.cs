using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAL.Library.Exceptions
{
    public class ExceptionHal : Exception
    {
        public ExceptionHal(string message)
            :base(message)
        {
            LogService.Write(message);
        }

    }
}
