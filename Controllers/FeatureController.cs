using Fixit.Models;
using Fixit.Request_and_Responses;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Fixit.Request_and_Responses.Service;
using Fixit.Request_and_Responses.Feature;
using Microsoft.AspNetCore.Cors;

namespace Fixit.Controllers
{
    public class FeatureController:BaseController
    {
        public FeatureController(FixitContext context):base(context)
        {

        }

        [Route("api/feature/create"), HttpPost]
        public BaseResponse addfeature ([FromBody] FeatureReq featureReq)
        {
            return new BLL.Feature(_db).createFeature(featureReq);
        }
        [Route("api/feature/edit"), HttpPost]
        public BaseResponse editFeature ([FromBody] FeatureReq featureReq)
        {
            return new BLL.Feature(_db).editFeature(featureReq);
        }
         [Route("api/feature/view"), HttpPost]
        public List<FeatureRes> viewFeature ([FromBody] int id)
        {
            return new BLL.Feature(_db).getFeature(id);
        }
        [Route("api/feature/delete"), HttpPost]
        public BaseResponse deleteFeature ([FromBody] int id)
        {
            return new BLL.Feature(_db).deleteFeature(id);
        }
    }

}