using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GourmetGame
{
    
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.Sizable,
                Text = caption,
                StartPosition = FormStartPosition.CenterParent,
                AutoSize = true
            };


            PictureBox image = new PictureBox()
            {
                Image = global::GourmetGame.Properties.Resources.question_logo,
                Location = new System.Drawing.Point(12, 19),
                Size = new System.Drawing.Size(52, 59)
            };


            Label textLabel = new Label() { Left = 62, Top = 20, Text = text, AutoSize=true, Font = new Font(Label.DefaultFont, FontStyle.Bold) };
            TextBox textBox = new TextBox() { Left = 65, Top = 50, Width = 200 };
            Button confirmation = new Button() { Text = "OK", Left = 65, Width = 50, Top = 85, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = "Cancelar", Left = 165, Width = 50, Top = 85, DialogResult = DialogResult.Cancel };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            cancel.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            prompt.Controls.Add(image);

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
