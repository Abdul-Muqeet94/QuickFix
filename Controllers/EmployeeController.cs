using Fixit.Models;
using Fixit.Request_and_Responses;
using Fixit.Request_and_Responses.Employee;
using Fixit.BLL;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Fixit.Controllers
{
    public class EmployeeController:BaseController
    {
        public EmployeeController(FixitContext context):base(context)
        {

        }

        [Route("api/employee/create"), HttpPost]

        public BaseResponse addEmployee ([FromBody] EmployeeReq employee)
        {
            return new BLL.Employee(_db).createEmployee(employee);
        }
        [Route("api/employee/getemployeebyshift"),HttpPost]
        public List<EmployeeRes> getEmployee([FromBody] int shiftId)
        {
            return new BLL.Employee(_db).getEmployeeByShift(shiftId);
        }
        [Route("api/employee/edit"), HttpPost]
        public BaseResponse editEmployee ([FromBody] EmployeeReq employee)
        {
            return new BLL.Employee(_db).editEmployee(employee);
        }
         [Route("api/employee/view"), HttpPost]
        public List<EmployeeRes> viewEmployee ([FromBody] int id)
        {
            return new BLL.Employee(_db).getEmployee(id);
        }
        [Route("api/employee/delete"), HttpPost]
        public BaseResponse deleteEmployee ([FromBody] int id)
        {
            return new BLL.Employee(_db).deleteemployee(id);
        }
    }

}