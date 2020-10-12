using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodoApplication
{
    public partial class FormMain : Form
    {
        private Service _service;
        //private List<TaskTodo> _listTaskBackLog;
        //private List<TaskTodo> _listTaskResolved;
        //private List<TaskTodo> _listTaskClosed;

        public FormMain()
        {
            InitializeComponent();
            _service = new Service();
            DisplayTasks();
            //_listTaskBackLog = _service.GetTaskByStatus(Status.BackLog);
            //_listTaskResolved = _service.GetTaskByStatus(Status.Resolved);
            //_listTaskClosed = _service.GetTaskByStatus(Status.Closed);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var formAdd = new FormAdd(this);
            formAdd.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        internal void AddTask(TaskTodo task)
        {
            _service.Add(task);
            DisplayTasks();
        }

        private void DisplayTaskByStatus(Status status, ListBox listBox)
        {
            listBox.DisplayMember = "Title";
            listBox.DataSource = _service.GetTaskByStatus(status);
        }
        internal void DisplayTasks()
        {
            DisplayTaskByStatus(Status.BackLog, lsBackLog);
            DisplayTaskByStatus(Status.Resolved, lsResolved);
            DisplayTaskByStatus(Status.Closed, lsClosed);
        }

        private void lsBackLog_DragDrop(object sender, DragEventArgs e)
        {
            var listBox = (ListBox)sender;
            if (e.Data.GetDataPresent(typeof(TaskTodo)))
            {
                var task = (TaskTodo)e.Data.GetData(typeof(TaskTodo));
                MessageBox.Show(task.Title);
                DisplayTasks();
            }
        }

        private void lsBackLog_MouseMove(object sender, MouseEventArgs e)
        {
            var listBox = (ListBox)sender;
        }

        private void lsBackLog_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void lsBackLog_DragLeave(object sender, EventArgs e)
        {
            var listBox = (ListBox)sender;
        }

        private void lsResolved_DragDrop(object sender, DragEventArgs e)
        {
            var listBox = (ListBox)sender;
            if (e.Data.GetDataPresent(typeof(TaskTodo)))
            {
                var task = (TaskTodo)e.Data.GetData(typeof(TaskTodo));
                MessageBox.Show(task.Title);
                DisplayTasks();
            }
        }

        private void lsResolved_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
    }
}
