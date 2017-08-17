using Fixit.Models;
using Fixit.Request_and_Responses;
using Fixit.Request_and_Responses.Employee;
using Fixit.BLL;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Fixit.Request_and_Responses.Task;
using Fixit.Request_and_Responses.Reports;

namespace Fixit.Controllers
{
    public class TaskController : BaseController
    {
        public TaskController(FixitContext context) : base(context)
        {
        }

        [Route("api/task/create"), HttpPost]
        public BaseResponse addTask([FromBody] TaskReq req)
        {
            return new BLL.Task(_db).createTask(req);
        }
        [Route("api/task/edit"), HttpPost]
        public BaseResponse editTask([FromBody] TaskReq req)
        {
            return new BLL.Task(_db).createTask(req);
        }
        [Route("api/task/view"), HttpPost]
        public List<TaskRes> viewTask([FromBody] int id)
        {
            return new BLL.Task(_db).getTask(id);
        }
         [Route("api/task/viewassigntask"), HttpPost]
        public List<TaskRes> viewAssignTask([FromBody] int id)
        {
            return new BLL.Task(_db).getAssignedTask(id);
        }
        [Route("api/task/viewcompletedtask"), HttpPost]
        public List<TaskRes> viewCompletedTask([FromBody] int id)
        {
            return new BLL.Task(_db).getCompletedTask(id);
        }
         [Route("api/task/viewcancelledtask"), HttpPost]
        public List<TaskRes> viewCancelledTask([FromBody] int id)
        {
            return new BLL.Task(_db).getCancelledTask(id);
        }
         [Route("api/task/viewforassign"), HttpPost]
        public List<TaskAssignRes> viewforAssignTask([FromBody] int id)
        {
            return new BLL.Task(_db).getForViewTask(id);
        }
         [Route("api/task/toassignview"), HttpPost]
        public List<TaskRes> toAssignView([FromBody] int id)
        {
            return new BLL.Task(_db).getToAssigned(id);
        }
        [Route("api/task/delete"), HttpPost]
        public BaseResponse deleteTask([FromBody] int id)
        {
            return new BLL.Task(_db).deletetask(id);
        }
         [Route("api/task/complete"), HttpPost]
        public BaseResponse completeTask([FromBody] CompleteTaskReq req)
        {
            return new BLL.Task(_db).completeTask(req);
        }
        [Route("api/task/cancel"), HttpPost]
        public BaseResponse cancelTask([FromBody] CompleteTaskReq req)
        {
            return new BLL.Task(_db).cancelTask(req);
        }
        [Route("api/task/assignEmployee"), HttpPost]
        public BaseResponse assignTask([FromBody] AssignReq req)
        {
            return new BLL.Task(_db).assigntask(req);
        }
        [Route("api/task/updateAssignedEmployee"), HttpPost]
        public BaseResponse updateAssignedTask([FromBody] AssignReq req)
        {
            return new BLL.Task(_db).updateAssignedTask(req);
        }
         [Route("api/task/sendemail"), HttpPost]
        public BaseResponse sendemail([FromBody] EmailReq req)
        {
            return new BLL.Task(_db).sendEmail(req);
        }

        
        // /api/task/sendemail 
    }

}