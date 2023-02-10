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

namespace Charities_System_Database.FM
{
    public partial class AddPayee : Form
    {
        public AddPayee()
        {
            InitializeComponent();
        }
        private void loadcomboclass()
        {
            DL.DataAccessLayer dl = new DL.DataAccessLayer();
            dl.Open();
            SqlDataAdapter sdar = new SqlDataAdapter("Select * from Codifications", dl.sqlconn);
            DataTable dt = new DataTable();
            sdar.Fill(dt);
            combclass.DataSource = dt;
            combclass.DisplayMember ="Codification";
            combclass.ValueMember = "C_Id";
            dl.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DL.DataAccessLayer DL = new DL.DataAccessLayer();
                DL.Open();
                SqlParameter[] param = new SqlParameter[11];
                param[0] = new SqlParameter("@p_id", SqlDbType.Int);
                param[0].Value = Convert.ToInt32(txtno.Text.Trim());

                param[1] = new SqlParameter("@p_name", SqlDbType.NVarChar, 50);
                param[1].Value = txtname.Text;

                param[2] = new SqlParameter("@p_gendar", SqlDbType.NVarChar, 10);
                param[2].Value = txtg.Text;

                param[3] = new SqlParameter("@p_cardNum", SqlDbType.NVarChar, 50);
                param[3].Value = txtnumcard.Text;

                param[4] = new SqlParameter("@p_numphone", SqlDbType.NVarChar, 50);
                param[4].Value = txtphone.Text;

                param[5] = new SqlParameter("@p_adddate", SqlDbType.DateTime);
                param[5].Value = Convert.ToDateTime(dateTP.Value);

                param[6] = new SqlParameter("@p_adderss", SqlDbType.NVarChar, 50);
                param[6].Value = txtadderss.Text;

                param[7] = new SqlParameter("@p_wivesNum", SqlDbType.NVarChar, 10);
                param[7].Value = txtw.Text;

                param[8] = new SqlParameter("@p_sonsNum", SqlDbType.NVarChar, 10);
                param[8].Value = txtS.Text;

                param[9] = new SqlParameter("@p_notes", SqlDbType.NVarChar, 100);
                param[9].Value = txtnot.Text;

                param[10] = new SqlParameter("@p_cId", SqlDbType.Int);
                param[10].Value = (Int32)combclass.SelectedValue;

                DL.ExecuteCommand("insert_Payee", param);
                MessageBox.Show("تم أضافة المنتفع بنجاح", "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DL.Close();
            }
            catch { return; };

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddPayee_Load(object sender, EventArgs e)
        {
            loadcomboclass();
        }
    }
}
