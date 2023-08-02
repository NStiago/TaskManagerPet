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
        bool isRunning = true;
        Thread? gettingProcesses;
        public BindingList<ProcessForDisplay> ProcessForDisplayList
        {
            get { return _processForDisplayList; }
            set 
            {
                _processForDisplayList = value;
                OnPropertyChanged();
            }
        }
        public TaskManager()
        {
            InitializeComponent();
            dataGridView1.DataBindings.Add("DataSource", this, nameof(ProcessForDisplayList));
        }

        private void TaskManager_Load(object sender, EventArgs e)
        {
            gettingProcesses = new Thread(() =>
            {
                //positionIndex и selectedPositionIndex - для запоминания выделенной строки и позиции скрола
                int positionIndex = 0;
                int selectedPositionIndex = 0;
                while (isRunning)
                {
                    if (dataGridView1.FirstDisplayedScrollingRowIndex != -1)
                        positionIndex = dataGridView1.FirstDisplayedScrollingRowIndex;
                    if (dataGridView1.CurrentCell != null)
                        selectedPositionIndex = dataGridView1.CurrentCell.RowIndex;

                    BeginInvoke(new Action(() =>
                    {
                        lock (processList)
                        {
                            processList = Process.GetProcesses().ToList();
                            ProcessForDisplayList = ProcessForDisplay.GetProcessForDisplays(processList);
                            label2.Text = ProcessForDisplayList.Count.ToString();
                        }
                        dataGridView1.CurrentCell = dataGridView1.Rows[selectedPositionIndex].Cells[0];
                        dataGridView1.FirstDisplayedScrollingRowIndex = positionIndex;
                    }));
                    Thread.Sleep(500);
                }
            });
            gettingProcesses.Start();
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            isRunning = true;
            if (!gettingProcesses.IsAlive)
            {
                gettingProcesses = new Thread(() =>
                 {
                     //positionIndex и selectedPositionIndex - для запоминания выделенной строки и позиции скрола
                     int positionIndex = 0;
                     int selectedPositionIndex = 0;
                     while (isRunning)
                     {
                         if (dataGridView1.FirstDisplayedScrollingRowIndex != -1)
                             positionIndex = dataGridView1.FirstDisplayedScrollingRowIndex;
                         if (dataGridView1.CurrentCell != null)
                             selectedPositionIndex = dataGridView1.CurrentCell.RowIndex;

                         BeginInvoke(new Action(() =>
                         {
                             lock (processList)
                             {
                                 processList = Process.GetProcesses().ToList();
                                 ProcessForDisplayList = ProcessForDisplay.GetProcessForDisplays(processList);
                                 label2.Text = ProcessForDisplayList.Count.ToString();
                             }
                             dataGridView1.CurrentCell = dataGridView1.Rows[selectedPositionIndex].Cells[0];
                             dataGridView1.FirstDisplayedScrollingRowIndex = positionIndex;
                         }));
                         Thread.Sleep(500);
                     }
                 });
            }
            gettingProcesses.IsBackground = true;
            gettingProcesses.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void подробнееToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            isRunning = false;
        }

    }
}