using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using WindowsApplication;

namespace CodeLibrary
{
    public class Person
    {
        Button myButton;

        public Person(Button button)
        {
            button.Click += Jumping;
            myButton = button;
        }

        public void Jumping(object sender, EventArgs args)
        {
            Console.WriteLine("Jumping");
            myButton.Click -= Jumping;
        }
    }

    public class DisplayWindows
    {
        private static Random rand = new Random();

        public static void Start()
        {
            Form form1 = new Form();
            form1.Text = "This is the title";

            Button button1 = new Button();
            button1.Text = "Button-1";
            button1.Top = 50;
            //button1.Click += (object sender, EventArgs e) => { MessageBox.Show("Hello World!"); };
            button1.Click += ButtonClickHandler;
            button1.MouseMove += Button1_MouseMove;

            Button button2 = new Button();
            button2.Text = "Button-2";
            button2.Top = 75;
            //button2.Click += (object sender, EventArgs e) => { MessageBox.Show("Hello World!"); };
            button2.Click += ButtonClickHandler;

            Person person = new Person(button2);

            Button button3 = new Button();
            button3.Text = "Button-3";
            button3.Top = 100;
            
            form1.Controls.Add(button1);
            form1.Controls.Add(button2);
            form1.Controls.Add(button3);

            form1.Show();
            Application.Run(form1);
        }

        public static void Start2()
        {
            Form1 form1 = new Form1();

            form1.Show();
            Application.Run(form1);
        }

        private static void Button1_MouseMove(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;

            button.Top = rand.Next(0, 200);
            button.Left = rand.Next(0, 200);
        }

        public static void ButtonClickHandler(object sender, EventArgs args)
        {
            Button button = (Button)sender;

            MessageBox.Show(string.Format("The button that was pressed was {0}", button.Text));
        }

    }
}
