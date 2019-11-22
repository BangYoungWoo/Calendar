using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Calendar : Form
    {
        static Date date = new Date();

        public Calendar()
        {
                InitializeComponent();
                date.SearchToDay(date.year,date.month);
                Date_Text_Write();
        }
        void Date_Text_Write()
        {
            button39.Text = ""+date.year;
            button3.Text = ""+date.month;

            button4.Text = date.RealCalendar[0, 0];
            button5.Text = date.RealCalendar[0, 1];
            button6.Text = date.RealCalendar[0, 2];
            button7.Text = date.RealCalendar[0, 3];
            button8.Text = date.RealCalendar[0, 4];
            button9.Text = date.RealCalendar[0, 5];
            button10.Text = date.RealCalendar[0, 6];
            button11.Text = date.RealCalendar[1, 0];
            button12.Text = date.RealCalendar[1, 1];
            button13.Text = date.RealCalendar[1, 2];
            button14.Text = date.RealCalendar[1, 3];
            button15.Text = date.RealCalendar[1, 4];
            button16.Text = date.RealCalendar[1, 5];
            button17.Text = date.RealCalendar[1, 6];
            button18.Text = date.RealCalendar[2, 0];
            button19.Text = date.RealCalendar[2, 1];
            button20.Text = date.RealCalendar[2, 2];
            button21.Text = date.RealCalendar[2, 3];
            button22.Text = date.RealCalendar[2, 4];
            button23.Text = date.RealCalendar[2, 5];
            button24.Text = date.RealCalendar[2, 6];
            button25.Text = date.RealCalendar[3, 0];
            button26.Text = date.RealCalendar[3, 1];
            button27.Text = date.RealCalendar[3, 2];
            button28.Text = date.RealCalendar[3, 3];
            button29.Text = date.RealCalendar[3, 4];
            button30.Text = date.RealCalendar[3, 5];
            button31.Text = date.RealCalendar[3, 6];
            button32.Text = date.RealCalendar[4, 0];
            button33.Text = date.RealCalendar[4, 1];
            button34.Text = date.RealCalendar[4, 2];
            button35.Text = date.RealCalendar[4, 3];
            button36.Text = date.RealCalendar[4, 4];
            button37.Text = date.RealCalendar[4, 5];
            button38.Text = date.RealCalendar[4, 6];
            button40.Text = date.RealCalendar[5, 0];
            button41.Text = date.RealCalendar[5, 1];
            button42.Text = date.RealCalendar[5, 2];
            button43.Text = date.RealCalendar[5, 3];
            button44.Text = date.RealCalendar[5, 4];
            button45.Text = date.RealCalendar[5, 5];
            button46.Text = date.RealCalendar[5, 6];
            button47.Text = date.RealTenStem;
            button48.Text = date.RealZodiac;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            date.month -= 1;
            date.MonthControl();
            date.SearchToDay(date.year, date.month);
            Date_Text_Write();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            date.month +=1;
            date.MonthControl();
            date.SearchToDay(date.year, date.month);

            Date_Text_Write();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button39_Click(object sender, EventArgs e)
        {

        }

        private void button40_Click(object sender, EventArgs e)
        {

        }

        private void button41_Click(object sender, EventArgs e)
        {

        }

        private void button42_Click(object sender, EventArgs e)
        {

        }

        private void button43_Click(object sender, EventArgs e)
        {

        }

        private void button44_Click(object sender, EventArgs e)
        {

        }

        private void button45_Click(object sender, EventArgs e)
        {

        }

        private void button46_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button47_Click(object sender, EventArgs e)
        {
            if (date.tenStemExchange == true)
                date.tenStemExchange = false;
            else if (date.tenStemExchange == false)
                date.tenStemExchange = true;
            date.SearchToDay(date.year, date.month);
            Date_Text_Write();
        }

        private void button48_Click(object sender, EventArgs e)
        {
            if (date.zodiacExchange == true)
                date.zodiacExchange = false;
            else if (date.zodiacExchange == false)
                date.zodiacExchange = true;
            date.SearchToDay(date.year, date.month);
            Date_Text_Write();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            if (date.year-10 >= 1919)
                date.year -= 10;
            else if(date.year - 10 < 1919)
                date.year =1919;
            date.SearchToDay(date.year, date.month);
            Date_Text_Write();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            if (date.year + 10 <= 2119)
                date.year += 10;
            else if (date.year + 10 > 2119)
                date.year = 2119;
            date.SearchToDay(date.year, date.month);
            Date_Text_Write();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button39_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button52_Click(object sender, EventArgs e)
        {
            if (date.year >= 1920)
                date.year -= 1;
            date.SearchToDay(date.year, date.month);
            Date_Text_Write();
        }

        private void button51_Click(object sender, EventArgs e)
        {
            if(date.year<=2118)
            date.year += 1;
            date.SearchToDay(date.year, date.month);
            Date_Text_Write();
        }
    }
}
