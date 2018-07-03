using Fixit.Models;
using Fixit.Request_and_Responses;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Fixit.Request_and_Responses.Service;
using Microsoft.AspNetCore.Cors;

namespace Fixit.Controllers
{
    public class ServiceController:BaseController
    {
        public ServiceController(FixitContext context):base(context)
        {

        }   
        
        [Route("api/service/create"), HttpPost]
        public BaseResponse addService ([FromBody] ServiceReq serviceReq)
        {
            return new BLL.Service(_db).createService(serviceReq);
        }
        
        [Route("api/service/edit"), HttpPost]
        public BaseResponse editService ([FromBody] ServiceReq serviceReq)
        {
            return new BLL.Service(_db).editService(serviceReq);
        }
        
         [Route("api/service/view"), HttpPost]
        public List<ServiceRes> viewService ([FromBody] int id)
        {
            return new BLL.Service(_db).getService(id);
        }
        [Route("api/service/delete"), HttpPost]
        public BaseResponse deleteService ([FromBody] int id)
        {
            return new BLL.Service(_db).deleteService(id);
        }
    }

}