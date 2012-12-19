using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Image_Processor
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pathTextBox.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures);

        }

      //Adding a shortcut to the button Press
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.D))
            {
                main_button.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

       
        

        private void button1_Click(object sender, EventArgs e)
        {
            string file_path = pathTextBox.Text;
            DirectoryInfo dinfo = new DirectoryInfo(file_path);
            FileInfo[] Files = dinfo.GetFiles("*.JPG");


            foreach (FileInfo file in Files)
            {



            
                    string name_old = file.Name;
                    string file_name = inputText.Text + inputText2.Text + ".JPG";
                    string name_old_two = Path.Combine(file_path, name_old);
                    string pattern = SPImageName.Text;
                    Match match = Regex.Match(file.Name, pattern);
                    string complete_path = Path.Combine(file_path, file_name);
                    if (match.Success)
                    {
                        if (File.Exists(complete_path))
                        {
                            pictureBox3.Visible = true;
                        }
                        else
                        {
                            pictureBox3.Visible = false;


                            imageName.Text = file_name;
                            File.Move(name_old_two, complete_path);
                            pictureBox1.Load(complete_path);
                            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;



                        }
                    }
               }


        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Plate image re-naming tool created by Alos Diallo for the Walhout Lab.  2012.");
        }

        private void tutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tutorial = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            tutorial = tutorial + @"\Tutorial.pdf";
            System.Diagnostics.Process.Start(tutorial);
        }

        private void inputText_TextChanged(object sender, EventArgs e)
        {
            Regex objAlphaPattern = new Regex(@"^[a-zA-Z0-9_@.-]*$");
            bool sts = objAlphaPattern.IsMatch(inputText.Text);

           
            if (sts == true)
            {
                inputText.BackColor = Color.White;
            }
            else
            {
                inputText.BackColor = Color.Red;
                MessageBox.Show("Please do not use special characters in your file names.");
            }
        }

        private void inputText2_TextChanged(object sender, EventArgs e)
        {
            Regex objAlphaPattern = new Regex(@"^[a-zA-Z0-9_@.-]*$");
            bool sts = objAlphaPattern.IsMatch(inputText2.Text);


            if (sts == true)
            {
                inputText2.BackColor = Color.White;
            }
            else
            {
                inputText2.BackColor = Color.Red;
                MessageBox.Show("Please do not use special characters in your file names.");
            }
        }




    }

}
