using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Skaitliukai_astrus
{
    class DataLayer
    {
        public static void insertRecord(Skaitliukas s)
        {
            SqlConnection con = new SqlConnection("Server=skaitliukai.database.windows.net, 1433; Database=Skaitliukai;Uid=skaitliukai;Pwd=Loxlox123;");
            con.Open();

            String query = "INSERT INTO Skaitliukai VALUES ('" + s.Id + "', '" + s.TipoPavadinimas + "' , '" + s.Number + "', '" + s.Username + "' );";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();

            String query2 = "INSERT INTO Skaitliuko_kita_info VALUES ('" + s.Id + "','" + s.DateCreated + "' );";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.ExecuteNonQuery();
        }
    }
}
