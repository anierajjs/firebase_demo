using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace firebaseDemo
{
    public partial class Form1 : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "g0931SEAuWtAsGmIt0QyUq2zVaym2HeoAAzp56iX",
            BasePath = "https://realtime-db-e433b-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };

        IFirebaseClient client;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client !=null)
            {
                MessageBox.Show("Connection is established");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var data = new Data
            {
                StudentNumber = textBox1.Text,
                Name = textBox2.Text,
                Course = textBox3.Text,
                YearSection = textBox4.Text
            };

            SetResponse response = await client.SetTaskAsync("Information/" + textBox1.Text, data);
            Data result = response.ResultAs<Data>();
            MessageBox.Show("Data inserted " + result.StudentNumber);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.GetTaskAsync("Information/" + textBox1.Text);
            Data obj = response.ResultAs<Data>();

            textBox1.Text = obj.StudentNumber;
            textBox2.Text = obj.Name;
            textBox3.Text = obj.Course;
            textBox4.Text = obj.YearSection;

            MessageBox.Show("Data retrieved successfully!");
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var data = new Data
            {
                StudentNumber = textBox1.Text,
                Name = textBox2.Text,
                Course = textBox3.Text,
                YearSection = textBox4.Text
            };
            FirebaseResponse response = await client.UpdateTaskAsync("Information/" + textBox1.Text, data);
            Data result = response.ResultAs<Data>();
            MessageBox.Show("Data updated successfully! " + result.StudentNumber);
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.DeleteTaskAsync("Information/" + textBox1.Text);
            MessageBox.Show("Deleted record of " + textBox1.Text);
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.DeleteTaskAsync("Information");
            MessageBox.Show(" all elements / Information node has been deleted");
        }
    }
}
