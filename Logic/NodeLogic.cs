using System;
using System.Diagnostics;
using System.Windows.Forms;

using GourmetGame.Models;

namespace GourmetGame
{


    public class NodeLogic
    {
	    public NodeLogic()
	    {		
	
	    }

        public Node InitialNodes()
        {
            Node bolo = new Node(null, null, Resources.Messages.BoloChocolate);
            Node lasanha = new Node(null, null, Resources.Messages.Lasanha);
            Node q_massa = new Node(lasanha, bolo, Resources.Messages.Massa);

            return q_massa;
        }

        public void askQuestion(Node previousQuestion, Node node, String mode)
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
                        GetNewAnswer(previousQuestion, node, mode);
                    }
                }
            }
        }

        private static void GetNewAnswer(Node previousQuestion, Node node, string mode)
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
