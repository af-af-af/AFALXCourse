using CourseFormApp.Exceptions;
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
            var throwExceptionExample = new ThrowExceptionExample();
            try 
            {
                throwExceptionExample.Run();
                MessageBox.Show("You are a rebel!");
            }
            catch(OurOwnException ex)
            {
                LogTextBox.Text += ex.Message + "\r\n";
                LogTextBox.Text += ex.StackTrace + "\r\n";
            }
            catch(Exception ex)
            {
                LogTextBox.Text += ex.Message + "\r\n";
                LogTextBox.Text += ex.StackTrace + "\r\n";
            }
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
            throw new OurOwnException("Do not click this button!!!!");
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
                LogTextBox.Text += "Operation performed successfully!\r\n";
            }
            catch (FormatException ex)
            {
                var exceptionMessage = "Format Exception caught!\r\n";
                LogTextBox.Text += exceptionMessage;
                LogTextBox.Text += ex.Message;
                LogTextBox.Text += ex.StackTrace;
            }
            catch(Exception ex)
            {
                var exceptionMessage = "Exception caught!\r\n";
                //LogTextBox.Text += exceptionMessage;
                LogTextBox.Text += ex.Message;
                LogTextBox.Text += ex.StackTrace;
                ResultTextBox.Text = "Invalid operation!\r\n";
            }
            finally
            {
                LogTextBox.Text += "Operation Performed...\r\n";
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