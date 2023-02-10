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

namespace Charities_System_Database
{
    public partial class Payee : Form
    {
        B.CL_Payee select = new B.CL_Payee();
        FM.EditPayee a = new FM.EditPayee();
        public Payee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Payee_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = select.GET_ALL_Payee();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FM.AddPayee add = new FM.AddPayee();
            add.ShowDialog();
            dataGridView1.DataSource = select.GET_ALL_Payee();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            a.ShowDialog();
            dataGridView1.DataSource = select.GET_ALL_Payee();
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            B.CL_Payee payee = new B.CL_Payee();
            try
            {
                if (dataGridView1.Rows.Count == 0) { MessageBox.Show("لا يوجد بيانات لحذفها", "عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else if (MessageBox.Show("هل تريد فعلا حذف المنتفع المحدد؟", "عملية الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    payee.DeletePayee(Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                    MessageBox.Show("تمت عملية الحذف بنجاح", "عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dataGridView1.DataSource = payee.GET_ALL_Payee();
                }
                else
                {
                    MessageBox.Show("تم إلغاء عملية الحذف", "عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch { return; };
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                a.txtno.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                a.txtname.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                a.txtg.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                //a.dateTP.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                a.txtnumcard.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                a.txtadderss.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                a.txtphone.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                a.txtw.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
                a.txtS.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
                a.txtnot.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString();
                a.combclass.Text = this.dataGridView1.CurrentRow.Cells[10].Value.ToString();

            }
            catch
            {


            } 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DL.DataAccessLayer d = new DL.DataAccessLayer();
                SqlDataAdapter sdar = new SqlDataAdapter("select P_Id'رقم المنتفع', P_Name'اسم المنتفع',P_Gender'الجنس',P_CardNum'رقم البطاقة',P_Address'العنوان',P_NumPhone'رقم الهاتف ',P_AddDate'تاريخ الأضافة',P_WivesNum'عدد الزوجات',P_SonsNum'عدد الأبناء',P_Notes'ملاحظات',Codification'المجموعة/التصنيف' from Payee p ,Codifications c where p.C_Id=c.C_Id  and Convert (nvarchar,P_Id)+P_name+P_Address+P_CardNum+P_NumPhone+Convert (nvarchar,P_Gender) like '%" + txtsearsh.Text + "%'", d.sqlconn);
                DataTable dt = new DataTable();
                dt.Clear();
                sdar.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch { return; };

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
