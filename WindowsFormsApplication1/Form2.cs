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
     public partial class Form2 : Form
     {
          String[] columns = new String[] { "EmployeeID", "FirstName", "Address", "ReportsTo" };

          public Form2()
          {
               InitializeComponent();
              
          }

          private void Form2_Load(object sender, EventArgs e)
          {

          }

          public void llenarTabla(String query) {
               SqlDataAdapter adapter;

               try
               {
                    adapter = new SqlDataAdapter(query, Connexion.getConnection());
                    DataTable dt = new DataTable();
                    dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;


               }
               catch (Exception e) {
               }
          }

          public void buscar()
          {
               String query = "Select * from employees where 1=1 ";
               
               foreach (Control control in Controls)
               {
                    if (control.TabIndex<=4 &&control.TabIndex>0)
                         if (control.Text.Length > 0)
                         {
                              Console.WriteLine(control.TabIndex);
                              if (control.TabIndex == 1) {
                                   query += " and " + columns.ElementAt(0) + "=" + control.Text;
                              }
                              else if (control.TabIndex == 2) 
                              {
                                   query += " and ( " + columns.ElementAt(control.TabIndex-1) + " like '%" + control.Text + "%' or  LastName like '%" + control.Text + "%') ";
                              }
                              else
                              {
                                   query += " and " + columns.ElementAt(control.TabIndex-1) + " like '%" + control.Text + "%' ";
                              }
                              
                         }
               }
               Console.WriteLine(query);
               llenarTabla(query);



          }

          private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
          {

          }

          private void button1_Click(object sender, EventArgs e)
          {
               buscar();
          }
     }
}
