namespace HardcodedFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            HardcodedButton = new Button();
            HardcodedButton.Parent = this;
            HardcodedButton.Top = 50;
            HardcodedButton.Left = 50;
            HardcodedButton.Text = "Hardcoded button...";
            HardcodedButton.Width = 10;
            HardcodedButton.Click += new System.EventHandler(ExtendButton);
            HardcodedButton.Click += new System.EventHandler(SayHello);
        }

        private void SayHello(object sender, EventArgs args)
        {
            MessageBox.Show("Hello!");
        }

        private void ExtendButton(object sender, EventArgs args)
        {
            HardcodedButton.Width += 20;
        }
    }
}