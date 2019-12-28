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
using System.Speech.Synthesis;


namespace Compiler_Final_Project
{
    public partial class Form1 : Form
    {

        public static SpeechSynthesizer Mark;


        FunctionsForTokenization f = new FunctionsForTokenization();
        public Form1()
        {
            InitializeComponent();
        }

        private void compileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ErrorWindow.Text = "";
            TokenWindow.Text = "";

            string[] CodeForTokenization = null;
            string[] CodeForSyntaxAnalyzer = null;
            string[] SubAnalyzer = null;
            string tokenString = "";
            int no = 1;


            CodeForTokenization = InputWindow.Text.Split(' ');
            string tokens;
            for (int i = 0; i < CodeForTokenization.Length; i++)
            {
                tokens = f.Keywords(CodeForTokenization[i]);
                if (tokens == null)
                {
                    goto a;
                }
                else
                {
                    // TokenWindow.Text= "Token number # " + tokencounter + " :    <" + CodeForTokenization[i] + " , " + tokens ;
                    tokenString += "<" + CodeForTokenization[i] + " , " + tokens + ">\n";
                    goto EndofCircle;
                }

            a:
                tokens = f.Symbols(CodeForTokenization[i]);
                if (tokens == null)
                {
                    goto b;
                }
                else
                {
                    // TokenWindow.Text = "Token number #" + tokencounter + " :    <" + CodeForTokenization[i] + " , " + tokens;
                    tokenString += "<" + CodeForTokenization[i] + " , " + tokens + ">\n"; ;
                    goto EndofCircle;
                }

            b:
                tokens = f.Operators(CodeForTokenization[i]);
                if (tokens == null)
                {
                    goto c;
                }
                else
                {
                    tokenString += "<" + CodeForTokenization[i] + " , " + tokens + ">\n";
                    //TokenWindow.Text = "Token number #" + tokencounter + " :    <" + CodeForTokenization[i] + " , " + tokens;
                    goto EndofCircle;
                }

            c:
                tokens = f.DataType(CodeForTokenization[i]);
                if (tokens == null)
                {
                    goto EndofCircle;
                }
                else
                {
                    tokenString += "<" + CodeForTokenization[i] + " , " + tokens + ">\n";
                    //TokenWindow.Text = "Token number #" + tokencounter + " :    <" + CodeForTokenization[i] + " , " + tokens;
                }

            EndofCircle:
                Console.WriteLine("");
            }

            TokenWindow.Text = tokenString;


            // text to speecch

          //  Mark.Speak(TokenWindow.Text);
            // Syntax Analyzer 
            
             int k;
             CodeForSyntaxAnalyzer = InputWindow.Text.Split(';');

             if (CodeForSyntaxAnalyzer[CodeForSyntaxAnalyzer.Length - 1] == "" || CodeForSyntaxAnalyzer[CodeForSyntaxAnalyzer.Length - 1] == " ")
             {
                 no = 2;
             }

             for (int j = 0; j <= CodeForSyntaxAnalyzer.Length - no; j++)
             {
                 SubAnalyzer = CodeForSyntaxAnalyzer[j].Split(' ');

                 

                 k = 0;

                 if (SubAnalyzer[k] == "int")
                 {
                     k++;
                     if (f.DataType(SubAnalyzer[k]) == "Identifier")
                     {
                         k++;
                         if (SubAnalyzer[k] == "=")
                         {
                             k++;
                             if (f.DataType(SubAnalyzer[k]) == "Integer")
                             {
                                 goto End;
                             }
                             else
                             {
                                 ErrorWindow.Text = "Syntax Error";
                                 break;
                             }
                         }
                     }
                 }
                 else if (SubAnalyzer[k] == "float")
                 {
                     k++;
                     if (f.DataType(SubAnalyzer[k]) == "Identifier")
                     {
                         k++;
                         if (SubAnalyzer[k] == "=")
                         {
                             k++;
                             if (f.DataType(SubAnalyzer[k]) == "Float")
                             {
                                 goto End;
                             }
                             else
                             {
                                 ErrorWindow.Text = "Syntax Error";
                                 break;
                             }
                         }
                     }
                 }
                 else
                 {
                     ErrorWindow.Text = "Syntax Error"; 
                     break;
                 }
             End:
                 ErrorWindow.Text = ""; 
             }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            InputWindow.Clear();
            ErrorWindow.Clear();
            TokenWindow.Clear();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputWindow.Clear();
            ErrorWindow.Clear();
            TokenWindow.Clear();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Title = "Open a file";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                InputWindow.Clear();
                using (StreamReader sr = new StreamReader(openfile.FileName))
                {
                    InputWindow.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Title = "Open a file";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                InputWindow.Clear();
                using (StreamReader sr = new StreamReader(openfile.FileName))
                {
                    InputWindow.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Title = "Save file";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter text = new StreamWriter(savefile.FileName);
                text.Write(InputWindow.Text);
                text.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Title = "Save file";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter text = new StreamWriter(savefile.FileName);
                text.Write(InputWindow.Text);
                text.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputWindow.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputWindow.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputWindow.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputWindow.SelectAll();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            InputWindow.Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            InputWindow.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            InputWindow.Paste();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int tokencounter;
            string[] CodeForTokenization = null;
            string[] CodeForSyntaxAnalyzer = null;
            string[] SubAnalyzer = null;
            string tokenString = "";


            CodeForTokenization = InputWindow.Text.Split(' ');
            string tokens;
            for (int i = 0; i < CodeForTokenization.Length; i++)
            {
                tokencounter = i + 1;
                tokens = f.Keywords(CodeForTokenization[i]);
                if (tokens == null)
                {
                    goto a;
                }
                else
                {
                    // TokenWindow.Text= "Token number # " + tokencounter + " :    <" + CodeForTokenization[i] + " , " + tokens ;
                    tokenString += "<" + CodeForTokenization[i] + " , " + tokens + ">\n";
                    goto EndofCircle;
                }

            a:
                tokens = f.Symbols(CodeForTokenization[i]);
                if (tokens == null)
                {
                    goto b;
                }
                else
                {
                    // TokenWindow.Text = "Token number #" + tokencounter + " :    <" + CodeForTokenization[i] + " , " + tokens;
                    tokenString += "<" + CodeForTokenization[i] + " , " + tokens + ">\n"; ;
                    goto EndofCircle;
                }

            b:
                tokens = f.Operators(CodeForTokenization[i]);
                if (tokens == null)
                {
                    goto c;
                }
                else
                {
                    tokenString += "<" + CodeForTokenization[i] + " , " + tokens + ">\n"; 
                    //TokenWindow.Text = "Token number #" + tokencounter + " :    <" + CodeForTokenization[i] + " , " + tokens;
                    goto EndofCircle;
                }

            c:
                tokens = f.DataType(CodeForTokenization[i]);
                if (tokens == null)
                {
                    goto EndofCircle;
                }
                else
                {
                    tokenString += "<" + CodeForTokenization[i] + " , " + tokens + ">\n";
                    //TokenWindow.Text = "Token number #" + tokencounter + " :    <" + CodeForTokenization[i] + " , " + tokens;
                }

            EndofCircle:
                Console.WriteLine("");
            }

            TokenWindow.Text = tokenString;
         
        }
   
    
    
    }
}
