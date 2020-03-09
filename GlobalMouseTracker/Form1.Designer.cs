namespace GlobalMouseTracker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.startBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.logGroupBox = new System.Windows.Forms.GroupBox();
            this.logTextBox = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.openBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.moveFreqTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.saveFreqBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.saveFreqTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.moveCheckBox = new System.Windows.Forms.CheckBox();
            this.leftCheckBox = new System.Windows.Forms.CheckBox();
            this.rightCheckBox = new System.Windows.Forms.CheckBox();
            this.wheelCheckBox = new System.Windows.Forms.CheckBox();
            this.logGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // startBtn
            // 
            this.startBtn.Enabled = false;
            this.startBtn.Location = new System.Drawing.Point(10, 527);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(209, 41);
            this.startBtn.TabIndex = 0;
            this.startBtn.Text = "Start tracking";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startTracking_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.Enabled = false;
            this.stopBtn.Location = new System.Drawing.Point(291, 527);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(210, 41);
            this.stopBtn.TabIndex = 1;
            this.stopBtn.Text = "Stop tracking";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopTracking_Click);
            // 
            // logGroupBox
            // 
            this.logGroupBox.Controls.Add(this.logTextBox);
            this.logGroupBox.Location = new System.Drawing.Point(12, 201);
            this.logGroupBox.Name = "logGroupBox";
            this.logGroupBox.Size = new System.Drawing.Size(489, 320);
            this.logGroupBox.TabIndex = 3;
            this.logGroupBox.TabStop = false;
            this.logGroupBox.Text = "Log";
            // 
            // logTextBox
            // 
            this.logTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.logTextBox.Location = new System.Drawing.Point(6, 21);
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.Size = new System.Drawing.Size(478, 293);
            this.logTextBox.TabIndex = 4;
            this.logTextBox.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // fileTextBox
            // 
            this.fileTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.fileTextBox.Location = new System.Drawing.Point(12, 13);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.ReadOnly = true;
            this.fileTextBox.Size = new System.Drawing.Size(362, 22);
            this.fileTextBox.TabIndex = 4;
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(382, 13);
            this.openBtn.Margin = new System.Windows.Forms.Padding(0);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(57, 31);
            this.openBtn.TabIndex = 5;
            this.openBtn.Text = "Open";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mouse move capture frequency:";
            // 
            // moveFreqTextBox
            // 
            this.moveFreqTextBox.Location = new System.Drawing.Point(218, 51);
            this.moveFreqTextBox.Name = "moveFreqTextBox";
            this.moveFreqTextBox.Size = new System.Drawing.Size(63, 22);
            this.moveFreqTextBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "ms";
            // 
            // saveFreqBtn
            // 
            this.saveFreqBtn.Location = new System.Drawing.Point(426, 51);
            this.saveFreqBtn.Name = "saveFreqBtn";
            this.saveFreqBtn.Size = new System.Drawing.Size(57, 31);
            this.saveFreqBtn.TabIndex = 9;
            this.saveFreqBtn.Text = "Save";
            this.saveFreqBtn.UseVisualStyleBackColor = true;
            this.saveFreqBtn.Click += new System.EventHandler(this.saveFreqBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Enabled = false;
            this.clearBtn.Location = new System.Drawing.Point(444, 13);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(57, 31);
            this.clearBtn.TabIndex = 10;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "File writing frequency:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.saveFreqTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.saveFreqBtn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.moveFreqTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 88);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Params";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Hz";
            // 
            // saveFreqTextBox
            // 
            this.saveFreqTextBox.Location = new System.Drawing.Point(155, 23);
            this.saveFreqTextBox.Name = "saveFreqTextBox";
            this.saveFreqTextBox.Size = new System.Drawing.Size(63, 22);
            this.saveFreqTextBox.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.wheelCheckBox);
            this.groupBox2.Controls.Add(this.rightCheckBox);
            this.groupBox2.Controls.Add(this.leftCheckBox);
            this.groupBox2.Controls.Add(this.moveCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(489, 53);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tracking options";
            // 
            // moveCheckBox
            // 
            this.moveCheckBox.AutoSize = true;
            this.moveCheckBox.Checked = true;
            this.moveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.moveCheckBox.Location = new System.Drawing.Point(10, 25);
            this.moveCheckBox.Name = "moveCheckBox";
            this.moveCheckBox.Size = new System.Drawing.Size(71, 21);
            this.moveCheckBox.TabIndex = 0;
            this.moveCheckBox.Text = "Moves";
            this.moveCheckBox.UseVisualStyleBackColor = true;
            this.moveCheckBox.CheckedChanged += new System.EventHandler(this.moveCheckBox_CheckedChanged);
            // 
            // leftCheckBox
            // 
            this.leftCheckBox.AutoSize = true;
            this.leftCheckBox.Checked = true;
            this.leftCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.leftCheckBox.Location = new System.Drawing.Point(94, 25);
            this.leftCheckBox.Name = "leftCheckBox";
            this.leftCheckBox.Size = new System.Drawing.Size(92, 21);
            this.leftCheckBox.TabIndex = 1;
            this.leftCheckBox.Text = "Left clicks";
            this.leftCheckBox.UseVisualStyleBackColor = true;
            this.leftCheckBox.CheckedChanged += new System.EventHandler(this.leftCheckBox_CheckedChanged);
            // 
            // rightCheckBox
            // 
            this.rightCheckBox.AutoSize = true;
            this.rightCheckBox.Checked = true;
            this.rightCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rightCheckBox.Location = new System.Drawing.Point(192, 25);
            this.rightCheckBox.Name = "rightCheckBox";
            this.rightCheckBox.Size = new System.Drawing.Size(101, 21);
            this.rightCheckBox.TabIndex = 2;
            this.rightCheckBox.Text = "Right clicks";
            this.rightCheckBox.UseVisualStyleBackColor = true;
            this.rightCheckBox.CheckedChanged += new System.EventHandler(this.rightCheckBox_CheckedChanged);
            // 
            // wheelCheckBox
            // 
            this.wheelCheckBox.AutoSize = true;
            this.wheelCheckBox.Checked = true;
            this.wheelCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wheelCheckBox.Location = new System.Drawing.Point(299, 25);
            this.wheelCheckBox.Name = "wheelCheckBox";
            this.wheelCheckBox.Size = new System.Drawing.Size(70, 21);
            this.wheelCheckBox.TabIndex = 3;
            this.wheelCheckBox.Text = "Wheel";
            this.wheelCheckBox.UseVisualStyleBackColor = true;
            this.wheelCheckBox.CheckedChanged += new System.EventHandler(this.wheelCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 578);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.fileTextBox);
            this.Controls.Add(this.logGroupBox);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.startBtn);
            this.Name = "Form1";
            this.Text = "Egi\'s Mouse Tracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.logGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.GroupBox logGroupBox;
        private System.Windows.Forms.RichTextBox logTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox moveFreqTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveFreqBtn;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox saveFreqTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox moveCheckBox;
        private System.Windows.Forms.CheckBox leftCheckBox;
        private System.Windows.Forms.CheckBox rightCheckBox;
        private System.Windows.Forms.CheckBox wheelCheckBox;
    }
}

