using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class ProcessForDisplay
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public double Memory { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
