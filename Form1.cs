using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GourmetGame
{
    public partial class Form1 : Form
    {
        public List<String> Comidas = new List<String>();
        public Dictionary<String, String> foodsAndProps = new Dictionary<String, String>();
        Node node = new Node().InitialNodes();

        public Form1()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            askQuestion(null, node, "s");
        }

        private void askQuestion(Node previousQuestion, Node node, String mode)
        {
            if (node.Question != null)
            {

                DialogResult dialogResult = CenteredMessageBox.Show("O prato que você pensou é " + node.Question + "?", "Confirm");
                if (dialogResult == DialogResult.Yes)
                {
                    if (node.Yes == null)
                    {
                        MessageBox.Show("Acertei");
                    }
                    else
                    {
                        askQuestion(node, node.Yes, "y");
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    if (node.No != null)
                    {
                        askQuestion(node, node.No, "n");
                    }
                    else
                    {
                        string answer = Prompt.ShowDialog("Qual prato você pensou?", "Qual prato você pensou?");
                        string question = Prompt.ShowDialog(answer + " é ___, mas " + node.Question + " não.", "");

                        Node new_answer = new Node(null, null, answer);
                        Node new_question = new Node(null, null, question);

                        new_question.Yes = new_answer;
                        new_question.No = node;
                        
                        if (previousQuestion != null)
                        {
                            if (mode == "y")
                            {
                                previousQuestion.Yes = new_question;
                            }
                            else
                            {
                                previousQuestion.No = new_question;
                            }
                        }
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
