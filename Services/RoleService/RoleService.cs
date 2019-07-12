using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ZILDING_CORE.Models;

namespace ZILDING_CORE.Services
{
    public class RoleService : IRoleService
    {
        private readonly ZildingDBContext _db;
        private readonly IHostingEnvironment _env;

        public RoleService(ZildingDBContext db, IHostingEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IEnumerable<dynamic> GetData(String cmdText)
        {
            using (var ctx = new ZildingDBContext())
            {
                var loggedInUser = new SqlParameter("@OrgLvlId", 1);

                var dbResults = ctx.RolesList
                    .FromSql("EXECUTE sp_get_rolesby_orglvlid  @OrgLvlId", loggedInUser)
                   .ToList();
            }

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{_env.EnvironmentName}.json", optional: true);
            var connectionStringConfig = builder.Build();
            using (var connection = new SqlConnection(connectionStringConfig.GetConnectionString("sqlServerConnection:connectionString")))
            {
                connection.Open();

                using (var command = new SqlCommand(cmdText, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        var fields = new List<String>();

                        for (var i = 0; i < dataReader.FieldCount; i++)
                        {
                            fields.Add(dataReader.GetName(i));
                        }

                        while (dataReader.Read())
                        {
                            var item = new ExpandoObject() as IDictionary<String, Object>;

                            for (var i = 0; i < fields.Count; i++)
                            {
                                item.Add(fields[i], dataReader[fields[i]]);
                            }

                            yield return item;
                        }
                    }
                }
            }
        }

        //    public bool InsertSalary_Details(InsertSalary_Details obj)
        //{

        //    var connection = (SqlConnection)context.Database.AsSqlServer().Connection.DbConnection;

        //    var command = connection.CreateCommand();
        //    command.CommandType = CommandType.StoredProcedure;
        //    command.CommandText = "MySproc";
        //    command.Parameters.AddWithValue("@MyParameter", 42);

        //    command.ExecuteNonQuery();
        //    bool res = false;
        //    SqlCommand SqlCmd = new SqlCommand("sp_InsertSalaryDetails");
        //    SqlCmd.CommandType = CommandType.StoredProcedure;
        //    SqlCmd.Parameters.AddWithValue("@ManpowerId", obj.ManpowerId);
        //    SqlCmd.Parameters.AddWithValue("@sal_Year", obj.sal_Year);
        //    SqlCmd.Parameters.AddWithValue("@sal_Month", obj.sal_Month);
        //    SqlCmd.Parameters.AddWithValue("@SalaryDetails", obj.SalaryDetails);
        //    SqlCmd.Parameters.AddWithValue("@CreatedBy", obj.ActionBy);
        //    int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
        //    if (result != Int32.MaxValue)
        //    {
        //        res = true;
        //    }
        //    return res;
        //}

     
      
    }
}
