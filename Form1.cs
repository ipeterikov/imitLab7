using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace hotel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random random = new Random();

        int cataclism, nature, price, people, clients, rating, month;
        bool oops;
        


        private void timer1_Tick(object sender, EventArgs e)
        {
            month++;

            cataclism = (int)numCataclism.Value;
            nature = trackBar1.Value;
            rating = (int)numRating.Value;

            people = random.Next(5000, 10000);
            clients = random.Next(1000, people);
            people = people + random.Next(0, clients/100);
            
            price = random.Next(200,500) + random.Next(0,(people/200))+(rating*10)+nature*10;

            if (oops == true){
                price=price-random.Next(0,cataclism*10);
                people=people-random.Next(0,cataclism*100);
            }
            clients = clients + nature * 100 - (price * 2) - cataclism * 10 + random.Next(0, people * rating / 10);
            lbClient.Text=clients.ToString();
            lbPeople.Text=people.ToString();    
            lbPrice.Text=price.ToString();
            chart1.Series[0].Points.AddXY(month, people);
            chart1.Series[1].Points.AddXY(month, clients);
            chart1.Series[2].Points.AddXY(month, price*10);

            if (checkBox1.Checked) oops = true;
            else oops = false;


        }

        private void btStart_Click(object sender, EventArgs e)
        {
            month = 0;

            cataclism = (int)numCataclism.Value;
            nature = trackBar1.Value;
            price = random.Next(100,300);
            rating = (int)numRating.Value;

            people = random.Next(5000, 10000);
            clients = random.Next(5000, people);

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear(); 
            chart1.Series[2].Points.Clear();
            chart1.Series[0].Points.AddXY(month, people);
            chart1.Series[1].Points.AddXY(month, clients);
            chart1.Series[2].Points.AddXY(month, price);
            if (checkBox1.Checked) oops = true;
            else oops = false;

            if (!timer1.Enabled)
            {
                timer1.Start();
            }
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            timer1.Stop(); 
        }
    }
}
