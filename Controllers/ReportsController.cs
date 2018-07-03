using Fixit.Models;
using Fixit.BLL.Reports;
using Fixit.Request_and_Responses;
using Fixit.Request_and_Responses.Reports;
using Microsoft.AspNetCore.Mvc;
using Fixit.Request_and_Responses.Task;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;

namespace Fixit.Controllers
{
    public class ReportsController:BaseController
    {
          public ReportsController(Fixit.Models.FixitContext context):base(context)
          {}

        [Route("api/report/taskview"), HttpPost]
        public List<TaskRes> addService([FromBody] ReportReq req) => new BLL.Reports.Reports(_db).getTask(req);
    }
}