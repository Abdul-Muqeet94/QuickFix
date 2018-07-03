using Fixit.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fixit.Controllers
{
    
        public abstract class BaseController : Controller
    {
        protected readonly FixitContext _db;
      
       
        public BaseController (FixitContext context){
 
        _db=context;
        }
    }
    
}