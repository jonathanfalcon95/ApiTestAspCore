using ApiTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Data
{
    public class Repository
    {
        private readonly string _connectionString;

        public Repository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("BaseContext");
        }

        //public async Task<List<Value>> GetAll()
        //{
        //    using (SqlConnection sql = new SqlConnection(_connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("GetAllValues", sql))
        //        {
        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //            var response = new List<Value>();
        //            await sql.OpenAsync();

        //            using (var reader = await cmd.ExecuteReaderAsync())
        //            {
        //                while (await reader.ReadAsync())
        //                {
        //                    response.Add(MapToValue(reader));
        //                }
        //            }

        //            return response;
        //        }
        //    }
        //}
        private object MapModel(SqlDataReader reader)
        {

            var model = new
            {
                SoftwareID = (long)reader["SoftwareID"],
                softwareName = reader["SoftwareName"].ToString(),
                HardwareID= (long)reader["HardwareID"],
                hardwareName = reader["HardwareName"].ToString()
            };
            return model;
        }


        private Hardware MapToHardware(SqlDataReader reader)
        {
            return new Hardware()
            {
                Id = 0,
                HardwareName = reader["HardwareName"].ToString(),
               
            };
        }

        public async Task<object> GetById(long Id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SelectHS", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@UserID", Id));
                    var response = new List<object>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapModel(reader));
                        }
                    }

                    return response;
                }
            }
        }

        //public async Task Insert(Value value)
        //{
        //    using (SqlConnection sql = new SqlConnection(_connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("InsertValue", sql))
        //        {
        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //            cmd.Parameters.Add(new SqlParameter("@value1", value.Value1));
        //            cmd.Parameters.Add(new SqlParameter("@value2", value.Value2));
        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();
        //            return;
        //        }
        //    }
        //}

        public async Task DeleteById(Assignment assignment)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteAss", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@userID", assignment.UserID));
                    cmd.Parameters.Add(new SqlParameter("@hardwareID", assignment.HardwareID));
                    cmd.Parameters.Add(new SqlParameter("@softwareID", assignment.SoftwareID));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }
    }
}
