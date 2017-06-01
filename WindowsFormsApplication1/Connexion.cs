using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
     class Connexion
     {
          private static SqlConnection sqcon;
          private static String connectionString = "server=localhost\\SQLEXPRESS ; database=Northwind ; integrated security = true";

          public static SqlConnection getConnection() {
               if (sqcon == null) {
                    try
                    {
                         sqcon = new SqlConnection(connectionString);
                         sqcon.Open();

                    }
                    catch (SqlException ex)
                    {
                         Console.WriteLine("HAy error en algo");
                    }
                    catch (Exception ex)
                    {
                    }
               }
               return sqcon;
          }

     }
}
