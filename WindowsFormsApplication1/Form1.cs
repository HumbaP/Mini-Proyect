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

          public bool newOne=true;
          static int[] tabIndexes = new int[] { 1,2,3,4,6,8,9,10,11, 12, 13, 14, 15, 16 };
          Dictionary<int, String> hash = new Dictionary<int, string>();
          static string[] columns = new string[] { "EmployeeID", "FirstName", "LastName","Title","TitleOfCourtesy", "BirthDate","HireDate","Address","City","Region","PostalCode","Country","HomePhone","Extension","Notes","ReportsTo" };
          public Form1()
          {
               InitializeComponent();
               for (int j = 0; j < columns.Length; j++) {
                    hash.Add(j, columns[j]);
               }
          }   

          private void Form1_Load(object sender, EventArgs e)
          {
               String connectionString = "server=localhost\\SQLEXPRESS ; database=Northwind ; integrated security = true";
               Console.Write(connectionString);

               radioButton1.Select();
               
               using (SqlConnection sqcon = new SqlConnection(connectionString))
               {
                //Abrimos la coneión
                try
                {
                    sqcon.Open();
                    SqlDataReader reader = null;
                    String query = "select * from employees";
                    SqlCommand myCommand = new SqlCommand(query, sqcon);

                    //Ejecutamos el comando SQL
                    reader = myCommand.ExecuteReader();

                    //imprimimos un encabezado para mostrar una tabla de resultados
                    while (reader.Read()) {
                        Console.WriteLine(reader["EmployeeID"]+ "\t"+reader["FirstName"]);
                    }

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("HAy error en algo");
                }
                catch (Exception ex) {
                }
                  
               }
          }

        public void crearQuery() {
            String query = "Select * from employees where 1=1 ";

               //foreach(Object o in this.Controls.)
              
               foreach (Control control in Controls) {
                    if (tabIndexes.Contains(control.TabIndex))
                         if (control.Text.Length > 0) {
                            
                         }
               }
        }

          private void button1_Click(object sender, EventArgs e)
          {
          
          }

          private void button2_Click(object sender, EventArgs e)
          {
               foreach (Control c in Controls) {
                    if (tabIndexes.Contains(c.TabIndex))
                         c.Text = "";
               }
          }

          private void radioButton2_CheckedChanged(object sender, EventArgs e)
          {
            textBox4.Enabled = true;
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Enabled = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Se ha salido alv");
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            this.crearQuery();
        }

          private void textBox1_Leave(object sender, EventArgs e)
          {
               this.crearQuery();
          }

          private void textBox2_Leave(object sender, EventArgs e)
          {
               this.crearQuery();
          }

          private void textBox3_Leave(object sender, EventArgs e)
          {
               this.crearQuery();
          }

          private void textBox5_Leave(object sender, EventArgs e)
          {
               this.crearQuery();
          }

          private void textBox6_Leave(object sender, EventArgs e)
          {
               this.crearQuery();
          }

          private void textBox7_Leave(object sender, EventArgs e)
          {
               this.crearQuery();
          }

          private void textBox8_Leave(object sender, EventArgs e)
          {
               this.crearQuery();
          }

          private void textBox9_Leave(object sender, EventArgs e)
          {
               this.crearQuery();
          }

          private void textBox10_Leave(object sender, EventArgs e)
          {
               this.crearQuery();
          }
     }
}
