using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.ACCESS.LAYER.Interfaces
{
    public interface IRepository
    {
        object executeScalerWithProc(string procName, params SqlParameter[] param);
        DataTable returnDTWithProc_adapter(string procName, params SqlParameter[] param);

    }
}
