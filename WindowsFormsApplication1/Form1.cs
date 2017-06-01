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
          Dictionary<int, String> empleados;
          SqlConnection sqcon;
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

               //Abrimos la coneión
               sqcon = Connexion.getConnection();
                  
               
          }

          public void limpiar() {
               foreach (Control c in Controls)
               {
                    if (c.TabIndex < columns.Length)
                    {
                         c.Text = "";
                         validacionDesign((TextBox)c, true);
                    }
               }
               //Regresamos el focus al id
               textBox4.Focus();
          }

       

          public void getJefes(int exclude=0) {
               
               SqlDataAdapter adapter = new SqlDataAdapter("select EmployeeID, Name=FirstName+' '+LastName from employees where EmployeeID not in("+exclude+")", sqcon);
               DataTable dt = new DataTable();
               adapter.Fill(dt);
               comboBox1.DataSource = dt.DefaultView;
               comboBox1.DisplayMember = "Name";
               comboBox1.ValueMember = "EmployeeID";
               

          }
          public SqlDataReader consultar(string query) {
               try
               {
                    SqlCommand myCommand = new SqlCommand(query, sqcon);
                    //Ejecutamos el comando SQL
                    return myCommand.ExecuteReader();
               }
               catch (Exception e)
               {

                    
                    return null;
               }
           }

          public Boolean validarFecha(TextBox textbox) {
              
               if (textbox.TextLength > 0)
               {
                    String[] fechas=textbox.Text.Split('/');
                    if (fechas.Length == 3) {
                         int dia;
                         int.TryParse(fechas[0], out dia);
                         int mes;
                         int.TryParse(fechas[1], out mes);
                         int year;
                         int.TryParse(fechas[2], out year);
                         if (mes > 12 || mes <= 0)
                              return false;
                         if (year % 4 == 0 && mes == 2)
                         {//Es año bisiesto y es febrero
                              if (dia <= 29) {
                                   return true;
                              }
                         }
                         else if (mes == 2) { //Es febrero
                              if (dia <= 28)
                              {
                                   return true;
                              }
                         }
                         else if (mes <= 7) {//Primera mitad pares son chidos
                              if (mes % 2 == 0)
                              {
                                   if (dia <= 30)
                                   {
                                        return true;

                                   }
                              }
                              else {
                                   if (dia <= 31)
                                   {
                                        return true;
                                   }
                              }
                         }else
                         {//Segunda mitad, no chidos
                              if (mes % 2 == 1)
                              {
                                   if (dia <= 30)
                                   {
                                        return true;

                                   }
                              }
                              else
                              {
                                   if (dia <= 31)
                                   {
                                        return true;
                                   }
                              }
                         }
                    }
               }
               return false;
          }

          public Boolean buscarEmpleado(int id) {
               string query = "select * from employees where EmployeeId=" + id;
               SqlDataReader reader= consultar(query);
               int empleadoId=0;
               if (reader != null) {
                    if (!reader.HasRows) {
                         MessageBox.Show("El empleado no existe", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                         reader.Close();
                         getJefes();
                         return false;
                    }

                    while (reader.Read()) {
                         empleadoId = (int)reader["EmployeeID"];
                         foreach (Control c in Controls) {
                              if (hash.ContainsKey(c.TabIndex-1)) {
                                   c.Text = ""+reader[hash.ElementAt(c.TabIndex-1).Value];
                              }
                         }
                    }
                    //Cerramos el maldito reader
                 
                    reader.Close();
                    getJefes(empleadoId);
                    return true;
               }
               MessageBox.Show("El empleado no existe", "Error",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
               getJefes();
               return false;
          }

          private void button1_Click(object sender, EventArgs e)
          {
          
          }

          private void button2_Click(object sender, EventArgs e)
          {
               limpiar();
          }

          private void radioButton2_CheckedChanged(object sender, EventArgs e)
          {
               newOne = false;
               limpiar();
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
            newOne = true;
            limpiar();
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
            
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
                    TextBox textbox = (TextBox)sender;
               if (newOne)
               {
                    validacionDesign(textbox, true);
                    return;}
               else {

                    int id;
                    int.TryParse(textbox.Text, out id);
                    if (id > 0)
                    {
                         if (!buscarEmpleado(id))
                         {
                              limpiar();
                         }
                    }
                    else { validacionDesign(textbox, false); }

               }
          }

          private void textBox1_Leave(object sender, EventArgs e)
          {
               
          }

          private void textBox2_Leave(object sender, EventArgs e)
          {
               
          }

          private void textBox3_Leave(object sender, EventArgs e)
          {
              
          }

          private void textBox5_Leave(object sender, EventArgs e)
          {
              
          }

          private void textBox6_Leave(object sender, EventArgs e)
          {
               
          }

          private void textBox7_Leave(object sender, EventArgs e)
          {
          }

          private void textBox8_Leave(object sender, EventArgs e)
          {
          }

          private void textBox9_Leave(object sender, EventArgs e)
          {
          }

          private void textBox10_Leave(object sender, EventArgs e)
          {
          }

          private void label12_Click(object sender, EventArgs e)
          {

          }

          private void textBox11_TextChanged(object sender, EventArgs e)
          {

          }

          private void label13_Click(object sender, EventArgs e)
          {

          }

          private void textBox12_TextChanged(object sender, EventArgs e)
          {

          }

          private void label14_Click(object sender, EventArgs e)
          {

          }

          private void label16_Click(object sender, EventArgs e)
          {

          }

          private void textBox12_Leave(object sender, EventArgs e)
          {
               Console.WriteLine();
               validacionDesign((TextBox)sender, validarFecha((TextBox)sender));
          }

          private void validacionDesign(TextBox textbox, bool passed) {
               if (passed) {
                    textbox.BackColor = Color.White;
                    textbox.ForeColor = Color.Black;
               }
               else { 
                    textbox.BackColor = Color.Red;
                    textbox.ForeColor = Color.White;
               }
          }

          private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
          {
               ComboBox combo = (ComboBox)sender;
               
          }

          private void button3_Click(object sender, EventArgs e)
          {
               Form2 form2 = new Form2();
               form2.Show();
          }
     }
}
