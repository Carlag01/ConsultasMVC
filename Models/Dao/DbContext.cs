using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultasMVC.Models.Dao
{
    public class DbContext
    {
        protected SqlConnection Conexion = new SqlConnection("Server=LAPTOP-QAVTDPMQ;DataBase=Tenis;Integrated Security=true");
    }
}
