using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace GourmetGame
{
    
    public static class CenteredMessageBox
    {
        public static DialogResult Show(string text, string caption, bool onlyOkButton)
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
            Label textLabel = new Label() { Left = 62, Top = 30, Text = text, AutoSize=true, Font = new Font(Label.DefaultFont, FontStyle.Bold) };
            PictureBox image = new PictureBox() 
            {
                Image = global::GourmetGame.Properties.Resources.question_logo,
                Location = new System.Drawing.Point(12, 19),
                Size = new System.Drawing.Size(52, 59)
            };

            if (!onlyOkButton)
            {
                Button yesButton = new Button() { Text = "Yes", Left = 65, Width = 50, Top = 70, DialogResult = DialogResult.Yes };
                yesButton.Click += (sender, e) => { prompt.Close(); };
                Button noButton = new Button() { Text = "No", Left = 165, Width = 50, Top = 70, DialogResult = DialogResult.No };
                noButton.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(yesButton);
                prompt.Controls.Add(noButton);
                prompt.AcceptButton = yesButton;
            } else
            {
                Button okButton = new Button() { Text = "Ok", Left = 165, Width = 50, Top = 70, DialogResult = DialogResult.OK };
                okButton.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(okButton);
                image.Image = global::GourmetGame.Properties.Resources.exclamlogo;
            }
            
            prompt.Controls.Add(image);
            prompt.Controls.Add(textLabel);

            return prompt.ShowDialog() == DialogResult.Yes ? DialogResult.Yes : DialogResult.No;
        }
    }
}
