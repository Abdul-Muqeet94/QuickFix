using Fixit.Models;
using Fixit.Request_and_Responses;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Fixit.Request_and_Responses.Service;
using Fixit.Request_and_Responses.Shifts;
using System;
using Fixit.Request_and_Responses.Employee;

namespace Fixit.Controllers
{
    public class ShiftController:BaseController
    {
        public ShiftController(FixitContext context):base(context)
        {

        }

        [Route("api/shift/create"), HttpPost]
        public BaseResponse addShift ([FromBody] ShiftReq shiftReq)
        {
            return new BLL.Shifts(_db).createShift(shiftReq);
        }
        [Route("api/shift/edit"), HttpPost]
        public BaseResponse editShift ([FromBody] ShiftReq shiftReq)
        {
            return new BLL.Shifts(_db).editShift(shiftReq);
        }
         [Route("api/shift/view"), HttpPost]
        public List<ShiftRes> viewShift ([FromBody] int id)
        {
            return new BLL.Shifts(_db).getShift(id);
        }
        [Route("api/shift/delete"), HttpPost]
        public BaseResponse deleteShift ([FromBody] int id)
        {
            return new BLL.Shifts(_db).deleteShift(id);
        }
        [Route("api/shift/getshiftfortask"), HttpPost]
        public List<shiftViewRes> getShiftForTask ([FromBody]  ShiftFilter req)
        {
            return new BLL.Shifts(_db).getShiftForTask(req);
        }
        [Route("api/shift/getshiftemployees"), HttpPost]
        public List<EmployeeRes> getShiftEmployees ([FromBody]  int id)
        {
            return new BLL.Shifts(_db).getShiftEmployees(id);
        }

        //getShiftForTask
    }

}