using System.Data;
using System.Data.SqlClient;

namespace TomTang.DbAccess
{
    /// <summary>
    ///���Ѩt�ΩҦ��ݭn���U�� SQL �ާ@�A�ȡC
    /// </summary>
    public class MSSqlOperator : DBOperatorBase
    {
        internal MSSqlOperator(string ConnectionString)
        {
            connection = new SqlConnection(ConnectionString);
            CreateCommands();
        }

        public override void Fill(DataTable dt)
        {
            SqlDataAdapter oAdapter = (SqlDataAdapter)GetPreparedDbAdapter();
            oAdapter.Fill(dt);
        }


        public override void Update(DataTable dt)
        {
            SqlDataAdapter oAdapter = (SqlDataAdapter)GetPreparedDbAdapter();
            oAdapter.Update(dt);
        }

        protected override IDbDataAdapter GetDBAdapter()
        {
            return new SqlDataAdapter();
        }
    }
}
