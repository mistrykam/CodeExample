using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Non-async
            //label1.Text = DoWork("Mark");

            label1.Text = "Processing...";

            // ASync
            Task t1 = Task.Factory.StartNew(() => DoWork("Mark", 2000)).ContinueWith((t) => label1.Text = t.Result, TaskScheduler.FromCurrentSynchronizationContext());

            // ASync
            CallDoWork();
        }
        
        private async void CallDoWork()
        {
            string result = await DoWorkAsync("Andrew", 5000);
            label1.Text = result;
        }

        private Task<string> DoWorkAsync(string name, int delay)
        {
            return Task.Factory.StartNew(
                () => {
                        return DoWork(name, delay);
                      });
        }

        private string DoWork(string name, int delay)
        {
            Thread.Sleep(delay);
            return "Hello World " + name + " " + DateTime.Now.ToString();
        }
    }
}
