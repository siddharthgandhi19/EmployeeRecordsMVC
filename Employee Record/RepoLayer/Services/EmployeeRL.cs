using CommonLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RepoLayer.Services
{
    public class EmployeeRL : IEmployeeRL
    {
        string connectionString;

        public EmployeeRL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("MVCProjectDB");
        }
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> lstemployee = new List<EmployeeModel>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    EmployeeModel employee = new EmployeeModel();

                    employee.EmployeeId = Convert.ToInt32(rdr["EmployeeID"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.City = rdr["City"].ToString();

                    lstemployee.Add(employee);
                }
                con.Close();
            }
            return lstemployee;
        }

        public EmployeeModel AddEmployee(EmployeeModel employeeModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", employeeModel.Name);
                cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                cmd.Parameters.AddWithValue("@Department", employeeModel.Department);
                cmd.Parameters.AddWithValue("@City", employeeModel.City);

                con.Open();
                var result = cmd.ExecuteNonQuery();
                con.Close();

                if (result > 0)
                {
                    return employeeModel;
                }
                else
                {
                    return null;
                }
            }
        }

        public EmployeeModel UpdateEmployee(EmployeeModel employeeModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", employeeModel.EmployeeId);
                cmd.Parameters.AddWithValue("@Name", employeeModel.Name);
                cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                cmd.Parameters.AddWithValue("@Department", employeeModel.Department);
                cmd.Parameters.AddWithValue("@City", employeeModel.City);

                con.Open();
                var result = cmd.ExecuteNonQuery();
                con.Close();

                if (result > 0)
                {
                    return employeeModel;
                }
                else
                {
                    return null;
                }
            }
        }

        public EmployeeModel GetEmployeeData(int EmployeeId)
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spGetEmpById", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeId", EmployeeId);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            employeeModel.EmployeeId = Convert.ToInt32(rd["EmployeeId"]);
                            employeeModel.Name = rd["Name"].ToString();
                            employeeModel.Gender = rd["Gender"].ToString();
                            employeeModel.Department = rd["Department"].ToString();
                            employeeModel.City = (rd["City"]).ToString();
                        }
                    }
                    con.Close();
                }
                return employeeModel;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool DeleteEmployee(int EmployeeId)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", EmployeeId);

                con.Open();
                var result = cmd.ExecuteNonQuery();
                con.Close();

                if (result > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
