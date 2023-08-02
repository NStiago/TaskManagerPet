using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class ProcessForDisplay:INotifyPropertyChanged
    {

        private int _id;
        private string _name;
        private double _memory;
        private string _status;




        public int Id 
        { 
            get =>_id;
            set 
            { 
                _id = value;
                OnPropertyChanged();
            }
        }
        public string Name 
        { 
            get=>_name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public double Memory 
        { 
            get=>_memory;
            set
            {
                _memory = value;
                OnPropertyChanged();
            }
        }
        public string Status 
        { 
            get=>_status;
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        public ProcessForDisplay(int id, string name, double memory, bool status)
        {
            Id = id;
            Name = name;
            Memory = memory;
            Status = status == true ? "Responding" : "Not responding";
        }

        public static BindingList<ProcessForDisplay> GetProcessForDisplays(List<Process> processList)
        {
            BindingList<ProcessForDisplay> processForDisplayList = new BindingList<ProcessForDisplay>();
            foreach (var process in processList)
            {
                processForDisplayList.Add(new ProcessForDisplay(process.Id, process.ProcessName, process.WorkingSet64, process.Responding));
            }
            return processForDisplayList;
        }
        

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
