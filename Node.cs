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
            Node bolo = new Node(null, null, "Bolo de Chocolate");
            Node lasanha= new Node(null, null, "Lasanha");
            Node q_massa = new Node(lasanha, bolo, "massa");

            return q_massa;
        }
    }
}
