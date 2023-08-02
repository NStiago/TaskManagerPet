using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using TaskManager.Models;

namespace TaskManager
{
    public partial class TaskManager : Form
    {
        List<Process> processList = new List<Process>();
        BindingList<ProcessForDisplay> processForDisplayList=new BindingList<ProcessForDisplay>();

        public TaskManager()
        {
            InitializeComponent();
        }

        private void TaskManager_Load(object sender, EventArgs e)
        {
            processList = Process.GetProcesses().ToList();
            processForDisplayList=ProcessForDisplay.GetProcessForDisplays(processList);
        }

        private void Ù‡ÈÎToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ÔÓ‰Ó·ÌÂÂToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}