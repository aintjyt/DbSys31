﻿using Dbsys.AppData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dbsys
{
    public partial class Frm_UserEntry : Form
    {
        UserRepository userRepo;
        int? userSelectedId = null;
        public Frm_UserEntry()
        {
            InitializeComponent();
            //
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize the user repository
            userRepo = new UserRepository();
            loadUser();
        }

        private void loadUser()
        {
            dgv_main.DataSource = userRepo.UserAccounts();
        }

        private void btnRegistion_Click(object sender, EventArgs e)
        {
            DBSYSEntities db = new DBSYSEntities();
            db.SP_NewUser1(txtUsername.Text, txtPassword.Text, UserLogged.GetInstance().UserAccount.userId, 1);
            loadUser();
            /*String username = txtUsername.Text;
            String pass = txtPassword.Text;

            String strOutputMsg = "";
            // Validation not allow empty or null value
            if (String.IsNullOrEmpty(username))
            {
                errorProviderCustom.SetError(txtUsername, "Empty Field!");
                return;
            }else 
            // Validation not allow empty or null value
            if (String.IsNullOrEmpty(pass))
            {
                errorProviderCustom.SetError(txtPassword, "Empty Field!");
                return;
            }

            // Create new object of USER_ACCOUNT
            UserAccount newUserAcc = new UserAccount();
            newUserAcc.userName = txtUsername.Text;
            newUserAcc.userPassword = txtPassword.Text;
            newUserAcc.userStatus = "Active";

            ErrorCode retValue = userRepo.NewUser(newUserAcc, ref strOutputMsg);
            if (retValue == ErrorCode.Success)
            {
                //Clear the errors
                errorProviderCustom.Clear();
                MessageBox.Show(strOutputMsg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadUser();

                txtPassword.Clear();
                txtUsername.Clear();
            }
            else
            {
                // error 
                MessageBox.Show(strOutputMsg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }*/
        }

        private void dgv_main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                userSelectedId = (Int32)dgv_main.Rows[e.RowIndex].Cells[0].Value;
                txtUsername.Text = dgv_main.Rows[e.RowIndex].Cells[1].Value as String;
                txtPassword.Text = dgv_main.Rows[e.RowIndex].Cells[2].Value as String;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception : {ex.Message}");
            }
        }

        private void ckShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (ckShowPass.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text;
            String pass = txtPassword.Text;
            String strOutputMsg = "";

            if (userSelectedId == null)
            {
                MessageBox.Show("No User Selected", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ErrorCode retValue = userRepo.RemoveUser(userSelectedId, ref strOutputMsg);
            if (retValue == ErrorCode.Success)
            {
                //Clear the errors
                errorProviderCustom.Clear();
                MessageBox.Show(strOutputMsg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadUser();
                //reset the selected id
                userSelectedId = null;

                txtPassword.Clear();
                txtUsername.Clear();
            }
            else
            {
                // error 
                MessageBox.Show(strOutputMsg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text;
            String pass = txtPassword.Text;

            String strOutputMsg = "";
            // Validation not allow empty or null value
            if (String.IsNullOrEmpty(username))
            {
                errorProviderCustom.SetError(txtUsername, "Empty Field!");
                return;
            }
            else
            // Validation not allow empty or null value
            if (String.IsNullOrEmpty(pass))
            {
                errorProviderCustom.SetError(txtPassword, "Empty Field!");
                return;
            }
            var userAccount = userRepo.GetUserByUsername(username);

            ErrorCode retValue = userRepo.UpdateUser(userSelectedId, userAccount, ref strOutputMsg);
            if (retValue == ErrorCode.Success)
            {
                //Clear the errors
                errorProviderCustom.Clear();
                MessageBox.Show(strOutputMsg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadUser();
                //reset the selected id
                userSelectedId = null;


                txtPassword.Clear();
                txtUsername.Clear();
            }
            else
            {
                // error 
                MessageBox.Show(strOutputMsg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            // Update Code here...
        }
    }
}
