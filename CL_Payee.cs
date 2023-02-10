using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charities_System_Database.B
{
    class CL_Payee
    {
        public DataTable GET_ALL_Payee()
        {
            DL.DataAccessLayer DL = new DL.DataAccessLayer();
            DataTable Dt = new DataTable();
            Dt = DL.SelectData("select_Payee", null);
            DL.Close();
            return Dt;
        }
      
        public DataTable GET_ALL_class()
        {
            DL.DataAccessLayer DL = new DL.DataAccessLayer();
            DataTable Dt = new DataTable();
            Dt = DL.SelectData("select_classe", null);
            DL.Close();
            return Dt;
        }
        public void DeletePayee(int ID)
        {
            DL.DataAccessLayer DAL = new DL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;
            DAL.ExecuteCommand("DELETE_Payee", param);
            DAL.Close();

        }
        public void DeleteClasse(int ID)
        {
            DL.DataAccessLayer DAL = new DL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;
            DAL.ExecuteCommand("DELETE_Classe", param);
            DAL.Close();

        }
        public void DeleteUser(string name)
        {
            DL.DataAccessLayer DAL = new DL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Name", SqlDbType.NVarChar, 30);
            param[0].Value = name;
            DAL.ExecuteCommand("DELETE_USER", param);
            DAL.Close();

        }
    }
}
