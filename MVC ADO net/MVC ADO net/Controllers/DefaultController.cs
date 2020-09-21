using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_ADO_net.Database;
using MVC_ADO_net.Models;

namespace MVC_ADO_net.Controllers
{
    public class DefaultController : Controller
    {
        DbConnection db = new DbConnection();
        public IActionResult Index()
        {
            string query = "SELECT * FROM Employees";
            List<Employees> employeeList;

            employeeList = db.getEmployees(query);

            return View(employeeList);
        }
    }
}