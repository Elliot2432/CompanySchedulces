using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CompanySchedulces.Models;
using System.Diagnostics;

namespace CompanySchedulces.Controllers
{
    public class EmployeesDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/EmployeesData/ListEmployees
        [HttpGet]
        public IEnumerable<EmployeeDto> ListEmployees()
        {
            List<Employee> Employees = db.Employees.ToList();
            List<EmployeeDto> EmployeesDtos = new List<EmployeeDto>();

            Employees.ForEach(a => EmployeesDtos.Add(new EmployeeDto() {
                EmployeeID = a.EmployeeID,
                EmployeeFname = a.EmployeeFname,
                EmployeeLname = a.EmployeeLname,
                EmployeePNumber = a.EmployeePNumber,
                EmployeePos = a.EmployeePos,
                EmployeeNum = a.EmployeeNum,
                Hired_date = a.Hired_date,
                EmployeeTypeOfHours = a.EmployeeTypeOfHours,
                EmployeeSalary = a.EmployeeSalary
            }));
            return EmployeesDtos;

        }

        // GET: api/EmployeesData/FindEmployee/5
        [ResponseType(typeof(Employee))]
        [HttpGet]
        public IHttpActionResult FindEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            EmployeeDto EmployeeDto = new EmployeeDto()
            {
                EmployeeID = employee.EmployeeID,
                EmployeeFname = employee.EmployeeFname,
                EmployeeLname = employee.EmployeeLname,
                EmployeePNumber = employee.EmployeePNumber,
                EmployeePos = employee.EmployeePos,
                EmployeeNum = employee.EmployeeNum,
                Hired_date = employee.Hired_date,
                EmployeeTypeOfHours = employee.EmployeeTypeOfHours,
                EmployeeSalary = employee.EmployeeSalary
            };
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(EmployeeDto);
        }

        // POST: api/EmployeesData/UpdateEmployee/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateEmployee(int id, Employee employee)
        {
            Debug.WriteLine("I have reached the update animal method!");
            if (!ModelState.IsValid)
            {
                Debug.WriteLine("Model State is invaild");
                return BadRequest(ModelState);
            }

            if (id != employee.EmployeeID)
            {
                Debug.WriteLine("ID mismatch");
                Debug.WriteLine("GET parameter" + id);
                Debug.WriteLine("POST parameter" + employee.EmployeeID);
                Debug.WriteLine("POST parameter" + employee.EmployeeFname);
                Debug.WriteLine("POST parameter" + employee.EmployeeLname);
                Debug.WriteLine("POST parameter" + employee.EmployeePNumber);
                Debug.WriteLine("POST parameter" + employee.EmployeePos);
                Debug.WriteLine("POST parameter" + employee.EmployeeNum);
                Debug.WriteLine("POST parameter" + employee.Hired_date);
                Debug.WriteLine("POST parameter" + employee.EmployeeTypeOfHours);
                Debug.WriteLine("POST parameter" + employee.EmployeeSalary);
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    Debug.WriteLine("Employee Not Found");
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            Debug.WriteLine("None of the conditions triggered");
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EmployeesData/AddEmployee
        [ResponseType(typeof(Employee))]
        [HttpPost]
        public IHttpActionResult AddEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employees.Add(employee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee.EmployeeID }, employee);
        }

        // POST: api/EmployeesData/DeleteEmployee/5
        [ResponseType(typeof(Employee))]
        [HttpPost]
        public IHttpActionResult DeleteEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.Employees.Remove(employee);
            db.SaveChanges();

            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.Employees.Count(e => e.EmployeeID == id) > 0;
        }
    }
}