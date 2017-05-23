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

namespace WindowsFormsApplication1
{
     public partial class Form1 : Form
     {
          public Form1()
          {
               InitializeComponent();
          }   

          private void Form1_Load(object sender, EventArgs e)
          {
               String connectionString = GetConnectionString();
               Console.Write(connectionString);
               using (SqlConnection sqcon = new SqlConnection(connectionString))
               {
                    //Abrimos la coneión
                    sqcon.Open();
                    using (SqlCommand command = new SqlCommand("select * from employees", sqcon))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                         //Leemos en el while
                         while (reader.Read())
                         {
                              Console.WriteLine("{0} {1] {2}",
                                             reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                         }
                    }
               }
          }

          private string GetConnectionString()
          {

             return  "Data Source = (local); Initial Catalog = Northwind; "
              + "Integrated Security=SSPI;";
          }

          private void button1_Click(object sender, EventArgs e)
          {

          }

          private void button2_Click(object sender, EventArgs e)
          {

          }

          private void radioButton2_CheckedChanged(object sender, EventArgs e)
          {

          }

          private void label1_Click(object sender, EventArgs e)
          {

          }

          private void label3_Click(object sender, EventArgs e)
          {

          }

          private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
          {

          }
     }
}
