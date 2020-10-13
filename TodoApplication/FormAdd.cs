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
    public partial class FormAdd : Form
    {
        private FormMain _formMain;
        private Validate _validate;

        public FormAdd(FormMain formMain)
        {
            InitializeComponent();

            _formMain = formMain;
            _validate = new Validate();

            dateCreate.Value = DateTime.Now;
            dateFinish.Value = DateTime.Now;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            TaskTodo task = GetTaskFromUI();
            if (_validate.IsValidTask(task))
            {
                _formMain.AddTask(task);
                Close();
            }
            else
            {
                MessageBox.Show("DATA IS INVALID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private TaskTodo GetTaskFromUI()
        {
            return new TaskTodo()
            {
                Title = txtTile.Text,
                Description = txtDescripton.Text,
                CreateDate = dateCreate.Value,
                FinishDate = dateFinish.Value,
                Status = Status.BackLog,
            };
        }
    }
}
