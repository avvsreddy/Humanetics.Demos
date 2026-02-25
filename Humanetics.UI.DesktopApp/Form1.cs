using Humanetics.Business.Math; // DRY - Don't Repeat Yourself
namespace Humanetics.UI.DesktopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int fno = int.Parse(textBox1.Text);
            int sno = int.Parse(textBox2.Text);

            int max = MaxFinder.FindMax(fno, sno);

            MessageBox.Show($"The maximum of {fno} and {sno} is {max}");
        }
    }
}
