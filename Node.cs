using System;
using System.Diagnostics;

namespace GourmetGame
{


    public class Node
    {
	    public Node ()
	    {		

	    }
        public Node(Node yes, Node no, string question)
        {
		    this.Yes = yes; ;
		    this.No = no;
		    this.Question = question;
        }

        public Node Yes { get; set; }
        public Node No { get; set; }
        public string Question { get; set; }

        public Node InitialNodes()
        {
            Node bolo = new Node(null, null, "bolo");
            Node lasanha= new Node(null, null, "lasanha");
            Node q_massa = new Node(lasanha, bolo, "massa");

            return q_massa;
        }

        public void loop ()
        {


            //ter a lista

            //   pergunta(n)
            //   -> yes pergunta(yes)
            //       no chama o pergunta(no)


        }
        public void InsertNewNode(ref Node nodeList, ref Node last_question_parent, ref Node last_question, ref Node new_answer, ref Node new_question)
        {




            //Break the tree;
            new_question.Yes = new_answer;
            new_question.No = last_question;
            if(last_question_parent != null)  last_question_parent.No = new_question;



        }

        public void Print_Nodes(Node n)
        {
            Debug.WriteLine(n.Question);
            if (n.Yes != null) Print_Nodes(n.Yes);
            if (n.No!= null) Print_Nodes(n.No);
        }

        public void test()
        {
            Node inicio = InitialNodes();

            Node sushi = new Node(null, null, "sushi");
            Node q_peixe = new Node(null, null, "peixe");


            Node x = inicio.Yes.Yes;
            Node x_pai = inicio.Yes;

           // InsertNewNode(ref inicio, ref x, ref inicio.Yes.Yes, ref sushi, ref q_peixe);


            Print_Nodes(inicio);

        }
    }
}
