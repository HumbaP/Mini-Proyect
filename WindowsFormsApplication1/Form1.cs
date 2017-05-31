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
               String connectionString = "server=localhost\\SQLEXPRESS ; database=Northwind ; integrated security = true";
               Console.Write(connectionString);


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

            foreach(Object o in this.Controls.)
        }

          private void button1_Click(object sender, EventArgs e)
          {
          
          }

          private void button2_Click(object sender, EventArgs e)
          {

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
    }
}
