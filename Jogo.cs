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
            this.Text = Resources.Messages.JogoGourmet;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            askQuestion(null, node, "s");
        }

        private void askQuestion(Node previousQuestion, Node node, String mode)
        {
            if (node.Question != null)
            {

                DialogResult dialogResult = CenteredMessageBox.Show(string.Format(Resources.Messages.OPratoQueVocePensouX, node.Question), "Confirm", false);
                if (dialogResult == DialogResult.Yes)
                {
                    if (node.Yes == null)
                    {
                        CenteredMessageBox.Show(Resources.Messages.AcerteiNovamente, Resources.Messages.JogoGourmet, true);
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
                        string answer = Prompt.ShowDialog(Resources.Messages.QualPratoVocePensou, Resources.Messages.Desisto);
                        string question = Prompt.ShowDialog(string.Format(Resources.Messages.XeMasYnao, answer, node.Question), Resources.Messages.Complete);

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

    }
}
