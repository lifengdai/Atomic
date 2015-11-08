using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Atomic
{
    public partial class Detail : Form
    {
        private const int NUM_OF_FIELD = 22;
        private const int TBS_HEIGHT = 20;
        private const int TBS_WIGTH = 160;
        private const int LBL_HEIGHT = 13;
        private const int LBL_WIGTH = 35;

        private const int TBS_X_POSITION_LEFT = 100;
        private const int TBS_X_POSITION_RIGHT = 400;
        private const int TBS_Y_POSITION = 40;
        private const int LBL_X_POSITION_LEFT = 22;
        private const int LBL_X_POSITION_RIGHT = 322;
        private const int FREE_SPACE = 10;
        private readonly string[] columnNames = { "familyName","address","suburb","postCode","homePh",
            "rating","numBedrooms","numBathrooms","additionalFamilyInfo",
            "commentsAboutFamily","pets","transport","computer","internet","musicalInstrument",
            "policeVetting","preferredGender","allergies","vegetarian","halalFood","smoker","nzStudent" };
        private const int NUMBERS = 6;
        private const bool INSERT = true;
        private const bool UPDATE = false;

        private string[] lblName = { "Family Name", "Address", "Suburb", "Postcode", 
                                    "Home ph", "Rating", "Rooms", "Bathrooms", 
                                    "Addition Info", "Comments", "Pets", "Transport", 
                                    "Computer", "Internet", "Music instru", "Police Vetting", 
                                    "Pref Gender", "Allergies", "vegetarian", "Halalfood",
                                    "Smoker", "NZ student" };
        private DealDatabaseOnServer ddos;
        private Object[] tbs;
        private Label[] lbl;
        private List<string> beforeUpdate;
        private string oString;
        private bool unlock;
        private bool insertOrUpdate;

        public Detail()
        {
            constr();
            this.Text = "Create Family";
            button1.Enabled = false;
            button1.Hide();
            btnDelete.Text = "Cancel";
            btnDelete.Enabled = true;
            btnSave.Enabled = true;
            insertOrUpdate = INSERT;
        }

        private void constr()
        {
            InitializeComponent();
            unlock = false;
            ddos = new DealDatabaseOnServer();
            tbs = new Object[NUM_OF_FIELD];
            lbl = new Label[NUM_OF_FIELD];
            createGUI();
        }

        public Detail(object o)
        {
            constr();
            oString = o.ToString();
            this.Text += "-- -- -- Profile ID -- " + oString;
            ddos.openConnection();
            int i = 0;
            beforeUpdate = ddos.displaydetail(oString);
            foreach (string item in beforeUpdate)
            {
                switch(i)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 8:
                    case 9:
                    case 10:
                        ((TextBox)tbs[i]).Text = item;
                        break;

                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                    case 17:
                    case 18:
                    case 19:
                    case 20:
                    case 21:
                        switch(item)
                        {
                            case "True":
                                ((ComboBox)tbs[i]).Text = "Yes";
                                break;
                            case "Fasle":
                                ((ComboBox)tbs[i]).Text = "No";
                                break;
                            default:
                                ((ComboBox)tbs[i]).Text = "";
                                break;
                        }
                        break;

                    default:
                        ((ComboBox)tbs[i]).Text = item;
                        break;
                }
                i++;
            }
            lockorunlock(false);
            insertOrUpdate = UPDATE;
        }

        private void createComboBox(int i)
        {
            tbs[i] = new ComboBox();
            ((ComboBox)tbs[i]).Location = new Point(i < NUM_OF_FIELD / 2 ? TBS_X_POSITION_LEFT : TBS_X_POSITION_RIGHT,
                TBS_Y_POSITION + FREE_SPACE * (i % (NUM_OF_FIELD / 2)) + TBS_HEIGHT * (i % (NUM_OF_FIELD / 2)));
            ((ComboBox)tbs[i]).Name = "tbs" + i;
            ((ComboBox)tbs[i]).Size = new Size(TBS_WIGTH, TBS_HEIGHT);
            ((ComboBox)tbs[i]).TabIndex = 0;
            ((ComboBox)tbs[i]).DropDownStyle = ComboBoxStyle.DropDownList;
            gbxbi.Controls.Add(((ComboBox)tbs[i]));
        }

        private void addItemsIntoComboBox(int i, int f)
        {
            switch(f)
            {
                case 1:
                    for (int j = 0; j < NUMBERS; j++)
                    {
                        ((ComboBox)tbs[i]).Items.Add(j.ToString());
                    }
                    break;
                case 2:
                    ((ComboBox)tbs[i]).Items.Add("Male");
                    ((ComboBox)tbs[i]).Items.Add("Female");
                    ((ComboBox)tbs[i]).Items.Add("N/A");
                    break;
                case 3:
                    ((ComboBox)tbs[i]).Items.Add("Yes");
                    ((ComboBox)tbs[i]).Items.Add("No");
                    break;
            }
        }

        private void createGUI()
        {
            for (int i = 0; i < NUM_OF_FIELD; i++)
            {
                switch(i)
                {
                    case 5:
                    case 6:
                    case 7:
                        createComboBox(i);
                        addItemsIntoComboBox(i, 1);
                        break;
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                        createComboBox(i);
                        addItemsIntoComboBox(i, 3);
                        break;
                    case 16:
                        createComboBox(i);
                        addItemsIntoComboBox(i, 2);
                        break;
                    case 17:
                    case 18:
                    case 19:
                    case 20:
                    case 21:
                        createComboBox(i);
                        addItemsIntoComboBox(i, 3);
                        break;

                    default:
                        tbs[i] = new TextBox();
                        ((TextBox)tbs[i]).Location = new Point(i < NUM_OF_FIELD / 2 ? TBS_X_POSITION_LEFT : TBS_X_POSITION_RIGHT,
                            TBS_Y_POSITION + FREE_SPACE * (i % (NUM_OF_FIELD / 2)) + TBS_HEIGHT * (i % (NUM_OF_FIELD / 2)));
                        ((TextBox)tbs[i]).Name = "tbs" + i;
                        ((TextBox)tbs[i]).Size = new Size(TBS_WIGTH, TBS_HEIGHT);
                        ((TextBox)tbs[i]).TabIndex = 0;
                        gbxbi.Controls.Add(((TextBox)tbs[i]));
                        break;
                }
                lbl[i] = new Label();
                lbl[i].AutoSize = true;
                lbl[i].Location = new Point(i < NUM_OF_FIELD / 2 ? LBL_X_POSITION_LEFT : LBL_X_POSITION_RIGHT,
                    (TBS_Y_POSITION + FREE_SPACE * (i % (NUM_OF_FIELD / 2)) + TBS_HEIGHT * (i % (NUM_OF_FIELD / 2)))
                    + FREE_SPACE / 2);
                lbl[i].Name = "lbl" + i;
                lbl[i].Size = new Size(LBL_WIGTH, LBL_HEIGHT);
                lbl[i].TabIndex = 1;
                lbl[i].Text = lblName[i];
                gbxbi.Controls.Add(lbl[i]);
            }
        }

        private void lockorunlock(bool b)
        {
            for (int i = 0; i < NUM_OF_FIELD; i++)
            {
                switch (i)
                {
                    case 5:
                    case 6:
                    case 7:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                    case 18:
                    case 19:
                    case 20:
                    case 21:
                        ((ComboBox)tbs[i]).Enabled = b;
                        break;
                    default:
                        ((TextBox)tbs[i]).ReadOnly = !b;
                        break;
                }
            }
        }

        private void buttonEnableOrDisable(bool b)
        {
            btnDelete.Enabled = b;
            btnSave.Enabled = b;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            unlock = !unlock;
            switch(unlock)
            {
                case true:
                    lockorunlock(unlock);
                    button1.Text = "lock";
                    buttonEnableOrDisable(unlock);
                    break;

                case false:
                    lockorunlock(unlock);
                    button1.Text = "Unlock";
                    buttonEnableOrDisable(unlock);
                    break;
            }  
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            switch(((Button)sender).Text)
            {
                case "Delete" :
                    DialogResult deleteWaringResult =
                        MessageBox.Show("Are you sure you want to delete ??? (This action cannot be undone)", "Warning", 
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    messageBoxButtonClicked(deleteWaringResult, "d");
                    break;

                case "Cancel":
                    DialogResult cancelWarningResult =
                        MessageBox.Show("Are you sure you want to leave ??? (Any unsaved data will be lost)", "Warning",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    messageBoxButtonClicked(cancelWarningResult, "c");
                    break;
            }
        }

        private void messageBoxButtonClicked(DialogResult d, string s)
        {
            switch(d)
            {
                case DialogResult.OK:
                    switch(s)
                    {
                        case "d":
                            ddos.delete(oString);
                            this.Close();
                            break;
                        case "c":
                            this.Close();
                            break;
                    }
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch(insertOrUpdate)
            {
                case INSERT:
                    ddos.openConnection();
                    ddos.create(makeCreateCommandString(0));
                    this.Close();
                    break;
                case UPDATE:
                    if (hasChangedOrNot() != null)
                    {
                        ddos.openConnection();
                        ddos.update(oString, hasChangedOrNot().Item1, hasChangedOrNot().Item2);
                    }
                    this.Close();
                    break;
            }
        }

        private Tuple<List<string>, List<string>> hasChangedOrNot()
        {
            List<string> c = new List<string>();
            List<string> v = new List<string>();

            for (int i = 0; i < makeCreateCommandString(1).Count; i++)
			{
                if (makeCreateCommandString(1)[i] != beforeUpdate[i])
                {
                    c.Add(columnNames[i]);
                    v.Add(makeCreateCommandString(1)[i]);
                }
			}

            if (c.Count == 0)
            {
                return null;
            }
            else
            {
                return Tuple.Create(c, v);
            }
        }

        private List<string> makeCreateCommandString(int f)
        {
            List<string> ccs = new List<string>();
            for (int i = 0; i < NUM_OF_FIELD; i++)
            {
                switch (i)
                {
                    case 5:
                    case 6:
                    case 7:
                    case 16:
                        if (f == 0)
                        {
                            ccs.Add(((ComboBox)tbs[i]).Text);
                        }
                        else
                        {
                            if (((ComboBox)tbs[i]).Text == "")
                            {
                                ccs.Add("NULL");
                            }
                            else
                            {
                                ccs.Add(((ComboBox)tbs[i]).Text);
                            }
                        }
                        break;
                    
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                    case 17:
                    case 18:
                    case 19:
                    case 20:
                    case 21:
                        if (f == 0)
                        {
                            ccs.Add(((ComboBox)tbs[i]).Text == "Yes" ? "1" : "0");
                        }
                        else
                        {
                            switch (((ComboBox)tbs[i]).Text)
                            {
                                case "Yes":
                                    ccs.Add("True");
                                    break;
                                case "No":
                                    ccs.Add("False");
                                    break;
                                default:
                                    ccs.Add("NULL");
                                    break;
                            }
                        }
                        break;

                    default:
                        ccs.Add(((TextBox)tbs[i]).Text);
                        break;
                }
            }
            return ccs;
        }
    }
}
