using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Atomic
{
    class DealDatabaseOnServer
    {
        private MySqlConnection con;
        private MySqlCommand cmd;
        private MySqlDataReader cmddr;

        public DealDatabaseOnServer()
        {
            con = new MySqlConnection("server=kate.ict.op.ac.nz;" +
            "database=darvja1_atomic;" + "uid=darvja1;" + "pwd=SnoopY9021003;");
        }

        public bool openConnection()
        {
            if (con.State.ToString() == "Open")
            {
                return true;
            }
            else
            {
                try
                {
                    con.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public List<string> displaydetail(string s)
        {
            List<string> ls = new List<string>();
            string cmdstring = "SELECT * FROM tblFamily WHERE familyID='" + s + "';";
            cmd = new MySqlCommand(cmdstring, con);
            cmddr = cmd.ExecuteReader();
            while (cmddr.Read())
            {
                for (int j = 1; j < 23; j++)
                {
                    ls.Add(checkNull(cmddr, j));
                }
            }
            cmddr.Close();
            return ls;
        }

        public List<List<string>> Search(List<Tuple<string, string>> want)
        {
            List<List<string>> result = new List<List<string>>();
            List<string> ls;
            int i = 0;
            string c = "";
            string cmdstring = "SELECT familyName, suburb, address, numBedrooms, rating, familyID FROM tblFamily WHERE ";
            foreach (Tuple<string, string> t in want) {
                string s;
                i++;
                if (i < want.Count)
                {
                    s = t.Item1 + "='" + t.Item2 + "' AND ";
                }
                else
                { 
                    s = t.Item1 + "='" + t.Item2 + "';";
                }
                c = c + s;
            }
            cmdstring += c;
            cmd = new MySqlCommand(cmdstring, con);
            cmddr = cmd.ExecuteReader();

                while (cmddr.Read())
                {
                    ls = new List<string>();
                    for (int j = 0; j < 6; j++)
                    {
                        ls.Add(checkNull(cmddr, j));
                    }
                    ls.Add("Detail");
                    result.Add(ls);
                }
                cmddr.Close();
            return result;
    }

        public void create(List<string> value)
        {
            string v = "";
            int i = 0;
            foreach (string item in value)
            {
                if (value.Count - 1 == i)
                {
                    v += "'" + item + "'";
                }
                else
                {
                    v += "'" + item + "'" + ",";
                }
                i++;
            }
            string columnNames = "(familyName,address,suburb,postCode,homePh," +
            "rating,numBedrooms,numBathrooms,additionalFamilyInfo," +
            "commentsAboutFamily,pets,transport,computer,internet,musicalInstrument," +
            "policeVetting,preferredGender,allergies,vegetarian,halalFood,smoker,nzStudent)";
            cmd = new MySqlCommand("INSERT INTO tblFamily " + columnNames + " VALUES (" + v + ");", con);
            cmd.ExecuteNonQuery();
        }

        public void delete(string value)
        {
            cmd = new MySqlCommand("DELETE FROM tblFamily WHERE familyID='" + value + "';", con);
            cmd.ExecuteNonQuery();
        }

        public void update(string ID, List<string> Column, List<string> Value)
        {
            string command = "";
            for (int i = 0; i < Column.Count; i++)
            {
                if (i == Column.Count - 1)
                {
                    command += Column[i] + "=" + "'" + Value[i] + "'";
                }
                else
                {
                    command += Column[i] + "=" + "'" + Value[i] + "',";
                }
            }
            cmd = new MySqlCommand("UPDATE tblFamily SET " + command + " WHERE familyID='" + ID + "';", con);
            cmd.ExecuteNonQuery();
        }

        public List<string> autosearch(string row, string thing)
        {
            List<string> str = new List<string>(); 
            string cmdstring = "SELECT * FROM tblFamily WHERE " + row + " LIKE " + "'" + thing + "%';";
            cmd = new MySqlCommand(cmdstring, con);
            cmddr = cmd.ExecuteReader();
            while (cmddr.Read())
            {
                str.Add(cmddr.GetString(row));
            }
            cmddr.Close();
            return str;
        }

        public List<List<string>> popAll()
        {
            List<List<string>> lls = new List<List<string>>();
            List<string> ls;
            string cmdcommand = "SELECT familyName, suburb, address, numBedrooms, rating, familyID FROM tblFamily;";
            cmd = new MySqlCommand(cmdcommand, con);
            cmddr = cmd.ExecuteReader();
            while (cmddr.Read()) 
            {
                ls = new List<string>();
                for (int i = 0; i < 6; i++)
                {
                    ls.Add(checkNull(cmddr, i));
                }
                ls.Add("Detail");
                lls.Add(ls);
            }
            cmddr.Close();
            return lls;
        }

        private string checkNull(MySqlDataReader msdr, int s)
        {
            if (msdr.IsDBNull(s))
            {
                return "NULL";
            }
            else
            {
                return msdr.GetString(s);
            }
        }

        public void closeConnection()
        {
            con.Close();
        }
    }
}
