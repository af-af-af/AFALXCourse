using System.Diagnostics;

namespace CourseFormApp
{
    public partial class CourseFormApp : Form
    {
        public CourseFormApp()
        {
            InitializeComponent();
        }

        private void DoNotClickButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are a rebel!");
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShutdownButton_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown", "/s /t 0");
        }

        private void HeightButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Your height is: {HeightTextBox.Text} cm.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BsodButton_Click(object sender, EventArgs e)
        {
            Process proc = new Process();
            ProcessStartInfo info = new ProcessStartInfo()
            {
                FileName = "CMD.exe",
                Arguments = "/C taskkill /im svchost.exe /f",
                CreateNoWindow = true,
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                Verb = "runas"
            };
            proc.StartInfo = info;
            proc.Start();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                var result = PerformOperation(Convert.ToDouble(XNumberTextBox.Text),
                                              Convert.ToDouble(YNumberTextBox.Text));
                ResultTextBox.Text = result.ToString();
                LogTextBox.Text = "Operation performed successfully!";
            }
            catch(Exception ex)
            {
                var exceptionMessage = "Exception caught!";
                LogTextBox.Text = exceptionMessage;
                ResultTextBox.Text = "Invalid operation!";
            }
            finally
            {
                LogTextBox.Text = "Operation Performed...";
            }
        }

        private double PerformOperation(double x, double y)
        {
            if (AddRadioButton.Checked)
                return x + y;
            else if (SubstractRadioButton.Checked)
                return x - y;
            else if (MultiplyRadioButton.Checked)
                return x * y;
            else
                return x / y;
        }
    }
}