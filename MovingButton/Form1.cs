namespace MovingButton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Random rnd = new Random();
            var randomInt = rnd.NextInt64(1,5);
            var randomDouble = rnd.NextDouble();
        }
    }
}