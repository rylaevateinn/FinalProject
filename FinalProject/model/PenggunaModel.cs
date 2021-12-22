using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace FinalProject.model
{
    class PenggunaModel
    {
        ModelTemplate temp;

        public string Email { get; set; }
        public string username { get; set; }
        public string telp { get; set; }
        public string password { get; set; }

        public PenggunaModel()
        {
            temp = new ModelTemplate();
        }

        //validasi login
        public bool CekLogin()
        {
            bool result = false;
            DataSet ds = new DataSet();
            ds = temp.Select("pengguna", "username = '" + username + "' AND password = '" + password + "'");
            // cek
            if (ds.Tables[0].Rows.Count > 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        //insert
        public bool InsertPengguna()
        {
            string data = "'" + Email + "','" + username + "','" + telp + "','" + password + "'";
            return temp.Insert("pengguna", data);
        }
    }
}
