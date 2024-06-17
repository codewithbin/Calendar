using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{

    public partial class UserControlDays : UserControl
    {
        public static string static_day;

        public UserControlDays()
        {
            InitializeComponent();
        }

        public void days(int numday)
        {
            lbdays.Text = numday + "";
        }

        public void getEvent(string s)
        {
            txtevent.Text = s;
        }

        public void setColor()
        {
            lbdays.ForeColor = Color.Red;
            this.BackColor = Color.LightGoldenrodYellow;
            txtevent.BackColor = Color.LightGoldenrodYellow;
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            static_day = lbdays.Text;
            EventForm eventForm = new EventForm();
            eventForm.Show();
        }
    }
}
