using Fixit.Models;
using System.Collections.Generic;
using System.Linq;
using Fixit.Request_and_Responses;
using Fixit.Request_and_Responses.Shifts;
using System;
using Microsoft.EntityFrameworkCore;
using Fixit.Request_and_Responses.Employee;

namespace Fixit.BLL
{
    public static class MyDateTimeUtil
    {
        public static DateTime CreateDateFromTime(int year, int month, int day, DateTime time)
        {
            return new DateTime(year, month, day, time.Hour, time.Minute, 0);
        }
    }
    public class Shifts
    {
        private readonly FixitContext _db;
        public Shifts(FixitContext context)
        {
            _db = context;
        }
        
        public List<shiftViewRes> getShiftForTask(ShiftFilter req)
        {
            List<shiftViewRes> toReturn=new List<shiftViewRes>();
            List<Models.Shifts> shifts=new List<Models.Shifts>();
            List<EmployeeShift> employeeshift=new List<EmployeeShift>();
            int day=(int)req.date.DayOfWeek;
            var db=_db;
            var service=db.services.Where(m=>m.name==req.name).Include(m=>m.employees).ThenInclude(m=>m.employee).ThenInclude(m=>m.employee_shift).ThenInclude(m=>m.shifts).FirstOrDefault();
            var employee=service.employees;
            switch(day)
            {
                case 1:
                
                foreach(var shift in employee)
                {
                    
                    foreach (var items in shift.employee.employee_shift)
                    {
                        if(items.shifts.day1==true && items.shifts.enable==true )
                        {
                            if(shifts.Contains(items.shifts))
                            {
                                continue;
                            }
                            else
                            {
                                shifts.Add(items.shifts);
                            }
                            
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                
                break;
                case 2:
                foreach(var shift in employee)
                {
                    
                    foreach (var items in shift.employee.employee_shift)
                    {
                        if(items.shifts.day2==true && items.shifts.enable==true )
                        {
                             if(shifts.Contains(items.shifts))
                            {
                                continue;
                            }
                            else
                            {
                                shifts.Add(items.shifts);
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                break;
                case 3:
                foreach(var shift in employee)
                {
                    
                    foreach (var items in shift.employee.employee_shift)
                    {
                        if(items.shifts.day3==true && items.shifts.enable==true )
                        {
                             if(shifts.Contains(items.shifts))
                            {
                                continue;
                            }
                            else
                            {
                                shifts.Add(items.shifts);
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                break;
                case 4:
                foreach(var shift in employee)
                {
                    
                    foreach (var items in shift.employee.employee_shift)
                    {
                        if(items.shifts.day4==true && items.shifts.enable==true )
                        {
                             if(shifts.Contains(items.shifts))
                            {
                                continue;
                            }
                            else
                            {
                                 if(shifts.Contains(items.shifts))
                            {
                                continue;
                            }
                            else
                            {
                                shifts.Add(items.shifts);
                            }
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                break;
                case 5:
                foreach(var shift in employee)
                {
                    
                    foreach (var items in shift.employee.employee_shift)
                    {
                        if(items.shifts.day5==true && items.shifts.enable==true )
                        {
                             if(shifts.Contains(items.shifts))
                            {
                                continue;
                            }
                            else
                            {
                                shifts.Add(items.shifts);
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                break;
                case 6:
                foreach(var shift in employee)
                {
                    
                    foreach (var items in shift.employee.employee_shift)
                    {
                        if(items.shifts.day6==true && items.shifts.enable==true )
                        {
                             if(shifts.Contains(items.shifts))
                            {
                                continue;
                            }
                            else
                            {
                                shifts.Add(items.shifts);
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                break;
                case 7:
                foreach(var shift in employee)
                {
                    
                    foreach (var items in shift.employee.employee_shift)
                    {
                        if(items.shifts.day7==true && items.shifts.enable==true )
                        {
                             if(shifts.Contains(items.shifts))
                            {
                                continue;
                            }
                            else
                            {
                                shifts.Add(items.shifts);
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                break;
            }
            foreach(var entity in shifts)
            {
                toReturn.Add(
                    new shiftViewRes{
                        id=entity.id,
                        time=entity.sTime.TimeOfDay+" "+entity.eTime.TimeOfDay
                    }
                );
            }
            return toReturn;
        }
        public BaseResponse createShift(ShiftReq req)
        {


            req.sTime = MyDateTimeUtil.CreateDateFromTime(2000, 01, 01, req.sTime);
            req.eTime = MyDateTimeUtil.CreateDateFromTime(2000, 01, 01, req.eTime);


            BaseResponse toReturn = new BaseResponse();
            var db = _db;
            var shift = new Models.Shifts();
            shift.name = req.name;
            shift.enable = req.enable;
            shift.eTime = req.eTime;
            shift.sTime = req.sTime;
            foreach (var entity in req.days)
            {
                shift.day1=(entity==1?true:shift.day1);
                shift.day2=(entity==2?true:shift.day2);
                shift.day3=(entity==3?true:shift.day3);
                shift.day4=(entity==4?true:shift.day4);
                shift.day5=(entity==5?true:shift.day5);
                shift.day6=(entity==6?true:shift.day6);
                shift.day7=(entity==7?true:shift.day7);
            }
            
            
            shift.enable=true;
            db.shifts.Add(shift);
            if (db.SaveChanges() > 0)
            {
                toReturn.developerMessage = "Shift Added Successfully";
                toReturn.status = 1;
                toReturn.id = shift.id;
            }
            else
            {
                toReturn.developerMessage = "unable to add Shift";
                toReturn.status = -1;
            }
            return toReturn;
        }

        public BaseResponse editShift(ShiftReq req)
        {
            BaseResponse toReturn = new BaseResponse();
            var db = _db;
            var shift = db.shifts.Where(c => c.id == req.id && c.enable == true).FirstOrDefault();
            shift.name = req.name;
            shift.eTime = req.eTime;
            shift.sTime = req.sTime;
            shift.day1=false;shift.day2=false;shift.day3=false;shift.day4=false;shift.day5=false;
            shift.day6=false;shift.day7=false;
             foreach (var entity in req.days)
            {
                
                shift.day1=(entity==1?true:shift.day1);
                shift.day2=(entity==2?true:shift.day2);
                shift.day3=(entity==3?true:shift.day3);
                shift.day4=(entity==4?true:shift.day4);
                shift.day5=(entity==5?true:shift.day5);
                shift.day6=(entity==6?true:shift.day6);
                shift.day7=(entity==7?true:shift.day7);
            }
            if (db.SaveChanges() > 0)
            {
                toReturn.developerMessage = "Shift edit successfully";
                toReturn.status = 1;
            }
            else
            {
                toReturn.developerMessage = "unable to edit Shift";
                toReturn.status = -1;
            }
            return toReturn;
        }

        public List<ShiftRes> getShift(int id)
        {
            List<ShiftRes> toReturn = new List<ShiftRes>();
            List<Models.Shifts> getShf = new List<Models.Shifts>();
            var db = _db;
            if (id == 0)
            {
                getShf = db.shifts.Where(c => c.enable == true).ToList();

            }
            else if (id == -1)
            {
                getShf = db.shifts.OrderByDescending(p => p.id).ToList();
                var model = getShf[0];
                getShf.Clear();
                getShf.Add(model);
            }
            else
            {
                getShf = db.shifts.Where(c => c.id == id && c.enable == true).ToList();
            }
            for (int i = 0; i < getShf.Count; i++)
            {
                ShiftRes res = new ShiftRes();
                res.id = getShf[i].id;
                res.name = getShf[i].name;
                res.sTime = getShf[i].sTime.TimeOfDay.ToString();
                res.eTime = getShf[i].eTime.TimeOfDay.ToString();
                res.enable = getShf[i].enable;
                
                       if(getShf[i].day1==true)
                       {
                           res.day.Add("Monday");
                       }
                        if(getShf[i].day2==true)
                       {
                            res.day.Add("Tuesday");
                       }
                        if(getShf[i].day3==true)
                       {
                           res.day.Add("Wednesday");
                       }
                        if(getShf[i].day4==true)
                        {
                            res.day.Add("Thursday");
                        }
                        if(getShf[i].day5==true)
                        {
                            res.day.Add("Friday");
                        }
                         if(getShf[i].day6==true)
                        {
                            res.day.Add("Saturday");
                        }
                         if(getShf[i].day7==true)
                        {
                            res.day.Add("Sunday");
                        }
                        toReturn.Add(res);
                }
            return toReturn;
        }

        public BaseResponse deleteShift(int id)
        {
            BaseResponse toReturn = new BaseResponse();
            var db = _db;
            var shift = db.shifts.Find(id);
            shift.enable = false;
            if (db.SaveChanges() > 0)
            {
                toReturn.developerMessage = "Shift  delete success";
                toReturn.status = 1;
            }
            else
            {
                toReturn.developerMessage = "unable to delete shift";
                toReturn.status = -1;
            }
            return toReturn;
        }

        public List<EmployeeRes> getShiftEmployees(int id)
        {
            List<EmployeeRes> toReturn=new List<EmployeeRes>();
            var db=_db;
            var shiftEmployees=db.employeeShift.Where(m=>m.shiftsId==id).Include(m=>m.employee).ToList();
            foreach (var entity in shiftEmployees)
            {
                toReturn.Add(new EmployeeRes{
                    id=entity.employee.id,
                    name=entity.employee.name
                });
            }
            return toReturn;
        }
    }
}