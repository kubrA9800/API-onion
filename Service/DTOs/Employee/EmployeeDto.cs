using Service.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Employee
{
    public class EmployeeDto:BaseDto
    {
        
        public string FullName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
    }
}
