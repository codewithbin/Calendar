using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Calendar
{
    public partial class Form1 : Form
    {
        public static Form1 Instance { get; private set; }
        public static Dictionary<int, string> userNames;
        public static int selectedAppID;
        public static int selectedUserID;
        int month, year;
        public static int static_month, static_year;

        public Form1()
        {
            InitializeComponent();
            Instance = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userNames = new Dictionary<int, string>();

            /*foreach (DataRow row in CSDL.Instance.DTuser.Rows)
            {
                int userID = Convert.ToInt32(row["ID_user"]);
                int appID = Convert.ToInt32(row["ID_app"]);

                if (!userNames.ContainsKey(userID))
                {
                    string userName = $"user{userNames.Count + 1}";
                    userNames.Add(userID, userName);
                }
            }*/

            for (int i = 1; i <= 10; i++)
            {
                int userID = i;
                string userName = $"user{i}";

                userNames.Add(userID, userName);
            }

            cbUser.DataSource = new BindingSource(userNames, null);
            cbUser.DisplayMember = "Value";
            cbUser.ValueMember = "Key";

            selectedUserID = (int)cbUser.SelectedValue;

            displayDays();
        }


        private string GetEnglishMonthName(int month)
        {
            string[] monthNames = new string[]
            {
                "January", "February", "March", "April", "May", "June",
                "July", "August", "September", "October", "November", "December"
            };

            if (month >= 1 && month <= 12)
            {
                return monthNames[month - 1];
            }
            else
            {
                return "";
            }
        }
        public static void RefreshData(int month, int year)
        {
            if (Instance != null)
            {
                Instance.refreshDays(month, year); 
            }
        }
        public void refreshDays(int month, int year)
        {
            daycontainer.Controls.Clear();
            static_month = month;
            static_year = year;
            //string monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            string monthName = GetEnglishMonthName(month);
            LBDATE.Text = monthName + " " + year;
            DateTime startofthemonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank usblank = new UserControlBlank();
                daycontainer.Controls.Add(usblank);
            }
            //MessageBox.Show(selectedAppID.ToString());

            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                foreach (DataRow drUser in CSDL.Instance.DTuser.Rows)
                {

                    int userID = Convert.ToInt32(drUser["ID_user"]);
                    int appID = Convert.ToInt32(drUser["ID_app"]);

                    if (userID == (int)cbUser.SelectedValue)
                    {
                        foreach (DataRow drEvent in CSDL.Instance.DTevent.Rows)
                        {
                            int eventAppID = Convert.ToInt32(drEvent["ID"]);

                            if (appID == eventAppID && i == Convert.ToInt32(drEvent["Day"]) && month == Convert.ToInt32(drEvent["Month"]) && year == Convert.ToInt32(drEvent["Year"]))
                            {
                                ucdays.getEvent(drEvent["Name"].ToString());
                                ucdays.setColor();
                                break;
                            }
                            //else ucdays.getEvent("");
                        }
                    }
                }
                daycontainer.Controls.Add(ucdays);
            }
        }
        private void displayDays()
        {
            /*DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;
            refreshDays(month, year);*/

            DataTable dtUser = CSDL.Instance.DTuser;
            DataRow[] selectedUser = dtUser.Select($"ID_user = {selectedUserID}");
            if (selectedUser.Length > 0)
            {
                selectedAppID = Convert.ToInt32(selectedUser[0]["ID_app"]);

                DateTime now = DateTime.Now;
                month = now.Month;
                year = now.Year;

                refreshDays(month, year);
            }
            else if (selectedUser.Length == 0)
            {
                selectedAppID = 0;

                DateTime now = DateTime.Now;
                month = now.Month;
                year = now.Year;

                refreshDays(month, year);
            }
        }

        private void cbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUser.SelectedValue != null && int.TryParse(cbUser.SelectedValue.ToString(), out int userId))
            {
                selectedUserID = userId;
                displayDays();
            }

            //displayDays();
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();
            month--;
            if(month == 0)
            {
                month = 12;
                year--;
            }
            refreshDays(month, year);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();
            month++;
            if (month == 13)
            {
                month = 1;
                year++;
            }
            refreshDays(month, year);
        }
    }
}
