using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace ClientApp
{
    public partial class Form1 : Form
    {

        private string applicationName;

        int adminID = 1;

        public Form1()
        {
            InitializeComponent();

            this.Text = "Bug Tracker";

            appTab.Enabled = false;

            bugsTab.Enabled = false;

            usersTab.Enabled = false;


        }


        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                //point the value of |DataDirectory| at our database in the datalayer
                string dataDirectory = ConfigurationManager.AppSettings["DataDirectory"];
                //string absoluteDataDirectory = Path.GetFullPath(dataDirectory);
                //AppDomain.CurrentDomain.SetData("DataDirectory", absoluteDataDirectory);

                //set application name
                //applicationName = ConfigurationManager.AppSettings["ApplicationName"].ToString();

                //set connection settings
                DataLayer.DB.ApplicationName = applicationName;
                DataLayer.DB.ConnectionTimeout = 30;

                //load all lists into listbox

                //load any existing application log entries
                //DataTable logTable = DataLayer.ApplicationLog.GetLog(applicationName);
                //dataGridViewApplicationLog.DataSource = logTable;
            }
            catch (SqlException sqlex)
            {
                //connection error...
                DisplayErrorMessage(sqlex.Message);
            }
        }


        /// <summary>
        /// This is a function that collects all applications
        /// </summary>
        private void LoadApplicationsList()
        {
            try
            {
                DataLayer.App apps = new DataLayer.App();

                List<DataLayer.Apps> appsList = apps.GetList();

                List<DataLayer.Apps> appsListForBugs = apps.GetList();

                appsList.Insert(0, new DataLayer.Apps() { AppName = "<Add New>" });

                appsListForBugs.Insert(0, new DataLayer.Apps() { AppName = "<Select A App>" });


                listBoxApps.DataSource = appsList; // apps.GetList();
                listBoxApps.DisplayMember = "AppName";

                appsComboBox.DataSource = appsListForBugs;
                appsComboBox.DisplayMember = "AppName";
            }
            catch (SqlException sqlex)
            {
                //connection error...
                DisplayErrorMessage(sqlex.Message);
            }
        }


        /// <summary>
        /// This is a function that collects all Users
        /// </summary>
        private void LoadUsersList()
        {

            try
            {
                DataLayer.User users = new DataLayer.User();

                List<DataLayer.User.Users> usersList = users.GetList();

                usersList.Insert(0, new DataLayer.User.Users() { UserName = "<Add New>" });


                usersListBox.DataSource = usersList; // apps.GetList();
                usersListBox.DisplayMember = "UserName";
            }
            catch (SqlException sqlex)
            {
                //connection error...
                DisplayErrorMessage(sqlex.Message);
            }

        }


        /// <summary>
        /// This is a function that collects all StatusCodes
        /// </summary>
        private void LoadStatusList()
        {

            try
            {
                DataLayer.StatusCodes statusCodes = new DataLayer.StatusCodes();

                List<DataLayer.StatusCodes.StatusCode> scList = statusCodes.GetList();

                scList.Insert(0, new DataLayer.StatusCodes.StatusCode() { StatusCodeDesc = "<Pick One>" });


                statusComboBox.DataSource = scList; // apps.GetList();
                statusComboBox.DisplayMember = "StatusCodeDesc";
            }
            catch (SqlException sqlex)
            {
                //connection error...
                DisplayErrorMessage(sqlex.Message);
            }

        }


        /// <summary>
        /// This is a function that collects all Bugs
        /// </summary>
        private void LoadBugsList()
        {
            try
            {
                DataLayer.Bugs bugs = new DataLayer.Bugs();

                List<DataLayer.Bugs.Bug> bugsList = bugs.GetList();

                bugsList.Insert(0, new DataLayer.Bugs.Bug() { BugDesc = "<Add New>" });


                bugListBox.DataSource = bugsList; // apps.GetList();
                bugListBox.DisplayMember = "BugDesc";
            }
            catch (SqlException sqlex)
            {
                //connection error...
                DisplayErrorMessage(sqlex.Message);
            }
        }


        /// <summary>
        /// This is gather the error and make an output for the user to see
        /// </summary>
        /// <param name="message">This will be the error message</param>
        private void DisplayErrorMessage(string message)
        {
            MessageBox.Show(this,
                message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }



        /// <summary>
        /// This function will handle what to do when the index is changed on the apps list box
        /// </summary>
        /// <param name="sender">This is the paramater for sender</param>
        /// <param name="e">This is the paramater for EventAtgs</param>
        private void listBoxApps_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataLayer.Apps selectedApp = (DataLayer.Apps)listBoxApps.SelectedValue;

            if (selectedApp.AppID != 0)
            {

                appIdTextBox.Text = selectedApp.AppID.ToString();
                appNameTextBox.Text = selectedApp.AppName;
                appVersionTextBox.Text = selectedApp.AppVersion.ToString();
                appDescTextBox.Text = selectedApp.AppDesc;

            }
            else
            {

                appIdTextBox.Text = null;
                appNameTextBox.Text = null;
                appVersionTextBox.Text = null;
                appDescTextBox.Text = null;

            }

        }


        /// <summary>
        /// This function will handle what to do when the app delete button is clicked
        /// </summary>
        /// <param name="sender">This is the paramater for sender</param>
        /// <param name="e">This is the paramater for EventAtgs</param>
        private void appDeleteButton_Click(object sender, EventArgs e)
        {

            DataLayer.Apps selectedApp = (DataLayer.Apps)listBoxApps.SelectedValue;

            DataLayer.App apps = new DataLayer.App();

            int getAppID = selectedApp.AppID;

            int checkedAppForBug = apps.CheckAppsForBugs(getAppID);

            DialogResult result = MessageBox.Show("Are You Sure You Want To Delete Application?", "Warning",
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {

                if (checkedAppForBug == 0)
                {

                    try
                    {

                        apps.DeleteApplication(getAppID);


                        //reload the log table to display new log data

                        List<DataLayer.Apps> appsList = apps.GetList();

                        appsList.Insert(0, new DataLayer.Apps() { AppName = "<Add New>" });


                        listBoxApps.DataSource = appsList; // apps.GetList();
                        listBoxApps.DisplayMember = "AppName";

                        appsComboBox.DataSource = appsList; // apps.GetList();
                        appsComboBox.DisplayMember = "AppName";


                    }
                    catch (SqlException sqlex)
                    {
                        DisplayErrorMessage(sqlex.Message);
                    }

                }

                else
                {

                    MessageBox.Show("You Can Not Delete Apps With Bugs");

                }
            

        }
            else if (result == DialogResult.No)
            {
                //code for No
            }
            else if (result == DialogResult.Cancel)
            {
                //code for Cancel
            }

        }



        /// <summary>
        /// This is the function that will handle the event when the save button is clicked for save application
        /// </summary>
        /// <param name="sender">This is the paramater for sender</param>
        /// <param name="e">This is the paramater for EventAtgs</param>
        private void appSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // A search must first be performed
                if (appNameTextBox.Text.Length > 0
                    && appVersionTextBox.Text.Length > 0
                    && appDescTextBox.Text.Length > 0
                    && appIdTextBox.Text.Length > 0)
                {
                    DataLayer.App apps = new DataLayer.App();

                    int AppID = int.Parse(appIdTextBox.Text);

                    apps.UpdateApplications(appNameTextBox.Text,
                                            appVersionTextBox.Text,
                                            appDescTextBox.Text,
                                            AppID);

                    //reload the data to refresh the hidden fields
                    //buttonGetEmployee_Click(sender, null);
                    List<DataLayer.Apps> appsList = apps.GetList();

                    appsList.Insert(0, new DataLayer.Apps() { AppName = "<Add New>" });


                    listBoxApps.DataSource = appsList; // apps.GetList();
                    listBoxApps.DisplayMember = "AppName";

                    appsComboBox.DataSource = appsList; // apps.GetList();
                    appsComboBox.DisplayMember = "AppName";
                }

                else if (appNameTextBox.Text.Length > 0
                    && appVersionTextBox.Text.Length > 0
                    && appDescTextBox.Text.Length > 0
                    && appIdTextBox.Text.Length == 0)
                {

                    DataLayer.App apps = new DataLayer.App();

                    apps.AddApplication(appNameTextBox.Text,
                                            appVersionTextBox.Text,
                                            appDescTextBox.Text);

                    List<DataLayer.Apps> appsList = apps.GetList();

                    appsList.Insert(0, new DataLayer.Apps() { AppName = "<Add New>" });


                    listBoxApps.DataSource = appsList; // apps.GetList();
                    listBoxApps.DisplayMember = "AppName";

                    appsComboBox.DataSource = appsList; // apps.GetList();
                    appsComboBox.DisplayMember = "AppName";

                }

                else
                {

                    MessageBox.Show("Please Fill In All Fields");

                }
            }
            catch (SqlException sqlex)
            {
                DisplayErrorMessage(sqlex.Message);
            }
        }



        /// <summary>
        /// This is the function that handles the even when a new user is selected on the user list box
        /// </summary>
        /// <param name="sender">This is the paramater for sender</param>
        /// <param name="e">This is the paramater for EventAtgs</param>
        private void usersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataLayer.User.Users selectedUser = (DataLayer.User.Users)usersListBox.SelectedValue;

            if (selectedUser.UserID != 0)
            {

                userIDTextBox.Text = selectedUser.UserID.ToString();
                userNameTextBox.Text = selectedUser.UserName;
                emailTextBox.Text = selectedUser.UserEmail;
                userTelTextBox.Text = selectedUser.UserTel;

            }
            else
            {

                userIDTextBox.Text = null;
                userNameTextBox.Text = null;
                emailTextBox.Text = null;
                userTelTextBox.Text = null;

            }

        }

        //************************************************************************************
        //This area does nothing but these were all created when i added tabs
        private void usersListBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void currentUsersLabel_Click(object sender, EventArgs e)
        {

        }

        private void userTelTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void userNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void userIDTextBox_TextChanged(object sender, EventArgs e)
        {

        }


        //***********************************************************************



        /// <summary>
        /// This is the function that will handle when the delete button is clicked on the users page
        /// It will make sure that the admin user will not be deleted
        /// </summary>
        /// <param name="sender">This is the paramater for sender</param>
        /// <param name="e">This is the paramater for EventAtgs</param>
        private void usersDelete_Click(object sender, EventArgs e)
        {

            DataLayer.User.Users selectedUser = (DataLayer.User.Users)usersListBox.SelectedValue;

            DataLayer.User users = new DataLayer.User();

            int getUserID = selectedUser.UserID;

            DialogResult result = MessageBox.Show("Are You Sure You Want To Delete?", "Warning",
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {

                if (getUserID != adminID)
                {

                    try
                    {

                        users.DeleteUsers(getUserID);

                        //reload the log table to display new log data

                        List<DataLayer.User.Users> appsList = users.GetList();

                        appsList.Insert(0, new DataLayer.User.Users() { UserName = "<Add New>" });


                        usersListBox.DataSource = appsList; // apps.GetList();
                        usersListBox.DisplayMember = "UserName";


                    }
                    catch (SqlException sqlex)
                    {
                        DisplayErrorMessage(sqlex.Message);
                    }

                }

                else
                {

                    MessageBox.Show("Cannt Delete Admin User");

                }


            }

            else if (result == DialogResult.No)
            {
                MessageBox.Show("Delete Has Been Cancled");
            }
            else if (result == DialogResult.Cancel)
            {
                MessageBox.Show("Delete Has Been Cancled");
            }

        }


        /// <summary>
        /// This is the function that will happen when the save button is clicked on the user tab
        /// It makes sure that all needed fields are filled in
        /// </summary>
        /// <param name="sender">This is the paramater for sender</param>
        /// <param name="e">This is the paramater for EventAtgs</param>
        private void usersSaveButton_Click(object sender, EventArgs e)
        {

            try
            {

                // A search must first be performed
                if (userNameTextBox.Text.Length > 0
                    && emailTextBox.Text.Length > 0
                    && userIDTextBox.Text.Length > 0)
                {
                    DataLayer.User users = new DataLayer.User();

                    int UserID = int.Parse(userIDTextBox.Text);

                    users.UpdateUsers(userNameTextBox.Text,
                                            emailTextBox.Text,
                                            userTelTextBox.Text,
                                            UserID);

                    //reload the data to refresh the hidden fields
                    //buttonGetEmployee_Click(sender, null);
                    List<DataLayer.User.Users> usersList = users.GetList();

                    usersList.Insert(0, new DataLayer.User.Users() { UserName = "<Add New>" });


                    usersListBox.DataSource = usersList; // apps.GetList();
                    usersListBox.DisplayMember = "AppName";
                }

                else if (userNameTextBox.Text.Length > 0
                    && emailTextBox.Text.Length > 0
                    && userIDTextBox.Text.Length == 0)
                {

                    DataLayer.User users = new DataLayer.User();

                    users.AddUser(userNameTextBox.Text,
                                            emailTextBox.Text,
                                            userTelTextBox.Text);

                    List<DataLayer.User.Users> usersList = users.GetList();

                    usersList.Insert(0, new DataLayer.User.Users() { UserName = "<Add New>" });


                    usersListBox.DataSource = usersList; // apps.GetList();
                    usersListBox.DisplayMember = "UserName";

                }

                else
                {

                    MessageBox.Show("Please Input All Fields That Are Needed");

                }
            }
            catch (SqlException sqlex)
            {
                DisplayErrorMessage(sqlex.Message);
            }

        }


        //******************************************************************
        //This area does nothing
        private void userTelLabel_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void userNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void userIDLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //*****************************************************************


        /// <summary>
        /// This function will handle when the user attemps to log into the application
        /// It will check if the username exists and if the user is the admin or not
        /// it will also run the functions that populate all the lists
        /// </summary>
        /// <param name="sender">This is the paramater for sender</param>
        /// <param name="e">This is the paramater for EventAtgs</param>
        private void logInButton_Click(object sender, EventArgs e)
        {

            string checkUserName = userEnterTextBox.Text;

            DataLayer.User users = new DataLayer.User();

            int checkedUser = users.CheckUser(checkUserName);


            if (checkedUser > 0 && checkedUser == adminID)
            {
                userEnterTextBox.Text = "";

                appTab.Enabled = true;

                bugsTab.Enabled = true;

                usersTab.Enabled = true;

                logInTab.Enabled = false;

                LoadUsersList();

                LoadBugsList();

                LoadApplicationsList();

                LoadStatusList();

                this.Text = "Bug Tracker - " + checkUserName;

                MessageBox.Show("You Are Logged In With The Admin Account");

            }
  

            else if (checkedUser > adminID)
            {

                userEnterTextBox.Text = "";

                appTab.Enabled = true;

                bugsTab.Enabled = true;

                logInTab.Enabled = false;

                LoadBugsList();

                LoadApplicationsList();

                LoadStatusList();

                this.Text = "Bug Tracker - " + checkUserName;

                MessageBox.Show("You Are Logged In");


            }

            else
            {

                userEnterTextBox.Text = "";

                MessageBox.Show("User Not Valid, Please Try Again");

            }



        }


        /// <summary>
        /// This is the function that will load all the text boxes when a specific bug is selected
        /// </summary>
        /// <param name="sender">This is the paramater for sender</param>
        /// <param name="e">This is the paramater for EventAtgs</param>
        private void bugListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataLayer.Bugs.Bug selectedBug = (DataLayer.Bugs.Bug)bugListBox.SelectedValue;

            if (selectedBug.BugID != 0)
            {

                bugIDTextBox.Text = selectedBug.BugID.ToString();
                submitDateTextBox.Text = selectedBug.BugDate.ToString();
                bugDescTextBox.Text = selectedBug.BugDesc;
                bugDetailsTextBox.Text = selectedBug.BugDetails;
                bugRepStepsextBox.Text = selectedBug.RepSteps;
                bugDetailsTextBox.Text = selectedBug.BugDetails;
                //bugStatusComboBox.Text = selectedBug.;
                //fixDateTextBox.Text = selectedBug.;

                DataTable logTable = DataLayer.Bugs.GetLog(selectedBug.BugID);
                dataGridViewBugLog.DataSource = logTable;



            }
            else
            {

                bugIDTextBox.Text = null;
                submitDateTextBox.Text = null;
                bugDescTextBox.Text = null;
                bugDetailsTextBox.Text = null;
                bugRepStepsextBox.Text = null;
                bugDetailsTextBox.Text = null;

            }

        }


        /// <summary>
        /// This was a test function to make sure that the application lists will always update on the bug page
        /// Even if a new app is added or an app is deleted
        /// </summary>
        /// <param name="sender">This is the paramater for sender</param>
        /// <param name="e">This is the paramater for EventAtgs</param>
        private void bugsTab_Click(object sender, EventArgs e)
        {
            DataLayer.Apps selectedApp = (DataLayer.Apps)listBoxApps.SelectedValue;

            DataLayer.App apps = new DataLayer.App();

            List<DataLayer.Apps> appsList = apps.GetList();

            appsList.Insert(0, new DataLayer.Apps() { AppName = "<Add New>" });


            appsComboBox.DataSource = appsList; // apps.GetList();
            appsComboBox.DisplayMember = "AppName";
        }

        private void statusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    }
    

