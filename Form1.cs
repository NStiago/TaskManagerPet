using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using TaskManager.Models;

namespace TaskManager
{
    public partial class TaskManager : Form, INotifyPropertyChanged
    {
        List<Process> processList = new List<Process>();
        BindingList<ProcessForDisplay> _processForDisplayList = new BindingList<ProcessForDisplay>();
        bool isRunning = true;
        Thread? gettingProcesses;
        //������� ��� ��������� ���������� (� ����������� �� ������� �������, ���������� ����������� �����)
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
            //dataGridView1.DataBindings.Add("DataSource", this, nameof(ProcessForDisplayList));
        }

        private void TaskManager_Load(object sender, EventArgs e)
        {
            toolStripButton1.Enabled = false;
            processList = Process.GetProcesses().ToList();
            dataGridView1.DataSource = SourceDataTable.GetSourceTable(processList);




            //gettingProcesses = new Thread(() =>
            //{
            //    //positionIndex � selectedPositionIndex - ��� ����������� ���������� ������ � ������� ������
            //    int positionIndex = 0;
            //    int selectedPositionIndex = 0;
            //    while (isRunning)
            //    {
            //        if (dataGridView1.FirstDisplayedScrollingRowIndex != -1)
            //            positionIndex = dataGridView1.FirstDisplayedScrollingRowIndex;
            //        if (dataGridView1.CurrentCell != null)
            //            selectedPositionIndex = dataGridView1.CurrentCell.RowIndex;

            //        BeginInvoke(new Action(() =>
            //        {
            //            lock (processList)
            //            {
            //                processList = Process.GetProcesses().ToList();
            //                ProcessForDisplayList = ProcessForDisplay.GetProcessForDisplays(processList);
            //                label2.Text = ProcessForDisplayList.Count.ToString();
            //            }
            //            dataGridView1.CurrentCell = dataGridView1.Rows[selectedPositionIndex].Cells[0];
            //            dataGridView1.FirstDisplayedScrollingRowIndex = positionIndex;
            //        }));
            //        //������ �������
            //        Thread.Sleep(500);
            //    }
            //});
            //gettingProcesses.Start();
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            toolStripButton1.Enabled = false;
            toolStripButton2.Enabled = true;
            isRunning = true;
            //if (!gettingProcesses.IsAlive)
            //{
            //    gettingProcesses = new Thread(() =>
            //     {
            //         //positionIndex � selectedPositionIndex - ��� ����������� ���������� ������ � ������� ������
            //         int positionIndex = 0;
            //         int selectedPositionIndex = 0;
            //         while (isRunning)
            //         {
            //             if (dataGridView1.FirstDisplayedScrollingRowIndex != -1)
            //                 positionIndex = dataGridView1.FirstDisplayedScrollingRowIndex;
            //             if (dataGridView1.CurrentCell != null)
            //                 selectedPositionIndex = dataGridView1.CurrentCell.RowIndex;

            //             BeginInvoke(new Action(() =>
            //             {
            //                 lock (processList)
            //                 {
            //                     processList = Process.GetProcesses().ToList();
            //                     ProcessForDisplayList = ProcessForDisplay.GetProcessForDisplays(processList);
            //                     label2.Text = ProcessForDisplayList.Count.ToString();
            //                 }
            //                 dataGridView1.CurrentCell = dataGridView1.Rows[selectedPositionIndex].Cells[0];
            //                 dataGridView1.FirstDisplayedScrollingRowIndex = positionIndex;
            //             }));
            //             //������ �������
            //             Thread.Sleep(500);
            //         }
            //     });
            //}
            //gettingProcesses.IsBackground = true;
            //gettingProcesses.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void InfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GetInformation());
        }

        private void KillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells != null)
                {
                    Process processToKill = processList.Where(x => x.Id.ToString() == dataGridView1.CurrentRow.Cells[0].Value.ToString()).ToList().FirstOrDefault();
                    KillProcess(processToKill);
                }
            }
            catch (Exception) { MessageBox.Show("������������ ���� ��� �������� ��������!"); }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            toolStripButton1.Enabled = true;
            toolStripButton2.Enabled = false;
            isRunning = false;
        }

        //����� ��� ��������� ����������� ���
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dataGridView1.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[hit.RowIndex].Selected = true;
                    contextMenuStrip1.Show(dataGridView1, e.Location);
                    dataGridView1.CurrentCell = dataGridView1.Rows[hit.RowIndex].Cells[0];
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            isRunning = false;
            e.Cancel = false;
        }

        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isRunning = false;
            Application.Exit();
        }

        private string GetInformation()
        {
            StringBuilder sb = new StringBuilder();

            if (dataGridView1.SelectedCells != null)
            {
                string processId;
                string processName;
                string processResponding;
                string processStartTime;
                string processHandle;
                string processPath;

                Process process = processList.Where(x => x.Id.ToString() == dataGridView1.CurrentRow.Cells[0].Value.ToString()).ToList().FirstOrDefault();
                try { processId = process.Id.ToString(); } catch (Exception) { processId = "�������� � �������"; }
                try { processName = process.ProcessName.ToString(); } catch (Exception) { processName = "�������� � �������"; }
                try { processResponding = process.Responding == true ? "���������: � ������\n" : "���������: �� ��������\n"; } catch (Exception) { processResponding = "�������� � �������\n"; }
                try { processStartTime = process.StartTime.ToString(); } catch (Exception) { processStartTime = "�������� � �������"; }
                try { processHandle = process.Handle.ToString(); } catch (Exception) { processHandle = "�������� � �������"; }
                try { processPath = process.MainModule.FileName.ToString(); } catch (Exception) { processPath = "�������� � �������"; }

                sb.Append($"ID ��������: " + processId + "\n");
                sb.Append($"�������� ��������: " + processName + "\n");
                sb.Append(processResponding);
                sb.Append($"����� �������: " + processStartTime + "\n");
                sb.Append($"Handle: " + processHandle + "\n");
                sb.Append($"����: " + processPath + "\n");
            }
            return sb.ToString();
        }

        private void KillProcess(Process process)
        {
            process.Kill();
            process.WaitForExit();
        }

       
        

    }
}