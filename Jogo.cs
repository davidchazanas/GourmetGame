using GourmetGame.Models;
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
        NodeLogic questionLogic = new NodeLogic();
        Node node;

        public Jogo()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.Text = Resources.Messages.JogoGourmet;
            node = questionLogic.InitialNodes();
        }

        private void start_click(object sender, EventArgs e)
        {
            questionLogic.askQuestion(null, node, "s");
        }

    }
}
