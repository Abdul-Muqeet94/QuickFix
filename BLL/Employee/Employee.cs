using Fixit.Models;
using Fixit.Request_and_Responses;
using Fixit.Request_and_Responses.Employee;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Fixit.Request_and_Responses.Service;
using Fixit.Request_and_Responses.Shifts;

namespace Fixit.BLL
{
    public class Employee
    {
         private readonly FixitContext _db;
        public Employee(FixitContext context)
        {
            _db=context;
        }
        public BaseResponse createEmployee(EmployeeReq req)
        {
            BaseResponse toReturn=new BaseResponse();
            var db=_db;
               Models.Employee emp= new Models.Employee{
                    name=req.name,
                    email=req.email,
                    code=req.code,
                    contactNo=req.contactNo,
                    emiratesId=req.emiratesId,
                    nationality=req.nationality,
                    address=req.address,
                    status=req.status,
                    skill=req.skill,
                    enable=true
                };
                db.employee.Add(emp);
            foreach (var entity in req.typeId)
            {
               var _service= db.services.Where(m=>m.id==entity).FirstOrDefault();
                db.employeeService.Add(
                    new EmployeeService{
                        service=_service,
                        employee=emp
                    }
                    
                );
            }
            foreach(var entity in req.shifts)
            {
                var shift=db.shifts.Where(m=>m.id==entity).FirstOrDefault();
                db.employeeShift.Add(
                    new EmployeeShift
                    {
                        shifts=shift,
                        employee=emp
                        
                    }
                );
            }
            if(db.SaveChanges()>0)
            {
                toReturn.developerMessage="Employee Added Successfully";
                toReturn.status=1;
            }
            else
            {
                toReturn.developerMessage="unable to add employee";
                toReturn.status=-1;
            }
            return toReturn;
        }

        public BaseResponse editEmployee(EmployeeReq req)
        {
            BaseResponse toReturn=new BaseResponse();
            var db=_db;
            var employee=db.employee.Where(c=>c.id==req.id && c.enable==true).FirstOrDefault();
            List<Services> services=new List<Services>();
            
            employee.email = req.email;
            employee.name = req.name;
            employee.code = req.code;
            employee.contactNo = req.contactNo;
            employee.emiratesId = req.emiratesId;
            employee.nationality = req.nationality;
            employee.address=req.address;
            employee.status = req.status;
            employee.skill=req.skill;
            employee.service.Clear();
            var toRemoveServices=db.employeeService.Where(m=>m.employee==employee).ToList();
            db.employeeService.RemoveRange(toRemoveServices);
            var shift=db.employeeShift.Where(m=>m.employee==employee).ToList();
            db.employeeShift.RemoveRange(shift);
            db.SaveChanges();

            foreach (var entity in req.typeId)
            {
                var service=db.services.Where(m=>m.id==entity).FirstOrDefault();
                db.employeeService.Add(
                    new EmployeeService{
                        service=service,
                        employee=employee
                    }
                 );
            }
             foreach(var entity in req.shifts)
            {
                var _shift=db.shifts.Where(m=>m.id==entity).FirstOrDefault();
                db.employeeShift.Add(
                    new EmployeeShift{
                        employee=employee,
                        shifts=_shift
                    }
                );
            }
            if(db.SaveChanges()>0)
            {
                toReturn.developerMessage= "Employee edit successfully";
                toReturn.status=1;
            }
            else
            {
                toReturn.developerMessage="unable to edit employee ";
                toReturn.status=-1;
            }
            return toReturn;
        }
        public List<EmployeeRes> getEmployeeByShift (int id)
        {
            var db=_db;
            List<EmployeeRes> toReturn =new List<EmployeeRes>();
            List<Models.Employee> getEmp=new List<Models.Employee>();
            var shiftEmployee=db.employeeShift.Where(m=>m.shiftsId==id).Include(m=>m.employee).ToList();
            foreach(var emp in shiftEmployee)
            {
                getEmp.Add(emp.employee);
            }
            
            foreach(var entity in getEmp)
            {
                toReturn.Add(new EmployeeRes{
                    id=entity.id,
                    name=entity.name,
                    nationality=entity.nationality,
                    email=entity.email,
                    status=entity.status,
                    code=entity.code,
                    contactNo=entity.contactNo,
                    emiratesId=entity.emiratesId,
                    skill=entity.skill
                });
            }
            return toReturn;
        }
        public List<EmployeeRes> getEmployee (int id)
        {
            List< EmployeeRes> toReturn=new List<EmployeeRes>();
            List<Models.Employee> getEmp=new List<Models.Employee>();
            var db=_db;
            if(id==0)
            {
                 getEmp=db.employee.Where(c=>c.enable==true).Include(m=>m.employee_shift).ThenInclude(m=>m.shifts)
                 .Include(c=>c.service).ThenInclude(m=>m.service).ToList();
                 
            }
            else
            {
                getEmp=db.employee.Where(c=>c.id==id && c.enable==true).Include(m=>m.employee_shift).ThenInclude(m=>m.shifts)
                .Include(m=>m.service).ThenInclude(m=>m.service).ToList();
            }
            for (int i=0;i<getEmp.Count;i++)
            {
                EmployeeRes res=new EmployeeRes();
                foreach(var entity in getEmp[i].service)
                {
                    res.typeId.Add(new ServiceRes{
                        id=entity.service.id,
                        name=entity.service.name
                    });
                }
                foreach(var items in getEmp[i].employee_shift)
                {
                    res.shift.Add(new ShiftRes{
                        id=items.shifts.id,
                        name=items.shifts.name,
                        sTime=items.shifts.sTime.ToString(),
                        eTime=items.shifts.eTime.ToString()
                    });
                }
                res.id=getEmp[i].id;
                res.name=getEmp[i].name;
                res.email=getEmp[i].email;
                res.status=getEmp[i].status;
                res.code=getEmp[i].code;
                res.contactNo=getEmp[i].contactNo;
                res.emiratesId=getEmp[i].emiratesId;
                res.nationality=getEmp[i].nationality;
                res.enable=getEmp[i].enable;
                res.address=getEmp[i].address;
                res.skill=getEmp[i].skill;
                toReturn.Add(res) ;
                
            }
            return toReturn; 
        }
        
        public BaseResponse deleteemployee (int id)
        {
            BaseResponse toReturn =new BaseResponse ();
            var db=_db;
            var employee=db.employee.Find(id);
            employee.enable=false;
            if(db.SaveChanges()>0)
            {
                toReturn.developerMessage="employee deleted successfully";
                toReturn.status=1;
            }
            else
            {
                toReturn.developerMessage="unable to delte employee";
                toReturn.status=-1;
            }
            return toReturn;
        }
    }
}