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

        public FormMain()
        {
            InitializeComponent();
            _service = new Service();

            DisplayTasks();
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
            DisplayTaskByStatus(Status.BackLog, listBackLog);
            DisplayTaskByStatus(Status.Resolved, lsResolved);
            DisplayTaskByStatus(Status.Closed, lsClosed);
        }
        private void listBox_MouseDown(object sender, MouseEventArgs e)
        {
            var listBox = (ListBox)sender;

            int index = listBox.IndexFromPoint(e.X, e.Y);
            if (index == -1)
                return;

            var task = (TaskTodo)listBox.Items[listBox.SelectedIndex];
            listBox.DoDragDrop(task, DragDropEffects.All);
        }

        private void listBox_DragDrop(object sender, DragEventArgs e)
        {
            var listBox = (ListBox)sender;

            if (e.Data.GetDataPresent(typeof(TaskTodo)))
            {
                var task = (TaskTodo)e.Data.GetData(typeof(TaskTodo));
                _service.SetStatusByLsName(task, listBox.Name);
                
                DisplayTasks();
            }
        }
        private void listBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
    }
}
