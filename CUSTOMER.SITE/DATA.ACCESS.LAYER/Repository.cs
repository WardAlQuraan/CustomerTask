using DATA.ACCESS.LAYER.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.ACCESS.LAYER
{
    public class Repository: IRepository
    {
        public String conStrt = String.Empty;
        DataTable _dt;
        public Repository()
        {
            conStrt = ConfigurationManager.ConnectionStrings["conStr"].ToString();
            _dt = new DataTable();
        }
        public object executeScalerWithProc(string procName, params SqlParameter[] param)
        {
            using (SqlConnection conn = new SqlConnection(conStrt))
            {
                SqlCommand cmd = new SqlCommand(procName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (param != null)
                {
                    foreach (SqlParameter p in param)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        public DataTable returnDTWithProc_adapter(string procName, params SqlParameter[] param)
        {
            using (SqlConnection conn = new SqlConnection(conStrt))
            {
                SqlDataAdapter da = new SqlDataAdapter(procName, conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (param != null)
                {
                    foreach (SqlParameter p in param)
                    {
                        da.SelectCommand.Parameters.Add(p);
                    }
                }
                _dt = new DataTable();
                conn.Open();
                da.Fill(_dt);
                return _dt;

            }
        }

        public DataSet returnDSWithProc_adapter(string procName, params SqlParameter[] param)
        {
            using (SqlConnection conn = new SqlConnection(conStrt))
            {
                SqlDataAdapter da = new SqlDataAdapter(procName, conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (param != null)
                {
                    foreach (SqlParameter p in param)
                    {
                        da.SelectCommand.Parameters.Add(p);
                    }
                }
                var dataSet = new DataSet();
                conn.Open();
                da.Fill(dataSet);
                return dataSet;

            }
        }
    }
}
