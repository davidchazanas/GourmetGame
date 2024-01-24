using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GourmetGame.Models
{


    public class Node
    {
	    public Node() { }

        public Node(Node yes, Node no, string question)
        {
		    this.Yes = yes;
		    this.No = no;
		    this.Question = question;
        }

        public Node Yes { get; set; }
        public Node No { get; set; }
        public string Question { get; set; }

    }
}
