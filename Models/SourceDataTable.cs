using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class SourceDataTable
    {
        public static DataTable GetSourceTable(List<Process> processList)
        {
            DataTable table = new DataTable("Список процессов");
            
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Memory", typeof(double));
            table.Columns.Add("Status", typeof(string));

            foreach (Process process in processList)
            {
                table.Rows.Add(
                    process.Id,
                    process.ProcessName,
                    Math.Round(Convert.ToDouble(process.WorkingSet64) / (1024 * 1024), 2),
                    process.Responding);
            }
            return table;
        }

    }
}
