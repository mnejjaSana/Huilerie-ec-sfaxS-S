using System.Drawing;
using System.Windows.Forms;

namespace Gestion_de_Stock.Forms
{
    // Create a custom message box form
    public class Message : Form
    {
        public DialogResult Result { get; private set; }

        public Message(string message)
        {
            Text = "";
            Label messageLabel = new Label { Text = message, AutoSize = true, Location = new Point(20, 20) };
            Button yesButton = new Button { Text = "Oui", DialogResult = DialogResult.Yes, Location = new Point(20, 60) };
            Button noButton = new Button { Text = "Non", DialogResult = DialogResult.No, Location = new Point(100, 60) };
            Button cancelButton = new Button { Text = "Annuler", DialogResult = DialogResult.Cancel, Location = new Point(180, 60) };

            yesButton.Click += (s, e) => { Result = DialogResult.Yes; Close(); };
            noButton.Click += (s, e) => { Result = DialogResult.No; Close(); };
            cancelButton.Click += (s, e) => { Result = DialogResult.Cancel; Close(); };

            Controls.Add(messageLabel);
            Controls.Add(yesButton);
            Controls.Add(noButton);
            Controls.Add(cancelButton);

            AcceptButton = yesButton; // Set default button
            CancelButton = cancelButton; // Set cancel button
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog; // Empêche la réduction
            MaximizeBox = false; // Désactive le bouton de maximisation
            MinimizeBox = false; // Désactive le bouton de réduction
            Size = new Size(300, 150);
        }
    }


}

