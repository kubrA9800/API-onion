using Domain.Models;
using Service.DTOs.Employee;
using Service.Responces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllAsync();
        Task CreateAsync(EmployeeCreateDto request);
        Task<BaseResponce> DeleteAsync(int? id);
    }
}
