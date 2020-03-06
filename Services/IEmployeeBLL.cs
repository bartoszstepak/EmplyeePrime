using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud_2.Models;
using Microsoft.AspNetCore.Http;

namespace crud_2.Controllers.BLL
{
    public interface IEmployeeBLL
    {
        IEnumerable<EmployeeListDTO> getAllEmployeesList();
        EmployeeDTO getEmployeeById(int id);
        Task<bool> createEmployeeAsync(Employee employee);
        Task<bool> updateEmployeeDetailsAsync(EmployeeDTO newEmployee, int id);
        Task<bool> removeEmployeeAsync(int id);
        string getEmployeeImage(int id);
        Task<bool> uploadImageAsync(HttpRequest request, int id);
        EmployeeDTO getEmplyeeByEmail(string email);

    }
}
