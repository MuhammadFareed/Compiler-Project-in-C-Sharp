using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Compiler_Final_Project
{
    public partial class Output_Window : Form
    {
        
        public Output_Window()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox2.Text = Input_Window.passingtext;
        }
    }
}
