using Fixit.Models;
using Fixit.Request_and_Responses;
using Fixit.Request_and_Responses.Employee;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Fixit.Request_and_Responses.EmployeeType;

namespace Fixit.BLL
{
    public class EmployeeType
    {
          private readonly FixitContext _db;
        public EmployeeType(FixitContext context)
        {
            _db=context;
        }
          public BaseResponse  createEmployeeType(EmployeeTypeReq req)
        {
            BaseResponse toReturn=new BaseResponse();
            var db=_db;
            db.employeeType.Add(
                new Models.EmployeeType{
                    name=req.name,
                    enable=true
                }
            );
            if(db.SaveChanges()>0)
            {
                toReturn.developerMessage="Employee Type Added Successfully";
                toReturn.status=1;
            }
            else
            {
                toReturn.developerMessage="unable to add employee type";
                toReturn.status=-1;
            }
            return toReturn;
        }

        public BaseResponse editEmployeeType(EmployeeTypeReq req)
        {
            BaseResponse toReturn=new BaseResponse();
            var db=_db;
            var employeeType=db.employeeType.Where(c=>c.id==req.id && c.enable==true).FirstOrDefault();
           
            employeeType.name = req.name;
            
            if(db.SaveChanges()>0)
            {
                toReturn.developerMessage= "employeeType edit successfully";
                toReturn.status=1;
            }
            else
            {
                toReturn.developerMessage="unable to edit employeeType ";
                toReturn.status=-1;
            }
            return toReturn;
        }

        public List<EmployeeTypeRes> getEmployeeType (int id)
        {
            List< EmployeeTypeRes> toReturn=new List<EmployeeTypeRes>();
            List<Models.EmployeeType> getEmp=new List<Models.EmployeeType>();
            var db=_db;
            if(id==0)
            {
                 getEmp=db.employeeType.Where(c=>c.enable==true).ToList();
                 
            }
            else
            {
                getEmp=db.employeeType.Where(c=>c.id==id && c.enable==true).ToList();
            }
            for (int i=0;i<getEmp.Count;i++)
            {
                EmployeeTypeRes res=new EmployeeTypeRes();
                res.id=getEmp[i].id;
                res.name=getEmp[i].name;
                toReturn.Add(res) ;
                
            }
            return toReturn; 
        }
        
        public BaseResponse deleteEmployeeType (int id)
        {
            BaseResponse toReturn =new BaseResponse ();
            var db=_db;
            var employeeType=db.employeeType.Find(id);
            employeeType.enable=false;
            if(db.SaveChanges()>0)
            {
                toReturn.developerMessage="employeeType deleted successfully";
                toReturn.status=1;
            }
            else
            {
                toReturn.developerMessage="unable to delte employeeType";
                toReturn.status=-1;
            }
            return toReturn;
        }
    }
}