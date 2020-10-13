namespace TodoApplication
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.listBackLog = new System.Windows.Forms.ListBox();
            this.lsResolved = new System.Windows.Forms.ListBox();
            this.lsClosed = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "BackLog";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(342, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Resolved";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(624, 52);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(64, 20);
            this.Label3.TabIndex = 5;
            this.Label3.Text = "Closed";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(240, 460);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(161, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(475, 460);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(161, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // listBackLog
            // 
            this.listBackLog.AllowDrop = true;
            this.listBackLog.FormattingEnabled = true;
            this.listBackLog.Location = new System.Drawing.Point(62, 75);
            this.listBackLog.Name = "listBackLog";
            this.listBackLog.Size = new System.Drawing.Size(192, 329);
            this.listBackLog.TabIndex = 9;
            this.listBackLog.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_DragDrop);
            this.listBackLog.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_DragEnter);
            this.listBackLog.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseDown);
            // 
            // lsResolved
            // 
            this.lsResolved.AllowDrop = true;
            this.lsResolved.FormattingEnabled = true;
            this.lsResolved.Location = new System.Drawing.Point(346, 75);
            this.lsResolved.Name = "lsResolved";
            this.lsResolved.Size = new System.Drawing.Size(192, 329);
            this.lsResolved.TabIndex = 10;
            this.lsResolved.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_DragDrop);
            this.lsResolved.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_DragEnter);
            this.lsResolved.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseDown);
            // 
            // lsClosed
            // 
            this.lsClosed.AllowDrop = true;
            this.lsClosed.FormattingEnabled = true;
            this.lsClosed.Location = new System.Drawing.Point(628, 75);
            this.lsClosed.Name = "lsClosed";
            this.lsClosed.Size = new System.Drawing.Size(192, 329);
            this.lsClosed.TabIndex = 11;
            this.lsClosed.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_DragDrop);
            this.lsClosed.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_DragEnter);
            this.lsClosed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseDown);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 514);
            this.Controls.Add(this.lsClosed);
            this.Controls.Add(this.lsResolved);
            this.Controls.Add(this.listBackLog);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plan Tracker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListBox listBackLog;
        private System.Windows.Forms.ListBox lsResolved;
        private System.Windows.Forms.ListBox lsClosed;
    }
}

