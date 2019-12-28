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
using System.CodeDom.Compiler;

namespace Compiler_Final_Project
{
    public class functions
    {
        public void variables(string var, int score)
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("C#");
            if (provider.IsValidIdentifier(var))
            {
                Console.WriteLine("Token number: " + score + " ----- < variable, " + var + " >");
            }
        }

        public void keywords(string key, int score)
        {
            Dictionary<string, string> dictkeywords = new Dictionary<string, string>()
            {
                {"abstract","abstract" },
                {"byte","byte" },
                {"class","class" },
                {"delegate","delegate" },
                {"event","event" },
                {"fixed","fixed" },
                {"if","if" },
                {"internal","internal" },
                {"new","new" },
                {"override","override" },
                {"readonly","readonly" },
                {"short","short" },
                {"struct","struct" },
                {"try","try" },
                {"unsafe","unsafe" },
                {"switch","switch" },
                {"do","do" },
                {"while","while" },
                {"catch","catch" },
                {"continue","continue" },
                {"this","this" },
                {"using","using" },
                {"else","else" },
                {"return","return" },
                {"private","private" },
                {"for","for" },
                {"static","static" },
                {"foreach","foreach" },
                {"protected","protected" },
                {"throw","throw" },
                {"break","break" },
                {"true","true" },
                {"namespace","namespace" },
                {"interface","interface" },
                {"public","public" },
                {"enum","enum" },
                {"false","false" }

            };

            for (int i = 0; i < dictkeywords.Count; i++)
            {
                if (key == dictkeywords.Keys.ElementAt(i))
                {
                    Console.WriteLine("Token number: " + score + " ----- < Keyword, {0} >", dictkeywords.Keys.ElementAt(i));
                    break;
                }
            }
        }

        public void symbols(string dictsym, int score)
        {
            Dictionary<string, string> dictSymbol = new Dictionary<string, string>()
                {
                {"(","opening round bracket" },
                {")","closing round bracket" },
                {"{","opening curly bracket" },
                {"}","closing curly bracket" },
                {"[","opening square bracket" },
                {"]","closing square bracket" },
                {",","comma" },
                {";","semi colon" }

            };

            for (int i = 0; i < dictSymbol.Count; i++)
            {
                if (dictsym == dictSymbol.Keys.ElementAt(i))
                {
                    Console.WriteLine("Token number: " + score + " ----- < {1}, {0} >", dictSymbol.Keys.ElementAt(i), dictSymbol[dictSymbol.Keys.ElementAt(i)]);
                    break;
                }
            }
        }

        public void operators(string dict1, int score)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>()
            {
                {"+","Addition Operator" },
                {"-","Subtraction Operator" },
                {"*", "Multiplication Operator"},
                {"/","Division Operator" },
                {"%","Modulus Operator" },
                {"=","Assignment Operator" },
                {"==","Equal to Operator" },
                {">","Greater than Operator" },
                {"<","Less than Operator" },
                {">=","Greater than or Equal to Operator" },
                {"<=","Less than or Equal to Operator" },
                {"!=","Not Equal to Operator" },
                {"||","OR Operator" },
                {"&&","AND Operator" },
                {"++","Increment Operator" },
                {"--","Decrement Operator" },
                {"!","Not Operator" },
                {"~","Bitwise Complement"},
                {"&","Bitwise AND" },
                {"|","Bitwise OR" },
                {"^","Bitwise Exclusive OR" },
                {"<<","Bitwise Left Shift" },
                {">>","Bitwise Right Shift" },
                {"+=","Addition Assignment" },
                {"-=","Subtraction Assignment" },
                {"*=","Multiplication Assignment" },
                {"/=","Division Assignment" },
                {"%=","Modulo Assignment" },
                {"&=","Bitwise AND Assignment" },
                {"|=","Bitwise OR Assignment" },
                {"^=","Bitwise XOR Assignment" },
                {"<<=","Left Shift Assignment" },
                {">>=","Right Shift Assignment" },
                {"=>","Lambda Operator" },
                {"sizeof()","Returns the size of a data type" },
                {"typeof()","Returns the type of a class" },
                {"?:","Conditional Expression" },
                {"is","Determines whether an object is of a certain type" },
                {"as","Cast without raising an exception if the cast fails." },
            };

            for (int i = 0; i < dict.Count; i++)
            {
                if (dict1 == dict.Keys.ElementAt(i))
                {
                    Console.WriteLine("Token number: " + score + " ----- < {1}, {0} >", dict.Keys.ElementAt(i), dict[dict.Keys.ElementAt(i)]);
                    break;
                }
            }
        }

        public void datatypes(string dict2, int score)
        {

            Dictionary<string, string> dictdata = new Dictionary<string, string>()
            {
                {"string","string" },
                {"int","integer" },
                {"float","float" },
                {"bool","boolean" },
                {"double","double"},
                {"char","character" },
                {"sbyte","sbyte" },
                {"short","short" },
                {"long","long" },
                {"byte","byte" },
                {"ushort","ushort" },
                {"uint","uint" },
                {"ulong","ulong" },
                {"decimal","decimal" },
                {"enum","enumerator" },
                {"struct","structure" },
                {"null","null" }
            
            };

            for (int i = 0; i < dictdata.Count; i++)
            {
                if (dict2.ToLower() == dictdata.Keys.ElementAt(i))
               {
                    Console.WriteLine("Token number: " + score + " ----- < Data type, {0} >", dictdata[dictdata.Keys.ElementAt(i)]);
                    break;
                }
            }
        }

        public void identifiers(string rest, int score)
        {
            byte[] asciiInput = Encoding.ASCII.GetBytes(rest);
            foreach (byte element in asciiInput)
            {
                if (element >= 48 && element <= 57)
                {
                    if (rest.Contains("."))
                    {
                        Console.WriteLine("Token number: " + score + " ----- < number, " + rest + " >");
                        break;
                    }
                    Console.WriteLine("Token number: " + score + " ----- < number, " + rest + " >");
                    break;
                }
            }
        }
    }



    public partial class Input_Window : Form
    {
        public static string passingtext;
        public Input_Window()
        {
            InitializeComponent();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Open a file";
            if(open.ShowDialog()==DialogResult.OK)
            {
                richTextBox1.Clear();
                using (StreamReader sr = new StreamReader(open.FileName))
                {
                    richTextBox1.Text = sr.ReadToEnd();
                    sr.Close();
                }

            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Save As";
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter textoutput = new StreamWriter(save.FileName);
                textoutput.Write(richTextBox1.Text);
                textoutput.Close();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void compileAndRunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
            passingtext = richTextBox1.Text;
            Output_Window ow = new Output_Window();
            ow.Show();

        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Open a file";
            if (open.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Clear();
                using (StreamReader sr = new StreamReader(open.FileName))
                {
                    richTextBox1.Text = sr.ReadToEnd();
                    sr.Close();
                }

            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Save As";
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter textoutput = new StreamWriter(save.FileName);
                textoutput.Write(richTextBox1.Text);
                textoutput.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Output_Window ow = new Output_Window();
            ow.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void compileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
