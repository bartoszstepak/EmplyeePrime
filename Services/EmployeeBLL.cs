using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using crud_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace crud_2.Controllers.BLL
{
    public class EmployeeBLL : IEmployeeBLL
    {
        private EmployeeContext _context;
        private IMapper _mapper;

        public EmployeeBLL(EmployeeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<EmployeeListDTO> getAllEmployeesList() {
            IEnumerable<Employee> employees = _context.Employees.ToList();
            return _mapper.Map<EmployeeListDTO[]>(employees);
        }

        public EmployeeDTO getEmployeeById(int id) {
            var employee = _context.Employees.Find(id);
            return _mapper.Map<EmployeeDTO>(employee);
        }


        public EmployeeDTO getEmplyeeByEmail(string email)
        {
            var query = from empl in _context.Employees select empl;
            var employeesList = query.ToList();
            var resultEmployee = employeesList.Where(empl => empl.login == email).Select(empl => empl).FirstOrDefault();

            EmployeeDTO employee = new EmployeeDTO();
            employee.id = resultEmployee.id;
            employee.login = resultEmployee.login;

            return employee;
        }


        public async Task<bool> createEmployeeAsync(Employee employee) {
            if (!await _context.Employees.AnyAsync(empl => empl.login == employee.login))
            {

                _context.Employees.Add(employee);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        public async Task<bool> updateEmployeeDetailsAsync(EmployeeDTO newEmployee, int id) {
            var employee = _context.Employees.First(e => e.id == newEmployee.id);
            employee.login = newEmployee.login;
            employee.secondName = newEmployee.secondName;
            employee.firstName = newEmployee.firstName;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> removeEmployeeAsync(int id) {
            var employee = _context.Employees.Find(id);
            if (employee == null) {
                return false;
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }

        public String getEmployeeImage(int id) {
            var employee = _context.Employees.Find(id);
            if (employee.image != null) {
                return Convert.ToBase64String(employee.image, 0, employee.image.Length);
            }
            return null;
        }

        public async Task<bool> uploadImageAsync(HttpRequest request, int id)
        {
            var file = request.Form.Files[0];
            var filePath = Path.GetTempFileName();
            foreach (var formFile in request.Form.Files) {
                if (formFile.Length > 0) {
                    var employee = _context.Employees.Find(id);
                    using (var inputStream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(inputStream);
                        byte[] array = new byte[inputStream.Length];
                        inputStream.Seek(0, SeekOrigin.Begin);
                        inputStream.Read(array, 0, array.Length);
                        string fName = formFile.FileName;
                        employee.image = array;

                        try
                        {
                            await _context.SaveChangesAsync();
                            return true;
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            return false;
                        }

                    }
                }
            }
            return false;
        }
    }
}
