namespace ClientApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.logInTab = new System.Windows.Forms.TabPage();
            this.userEnterTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.logInButton = new System.Windows.Forms.Button();
            this.appTab = new System.Windows.Forms.TabPage();
            this.listAppsLabel = new System.Windows.Forms.Label();
            this.appDescLabel = new System.Windows.Forms.Label();
            this.appVersionLabel = new System.Windows.Forms.Label();
            this.appNameLabel = new System.Windows.Forms.Label();
            this.appIdLabel = new System.Windows.Forms.Label();
            this.appDescTextBox = new System.Windows.Forms.TextBox();
            this.appVersionTextBox = new System.Windows.Forms.TextBox();
            this.appNameTextBox = new System.Windows.Forms.TextBox();
            this.appIdTextBox = new System.Windows.Forms.TextBox();
            this.appSaveButton = new System.Windows.Forms.Button();
            this.appDeleteButton = new System.Windows.Forms.Button();
            this.listBoxApps = new System.Windows.Forms.ListBox();
            this.bugsTab = new System.Windows.Forms.TabPage();
            this.bugsSaveButton = new System.Windows.Forms.Button();
            this.bugsDeleteButton = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.fixDateTextBox = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.submitDateTextBox = new System.Windows.Forms.TextBox();
            this.bugDescTextBox = new System.Windows.Forms.TextBox();
            this.bugDetailsTextBox = new System.Windows.Forms.TextBox();
            this.bugRepStepsextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.applicationLabelBug = new System.Windows.Forms.Label();
            this.bugStatusComboBox = new System.Windows.Forms.ComboBox();
            this.dataGridViewBugLog = new System.Windows.Forms.DataGridView();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.appsComboBox = new System.Windows.Forms.ComboBox();
            this.bugIDTextBox = new System.Windows.Forms.TextBox();
            this.bugListBox = new System.Windows.Forms.ListBox();
            this.usersTab = new System.Windows.Forms.TabPage();
            this.usersListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.currentUsersLabel = new System.Windows.Forms.Label();
            this.userTelTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.userIDTextBox = new System.Windows.Forms.TextBox();
            this.usersDelete = new System.Windows.Forms.Button();
            this.usersSaveButton = new System.Windows.Forms.Button();
            this.userTelLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.userIDLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.logInTab.SuspendLayout();
            this.appTab.SuspendLayout();
            this.bugsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBugLog)).BeginInit();
            this.usersTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.logInTab);
            this.tabControl1.Controls.Add(this.appTab);
            this.tabControl1.Controls.Add(this.bugsTab);
            this.tabControl1.Controls.Add(this.usersTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1445, 818);
            this.tabControl1.TabIndex = 0;
            // 
            // logInTab
            // 
            this.logInTab.Controls.Add(this.userEnterTextBox);
            this.logInTab.Controls.Add(this.label2);
            this.logInTab.Controls.Add(this.logInButton);
            this.logInTab.Location = new System.Drawing.Point(10, 48);
            this.logInTab.Name = "logInTab";
            this.logInTab.Padding = new System.Windows.Forms.Padding(3);
            this.logInTab.Size = new System.Drawing.Size(1425, 760);
            this.logInTab.TabIndex = 0;
            this.logInTab.Text = "Log In";
            this.logInTab.UseVisualStyleBackColor = true;
            // 
            // userEnterTextBox
            // 
            this.userEnterTextBox.Location = new System.Drawing.Point(477, 327);
            this.userEnterTextBox.Name = "userEnterTextBox";
            this.userEnterTextBox.Size = new System.Drawing.Size(498, 38);
            this.userEnterTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(572, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(326, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Please Enter User Name";
            // 
            // logInButton
            // 
            this.logInButton.Location = new System.Drawing.Point(666, 428);
            this.logInButton.Name = "logInButton";
            this.logInButton.Size = new System.Drawing.Size(137, 58);
            this.logInButton.TabIndex = 0;
            this.logInButton.Text = "Log In";
            this.logInButton.UseVisualStyleBackColor = true;
            this.logInButton.Click += new System.EventHandler(this.logInButton_Click);
            // 
            // appTab
            // 
            this.appTab.Controls.Add(this.listAppsLabel);
            this.appTab.Controls.Add(this.appDescLabel);
            this.appTab.Controls.Add(this.appVersionLabel);
            this.appTab.Controls.Add(this.appNameLabel);
            this.appTab.Controls.Add(this.appIdLabel);
            this.appTab.Controls.Add(this.appDescTextBox);
            this.appTab.Controls.Add(this.appVersionTextBox);
            this.appTab.Controls.Add(this.appNameTextBox);
            this.appTab.Controls.Add(this.appIdTextBox);
            this.appTab.Controls.Add(this.appSaveButton);
            this.appTab.Controls.Add(this.appDeleteButton);
            this.appTab.Controls.Add(this.listBoxApps);
            this.appTab.Location = new System.Drawing.Point(10, 48);
            this.appTab.Name = "appTab";
            this.appTab.Padding = new System.Windows.Forms.Padding(3);
            this.appTab.Size = new System.Drawing.Size(1425, 760);
            this.appTab.TabIndex = 1;
            this.appTab.Text = "Applications";
            this.appTab.UseVisualStyleBackColor = true;
            // 
            // listAppsLabel
            // 
            this.listAppsLabel.AutoSize = true;
            this.listAppsLabel.Location = new System.Drawing.Point(1112, -4);
            this.listAppsLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.listAppsLabel.Name = "listAppsLabel";
            this.listAppsLabel.Size = new System.Drawing.Size(260, 32);
            this.listAppsLabel.TabIndex = 35;
            this.listAppsLabel.Text = "List Of Applications";
            // 
            // appDescLabel
            // 
            this.appDescLabel.AutoSize = true;
            this.appDescLabel.Location = new System.Drawing.Point(69, 404);
            this.appDescLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.appDescLabel.Name = "appDescLabel";
            this.appDescLabel.Size = new System.Drawing.Size(137, 32);
            this.appDescLabel.TabIndex = 34;
            this.appDescLabel.Text = "App Desc";
            // 
            // appVersionLabel
            // 
            this.appVersionLabel.AutoSize = true;
            this.appVersionLabel.Location = new System.Drawing.Point(61, 292);
            this.appVersionLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.appVersionLabel.Name = "appVersionLabel";
            this.appVersionLabel.Size = new System.Drawing.Size(170, 32);
            this.appVersionLabel.TabIndex = 33;
            this.appVersionLabel.Text = "App Version";
            // 
            // appNameLabel
            // 
            this.appNameLabel.AutoSize = true;
            this.appNameLabel.Location = new System.Drawing.Point(53, 173);
            this.appNameLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.appNameLabel.Name = "appNameLabel";
            this.appNameLabel.Size = new System.Drawing.Size(148, 32);
            this.appNameLabel.TabIndex = 32;
            this.appNameLabel.Text = "App Name";
            // 
            // appIdLabel
            // 
            this.appIdLabel.AutoSize = true;
            this.appIdLabel.Location = new System.Drawing.Point(53, 70);
            this.appIdLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.appIdLabel.Name = "appIdLabel";
            this.appIdLabel.Size = new System.Drawing.Size(100, 32);
            this.appIdLabel.TabIndex = 31;
            this.appIdLabel.Text = "App ID";
            // 
            // appDescTextBox
            // 
            this.appDescTextBox.Location = new System.Drawing.Point(229, 397);
            this.appDescTextBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.appDescTextBox.Multiline = true;
            this.appDescTextBox.Name = "appDescTextBox";
            this.appDescTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.appDescTextBox.Size = new System.Drawing.Size(463, 293);
            this.appDescTextBox.TabIndex = 30;
            // 
            // appVersionTextBox
            // 
            this.appVersionTextBox.Location = new System.Drawing.Point(248, 292);
            this.appVersionTextBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.appVersionTextBox.Name = "appVersionTextBox";
            this.appVersionTextBox.Size = new System.Drawing.Size(260, 38);
            this.appVersionTextBox.TabIndex = 29;
            // 
            // appNameTextBox
            // 
            this.appNameTextBox.Location = new System.Drawing.Point(229, 166);
            this.appNameTextBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.appNameTextBox.Name = "appNameTextBox";
            this.appNameTextBox.Size = new System.Drawing.Size(260, 38);
            this.appNameTextBox.TabIndex = 28;
            // 
            // appIdTextBox
            // 
            this.appIdTextBox.Enabled = false;
            this.appIdTextBox.Location = new System.Drawing.Point(229, 54);
            this.appIdTextBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.appIdTextBox.Name = "appIdTextBox";
            this.appIdTextBox.Size = new System.Drawing.Size(92, 38);
            this.appIdTextBox.TabIndex = 27;
            // 
            // appSaveButton
            // 
            this.appSaveButton.Location = new System.Drawing.Point(499, 709);
            this.appSaveButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.appSaveButton.Name = "appSaveButton";
            this.appSaveButton.Size = new System.Drawing.Size(200, 55);
            this.appSaveButton.TabIndex = 26;
            this.appSaveButton.Text = "Save";
            this.appSaveButton.UseVisualStyleBackColor = true;
            this.appSaveButton.Click += new System.EventHandler(this.appSaveButton_Click);
            // 
            // appDeleteButton
            // 
            this.appDeleteButton.Location = new System.Drawing.Point(1165, 709);
            this.appDeleteButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.appDeleteButton.Name = "appDeleteButton";
            this.appDeleteButton.Size = new System.Drawing.Size(200, 55);
            this.appDeleteButton.TabIndex = 25;
            this.appDeleteButton.Text = "Delete";
            this.appDeleteButton.UseVisualStyleBackColor = true;
            this.appDeleteButton.Click += new System.EventHandler(this.appDeleteButton_Click);
            // 
            // listBoxApps
            // 
            this.listBoxApps.FormattingEnabled = true;
            this.listBoxApps.ItemHeight = 31;
            this.listBoxApps.Location = new System.Drawing.Point(797, 56);
            this.listBoxApps.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxApps.Name = "listBoxApps";
            this.listBoxApps.Size = new System.Drawing.Size(567, 593);
            this.listBoxApps.TabIndex = 24;
            this.listBoxApps.SelectedIndexChanged += new System.EventHandler(this.listBoxApps_SelectedIndexChanged);
            // 
            // bugsTab
            // 
            this.bugsTab.Controls.Add(this.bugsSaveButton);
            this.bugsTab.Controls.Add(this.bugsDeleteButton);
            this.bugsTab.Controls.Add(this.label13);
            this.bugsTab.Controls.Add(this.label12);
            this.bugsTab.Controls.Add(this.label11);
            this.bugsTab.Controls.Add(this.label10);
            this.bugsTab.Controls.Add(this.label9);
            this.bugsTab.Controls.Add(this.label8);
            this.bugsTab.Controls.Add(this.label7);
            this.bugsTab.Controls.Add(this.label6);
            this.bugsTab.Controls.Add(this.fixDateTextBox);
            this.bugsTab.Controls.Add(this.textBox6);
            this.bugsTab.Controls.Add(this.submitDateTextBox);
            this.bugsTab.Controls.Add(this.bugDescTextBox);
            this.bugsTab.Controls.Add(this.bugDetailsTextBox);
            this.bugsTab.Controls.Add(this.bugRepStepsextBox);
            this.bugsTab.Controls.Add(this.label5);
            this.bugsTab.Controls.Add(this.label4);
            this.bugsTab.Controls.Add(this.applicationLabelBug);
            this.bugsTab.Controls.Add(this.bugStatusComboBox);
            this.bugsTab.Controls.Add(this.dataGridViewBugLog);
            this.bugsTab.Controls.Add(this.statusComboBox);
            this.bugsTab.Controls.Add(this.appsComboBox);
            this.bugsTab.Controls.Add(this.bugIDTextBox);
            this.bugsTab.Controls.Add(this.bugListBox);
            this.bugsTab.Location = new System.Drawing.Point(10, 48);
            this.bugsTab.Name = "bugsTab";
            this.bugsTab.Padding = new System.Windows.Forms.Padding(3);
            this.bugsTab.Size = new System.Drawing.Size(1425, 760);
            this.bugsTab.TabIndex = 2;
            this.bugsTab.Text = "Bugs";
            this.bugsTab.UseVisualStyleBackColor = true;
            this.bugsTab.Click += new System.EventHandler(this.bugsTab_Click);
            // 
            // bugsSaveButton
            // 
            this.bugsSaveButton.Location = new System.Drawing.Point(1242, 695);
            this.bugsSaveButton.Name = "bugsSaveButton";
            this.bugsSaveButton.Size = new System.Drawing.Size(144, 59);
            this.bugsSaveButton.TabIndex = 33;
            this.bugsSaveButton.Text = "Save";
            this.bugsSaveButton.UseVisualStyleBackColor = true;
            // 
            // bugsDeleteButton
            // 
            this.bugsDeleteButton.Location = new System.Drawing.Point(29, 674);
            this.bugsDeleteButton.Name = "bugsDeleteButton";
            this.bugsDeleteButton.Size = new System.Drawing.Size(144, 59);
            this.bugsDeleteButton.TabIndex = 32;
            this.bugsDeleteButton.Text = "Delete Bug";
            this.bugsDeleteButton.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(948, 419);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(258, 32);
            this.label13.TabIndex = 31;
            this.label13.Text = "Update Comments:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(455, 701);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 32);
            this.label12.TabIndex = 30;
            this.label12.Text = "Fix Date:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(449, 650);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 32);
            this.label11.TabIndex = 29;
            this.label11.Text = "Status:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(438, 450);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(155, 32);
            this.label10.TabIndex = 28;
            this.label10.Text = "Rep Steps:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(437, 277);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 32);
            this.label9.TabIndex = 27;
            this.label9.Text = "Details:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(438, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(166, 32);
            this.label8.TabIndex = 26;
            this.label8.Text = "Description:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(438, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 32);
            this.label7.TabIndex = 25;
            this.label7.Text = "Submit Date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(455, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 32);
            this.label6.TabIndex = 24;
            this.label6.Text = "Bug ID:";
            // 
            // fixDateTextBox
            // 
            this.fixDateTextBox.Location = new System.Drawing.Point(623, 695);
            this.fixDateTextBox.Name = "fixDateTextBox";
            this.fixDateTextBox.Size = new System.Drawing.Size(210, 38);
            this.fixDateTextBox.TabIndex = 23;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(939, 464);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(480, 218);
            this.textBox6.TabIndex = 22;
            // 
            // submitDateTextBox
            // 
            this.submitDateTextBox.Enabled = false;
            this.submitDateTextBox.Location = new System.Drawing.Point(623, 105);
            this.submitDateTextBox.Name = "submitDateTextBox";
            this.submitDateTextBox.Size = new System.Drawing.Size(210, 38);
            this.submitDateTextBox.TabIndex = 21;
            // 
            // bugDescTextBox
            // 
            this.bugDescTextBox.Location = new System.Drawing.Point(437, 187);
            this.bugDescTextBox.Multiline = true;
            this.bugDescTextBox.Name = "bugDescTextBox";
            this.bugDescTextBox.Size = new System.Drawing.Size(396, 77);
            this.bugDescTextBox.TabIndex = 20;
            // 
            // bugDetailsTextBox
            // 
            this.bugDetailsTextBox.Location = new System.Drawing.Point(437, 321);
            this.bugDetailsTextBox.Multiline = true;
            this.bugDetailsTextBox.Name = "bugDetailsTextBox";
            this.bugDetailsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.bugDetailsTextBox.Size = new System.Drawing.Size(396, 116);
            this.bugDetailsTextBox.TabIndex = 19;
            // 
            // bugRepStepsextBox
            // 
            this.bugRepStepsextBox.Location = new System.Drawing.Point(437, 497);
            this.bugRepStepsextBox.Multiline = true;
            this.bugRepStepsextBox.Name = "bugRepStepsextBox";
            this.bugRepStepsextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.bugRepStepsextBox.Size = new System.Drawing.Size(396, 147);
            this.bugRepStepsextBox.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 32);
            this.label5.TabIndex = 17;
            this.label5.Text = "Bug List:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 32);
            this.label4.TabIndex = 16;
            this.label4.Text = "Status Filter:";
            // 
            // applicationLabelBug
            // 
            this.applicationLabelBug.AutoSize = true;
            this.applicationLabelBug.Location = new System.Drawing.Point(19, 39);
            this.applicationLabelBug.Name = "applicationLabelBug";
            this.applicationLabelBug.Size = new System.Drawing.Size(179, 32);
            this.applicationLabelBug.TabIndex = 15;
            this.applicationLabelBug.Text = "Applications:";
            // 
            // bugStatusComboBox
            // 
            this.bugStatusComboBox.FormattingEnabled = true;
            this.bugStatusComboBox.Location = new System.Drawing.Point(623, 650);
            this.bugStatusComboBox.Name = "bugStatusComboBox";
            this.bugStatusComboBox.Size = new System.Drawing.Size(210, 39);
            this.bugStatusComboBox.TabIndex = 14;
            // 
            // dataGridViewBugLog
            // 
            this.dataGridViewBugLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBugLog.Location = new System.Drawing.Point(877, 39);
            this.dataGridViewBugLog.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dataGridViewBugLog.Name = "dataGridViewBugLog";
            this.dataGridViewBugLog.Size = new System.Drawing.Size(548, 348);
            this.dataGridViewBugLog.TabIndex = 13;
            // 
            // statusComboBox
            // 
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Location = new System.Drawing.Point(212, 102);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(219, 39);
            this.statusComboBox.TabIndex = 3;
            this.statusComboBox.SelectedIndexChanged += new System.EventHandler(this.statusComboBox_SelectedIndexChanged);
            // 
            // appsComboBox
            // 
            this.appsComboBox.FormattingEnabled = true;
            this.appsComboBox.Location = new System.Drawing.Point(212, 32);
            this.appsComboBox.Name = "appsComboBox";
            this.appsComboBox.Size = new System.Drawing.Size(219, 39);
            this.appsComboBox.TabIndex = 2;
            // 
            // bugIDTextBox
            // 
            this.bugIDTextBox.Enabled = false;
            this.bugIDTextBox.Location = new System.Drawing.Point(569, 32);
            this.bugIDTextBox.Name = "bugIDTextBox";
            this.bugIDTextBox.Size = new System.Drawing.Size(100, 38);
            this.bugIDTextBox.TabIndex = 1;
            // 
            // bugListBox
            // 
            this.bugListBox.FormattingEnabled = true;
            this.bugListBox.ItemHeight = 31;
            this.bugListBox.Location = new System.Drawing.Point(25, 222);
            this.bugListBox.Name = "bugListBox";
            this.bugListBox.Size = new System.Drawing.Size(406, 438);
            this.bugListBox.TabIndex = 0;
            this.bugListBox.SelectedIndexChanged += new System.EventHandler(this.bugListBox_SelectedIndexChanged);
            // 
            // usersTab
            // 
            this.usersTab.Controls.Add(this.usersListBox);
            this.usersTab.Controls.Add(this.label1);
            this.usersTab.Controls.Add(this.currentUsersLabel);
            this.usersTab.Controls.Add(this.userTelTextBox);
            this.usersTab.Controls.Add(this.emailTextBox);
            this.usersTab.Controls.Add(this.userNameTextBox);
            this.usersTab.Controls.Add(this.userIDTextBox);
            this.usersTab.Controls.Add(this.usersDelete);
            this.usersTab.Controls.Add(this.usersSaveButton);
            this.usersTab.Controls.Add(this.userTelLabel);
            this.usersTab.Controls.Add(this.label3);
            this.usersTab.Controls.Add(this.userNameLabel);
            this.usersTab.Controls.Add(this.userIDLabel);
            this.usersTab.Location = new System.Drawing.Point(10, 48);
            this.usersTab.Name = "usersTab";
            this.usersTab.Padding = new System.Windows.Forms.Padding(3);
            this.usersTab.Size = new System.Drawing.Size(1425, 760);
            this.usersTab.TabIndex = 3;
            this.usersTab.Text = "Users";
            this.usersTab.UseVisualStyleBackColor = true;
            // 
            // usersListBox
            // 
            this.usersListBox.FormattingEnabled = true;
            this.usersListBox.ItemHeight = 31;
            this.usersListBox.Location = new System.Drawing.Point(790, 74);
            this.usersListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usersListBox.Name = "usersListBox";
            this.usersListBox.Size = new System.Drawing.Size(567, 593);
            this.usersListBox.TabIndex = 26;
            this.usersListBox.SelectedIndexChanged += new System.EventHandler(this.usersListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 683);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 32);
            this.label1.TabIndex = 25;
            this.label1.Text = "Fields With * Are Required";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // currentUsersLabel
            // 
            this.currentUsersLabel.AutoSize = true;
            this.currentUsersLabel.Location = new System.Drawing.Point(942, 26);
            this.currentUsersLabel.Name = "currentUsersLabel";
            this.currentUsersLabel.Size = new System.Drawing.Size(189, 32);
            this.currentUsersLabel.TabIndex = 24;
            this.currentUsersLabel.Text = "Current Users";
            this.currentUsersLabel.Click += new System.EventHandler(this.currentUsersLabel_Click);
            // 
            // userTelTextBox
            // 
            this.userTelTextBox.Location = new System.Drawing.Point(285, 318);
            this.userTelTextBox.Name = "userTelTextBox";
            this.userTelTextBox.Size = new System.Drawing.Size(320, 38);
            this.userTelTextBox.TabIndex = 23;
            this.userTelTextBox.TextChanged += new System.EventHandler(this.userTelTextBox_TextChanged);
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(285, 248);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(320, 38);
            this.emailTextBox.TabIndex = 22;
            this.emailTextBox.TextChanged += new System.EventHandler(this.emailTextBox_TextChanged);
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(285, 164);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(320, 38);
            this.userNameTextBox.TabIndex = 21;
            this.userNameTextBox.TextChanged += new System.EventHandler(this.userNameTextBox_TextChanged);
            // 
            // userIDTextBox
            // 
            this.userIDTextBox.Enabled = false;
            this.userIDTextBox.Location = new System.Drawing.Point(285, 88);
            this.userIDTextBox.Name = "userIDTextBox";
            this.userIDTextBox.Size = new System.Drawing.Size(320, 38);
            this.userIDTextBox.TabIndex = 20;
            this.userIDTextBox.TextChanged += new System.EventHandler(this.userIDTextBox_TextChanged);
            // 
            // usersDelete
            // 
            this.usersDelete.Location = new System.Drawing.Point(1229, 683);
            this.usersDelete.Name = "usersDelete";
            this.usersDelete.Size = new System.Drawing.Size(128, 52);
            this.usersDelete.TabIndex = 19;
            this.usersDelete.Text = "Delete";
            this.usersDelete.UseVisualStyleBackColor = true;
            this.usersDelete.Click += new System.EventHandler(this.usersDelete_Click);
            // 
            // usersSaveButton
            // 
            this.usersSaveButton.Location = new System.Drawing.Point(479, 448);
            this.usersSaveButton.Name = "usersSaveButton";
            this.usersSaveButton.Size = new System.Drawing.Size(126, 50);
            this.usersSaveButton.TabIndex = 18;
            this.usersSaveButton.Text = "Save";
            this.usersSaveButton.UseVisualStyleBackColor = true;
            this.usersSaveButton.Click += new System.EventHandler(this.usersSaveButton_Click);
            // 
            // userTelLabel
            // 
            this.userTelLabel.AutoSize = true;
            this.userTelLabel.Location = new System.Drawing.Point(77, 324);
            this.userTelLabel.Name = "userTelLabel";
            this.userTelLabel.Size = new System.Drawing.Size(129, 32);
            this.userTelLabel.TabIndex = 17;
            this.userTelLabel.Text = "User Tel:";
            this.userTelLabel.Click += new System.EventHandler(this.userTelLabel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 32);
            this.label3.TabIndex = 16;
            this.label3.Text = "*User Email:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(77, 167);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(175, 32);
            this.userNameLabel.TabIndex = 15;
            this.userNameLabel.Text = "*User Name:";
            this.userNameLabel.Click += new System.EventHandler(this.userNameLabel_Click);
            // 
            // userIDLabel
            // 
            this.userIDLabel.AutoSize = true;
            this.userIDLabel.Location = new System.Drawing.Point(77, 94);
            this.userIDLabel.Name = "userIDLabel";
            this.userIDLabel.Size = new System.Drawing.Size(116, 32);
            this.userIDLabel.TabIndex = 14;
            this.userIDLabel.Text = "User ID:";
            this.userIDLabel.Click += new System.EventHandler(this.userIDLabel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1445, 818);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Bug Tracker App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.logInTab.ResumeLayout(false);
            this.logInTab.PerformLayout();
            this.appTab.ResumeLayout(false);
            this.appTab.PerformLayout();
            this.bugsTab.ResumeLayout(false);
            this.bugsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBugLog)).EndInit();
            this.usersTab.ResumeLayout(false);
            this.usersTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage logInTab;
        private System.Windows.Forms.TabPage appTab;
        private System.Windows.Forms.Label listAppsLabel;
        private System.Windows.Forms.Label appDescLabel;
        private System.Windows.Forms.Label appVersionLabel;
        private System.Windows.Forms.Label appNameLabel;
        private System.Windows.Forms.Label appIdLabel;
        private System.Windows.Forms.TextBox appDescTextBox;
        private System.Windows.Forms.TextBox appVersionTextBox;
        private System.Windows.Forms.TextBox appNameTextBox;
        private System.Windows.Forms.TextBox appIdTextBox;
        private System.Windows.Forms.Button appSaveButton;
        private System.Windows.Forms.Button appDeleteButton;
        private System.Windows.Forms.ListBox listBoxApps;
        private System.Windows.Forms.TabPage bugsTab;
        private System.Windows.Forms.TabPage usersTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label currentUsersLabel;
        private System.Windows.Forms.TextBox userTelTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.TextBox userIDTextBox;
        private System.Windows.Forms.Button usersDelete;
        private System.Windows.Forms.Button usersSaveButton;
        private System.Windows.Forms.Label userTelLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Label userIDLabel;
        private System.Windows.Forms.ListBox usersListBox;
        private System.Windows.Forms.TextBox userEnterTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button logInButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox fixDateTextBox;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox submitDateTextBox;
        private System.Windows.Forms.TextBox bugDescTextBox;
        private System.Windows.Forms.TextBox bugDetailsTextBox;
        private System.Windows.Forms.TextBox bugRepStepsextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label applicationLabelBug;
        private System.Windows.Forms.ComboBox bugStatusComboBox;
        private System.Windows.Forms.DataGridView dataGridViewBugLog;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.ComboBox appsComboBox;
        private System.Windows.Forms.TextBox bugIDTextBox;
        private System.Windows.Forms.ListBox bugListBox;
        private System.Windows.Forms.Button bugsSaveButton;
        private System.Windows.Forms.Button bugsDeleteButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}

