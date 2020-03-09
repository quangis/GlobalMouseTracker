/* 
 * MIT LICENSE
 * 
 * Copyright 2020 Enkhbold Nyamsuren
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software 
 * and associated documentation files (the "Software"), to deal in the Software without restriction, 
 * including without limitation the rights to use, copy, modify, merge, publish, distribute, 
 * sublicense, and/or sell copies of the Software, and to permit persons to whom the Software 
 * is furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE 
 * AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, 
 * DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GlobalMouseTracker
{
    public partial class Form1 : Form
    {
        private StreamWriter sw = null;

        public Form1() {
            InitializeComponent();

            this.saveFreqTextBox.Text = "" + Program.DEF_SAVE_FREQ;
            this.moveFreqTextBox.Text = "" + Program.DEF_MOVE_FREQ;

            Program.WheelFlag = this.wheelCheckBox.Checked;
            Program.RightFlag = this.rightCheckBox.Checked;
            Program.LeftFlag = this.leftCheckBox.Checked;
            Program.MoveFlag = this.moveCheckBox.Checked;
        }

        private void startTracking_Click(object sender, EventArgs e) {
            if (!(this.moveCheckBox.Checked || this.rightCheckBox.Checked 
                || this.leftCheckBox.Checked || this.wheelCheckBox.Checked)) {

                this.logTextBox.Text += "Select at least one feature to track.\n";

                return;
            }

            if (Program.StartTracing()) {
                this.clearBtn.Enabled = false;
                this.saveFreqBtn.Enabled = false;
                this.saveFreqTextBox.Enabled = false;
                this.moveFreqTextBox.Enabled = false;
                this.startBtn.Enabled = false;

                this.moveCheckBox.Enabled = false;
                this.leftCheckBox.Enabled = false;
                this.rightCheckBox.Enabled = false;
                this.wheelCheckBox.Enabled = false;

                this.stopBtn.Enabled = true;

                this.logTextBox.Text += DateTime.Now.ToString("HH:mm:ss:fff")
                    + " Started tracking.\n";
            }
        }

        private void stopTracking_Click(object sender, EventArgs e) {
            if (Program.EndTracing()) {
                this.clearBtn.Enabled = true;
                this.saveFreqBtn.Enabled = true;
                this.saveFreqTextBox.Enabled = true;
                this.moveFreqTextBox.Enabled = true;
                this.startBtn.Enabled = true;

                this.moveCheckBox.Enabled = true;
                this.leftCheckBox.Enabled = true;
                this.rightCheckBox.Enabled = true;
                this.wheelCheckBox.Enabled = true;

                this.stopBtn.Enabled = false;

                this.logTextBox.Text += DateTime.Now.ToString("HH:mm:ss:fff")
                    + " Ended tracking.\n";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            if (Program.EndTracing()) {
                try {
                    this.sw.Flush();
                    this.sw.Close();
                }
                catch (IOException ex) {
                    // [TODO]
                }
            }
        }

        private void openFile_Click(object sender, EventArgs e) {
            this.openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e) {
            try {
                this.sw = File.CreateText(this.openFileDialog1.FileName);

                this.openBtn.Enabled = false;

                this.clearBtn.Enabled = true;
                this.startBtn.Enabled = true;

                this.fileTextBox.Text = this.openFileDialog1.FileName;

                this.logTextBox.Text += "Opened data file "
                    + this.openFileDialog1.FileName + "\n";
            }
            catch (IOException ex) {
                this.logTextBox.Text += "Failed to open data file "
                    + this.openFileDialog1.FileName + "\n"
                    + ex.Message + "\n";
            }
        }

        private void clearBtn_Click(object sender, EventArgs e) {
            try {
                this.sw.Flush();
                this.sw.Close();

                this.openBtn.Enabled = true;
                this.clearBtn.Enabled = false;
                this.startBtn.Enabled = false;

                this.fileTextBox.Text = "";

                this.logTextBox.Text += "Closed data file "
                    + this.openFileDialog1.FileName + "\n";
            }
            catch (IOException ex) {
                this.logTextBox.Text += "Failed to close data file "
                    + this.openFileDialog1.FileName + "\n"
                    + ex.Message + "\n";
            }
        }

        public void writeToFile(List<string> lines) {
            try {
                foreach (string line in lines) {
                    this.sw.WriteLine(line);
                }
                this.sw.Flush();
            }
            catch (IOException ex) {

            }
        }

        private void saveFreqBtn_Click(object sender, EventArgs e) {
            int saveFreq = 0;
            if (!Int32.TryParse(this.saveFreqTextBox.Text, out saveFreq)) {
                this.saveFreqTextBox.Text = "" + Program.DEF_SAVE_FREQ;
                this.logTextBox.Text += "Integer value is required for writing frequency.\n";
                return;
            }

            if (Program.MIN_SAVE_FREQ > saveFreq) {
                this.saveFreqTextBox.Text = "" + Program.DEF_SAVE_FREQ;
                this.logTextBox.Text += "The minimum value for writing frequency is "
                    + Program.MIN_SAVE_FREQ + "\n";
                return;
            }

            int moveFreq = 0;
            if (!Int32.TryParse(this.moveFreqTextBox.Text, out moveFreq)) {
                this.moveFreqTextBox.Text = "" + Program.DEF_MOVE_FREQ;
                this.logTextBox.Text += "Integer value is required for capture frequency.\n";
                return;
            }

            if (Program.MIN_MOVE_FREQ > moveFreq) {
                this.moveFreqTextBox.Text = "" + Program.DEF_MOVE_FREQ;
                this.logTextBox.Text += "The minimum value for capture frequency is "
                    + Program.MIN_MOVE_FREQ + "\n";
                return;
            }

            Program.setSaveFreq(saveFreq);
            Program.setMoveFreq(moveFreq);
            this.logTextBox.Text += "Changes were saved.\n";
        }

        private void wheelCheckBox_CheckedChanged(object sender, EventArgs e) {
            Program.WheelFlag = this.wheelCheckBox.Checked;
        }

        private void rightCheckBox_CheckedChanged(object sender, EventArgs e) {
            Program.RightFlag = this.rightCheckBox.Checked;
        }

        private void leftCheckBox_CheckedChanged(object sender, EventArgs e) {
            Program.LeftFlag = this.leftCheckBox.Checked;
        }

        private void moveCheckBox_CheckedChanged(object sender, EventArgs e) {
            Program.MoveFlag = this.moveCheckBox.Checked;
        }
    }
}
