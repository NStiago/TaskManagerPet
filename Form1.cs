using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace TaskManager
{
    public partial class TaskManager : Form
    {
        List<Process> processList = new List<Process>();

        public TaskManager()
        {
            InitializeComponent();
        }

        private void TaskManager_Load(object sender, EventArgs e)
        {
            processList = Process.GetProcesses().ToList();

        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}