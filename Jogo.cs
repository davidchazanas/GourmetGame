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
    public partial class Jogo : Form
    {
        public List<String> Comidas = new List<String>();
        public Dictionary<String, String> foodsAndProps = new Dictionary<String, String>();
        Node node = new Node().InitialNodes();

        public Jogo()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.Text = "Jogo Gourmet";
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

                DialogResult dialogResult = CenteredMessageBox.Show("O prato que você pensou é " + node.Question + "?", "Confirm", false);
                if (dialogResult == DialogResult.Yes)
                {
                    if (node.Yes == null)
                    {
                        CenteredMessageBox.Show("Acertei de novo!", "Jogo Gourmet", true);
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
                        string answer = Prompt.ShowDialog("Qual prato você pensou?", "Desisto");
                        string question = Prompt.ShowDialog(answer + " é ___, mas " + node.Question + " não.", "Complete");

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
