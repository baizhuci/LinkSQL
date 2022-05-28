using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinkSQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string connString;
        MySqlCommand comm = new MySqlCommand();
        MySqlConnection conn;

        private void button1_Click(object sender, EventArgs e)
        {
            connString = "server=localhost; database=test; uid=root; pwd=q1298516531;Character Set=utf8;";
            conn = new MySqlConnection(connString);
            comm.Connection = conn;
            conn.Open();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from score where ";
                int n = 0;
                if (textBox1.Text != "")
                { 
                    sql += label1.Text + " = " + textBox1.Text; 
                    n++;
                }
                if (textBox2.Text != "")
                {
                    if (n == 0)
                        sql += " " + label2.Text + " = " + textBox2.Text;
                    else
                        sql += " and " + label2.Text + " = " + textBox2.Text;
                }
                if (textBox4.Text != "")
                {
                    if (n == 0)
                        sql += " " + label4.Text + " = " + textBox4.Text;
                    else
                        sql += " and " + label4.Text + " = " + textBox4.Text;
                }
                sql += ";";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connString);
                DataSet ds = new DataSet();
                da.Fill(ds, "score");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "score";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "insert into score values("+textBox1.Text+","+textBox2.Text+","+textBox4.Text+");";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connString);
                DataSet ds = new DataSet();
                da.Fill(ds, "score");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "score";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                string sql = "delete from score where " ;
                int n = 0;
                if (textBox1.Text != "")
                {
                    sql += label1.Text + " = " + textBox1.Text;
                    n++;
                }
                if (textBox2.Text != "")
                {
                    if (n == 0)
                        sql += " " + label2.Text + " = " + textBox2.Text;
                    else
                        sql += " and " + label2.Text + " = " + textBox2.Text;
                }
                if (textBox4.Text != "")
                {
                    if (n == 0)
                        sql += " " + label4.Text + " = " + textBox4.Text;
                    else
                        sql += " and " + label4.Text + " = " + textBox4.Text;
                }
                sql += ";";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connString);
                DataSet ds = new DataSet();
                da.Fill(ds, "score");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "score";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int n = 0;
                string sql = "update score set " + label4.Text + " = " + textBox4.Text + " where s_id = " + textBox1.Text + " and c_id=" + textBox4.Text + ";";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connString);
                DataSet ds = new DataSet();
                da.Fill(ds, "score");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "score";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
