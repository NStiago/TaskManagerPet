using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Runtime.CompilerServices;
using System.Security;
using TaskManager.Models;

namespace TaskManager
{
    public partial class TaskManager : Form, INotifyPropertyChanged
    {
        List<Process> processList = new List<Process>();
        BindingList<ProcessForDisplay> _processForDisplayList = new BindingList<ProcessForDisplay>();
        public BindingList<ProcessForDisplay> ProcessForDisplayList
        {
            get { return _processForDisplayList; }
            set
            {
                _processForDisplayList = value;
                OnPropertyChanged();
            }
        }

        //bool isRunning = true;
        Thread? gettingProcesses;

        //1. Êëàññ êîëëåêöèè 2. Ïðèâÿçêà êîëè÷åñòâà ïðîöåññîâ 3. Ôîíîâôé ïðîöåññ


        public TaskManager()
        {
            InitializeComponent();
            dataGridView1.DataBindings.Add("DataSource", this, nameof(ProcessForDisplayList));
            
            //label2.DataBindings.Add("Text", CountOfProcesses, null); 
        }

        private void TaskManager_Load(object sender, EventArgs e)
        {
                        processList = Process.GetProcesses().ToList();
                        ProcessForDisplayList = ProcessForDisplay.GetProcessForDisplays(processList);
                        


            //dataGridView1.DataSource = processForDisplayList;
            //label2.Text = processForDisplayList.Count.ToString();
        }

        private void ôàéëToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ïîäðîáíååToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}