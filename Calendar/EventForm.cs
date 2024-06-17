using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class EventForm : Form
    {
        public static string selectedEventID;
        public static int selectedUsernameID;
        public EventForm()
        {
            InitializeComponent();
            initStartTime();
            //initEndTime();
        }

        private void initStartTime()
        {
            cbStart.Items.Clear();
            for(int i = 0; i<=23; i++)
            {
                cbStart.Items.Add(i);
            }
            cbStart.SelectedIndexChanged += cbStart_SelectedIndexChanged;
        }
        private void initEndTime(int start)
        {
            cbEnd.Items.Clear();
            for (int i = start + 1; i <= 24; i++)
            {
                cbEnd.Items.Add(i);
            }
        }
        private void cbStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStart.SelectedItem != null)
            {
                int start;
                if (int.TryParse(cbStart.SelectedItem.ToString(), out start))
                {
                    cbEnd.Enabled = true;
                    initEndTime(start);
                }
            }
        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            int day = Convert.ToInt32(UserControlDays.static_day);
            int month = Convert.ToInt32(Form1.static_month);
            int year = Convert.ToInt32(Form1.static_year);
            lbDate.Text = day + "/" + month + "/" + year;

            dataGridView1.Columns.Clear();
            /*dataGridView1.Columns.Add("Day", "Day");
            dataGridView1.Columns.Add("Month", "Month");
            dataGridView1.Columns.Add("Year", "Year");*/
            dataGridView1.Columns.Add("ID", "ID");
            //dataGridView1.Columns["ID"].Width = 50;
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Loca", "Location");
            dataGridView1.Columns.Add("Start", "Start");
            dataGridView1.Columns.Add("End", "End");

            dataGridView1.Columns["ID"].Visible = false;

            dataGridView2.Columns.Clear();
            dataGridView2.Columns.Add("Name_user", "Name");

            btnNew.Enabled = false;
            btnDel.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;

            bool check = false;

            foreach (DataRow dr2 in CSDL.Instance.DTuser.Rows)
            {
                if (Form1.selectedUserID == Convert.ToInt32(dr2["ID_user"]))
                {
                    foreach (DataRow dr in CSDL.Instance.DTevent.Rows)
                    {
                        if (dr["ID"].ToString() == dr2["ID_app"].ToString() && day == Convert.ToInt32(dr["Day"]) && month == Convert.ToInt32(dr["Month"]) && year == Convert.ToInt32(dr["Year"]))
                        {
                            check = true;
                            dataGridView1.Rows.Add(dr["ID"], dr["Name"], dr["Loca"], dr["Start"], dr["End"]);

                            btnNew.Enabled = true;
                            btnDel.Enabled = true;
                            btnUpdate.Enabled = true;
                            btnSave.Enabled = false;
                            //break;
                        }
                    }
                }
            }

            
            if (check && dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                txtName.Text = selectedRow.Cells["Name"].Value.ToString();
                txtLoca.Text = selectedRow.Cells["Loca"].Value.ToString();
                cbStart.Text = selectedRow.Cells["Start"].Value.ToString();
                cbEnd.Text = selectedRow.Cells["End"].Value.ToString();

                selectedEventID = selectedRow.Cells["ID"].Value.ToString();

                LoadUserData(selectedEventID);
            }
            else
            {
                btnNewUser.Enabled = false;
            }
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }
        private void LoadUserData(string eventId)
        {
            dataGridView2.Rows.Clear();

            // Find users associated with the specified event ID
            foreach (DataRow dr in CSDL.Instance.DTuser.Rows)
            {
                if (dr["ID_app"].ToString() == eventId)
                {
                    int userId = Convert.ToInt32(dr["ID_user"]);
                    if (Form1.userNames.TryGetValue(userId, out string userName))
                    {
                        dataGridView2.Rows.Add(userName);
                    }
                }
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            UpdateControlsFromSelectedRow();

            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                selectedEventID = selectedRow.Cells["ID"].Value.ToString();

                // Load data into dataGridView2 based on selected event ID
                LoadUserData(selectedEventID);
            }
        }

        private void UpdateControlsFromSelectedRow()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                txtName.Text = selectedRow.Cells["Name"].Value.ToString();
                txtLoca.Text = selectedRow.Cells["Loca"].Value.ToString();
                cbStart.Text = selectedRow.Cells["Start"].Value.ToString();
                cbEnd.Text = selectedRow.Cells["End"].Value.ToString();

                selectedEventID = selectedRow.Cells["ID"].Value.ToString();
            }
        }

        private bool IsFormDataValid()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter appointment name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLoca.Text))
            {
                MessageBox.Show("Please enter appointment location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cbStart.SelectedItem == null)
            {
                MessageBox.Show("Please select start time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cbEnd.SelectedItem == null)
            {
                MessageBox.Show("Please select end time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int start = Convert.ToInt32(cbStart.SelectedItem);
            int end = Convert.ToInt32(cbEnd.SelectedItem);
            if (end <= start)
            {
                MessageBox.Show("End time must be greater than start time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private bool IsEventTimeValid(int day, int month, int year, int start, int end)
        {
            foreach (DataRow dr in CSDL.Instance.DTevent.Rows)
            {
                int eventDay = Convert.ToInt32(dr["Day"]);
                int eventMonth = Convert.ToInt32(dr["Month"]);
                int eventYear = Convert.ToInt32(dr["Year"]);
                int eventStart = Convert.ToInt32(dr["Start"]);
                int eventEnd = Convert.ToInt32(dr["End"]);

                if (day == eventDay && month == eventMonth && year == eventYear)
                {
                    if (!(end <= eventStart || start >= eventEnd))
                    {
                        MessageBox.Show("There is already an event scheduled during this time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }
        private void GetSelectedRowID()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                selectedEventID = selectedRow.Cells["ID"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Please select a row.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsFormDataValid())
            {
                return;
            }

            int day = Convert.ToInt32(UserControlDays.static_day);
            int month = Convert.ToInt32(Form1.static_month);
            int year = Convert.ToInt32(Form1.static_year);
            string name = txtName.Text;
            string loca = txtLoca.Text;
            int start = Convert.ToInt32(cbStart.SelectedItem);
            int end = Convert.ToInt32(cbEnd.SelectedItem);

            /*if (!IsEventTimeValid(day, month, year, start, end))
            {
                return;
            }*/

            CSDL.Instance.AddEvent(day, month, year, name, loca, start, end);
            /*MessageBox.Show(Form1.selectedUserID.ToString() + CSDL.Instance.DTevent.Rows.Count.ToString());
            CSDL.Instance.AddUser(Form1.selectedUserID, CSDL.Instance.DTevent.Rows.Count);*/

            MessageBox.Show("Appointment saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            
            int day = Convert.ToInt32(UserControlDays.static_day);
            int month = Convert.ToInt32(Form1.static_month);
            int year = Convert.ToInt32(Form1.static_year);
            GetSelectedRowID();
            int id = Convert.ToInt32(selectedEventID);

            CSDL.Instance.DeleteEvent(day, month, year, id);

            MessageBox.Show("Appointment deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!IsFormDataValid())
            {
                return;
            }

            int day = Convert.ToInt32(UserControlDays.static_day);
            int month = Convert.ToInt32(Form1.static_month);
            int year = Convert.ToInt32(Form1.static_year);
            GetSelectedRowID();
            int id = Convert.ToInt32(selectedEventID);
            string name = txtName.Text;
            string loca = txtLoca.Text;
            int start = Convert.ToInt32(cbStart.SelectedItem);
            int end = Convert.ToInt32(cbEnd.SelectedItem);

            /*if (!IsEventTimeValid(day, month, year, start, end))
            {
                return;
            }*/

            CSDL.Instance.UpdateEvent(id, day, month, year, name, loca, start, end);

            MessageBox.Show("Appointment updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = false;
            btnReset.Enabled = true;
            btnDel.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            txtName.Text = "";
            txtLoca.Text = "";
            cbStart.SelectedIndex = -1;
            cbEnd.SelectedIndex = -1;
            cbEnd.Enabled = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnReset.Enabled = false;
            EventForm_Load(sender, e);
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            cbUsername.Enabled = true;
            btnAddUser.Enabled = true;
            btnNewUser.Enabled = false;

            cbUsername.DataSource = new BindingSource(Form1.userNames, null);
            cbUsername.DisplayMember = "Value";
            cbUsername.ValueMember = "Key";

            selectedUsernameID = (int)cbUsername.SelectedValue;

            cbUsername.SelectedIndexChanged += cbUsername_SelectedIndexChanged;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            cbUsername.Enabled = false;
            btnAddUser.Enabled = false;
            btnNewUser.Enabled = true;

            CSDL.Instance.AddUser(selectedUsernameID, Convert.ToInt32(selectedEventID));

            EventForm_Load(sender, e);
        }

        private void cbUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUsername.SelectedValue != null && int.TryParse(cbUsername.SelectedValue.ToString(), out int userId))
            {
                selectedUsernameID = userId;
            }
            //MessageBox.Show(selectedUsernameID.ToString());
        }
    }
}
