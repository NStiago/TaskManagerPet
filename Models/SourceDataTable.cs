using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class SourceDataTable : INotifyPropertyChanged
    {
        private DataTable _table;
        public DataTable Table { 
            get 
            { 
                return _table;
            }
            set 
            { 
                _table = value;
                OnPropertyChanged();
            }
        }
        public SourceDataTable(List<Process> processList)
        {
            Table = new DataTable();
            Table.Columns.Add("ID", typeof(int));
            Table.Columns.Add("Name", typeof(string));
            Table.Columns.Add("Memory", typeof(double));
            Table.Columns.Add("Status", typeof(string));

            foreach (Process process in processList)
            {
                Table.Rows.Add(
                    process.Id,
                    process.ProcessName,
                    Math.Round(Convert.ToDouble(process.WorkingSet64) / (1024 * 1024), 2),
                    process.Responding == true ? "Responding" : "Not responding");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


}
