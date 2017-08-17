using System.Collections.Generic;
using System.Linq;
using Fixit.Models;
using Fixit.Request_and_Responses.Feature;
using Fixit.Request_and_Responses.Reports;
using Fixit.Request_and_Responses.Service;
using Fixit.Request_and_Responses.Task;
using Microsoft.EntityFrameworkCore;

namespace Fixit.BLL.Reports
{
    public class Reports
    {
        private readonly FixitContext _db;
        public Reports(FixitContext context)
        {
            _db = context;
        }

        public List<TaskRes> getTask(ReportReq req)
        {
            List<TaskRes> toReturn =new List<TaskRes>();
            var db=_db;
            List<Fixit.Models.Task> taskList=new List<Fixit.Models.Task>();
            if(req.orderId!=0 && req.fromDate!=null && req.toDate!=null)
            {
            taskList =db.tasks.Where(m=>m.enable==true && m.id==req.orderId && m.date >=req.fromDate && m.date<=req.toDate)
            .Include(c=>c.services_employee)
                .ThenInclude(m=>m.selectedservice)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_features)
                .ThenInclude(m=>m.features)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_shift)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.employee).OrderByDescending(m=>m.id).ToList();
            }
            else{
                taskList =db.tasks.Where(m=>m.enable==true && m.date >=req.fromDate && m.date<=req.toDate)
                .Include(c=>c.services_employee)
                .ThenInclude(m=>m.selectedservice)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_features)
                .ThenInclude(m=>m.features)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_shift)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.employee).OrderByDescending(m=>m.id).ToList();
            }
             if(req.serviceId!=0 && req.employeeId==0 && req.featureId!=0)
            {
                var feature =db.selected_features.Where(m=>m.featuresid==req.featureId).FirstOrDefault();
                var task_srevice=db.task_has_employee.Where(m=>m.selectedserviceid==req.serviceId  && m.selected_features.Contains(feature)).FirstOrDefault();
                taskList=taskList.Where(m=>m.services_employee.Contains(task_srevice)).ToList();
            }
            else if(req.employeeId!=0 && req.serviceId==0 && req.serviceId!=0)
            {
                var feature =db.selected_features.Where(m=>m.featuresid==req.featureId).FirstOrDefault();
                var task_srevice=db.task_has_employee.Where(m=>m.employeeid==req.employeeId && m.selected_features.Contains(feature)).FirstOrDefault();
                taskList=taskList.Where(m=>m.services_employee.Contains(task_srevice)).ToList();
            }
            else if(req.employeeId!=0 && req.serviceId!=0 && req.serviceId!=0)
            {
                var feature =db.selected_features.Where(m=>m.featuresid==req.featureId).FirstOrDefault();
                var task_srevice=db.task_has_employee.Where(m=>m.employeeid==req.employeeId && m.selectedserviceid==req.serviceId && m.selected_features.Contains(feature)).FirstOrDefault();
                taskList=taskList.Where(m=>m.services_employee.Contains(task_srevice)).ToList();
            }
            else if(req.serviceId!=0 && req.employeeId==0 && req.featureId==0)
            {
                var task_srevice=db.task_has_employee.Where(m=>m.selectedserviceid==req.serviceId ).FirstOrDefault();
                taskList=taskList.Where(m=>m.services_employee.Contains(task_srevice)).ToList();
            }
            else if(req.employeeId!=0 && req.serviceId==0 && req.serviceId==0)
            {
                var task_srevice=db.task_has_employee.Where(m=>m.employeeid==req.employeeId ).FirstOrDefault();
                taskList=taskList.Where(m=>m.services_employee.Contains(task_srevice)).ToList();
            }
            else if(req.employeeId!=0 && req.serviceId!=0 && req.serviceId==0)
            {
                var task_srevice=db.task_has_employee.Where(m=>m.employeeid==req.employeeId && m.selectedserviceid==req.serviceId).FirstOrDefault();
                taskList=taskList.Where(m=>m.services_employee.Contains(task_srevice)).ToList();
            }
            else if(req.employeeId==0 && req.serviceId==0 && req.featureId!=0)
            {
                var feature =db.selected_features.Where(m=>m.featuresid==req.featureId).FirstOrDefault();
                var task_srevice=db.task_has_employee.Where( m=>m.selected_features.Contains(feature)).FirstOrDefault();
                taskList=taskList.Where(m=>m.services_employee.Contains(task_srevice)).ToList();
            }
            else
            {
                taskList=taskList;
            }

            for (int i = 0; i < taskList.Count; i++)
            {
                string[] words=new string[2];
                TaskRes res = new TaskRes();
                List<ServiceRes> services=new List<ServiceRes>();
                res.id = taskList[i].id;
                if(taskList[i].location!=null)
                {
                    words= taskList[i].location.Split(',');
                }
                
                res.lat=words[0];
                res.longg=words[1];
                res.landmark = taskList[i].landmark;
                res.house_no = taskList[i].house_no;
                res.customer_contact = taskList[i].customer_contact;
                res.date = taskList[i].date.ToString();
                res.name=taskList[i].name;
                res.callUpCharges=taskList[i].callUpCharges;
                res.shift=taskList[i].shift;
                res.paymentStatus=(taskList[i].paymentStatus==0)?"Un Paid":"Paid";
                foreach(var entity in taskList[i].services_employee)
                {
                    ServiceRes service=new ServiceRes();
                    service.id=entity.selectedservice.id;
                    service.name=entity.selectedservice.name;
                    service.description=entity.selectedservice.description;
                    res.selected_shift=entity.selected_shift;
                    foreach(var feature in entity.selected_features)
                    {
                        FeatureRes features=new FeatureRes();
                        features.id=feature.features.id;
                        features.name=feature.features.name;
                        features.description=feature.features.description;
                        service.feature.Add(features);
                    }
                    res.selected_shift=entity.selected_shift;
                    if(entity.employee!=null)
                    {
                        res.assigned_employee.Add(entity.employee.name);
                    }
                    else{

                        res.assigned_employee=new List<string>();
                    }
                    
                   res.selected_features.Add(service);
                    
                }
                toReturn.Add(res);

            }

            return toReturn;
        }
    }
}