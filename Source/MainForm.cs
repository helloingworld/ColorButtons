namespace ColorButtons
{

    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {

        private readonly Random random;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // Required method for designer support
            this.InitializeComponent();

            // Initialize the random number generator
            this.random = new Random();
        }

        /// <summary>
        /// Event: Performs important program initialization tasks when the main form is loaded.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Empty event data.</param>
        private void FormLoadEvent(object sender, EventArgs e)
        {
            // Add color buttons
            foreach (Color color in ColorUtils.GetWebColors())
            {
                this.addColorButton(color);
            }

            // Update color button count
            this.updateButtonCount("Start clicking");
        }

        private void ButtonClickEvent(object sender, EventArgs e)
        {

            Button senderButton = sender as Button;

            this.BackColor = ((Button)senderButton).BackColor;

            senderButton.Click -= new System.EventHandler(ButtonClickEvent);
            this.Controls.Remove(senderButton);
            senderButton.Dispose();

            this.updateButtonCount(this.BackColor.Name);
        }


        private void addColorButton(Color color)
        {
            Button button = new Button()
            {
                AutoSize = true,
                BackColor = color,
                FlatStyle = FlatStyle.Flat,
                Font = new Font(Font.Name, 11),
                ForeColor = color.GetBrightness() > 0.5f ? Color.Black : Color.White,
                Text = color.Name,
            };
            this.Controls.Add(button);

            button.Left = random.Next(this.ClientSize.Width - button.Width);
            button.Top = random.Next(this.ClientSize.Height - button.Height);
            button.Click += new System.EventHandler(ButtonClickEvent);
        }

        private void updateButtonCount(string prefix)
        {
            this.Text = $"{prefix} - {this.Controls.Count} Color Buttons left";
        }

    }
}
