using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GourmetGame
{
    
    public static class CenteredMessageBox
    {
        public static DialogResult Show(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 267,
                Height = 150,
                FormBorderStyle = FormBorderStyle.Sizable,
                Text = caption,
                StartPosition = FormStartPosition.CenterParent,
                AutoSize = true
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text, AutoSize=true};
            Button yesButton = new Button() { Text = "Yes", Left = 50, Width = 50, Top = 70, DialogResult = DialogResult.Yes };
            yesButton.Click += (sender, e) => { prompt.Close(); };
            Button noButton = new Button() { Text = "No", Left = 150, Width = 50, Top = 70, DialogResult = DialogResult.No };
            noButton.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(yesButton);
            prompt.Controls.Add(noButton);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = yesButton;

            return prompt.ShowDialog() == DialogResult.Yes ? DialogResult.Yes : DialogResult.No;
        }
    }
}
