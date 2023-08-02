using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class ProcessForDisplay
    {
        public ProcessForDisplay(int id, string name, double memory, bool status)
        {
            Id= id;
            Name= name;
            Memory= memory;
            Status = status == true ? "Responding" : "Not responding";
        }
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public double Memory { get; set; }
        public string Status { get; set; } = string.Empty;

        public static BindingList<ProcessForDisplay> GetProcessForDisplays(List<Process> processList)
        {
            BindingList<ProcessForDisplay> processForDisplayList = new BindingList<ProcessForDisplay>();
            foreach (var process in processList)
            {
                processForDisplayList.Add(new ProcessForDisplay(process.Id, process.ProcessName, process.WorkingSet64, process.Responding));
            }
            return processForDisplayList;
        }
    }
}
