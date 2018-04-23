using Microsoft.OData.Client;
using NSCCApplicationClient.Default;
using NSCCApplicationClient.NSCCApplicationFormDataLayer.Models;
using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NSCCApplicationClient
{
    public partial class middleNameTextBox : Form
    {

        Container service;

        Boolean provStateOther;

        Boolean provState;

        Boolean citizenshipOther;

        Boolean citizenshipAnswerd;

        Boolean provStateAnswerd;

        Boolean firstLanguageOther = true;

        Boolean firstLanguageOtherAnswerd;

        Boolean makeApplication;


        public middleNameTextBox()
        {
            InitializeComponent();
        }
        /// <summary>
        /// This will run when the form is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            provStateOtherTextBox.Enabled = false;

            try
            {


                service = new Container(new Uri("http://nsccapplicationformdbservice.azurewebsites.net"));

                service.MergeOption = MergeOption.OverwriteChanges;

                //pre load all drop downs

                var applicantList1 = service.Applicants.Expand
                    ("ProvinceState,Country,TheCitizenship,CitizenshipOtherForApplicant")
                    .OrderBy(a => a.LastName).ToList();



                //Display Programs            

                var programsList = service.Programs.Expand(p => p.Campuss).ToList();

                programsList.Insert(0, new NSCCApplicationFormDataLayer.Models.Program
                { Name = "<Select A Program>" });

                programsComboBox1.DataSource = programsList;

                programsComboBox1.DisplayMember = "Name";

                var programsList2 = service.Programs.Expand(p => p.Campuss).ToList();

                programsList2.Insert(0, new NSCCApplicationFormDataLayer.Models.Program
                { Name = "<Select A Program>" });

                programsComboBox2.DataSource = programsList2;

                programsComboBox2.DisplayMember = "Name";



                //Display Campus
                var campusList = service.Campuses.OrderBy(p => p.Name).ToList();

                campusList.Insert(0, new Campus { Name = "<Select A Campus>" });

                campusComboBox1.DataSource = campusList;

                campusComboBox1.DisplayMember = "Name";

                var campusList2 = service.Campuses.OrderBy(p => p.Name).ToList();

                campusList2.Insert(0, new Campus { Name = "<Select A Campus>" });

                campusComboBox2.DataSource = campusList2;

                campusComboBox2.DisplayMember = "Name";


                //Display Genders
                var genderList = service.Genders.OrderBy(p => p.Description).ToList();

                genderList.Insert(0, new Gender { Description = "<Select A Gender>" });

                genderComboBox.DataSource = genderList;

                genderComboBox.DisplayMember = "Description";


                //Display Country
                var countryList = service.Countries.OrderBy(p => p.Name).ToList();

                countryList.Insert(0, new Country { Name = "<Select A Country>" });

                countryComboBox.DataSource = countryList;

                countryComboBox.DisplayMember = "Name";



                //Display Province State
                var provStateList = service.ProvinceStates.OrderBy(p => p.Name).ToList();

                provStateList.Insert(0, new ProvinceState { Name = "<Select A Province/State>" });

                provStateComboBox.DataSource = provStateList;

                provStateComboBox.DisplayMember = "Name";




                //Display Citizenships
                var citizenshipsList = service.Citizenships.OrderBy(p => p.Description).ToList();

                citizenshipsList.Insert(0, new Citizenship { Description = "<Select A Citizenship>" });

                citizenshipComboBox.DataSource = citizenshipsList;

                citizenshipComboBox.DisplayMember = "Description";



                //Display Citizenships Other
                var citizenshipsOtherList = service.Countries.OrderBy(p => p.Name).ToList();

                citizenshipsOtherList.Insert(0, new Country { Name = "<Select A Citizenship Other>" });

                citizenshipOtherComboBox.DataSource = citizenshipsOtherList;

                citizenshipOtherComboBox.DisplayMember = "Name";


                List<Applicant> applicantList = service.Applicants.OrderBy(a => a.LastName).ToList();

                applicantsListBox.DataSource = applicantList;

                applicantsListBox.DisplayMember = "LastName";


                List<NSCCApplicationFormDataLayer.Models.Application> applicationList
                    = service.Applications
                    .Expand(a => a.Applicant)
                    .OrderBy(a => a.Applicant.LastName)
                    .ToList();

            }
            catch
            {

                MessageBox.Show("An Error Has Occured With The API");

                this.Close();

            }



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void programsComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void countryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void citizenshipComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void firstNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void firstNameTextBox_TextChanged(object sender, EventArgs e)
        {


        }

        /// <summary>
        /// This is the function that happend when the index is changed on the country combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void countryComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            try
            {


                Country selectedCountry
                    = (Country)countryComboBox.SelectedItem;

                var provStateList =
                    service.ProvinceStates.Where(p => p.CountryCode == selectedCountry.Code).ToList();

                int counter = provStateList.Count;


                if (counter > 0)
                {
                    provStateComboBox.Enabled = true;

                    provStateOtherTextBox.Enabled = false;

                    provStateComboBox.DataSource = provStateList;

                    provStateComboBox.DisplayMember = "Name";

                    provStateOther = false;

                    provState = true;

                    provStateAnswerd = true;

                }
                else if (selectedCountry.Name == "<Select A Country>")
                {

                    provStateComboBox.Enabled = false;

                    provStateOtherTextBox.Enabled = false;

                    provState = false;

                }
                else
                {

                    provStateOther = true;

                    provStateAnswerd = true;

                    provStateComboBox.Enabled = false;

                    provStateOtherTextBox.Enabled = true;

                    provState = false;

                }

            }
            catch
            {

                MessageBox.Show("An Error Has Occured");

            }

        }

        /// <summary>
        /// This is the function that happend when the index is changed on the citizenship combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void citizenshipComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            try
            {


                Citizenship selectedCitizenship
                 = (Citizenship)citizenshipComboBox.SelectedItem;


                if (selectedCitizenship.Description == "Other")
                {

                    citizenshipOtherComboBox.Enabled = true;

                    citizenshipOther = true;

                }
                else if (selectedCitizenship.Description == "Refugee with protected person status")
                {

                    citizenshipOtherComboBox.Enabled = true;

                    citizenshipOther = true;

                }
                else
                {

                    citizenshipOtherComboBox.Enabled = false;

                    citizenshipOther = false;

                }

            }
            catch
            {

                MessageBox.Show("An Error Has Occured");


            }

        }

        /// <summary>
        /// This is the function that occurs when the save button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click_1(object sender, EventArgs e)
        {


            Country selectedCountry
                = (Country)countryComboBox.SelectedItem;


            Gender selectedGender
                = (Gender)genderComboBox.SelectedItem;


            ProvinceState selectedProvState
                = (ProvinceState)provStateComboBox.SelectedItem;


            Citizenship selectedCitizenship
                = (Citizenship)citizenshipComboBox.SelectedItem;


            Country selectedCitizenshipOther
                = (Country)citizenshipOtherComboBox.SelectedItem;


            Campus selectedCampus
                = (Campus)campusComboBox1.SelectedItem;


            NSCCApplicationFormDataLayer.Models.Program selectedProgram
               = (NSCCApplicationFormDataLayer.Models.Program)programsComboBox1.SelectedItem;

            Campus selectedCampus2
                = (Campus)campusComboBox2.SelectedItem;


            NSCCApplicationFormDataLayer.Models.Program selectedProgram2
               = (NSCCApplicationFormDataLayer.Models.Program)programsComboBox2.SelectedItem;


            if (makeApplication == false)
            {
                int counter = 0;

                if (firstNameTextBox.Text.Length == 0)
                {

                    MessageBox.Show("Please Fill In A First Name");

                }
                else if (lastNameTextBox.Text.Length == 0)
                {

                    MessageBox.Show("Please Fill In A Last Name");

                }
                else if (dateOfBirthTextBox.Text.Length == 0)
                {

                    MessageBox.Show("Please Fill In A Date Of Birth");

                }
                else if (IsCorrectDate(dateOfBirthTextBox.Text) == false)
                {

                    MessageBox.Show("Please Fill In A Valid Date Of Birth");

                }
                else if (selectedGender.Description == "<Select A Gender>")
                {

                    MessageBox.Show("Please Select A Gender");

                }
                else if (selectedCountry.Name == "<Select A Country>")
                {

                    MessageBox.Show("Please Select A Country");

                }
                else if (streetTextBox.Text.Length == 0)
                {

                    MessageBox.Show("Please Fill In A Street Address");

                }
                else if (cityTextBox.Text.Length == 0)
                {

                    MessageBox.Show("Please Fill In A City");

                }
                else if (selectedProvState.Name == "<Select A Province/State>" && provState == true)
                {

                    MessageBox.Show("Please Select A Province/State");

                }
                else if (provStateOtherTextBox.Text.Length == 0 && provStateOther == true)
                {

                    MessageBox.Show("Please Fill In A Province State Other");

                }
                else if (emailTextBox.Text.Length == 0)
                {

                    MessageBox.Show("Please Fill In An Email");

                }
                else if (IsValidEmail(emailTextBox.Text) == false)
                {

                    MessageBox.Show("Please Fill In A Valid Email");

                }

                if (selectedCitizenship.Description == "<Select A Citizenship>")
                {

                    MessageBox.Show("Please Select A Citizenship");

                }
                else
                {

                    citizenshipAnswerd = true;

                    counter += 1;

                }

                if (selectedCitizenshipOther.Name == "<Select A Citizenship Other>" && citizenshipOther == true)
                {

                    MessageBox.Show("Please Select A Citizenship Other");

                }
                else
                {

                    citizenshipAnswerd = true;

                    counter += 1;


                }


                if (selectedProgram.Name == "<Select A Program>")
                {

                    MessageBox.Show("Please Select A Program");

                }
                else if (selectedCampus.Name == "<Select A Campus>")
                {

                    MessageBox.Show("Please Select A Campus");

                }
                else if (selectedProgram2.Name == "<Select A Program>")
                {

                    MessageBox.Show("Please Select A Second Program");

                }
                else if (selectedCampus2.Name == "<Select A Campus>")
                {

                    MessageBox.Show("Please Select A Second Campus");

                }
                else if (phoneTextBox.Text.Length == 0)
                {

                    MessageBox.Show("Please Fill In An Phone Number");

                }
                else if (IsValidPhone(phoneTextBox.Text) == false)
                {

                    MessageBox.Show("Please Fill In A Valid Phone Number");

                }




                if (firstLanguageOtherTextBox.Text.Length == 0 && firstLanguageOther == true)
                {

                    MessageBox.Show("Please Fill In A First Language Other");

                    firstLanguageOtherAnswerd = false;


                }

                else
                {

                    firstLanguageOtherAnswerd = true;

                    counter += 1;


                }


                if (counter == 3)
                {

                    makeApplication = true;

                }


            }

            if (makeApplication == true)
            {


                if (firstNameTextBox.Text.Length > 0 &&
                    lastNameTextBox.Text.Length > 0 &&
                    dateOfBirthTextBox.Text.Length > 0 &&
                    selectedGender.Description != "<Select A Gender>" &&
                    selectedCountry.Name != "<Select A Country>" &&
                    streetTextBox.Text.Length > 0 &&
                    cityTextBox.Text.Length > 0 &&
                    provStateAnswerd == true &&
                    emailTextBox.Text.Length > 0 &&
                    selectedCitizenship.Description != "<Select A Citizenship>" &&
                    citizenshipAnswerd == true &&
                    selectedProgram.Name != "<Select A Program>" &&
                    selectedCampus.Name != "<Select A Campus>" &&
                    selectedProgram2.Name != "<Select A Program>" &&
                    selectedCampus2.Name != "<Select A Campus>" &&
                    phoneTextBox.Text.Length > 0 &&
                    firstLanguageOtherAnswerd == true
                    )
                {

                    try
                    {


                        //Make and add applicant to database
                        Applicant newApplicant = new Applicant();

                        newApplicant.FirstName = firstNameTextBox.Text;

                        if (String.IsNullOrEmpty(middelNameTextBox.Text) == false)
                        {

                            newApplicant.MiddleName = middelNameTextBox.Text;

                        }

                        newApplicant.LastName = lastNameTextBox.Text;

                        newApplicant.DateOfBirth = DateTime.Parse(dateOfBirthTextBox.Text);

                        newApplicant.Gender = selectedGender.Code;

                        newApplicant.CountryCode = selectedCountry.Code;

                        newApplicant.StreetAddress1 = streetTextBox.Text;

                        newApplicant.City = cityTextBox.Text;

                        newApplicant.ProvinceStateCode = selectedProvState.Code;

                        newApplicant.ProvinceStateOther = provStateOtherTextBox.Text;

                        newApplicant.EmailAddress = emailTextBox.Text;

                        newApplicant.Citizenship = selectedCitizenship.Id;

                        newApplicant.CitizenshipOther = selectedCitizenshipOther.Code;

                        newApplicant.IsEnglishFirstLanguage = englishFirstCheckBox.Checked;

                        newApplicant.HasCriminalConvicition = pastCrimeCheckBox.Checked;

                        newApplicant.IsIndigenous = firstNationCheckBox.Checked;

                        newApplicant.IsAfricanCanadian = africanChildCheckBox.Checked;

                        newApplicant.HasDisability = disabilityCheckBox.Checked;

                        newApplicant.PhoneHome = phoneTextBox.Text;

                        newApplicant.FirstLanguageOther = firstLanguageOtherTextBox.Text;

                        service.AddToApplicants(newApplicant);

                        service.SaveChanges();


                        //Make and add application to database
                        NSCCApplicationFormDataLayer.Models.Application newApplication =
                            new NSCCApplicationFormDataLayer.Models.Application();

                        newApplication.ApplicantId = newApplicant.ApplicantId;

                        newApplication.SubmissionDate = DateTime.Now;

                        newApplication.ApplicationFee = 50;

                        newApplication.Paid = false;

                        service.AddToApplications(newApplication);

                        service.SaveChanges();


                        //Make and add program choice to database
                        ProgramChoice newProgramChoice = new ProgramChoice();

                        newProgramChoice.ApplicantId = newApplicant.ApplicantId;

                        newProgramChoice.ProgramId = selectedProgram.Id;

                        newProgramChoice.CampusId = selectedCampus.Id;

                        newProgramChoice.Preference = 1;

                        service.AddToProgramChoices(newProgramChoice);

                        service.SaveChanges();



                        //Make and add program choice to database
                        ProgramChoice newProgramChoice2 = new ProgramChoice();

                        newProgramChoice2.ApplicantId = newApplicant.ApplicantId;

                        newProgramChoice2.ProgramId = selectedProgram2.Id;

                        newProgramChoice2.CampusId = selectedCampus2.Id;

                        newProgramChoice2.Preference = 0;

                        service.AddToProgramChoices(newProgramChoice2);

                        service.SaveChanges();


                        //Reload all of the dropdowns and text boxes and check boxes

                        var applicantList1 = service.Applicants.Expand("ProvinceState,Country,TheCitizenship,CitizenshipOtherForApplicant").OrderBy(a => a.LastName).ToList();

                        //Display Programs            

                        var programsList = service.Programs.Expand(p => p.Campuss).ToList();

                        programsList.Insert(0, new NSCCApplicationFormDataLayer.Models.Program
                        { Name = "<Select A Program>" });

                        programsComboBox1.DataSource = programsList;

                        programsComboBox1.DisplayMember = "Name";

                        var programsList2 = service.Programs.Expand(p => p.Campuss).ToList();

                        programsList2.Insert(0, new NSCCApplicationFormDataLayer.Models.Program
                        { Name = "<Select A Program>" });

                        programsComboBox2.DataSource = programsList2;

                        programsComboBox2.DisplayMember = "Name";



                        //Display Campus
                        var campusList = service.Campuses.OrderBy(p => p.Name).ToList();

                        campusList.Insert(0, new Campus { Name = "<Select A Campus>" });

                        campusComboBox1.DataSource = campusList;

                        campusComboBox1.DisplayMember = "Name";

                        var campusList2 = service.Campuses.OrderBy(p => p.Name).ToList();

                        campusList2.Insert(0, new Campus { Name = "<Select A Campus>" });

                        campusComboBox2.DataSource = campusList2;

                        campusComboBox2.DisplayMember = "Name";


                        //Display Genders
                        var genderList = service.Genders.OrderBy(p => p.Description).ToList();

                        genderList.Insert(0, new Gender { Description = "<Select A Gender>" });

                        genderComboBox.DataSource = genderList;

                        genderComboBox.DisplayMember = "Description";


                        //Display Country
                        var countryList = service.Countries.OrderBy(p => p.Name).ToList();

                        countryList.Insert(0, new Country { Name = "<Select A Country>" });

                        countryComboBox.DataSource = countryList;

                        countryComboBox.DisplayMember = "Name";



                        //Display Province State
                        var provStateList = service.ProvinceStates.OrderBy(p => p.Name).ToList();

                        provStateList.Insert(0, new ProvinceState { Name = "<Select A Province/State>" });

                        provStateComboBox.DataSource = provStateList;

                        provStateComboBox.DisplayMember = "Name";




                        //Display Citizenships
                        var citizenshipsList = service.Citizenships.OrderBy(p => p.Description).ToList();

                        citizenshipsList.Insert(0, new Citizenship { Description = "<Select A Citizenship>" });

                        citizenshipComboBox.DataSource = citizenshipsList;

                        citizenshipComboBox.DisplayMember = "Description";



                        //Display Citizenships Other
                        var citizenshipsOtherList = service.Countries.OrderBy(p => p.Name).ToList();

                        citizenshipsOtherList.Insert(0, new Country { Name = "<Select A Citizenship Other>" });

                        citizenshipOtherComboBox.DataSource = citizenshipsOtherList;

                        citizenshipOtherComboBox.DisplayMember = "Name";

                        firstNameTextBox.Text = "";

                        lastNameTextBox.Text = "";

                        middelNameTextBox.Text = "";

                        phoneTextBox.Text = "";

                        dateOfBirthTextBox.Text = "";

                        streetTextBox.Text = "";

                        cityTextBox.Text = "";

                        provStateOtherTextBox.Text = "";

                        emailTextBox.Text = "";

                        pastCrimeCheckBox.Checked = false;

                        childAbuseCheckBox.Checked = false;

                        pastDisciplinaryCheckBox.Checked = false;

                        africanChildCheckBox.Checked = false;

                        firstNationCheckBox.Checked = false;

                        currentALPCheckBox.Checked = false;

                        disabilityCheckBox.Checked = false;

                        englishFirstCheckBox.Checked = false;

                        MessageBox.Show("Thank you for filling out an application");


                        //Load up the applicants list box
                        List<Applicant> applicantList = service.Applicants.OrderBy(a => a.LastName).ToList();

                        applicantsListBox.DataSource = applicantList;

                        applicantsListBox.DisplayMember = "LastName";
                    }
                    catch
                    {

                        MessageBox.Show("An error has occured");

                    }
                }

            }

        }

        /// <summary>
        /// This is the function that will occur when the english first button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void englishFirstCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            if(englishFirstCheckBox.Checked == false)
            {

                firstLanguageOtherTextBox.Enabled = true;

                firstLanguageOther = true;

                firstLanguageOtherTextBox.Text = "";

            }
            else
            {

                firstLanguageOtherTextBox.Enabled = false;

                firstLanguageOther = false;

                firstLanguageOtherTextBox.Text = "N/A";


            }

        }

        /// <summary>
        /// This is the function that happend when the index is changed on the program combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void programsComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {


            var programList = service.Programs.Expand(p => p.Campuss).ToList();

            if (programsComboBox1.SelectedIndex > -1)
            {

                List<Campus> campusList = (programList[programsComboBox1.SelectedIndex]
                        .Campuss.OrderBy(p => p.Name)).ToList();


                campusComboBox1.DataSource = campusList;
                campusComboBox1.DisplayMember = "Name";

            }



        }

        /// <summary>
        /// This is the function that happend when the index is changed on the program combo box 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void programsComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            var programList = service.Programs.Expand(p => p.Campuss).ToList();

            if (programsComboBox2.SelectedIndex > -1)
            {

                List<Campus> campusList = (programList[programsComboBox2.SelectedIndex]
                        .Campuss.OrderBy(p => p.Name)).ToList();


                campusComboBox2.DataSource = campusList;
                campusComboBox2.DisplayMember = "Name";

            }

        }


        /// <summary>
        /// This will check if the user entered a valid email
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        bool IsValidEmail(string strIn)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

            //https://stackoverflow.com/questions/5342375/regex-email-validation/6893571#6893571
        }


        /// <summary>
        /// This will check if the user entered a correct date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        bool IsCorrectDate(string date)
        {

            return Regex.IsMatch(date, "(19|20)[0-9]{2}-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[01])");

            //https://stackoverflow.com/questions/5247219/regular-expression-to-detect-yyyy-mm-dd

        }


        /// <summary>
        /// This will check if the user entered a valid phone number
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        bool IsValidPhone(string phone)
        {

            return Regex.IsMatch(phone, @"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$");

            //https://stackoverflow.com/questions/18091324/regex-to-match-all-us-phone-number-formats

        }



        /// <summary>
        /// This is the function that happend when the index is changed on the applicant list box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void applicantsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            Applicant selectedApplicant = (Applicant)applicantsListBox.SelectedItem;

            List<NSCCApplicationFormDataLayer.Models.Application> applicationList =
                service.Applications.Expand("ProgramChoice($expand=Campus,Program)")
                .Where(a => a.ApplicantId == selectedApplicant.ApplicantId).ToList();


            applicantIdTextBox.Text = selectedApplicant.ApplicantId.ToString();

            applicantFirstNameTextBox.Text = selectedApplicant.FirstName;

            applicantMiddleNameTextBox.Text = selectedApplicant.MiddleName;

            applicantLastNameTextBox.Text = selectedApplicant.LastName;

            applicantDOBTextBox.Text = selectedApplicant.DateOfBirth.ToString();

            applicantGenTextBox.Text = selectedApplicant.Gender;

            applicantCountryTextBox.Text = selectedApplicant.Country.Name.ToString();

            applicantStreetTextBox.Text = selectedApplicant.StreetAddress1;

            applicantCityTextBox.Text = selectedApplicant.City;

            applicantProvStateTextBox.Text = selectedApplicant.ProvinceStateCode;

            applicantEmailTextBox.Text = selectedApplicant.EmailAddress;

            applicantCitizenshipTextBox.Text = selectedApplicant.TheCitizenship.Description;

            //applicantCitizenOtherTextBox.Text = selectedApplicant.CitizenshipOtherForApplicant.Name.ToString();

            bool checkCriminal = selectedApplicant.HasCriminalConvicition;

            bool checkAfrican = selectedApplicant.IsAfricanCanadian;

            bool checkNation = selectedApplicant.IsIndigenous;

            bool checkDisability = selectedApplicant.HasDisability;

            if(checkCriminal == true)
            {

                criminalTextBox.Text = "Yes";

            }
            else
            {

                criminalTextBox.Text = "No";

            }


            if (checkAfrican == true)
            {

                africanTextBox.Text = "Yes";

            }
            else
            {

                africanTextBox.Text = "No";

            }


            if (checkNation == true)
            {

                nationTextBox.Text = "Yes";

            }
            else
            {

                nationTextBox.Text = "No";

            }


            if (checkDisability == true)
            {

                documentedTextBox.Text = "Yes";

            }
            else
            {

                documentedTextBox.Text = "No";

            }

            //This is how you populate the campus and program choice

            progChoice1TextBox.Text = applicationList[0].ProgramChoice[0].Program.Name;


            progChoice2TextBox.Text = applicationList[0].ProgramChoice[1].Program.Name;

            campus1TextBox.Text = applicationList[0].ProgramChoice[0].Campus.Name;

            campus2TextBox.Text = applicationList[0].ProgramChoice[1].Campus.Name;

            subDateTextBox.Text = applicationList[0].SubmissionDate.ToString();

            bool checkPaid = applicationList[0].Paid;       

            if(checkPaid == true)
            {

                paidTextBox.Text = "Yes";

            }
            else
            {

                paidTextBox.Text = "No";

            }


        }
    }
}
