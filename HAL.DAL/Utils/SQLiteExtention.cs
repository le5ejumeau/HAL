using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAL.DAL.Extentions
{
    internal static class SQLiteExtention
    {
        internal static SQLiteCommand CreateCommand(this SQLiteConnection context, String commandText, params  SQLiteParameter[] parameters)
        {   
            SQLiteCommand command = context.CreateCommand();
            command.CommandText = commandText;
            command.Parameters.AddRange(parameters);

            return command;
        }
    }
}
