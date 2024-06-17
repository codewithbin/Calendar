using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    internal class CSDL
    {
        private static int new_id = 0;
        public DataTable DTevent { get; set; }
        public DataTable DTuser { get; set; }
        public static CSDL Instance
        {
            get
            {
                if (_Instance == null) _Instance = new CSDL();
                return _Instance;
            }
            set
            {

            }
        }
        private static CSDL _Instance;

        private CSDL()
        {
            DTevent = new DataTable();
            DTevent.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("ID", typeof(int)),
                new DataColumn("Day", typeof(int)),
                new DataColumn("Month", typeof(int)),
                new DataColumn("Year", typeof(int)),
                new DataColumn("Name", typeof(string)),
                new DataColumn("Loca", typeof(string)),
                new DataColumn("Start", typeof(int)),
                new DataColumn("End", typeof(int))
            });

            DataRow dr1 = DTevent.NewRow();
            dr1["ID"] = ++new_id;
            dr1["Day"] = 1;
            dr1["Month"] = 5;
            dr1["Year"] = 2024;
            dr1["Name"] = "ev1";
            dr1["Loca"] = "school";
            dr1["Start"] = 1;
            dr1["End"] = 5;
            DTevent.Rows.Add(dr1);

            DataRow dr2 = DTevent.NewRow();
            dr2["ID"] = ++new_id;
            dr2["Day"] = 18;
            dr2["Month"] = 5;
            dr2["Year"] = 2024;
            dr2["Name"] = "ev2";
            dr2["Loca"] = "school";
            dr2["Start"] = 2;
            dr2["End"] = 6;
            DTevent.Rows.Add(dr2);

            DataRow dr3 = DTevent.NewRow();
            dr3["ID"] = ++new_id;
            dr3["Day"] = 24;
            dr3["Month"] = 5;
            dr3["Year"] = 2024;
            dr3["Name"] = "ev3";
            dr3["Loca"] = "school";
            dr3["Start"] = 3;
            dr3["End"] = 7;
            DTevent.Rows.Add(dr3);

            DataRow dr4 = DTevent.NewRow();
            dr4["ID"] = ++new_id;
            dr4["Day"] = 1;
            dr4["Month"] = 5;
            dr4["Year"] = 2024;
            dr4["Name"] = "ev4";
            dr4["Loca"] = "school";
            dr4["Start"] = 6;
            dr4["End"] = 8;
            DTevent.Rows.Add(dr4);

            DataRow dr5 = DTevent.NewRow();
            dr5["ID"] = ++new_id;
            dr5["Day"] = 18;
            dr5["Month"] = 5;
            dr5["Year"] = 2024;
            dr5["Name"] = "ev5";
            dr5["Loca"] = "school";
            dr5["Start"] = 7;
            dr5["End"] = 9;
            DTevent.Rows.Add(dr5);

            //AddEvent(30, 5, 2024, "aaa", "bbb", 5, 11);

            DTuser = new DataTable();
            DTuser.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("ID_user", typeof(int)),
                new DataColumn("Name_user", typeof (string)),
                new DataColumn("ID_app", typeof(int))
            });

            DataRow dr6 = DTuser.NewRow();
            dr6["ID_user"] = 1;
            dr6["ID_app"] = 1;
            DTuser.Rows.Add(dr6);

            DataRow dr7 = DTuser.NewRow();
            dr7["ID_user"] = 2;
            dr7["ID_app"] = 4;
            DTuser.Rows.Add(dr7);

            DataRow dr8 = DTuser.NewRow();
            dr8["ID_user"] = 3;
            dr8["ID_app"] = 1;
            DTuser.Rows.Add(dr8);

            DataRow dr9 = DTuser.NewRow();
            dr9["ID_user"] = 1;
            dr9["ID_app"] = 2;
            DTuser.Rows.Add(dr9);

            DataRow dr10 = DTuser.NewRow();
            dr10["ID_user"] = 3;
            dr10["ID_app"] = 5;
            DTuser.Rows.Add(dr10);
        }

        public void AddUser(int userID, int appID)
        {
            DataRow dr = DTuser.NewRow();
            dr["ID_user"] = userID;
            dr["ID_app"] = appID;
            DTuser.Rows.Add(dr);
        }
        public void AddEvent(int day, int month, int year, string name, string loca, int start, int end)
        {
            DataRow dr = DTevent.NewRow();
            dr["ID"] = ++new_id;
            dr["Day"] = day;
            dr["Month"] = month;
            dr["Year"] = year;
            dr["Name"] = name;
            dr["Loca"] = loca;
            dr["Start"] = start;
            dr["End"] = end;
            DTevent.Rows.Add(dr);

            int appID = Convert.ToInt32(dr["ID"]);
            int selectedUserID = Form1.selectedUserID;
            AddUser(selectedUserID, appID);

            //MessageBox.Show(dr["Name"] + " " + dr["Loca"]);

            Form1 form1Instance = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (form1Instance != null)
            {
                form1Instance.refreshDays(month, year);
            }
        }
        public void UpdateEvent(int id, int day, int month, int year, string name, string loca, int start, int end)
        {
            int index = -1;
            int i = 0;
            foreach (DataRow dr in DTevent.Rows)
            {
                if (day == Convert.ToInt32(dr["Day"]) && month == Convert.ToInt32(dr["Month"]) && year == Convert.ToInt32(dr["Year"]) && id == Convert.ToInt32(dr["ID"]))
                {
                    index = i;
                    break;
                }
                i++;
            }
            if (index >= 0 && index < DTevent.Rows.Count)
            {
                DataRow dr = DTevent.Rows[index];

                dr["ID"] = id;
                dr["Day"] = day;
                dr["Month"] = month;
                dr["Year"] = year;
                dr["Name"] = name;
                dr["Loca"] = loca;
                dr["Start"] = start;
                dr["End"] = end;

                Form1 form1Instance = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                if (form1Instance != null)
                {
                    form1Instance.refreshDays(month, year);
                }
            }
        }
        public void DeleteEvent(int day, int month, int year, int id)
        {
            int index = -1;
            int i = 0;
            foreach (DataRow dr in DTevent.Rows)
            {
                if(day == Convert.ToInt32(dr["Day"]) && month == Convert.ToInt32(dr["Month"]) && year == Convert.ToInt32(dr["Year"]) && id == Convert.ToInt32(dr["ID"]))
                {
                    index = i;
                    break;
                }
                i++;
            }
            if (index >= 0 && index < DTevent.Rows.Count)
            {
                DTevent.Rows.RemoveAt(index);

                Form1 form1Instance = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                if (form1Instance != null)
                {
                    form1Instance.refreshDays(month, year);
                }
            }
        }

    }
}
