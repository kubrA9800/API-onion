using AutoMapper;
using Domain.Models;
using Repository.Repositories.Interfaces;
using Service.DTOs.Employee;
using Service.Responces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepo, IMapper mapper) 
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }
        public Task CreateAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(EmployeeCreateDto request)
        {
            await _employeeRepo.CreateAsync(_mapper.Map<Employee>(request));
        }

        public async Task<BaseResponce> DeleteAsync(int? id)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(id);
                var data = await _employeeRepo.GetAsync(id);
                await _employeeRepo.DeleteAsync(data);  
                return new BaseResponce { IsSuccess = true, ErrorMessage=null };
            }
            catch (Exception ex)
            {

                return new BaseResponce { IsSuccess = false, ErrorMessage=ex.Message };
            }
        }

        public async Task<List<EmployeeDto>> GetAllAsync()
        {
           return _mapper.Map<List<EmployeeDto>>(await _employeeRepo.GetAllAsync());
        }


    }
}
