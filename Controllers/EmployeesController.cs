using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using crud_2.Models;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using crud_2.Controllers.BLL;
using crud_2.Services;

namespace crud_2.Controllers
{
    [Route("api/values")]
    [Produces("application/json")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeBLL _employeeBLL;
        private readonly ILoginBLL _loginBLL;

        public EmployeesController(
            IEmployeeBLL employeeBLL,
            ILoginBLL loginBLL
            )
        {
            _employeeBLL = employeeBLL;
            _loginBLL = loginBLL;
        }



        [HttpGet, Authorize]
        public ActionResult<IEnumerable<EmployeeListDTO>> GetEmployees()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return _employeeBLL.getAllEmployeesList().ToList();
        }


        [HttpGet("{id}"), Authorize]
        public async Task<IActionResult> GetEmployee([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = _employeeBLL.getEmployeeById(id);

            return employee == null ? NotFound() : (IActionResult)Ok(employee);
        }



        [HttpPost("upload-image/{id}"), Authorize, DisableRequestSizeLimit]
        public async Task<IActionResult> putFile([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _employeeBLL.uploadImageAsync(Request, id) ? Ok() : (IActionResult)NotFound();
        }


        [HttpGet("img/{id}"), Authorize]
        public async Task<IActionResult> getEmployeeImageAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var imageString = _employeeBLL.getEmployeeImage(id);
            return imageString != null ? Ok(imageString) : (IActionResult)NotFound();

        }


        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> updateEmployee([FromRoute] int id, [FromBody] Employee newEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newEmployee.id)
            {
                return BadRequest();
            }

            EmployeeDTO currntEmployee = _employeeBLL.getEmployeeById(id);

            Login userCredentails = new Login(newEmployee.login, newEmployee.password);
            bool updatedCredentialsStatus = await _loginBLL.updateUserCredentialsAsyns(userCredentails, currntEmployee.login);

            currntEmployee.id = newEmployee.id;
            currntEmployee.login = newEmployee.login;
            currntEmployee.firstName = newEmployee.firstName;
            currntEmployee.secondName = newEmployee.secondName;

            bool updatedSatus = await _employeeBLL.updateEmployeeDetailsAsync(currntEmployee, id);

            return updatedSatus ? NoContent() : (IActionResult)NotFound();

        }

        [HttpPost, Authorize]
        public async Task<IActionResult> addEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Login userCredentails = new Login(employee.login, employee.password);

            bool createdEmplStatus = await _employeeBLL.createEmployeeAsync(employee);
            bool createdCredentialsStatus = await _loginBLL.createUserCredentialsAsyns(userCredentails);

            return createdEmplStatus ? StatusCode(201) : NotFound();
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            EmployeeDTO empl = _employeeBLL.getEmployeeById(id);

            bool removingUserCredetialsStatus = await _loginBLL.removeUserCredentials(empl.login);
            bool removingStatus = await _employeeBLL.removeEmployeeAsync(id);

            return removingStatus ? Ok() : (IActionResult)NotFound();
        }

    }
}