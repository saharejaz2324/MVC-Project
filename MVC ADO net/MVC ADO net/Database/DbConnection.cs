using MVC_ADO_net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ADO_net.Database
{
    public class DbConnection
    {
        private static string sqlDataSource = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeesData;Trusted_Connection=True;";

        public List<Employees> getEmployees(string query)
        {
            List<Employees> employeeList = new List<Employees>();

            try
            {
                using (SqlConnection con = new SqlConnection(sqlDataSource))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var employee = new Employees();

                        employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                        employee.Name = rdr["Name"].ToString();
                        employee.Gender = rdr["Gender"].ToString();
                        employee.Age = Convert.ToInt32(rdr["Age"]);
                        employee.Position = rdr["Position"].ToString();
                        employee.Office = rdr["Office"].ToString();
                        employee.HireDate = Convert.ToDateTime(rdr["HireDate"]);
                        employee.Salary = Convert.ToInt32(rdr["Salary"]);
                        employeeList.Add(employee);
                    }
                }
                return employeeList;
            }
            catch (SqlException sq)
            {
                throw sq;
            }  
        }
    }
}
