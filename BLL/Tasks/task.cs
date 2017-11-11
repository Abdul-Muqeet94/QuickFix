using Fixit.Models;
using Fixit.Request_and_Responses;
using System.Collections.Generic;
using System.Linq;
using Fixit.Request_and_Responses.Task;
using Microsoft.EntityFrameworkCore;
using Fixit.Request_and_Responses.Service;
using Fixit.Request_and_Responses.Feature;
using Fixit.Request_and_Responses.Employee;
using Fixit.Request_and_Responses.Reports;

namespace Fixit.BLL
{
    public class Task
    {
        private readonly FixitContext _db;
        public Task(FixitContext context)
        {
            _db = context;
        }
        public BaseResponse createTask(TaskReq req)
        {
            BaseResponse toReturn = new BaseResponse();
            var db = _db;
            List<TaskHasEmployee> serviceMapping = new List<TaskHasEmployee>();
            List<SelectedFeatures> featuresMapping =new List<SelectedFeatures>();
            
              Models.Task task=  new Models.Task();
                
                    task.landmark = req.landmark;
                    task.location = req.location;
                    task.house_no = req.house_no;
                    task.customer_contact = req.customer_contact;
                    task.date = req.date;
                    task.enable = true;
                    task.callUpCharges=0;
                    task.name=req.name;
                    task.shift=req.shift;
                    task.paymentStatus=req.paymentStatus;
                    task.email=req.email;
                    task.image=req.image;
                    task.complete=0;
            foreach (var entity in req.selected_services)
            {
                var service =db.services.Find(entity.id);
                TaskHasEmployee _serviceMapping =new TaskHasEmployee();
                _serviceMapping.selectedservice=service;
                _serviceMapping.selected_shift=db.shifts.Find(req.selected_shift);
                _serviceMapping.enable=true;
                _serviceMapping.task=task;
                foreach(var feature in entity.features)
                {
                    var _features=db.Features.Find(feature);
                    featuresMapping.Add(new SelectedFeatures {
                        features=_features,
                        taskhasemployee=_serviceMapping,
                        enable=true
                    });
                }
                _serviceMapping.selected_features.AddRange(featuresMapping);
                serviceMapping.Add(_serviceMapping);
            }
            
            task.services_employee=serviceMapping;
            db.selected_features.AddRange(featuresMapping);
            db.task_has_employee.AddRange(serviceMapping);
            db.tasks.Add(task);
           
            
            
            if (db.SaveChanges() > 0)
            {
                toReturn.developerMessage = "Task Assigned Successfully";
                toReturn.status = 1;
            }
            else
            {
                toReturn.developerMessage = "unable to Assign Task";
                toReturn.status = -1;
            }
            return toReturn;
        }

        public BaseResponse editTask(TaskReq req)
        {
            BaseResponse toReturn = new BaseResponse();
            List<TaskHasEmployee> serviceMapping = new List<TaskHasEmployee>();
            List<SelectedFeatures> featuresMapping =new List<SelectedFeatures>();
            var db = _db;

            var task = db.tasks.Where(c => c.id == req.id && c.enable == true)
            .Include(c=>c.services_employee)
                .ThenInclude(m=>m.selectedservice)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_features)
                .ThenInclude(m=>m.features)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_shift)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.employee)
                .FirstOrDefault();

            task.landmark = req.landmark;
            task.location = req.location;
            task.house_no = req.house_no;
            task.shift=req.shift;
            task.customer_contact = req.customer_contact;
            foreach(var entity in task.services_employee)
            {
                db.selected_features.RemoveRange(entity.selected_features);
                
            }
            db.task_has_employee.RemoveRange(task.services_employee);
            task.date = req.date;
             foreach (var entity in req.selected_services)
            {
                var service =db.services.Find(entity.id);
                TaskHasEmployee _serviceMapping =new TaskHasEmployee();
                _serviceMapping.selectedservice=service;
                _serviceMapping.selected_shift=db.shifts.Find(req.selected_shift);
                _serviceMapping.enable=true;
                _serviceMapping.task=task;
                foreach(var feature in entity.features)
                {
                    var _features=db.Features.Find(feature);
                    featuresMapping.Add(new SelectedFeatures {
                        features=_features,
                        taskhasemployee=_serviceMapping,
                        enable=true
                    });
                }
                _serviceMapping.selected_features.AddRange(featuresMapping);
                serviceMapping.Add(_serviceMapping);
            }
            
            task.services_employee=serviceMapping;
            db.selected_features.AddRange(featuresMapping);
            db.task_has_employee.AddRange(serviceMapping);

            if (db.SaveChanges() > 0)
            {
                toReturn.developerMessage = "Task edited Successfully";
                toReturn.status = 1;
            }
            else
            {
                toReturn.developerMessage = "Unable to edit Task";
                toReturn.status = -1;
            }
            return toReturn;
        }

        public List<TaskRes> getTask(int id)
        {
            List<TaskRes> toReturn = new List<TaskRes>();
            List<Models.Task> getTsk = new List<Models.Task>();
            var db = _db;
            if (id == 0)
            {
                getTsk = db.tasks.Where(c => c.enable == true)
                .Include(c=>c.services_employee)
                .ThenInclude(m=>m.selectedservice)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_features)
                .ThenInclude(m=>m.features)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_shift)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.employee).OrderByDescending(m=>m.id)
                .ToList();

            }
            else
            {
                getTsk = db.tasks.Where(c => c.id == id && c.enable == true)
                .Include(c=>c.services_employee)
                .ThenInclude(m=>m.selectedservice)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_features)
                .ThenInclude(m=>m.features)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_shift)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.employee).OrderByDescending(m=>m.id)
                .ToList();
            }
            for (int i = 0; i < getTsk.Count; i++)
            {
                string[] words=new string[2];
                TaskRes res = new TaskRes();
                List<ServiceRes> services=new List<ServiceRes>();
                res.id = getTsk[i].id;
                if(getTsk[i].location!=null)
                {
                    words= getTsk[i].location.Split(',');
                }
                
                res.lat=words[0];
                res.longg=words[1];
                res.landmark = getTsk[i].landmark;
                res.house_no = getTsk[i].house_no;
                res.customer_contact = getTsk[i].customer_contact;
                res.date = getTsk[i].date.ToString();
                res.name=getTsk[i].name;
                res.callUpCharges=getTsk[i].callUpCharges;
                res.shift=getTsk[i].shift;
                res.paymentStatus=(getTsk[i].paymentStatus==0)?"Un Paid":"Paid";
                res.complete=(getTsk[i].complete==0)?"In Complete":"Completed";
                res.email=getTsk[i].email;
                res.comments=getTsk[i].comments;
                res.image=getTsk[i].image;
                
                foreach(var entity in getTsk[i].services_employee)
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
        //
         public List<TaskRes> getToAssigned(int id)
        {
            List<TaskRes> toReturn = new List<TaskRes>();
            List<Models.Task> getTsk = new List<Models.Task>();
            var db = _db;
            if (id == 0)
            {
                getTsk = db.tasks.Where(c => c.enable == true && c.complete!=2)
                .Include(c=>c.services_employee)
                .ThenInclude(m=>m.selectedservice)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_features)
                .ThenInclude(m=>m.features)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_shift)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.employee)
                .ToList();

            }
            else
            {
                getTsk = db.tasks.Where(c => c.id == id && c.complete!=2 && c.enable == true)
                .Include(c=>c.services_employee)
                .ThenInclude(m=>m.selectedservice)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_features)
                .ThenInclude(m=>m.features)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_shift)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.employee)
                .ToList();
            }
            for (int i = 0; i < getTsk.Count; i++)
            {
                bool todo=true;
                string[] words=new string[2];
                TaskRes res = new TaskRes();
                List<ServiceRes> services=new List<ServiceRes>();
                foreach(var entity in getTsk[i].services_employee)
                {
                    ServiceRes service=new ServiceRes();
                    if(entity.employee==null)
                    {
                        entity.employee=new Fixit.Models.Employee();
                        todo=true;
                    }
                    else{
                        todo=false;
                        continue;
                    }
                    if(entity.selectedservice!=null)
                    {
                        service.id=entity.selectedservice.id;
                    service.name=entity.selectedservice.name;
                    service.description=entity.selectedservice.description;
                    }
                    else{
                        service.id=0;
                    service.name="";
                    service.description="";
                    }
                    if(entity.selected_shift!=null){
                        res.selected_shift=entity.selected_shift;
                    }
                    if(entity.selected_features!=null)
                    {
                        foreach(var feature in entity.selected_features)
                    {
                        FeatureRes features=new FeatureRes();
                        features.id=feature.features.id;
                        features.name=feature.features.name;
                        features.description=feature.features.description;
                        service.feature.Add(features);
                    }

                    }
                    if(entity.selected_features!=null)
                    {
                        res.selected_shift=entity.selected_shift;
                    }

                   res.selected_features.Add(service);
                    
                }
                if(todo)
                {
                res.id = getTsk[i].id;
                if(getTsk[i].location!=null)
                {
                    words= getTsk[i].location.Split(',');
                     res.lat=words[0];
                    res.longg=words[1];
                }
                else{
                    res.lat="";
                    res.longg="";
                }
                
               
                res.landmark = (getTsk[i].landmark!=null)?getTsk[i].landmark:"";
                res.house_no = (getTsk[i].house_no!=null)?getTsk[i].house_no:"";
                res.customer_contact = (getTsk[i].customer_contact!=null)?getTsk[i].customer_contact:"";
                res.date = (getTsk[i].date.ToString()!=null)?getTsk[i].date.ToString():"";
                res.name=(getTsk[i].name!=null)?getTsk[i].name:"";
                res.callUpCharges=(getTsk[i].callUpCharges!=0)?getTsk[i].callUpCharges:0;
                res.shift=(getTsk[i].shift!=null)?getTsk[i].shift:"";
                res.paymentStatus=(getTsk[i].paymentStatus==0)?"Un Paid":"Paid";
                res.complete=(getTsk[i].complete==0)?"InComplete":"Completed";
                res.email=(getTsk[i].email!=null)?getTsk[i].email:"";
                res.comments=(getTsk[i].comments!=null)?getTsk[i].comments:"";
                res.image=(getTsk[i].image!=null)?getTsk[i].image:"";
                toReturn.Add(res);
                }

            }
            if(toReturn.Count>0)
            {
                toReturn[0].count=toReturn.Count;
            }
            
            return toReturn;
        }

public BaseResponse completeTask(CompleteTaskReq req)
{
    BaseResponse toReturn=new BaseResponse();
    var db=_db;
    var task=db.tasks.Where(m=>m.enable==true && m.id==req.id).FirstOrDefault();
    task.complete=1;
    task.comments=req.comments;
    task.callUpCharges=req.amount;
    if(db.SaveChanges()>0)
    {
        toReturn.developerMessage="Task Completed Successfully";
        toReturn.status=1;
    }
    else
    {
        toReturn.developerMessage="Unable to Complete Task";
        toReturn.status=0;
    }
    return toReturn;
}

public BaseResponse cancelTask(CompleteTaskReq req)
{
    BaseResponse toReturn=new BaseResponse();
    var db=_db;
    var task=db.tasks.Where(m=>m.enable==true && m.id==req.id).FirstOrDefault();
    task.complete=2;
    task.comments=req.comments;
    if(db.SaveChanges()>0)
    {
        toReturn.developerMessage="Task Cancelled Successfully";
        toReturn.status=1;
    }
    else
    {
        toReturn.developerMessage="Unable to Cancel Task";
        toReturn.status=0;
    }
    return toReturn;
}
 public List<TaskRes> getAssignedTask(int id)
        {
            List<TaskRes> toReturn = new List<TaskRes>();
            List<Models.Task> getTsk = new List<Models.Task>();
            var db = _db;
            if (id == 0)
            {
                getTsk = db.tasks.Where(c => c.enable == true && c.complete!=1)
                .Include(c=>c.services_employee)
                .ThenInclude(m=>m.selectedservice)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_features)
                .ThenInclude(m=>m.features)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_shift)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.employee)
                .ToList();

            }
            else
            {
                getTsk = db.tasks.Where(c => c.id == id && c.enable == true && c.complete!=1)
                .Include(c=>c.services_employee)
                .ThenInclude(m=>m.selectedservice)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_features)
                .ThenInclude(m=>m.features)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_shift)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.employee)
                .ToList();
            }
            for (int i = 0; i < getTsk.Count; i++)
            {
                bool todo=true;
                string[] words=new string[2];
                TaskRes res = new TaskRes();
                List<ServiceRes> services=new List<ServiceRes>();
                foreach(var entity in getTsk[i].services_employee)
                {
                    ServiceRes service=new ServiceRes();
                    if(entity.employee!=null)
                    {
                        res.assigned_employee.Add(entity.employee.name);
                        todo=true;
                    }
                    else{
                        todo=false;
                        continue;
                    }
                    
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
                    if(entity.selected_shift!=null)
                    {
                        res.selected_shift=entity.selected_shift;
                    }
                    else
                    {
                        res.selected_shift=new Models.Shifts();
                    }
                    
                    
                    
                   res.selected_features.Add(service);
                    
                }
                if(todo)
                {
                res.id = getTsk[i].id;
                if(getTsk[i].location!=null)
                {
                    words= getTsk[i].location.Split(',');
                    res.lat=words[0];
                res.longg=words[1];
                }
                else{
                    res.lat="";
                res.longg="";
                }
                
                
                res.email=getTsk[i].email;
                res.landmark = getTsk[i].landmark;
                res.house_no = getTsk[i].house_no;
                res.customer_contact = getTsk[i].customer_contact;
                res.date = getTsk[i].date.ToString();
                res.name=getTsk[i].name;
                res.callUpCharges=getTsk[i].callUpCharges;
                res.shift=getTsk[i].shift;
                res.paymentStatus=(getTsk[i].paymentStatus==0)?"Un Paid":"Paid";
                res.complete=(getTsk[i].complete==0)?"In Complete":"Completed";
                res.comments=getTsk[i].comments;
                res.image=getTsk[i].image;
                toReturn.Add(res);
                }

            }
            return toReturn;
        }


 
  public List<TaskRes> getCompletedTask(int id)
        {
            List<TaskRes> toReturn = new List<TaskRes>();
            List<Models.Task> getTsk = new List<Models.Task>();
            var db = _db;
            if (id == 0)
            {
                getTsk = db.tasks.Where(c => c.enable == true &&  c.complete==1)
                .Include(c=>c.services_employee)
                .ThenInclude(m=>m.selectedservice)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_features)
                .ThenInclude(m=>m.features)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_shift)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.employee)
                .ToList();

            }
            else
            {
                getTsk = db.tasks.Where(c => c.id == id && c.enable == true && c.complete==1)
                .Include(c=>c.services_employee)
                .ThenInclude(m=>m.selectedservice)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_features)
                .ThenInclude(m=>m.features)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_shift)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.employee)
                .ToList();
            }
            for (int i = 0; i < getTsk.Count; i++)
            {
                bool todo=true;
                string[] words=new string[2];
                TaskRes res = new TaskRes();
                List<ServiceRes> services=new List<ServiceRes>();
                foreach(var entity in getTsk[i].services_employee)
                {
                    ServiceRes service=new ServiceRes();
                    if(entity.employee!=null)
                    {
                        res.assigned_employee.Add(entity.employee.name);
                        todo=true;
                    }
                    else{
                        todo=false;
                        continue;
                    }
                    
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
                    if(entity.selected_shift!=null)
                    {
                        res.selected_shift=entity.selected_shift;
                    }
                    else
                    {
                        res.selected_shift=new Models.Shifts();
                    }
                    
                   res.selected_features.Add(service);
                    
                }
                if(todo)
                {
                res.id = getTsk[i].id;
                if(getTsk[i].location!=null)
                {
                    words= getTsk[i].location.Split(',');
                     res.lat=words[0];
                res.longg=words[1];
                }
                else{
                    res.lat="";
                res.longg="";
                }
               
                res.email=getTsk[i].email;
                res.landmark = getTsk[i].landmark;
                res.house_no = getTsk[i].house_no;
                res.customer_contact = getTsk[i].customer_contact;
                res.date = getTsk[i].date.ToString();
                res.name=getTsk[i].name;
                res.callUpCharges=getTsk[i].callUpCharges;
                res.shift=getTsk[i].shift;
                res.paymentStatus=(getTsk[i].paymentStatus==0)?"Un Paid":"Paid";
                res.complete=(getTsk[i].complete==0)?"In Complete":"Completed";
                res.comments=getTsk[i].comments;
                res.image=getTsk[i].image;
                toReturn.Add(res);
                }

            }
            return toReturn;
        }
  public List<TaskRes> getCancelledTask(int id)
        {
            List<TaskRes> toReturn = new List<TaskRes>();
            List<Models.Task> getTsk = new List<Models.Task>();
            var db = _db;
            if (id == 0)
            {
                getTsk = db.tasks.Where(c => c.enable == true &&  c.complete==2)
                .Include(c=>c.services_employee)
                .ThenInclude(m=>m.selectedservice)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_features)
                .ThenInclude(m=>m.features)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_shift)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.employee)
                .ToList();

            }
            else
            {
                getTsk = db.tasks.Where(c => c.id == id && c.enable == true && c.complete==2)
                .Include(c=>c.services_employee)
                .ThenInclude(m=>m.selectedservice)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_features)
                .ThenInclude(m=>m.features)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_shift)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.employee)
                .ToList();
            }
            for (int i = 0; i < getTsk.Count; i++)
            {
                bool todo=true;
                string[] words=new string[2];
                TaskRes res = new TaskRes();
                List<ServiceRes> services=new List<ServiceRes>();
                foreach(var entity in getTsk[i].services_employee)
                {
                    ServiceRes service=new ServiceRes();
                    if(entity.employee!=null)
                    {
                        res.assigned_employee.Add(entity.employee.name);
                        
                    }
                    else{
                        
                        res.assigned_employee=new List<string>();
                    }
                    
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
                    
                    
                   res.selected_features.Add(service);
                    
                }
                
                res.id = getTsk[i].id;
                if(getTsk[i].location!=null)
                {
                    words= getTsk[i].location.Split(',');
                }
                else
                {
                    words[0]=""; words[1]="";
                }
                
                res.lat=words[0];
                res.longg=words[1];
                res.email=getTsk[i].email;
                res.landmark = getTsk[i].landmark;
                res.house_no = getTsk[i].house_no;
                res.customer_contact = getTsk[i].customer_contact;
                res.date = getTsk[i].date.ToString();
                res.name=getTsk[i].name;
                res.callUpCharges=getTsk[i].callUpCharges;
                res.shift=getTsk[i].shift;
                res.paymentStatus=(getTsk[i].paymentStatus==0)?"Un Paid":"Paid";
                res.complete="Cancelled";
                res.comments=getTsk[i].comments;
                res.image=getTsk[i].image;
                toReturn.Add(res);
                

            }
            return toReturn;
        }


 
 
 
 public List<TaskAssignRes> getForViewTask(int id)
        {
            List<TaskAssignRes> toReturn = new List<TaskAssignRes>();
            List<Models.Task> getTsk = new List<Models.Task>();
            var db = _db;
            if (id == 0)
            {
                getTsk = db.tasks.Where(c => c.enable == true)
                .Include(c=>c.services_employee)
                .ThenInclude(m=>m.selectedservice)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_features)
                .ThenInclude(m=>m.features)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_shift)
                .ToList();

            }
            else
            {
                getTsk = db.tasks.Where(c => c.id == id && c.enable == true)
                .Include(c=>c.services_employee)
                .ThenInclude(m=>m.selectedservice)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_features)
                .ThenInclude(m=>m.features)
                .Include(m=>m.services_employee)
                .ThenInclude(m=>m.selected_shift)
                .ToList();
            }
            for (int i = 0; i < getTsk.Count; i++)
            {
                TaskAssignRes res = new TaskAssignRes();
                List<ViewServiceRes> services=new List<ViewServiceRes>();
                res.id = getTsk[i].id;
                string[] words= getTsk[i].location.Split(',');
                res.lat=words[0];
                res.longg=words[1];
                res.landmark = getTsk[i].landmark;
                res.house_no = getTsk[i].house_no;
                res.customer_contact = getTsk[i].customer_contact;
                res.date = getTsk[i].date.ToString();
                res.name=getTsk[i].name;
                res.callUpCharges=getTsk[i].callUpCharges;
                res.paymentStatus=(getTsk[i].paymentStatus==0)?"Un Paid":"Paid";
                res.complete=(getTsk[i].complete==0)?"In Complete":"Completed";
                res.email=getTsk[i].email;
                res.comments=getTsk[i].comments;
                res.image=getTsk[i].image;
                
                foreach(var entity in getTsk[i].services_employee)
                {
                    ViewServiceRes service=new ViewServiceRes();
                    service.id=entity.selectedservice.id;
                    service.name=entity.selectedservice.name;
                    service.description=entity.selectedservice.description;
                    res.shiftId=entity.selected_shift.id;
                    res.shift=entity.selected_shift.sTime.TimeOfDay+" "+entity.selected_shift.eTime.TimeOfDay;
                    foreach(var feature in entity.selected_features)
                    {
                        FeatureRes features=new FeatureRes();
                        features.id=feature.features.id;
                        features.name=feature.features.name;
                        features.description=feature.features.description;
                        service.feature.Add(features);
                    }
                    //List<Services> _getServices=new List<Services>();
                    var _getService=db.services.Where(m=>m.id==entity.selectedserviceid).FirstOrDefault();
                    List<Fixit.Models.Employee> employeesList =new List<Fixit.Models.Employee>();
                    var shiftsEmployee=db.employeeShift.Where(m=>m.shiftsId==entity.selected_shift.id).Include(m=>m.employee).ToList();
                     employeesList=db.employee.Where(m=>m.enable==true && m.service.Any(y=>y.serviceId==entity.selectedservice.id)
                     ).Include(m=>m.service).ToList();
                    foreach(var employee  in employeesList)
                    {
                        EmployeeRes employeeRes=new EmployeeRes();
                        employeeRes.id=employee.id;
                        employeeRes.name=employee.name;
                        service.assigned_employee.Add(employeeRes);
                    }
                    // for(int k=0;k<employeesList.Count;k++)
                    // {
                    //     EmployeeRes employeeRes=new EmployeeRes();
                    //     if(employeesList[k].id==shiftsEmployee[k].employee.id)
                    //     {
                    //     employeeRes.id=employeesList[k].id;
                    //     employeeRes.name=employeesList[k].name;
                    //     service.assigned_employee.Add(employeeRes);
                    //     }
                    //     else
                    //     {
                    //         continue;
                    //     }
                        
                    //}
                    res.selected_features.Add(service);
                    
                }
                toReturn.Add(res);
            }
            return toReturn;
        }
        public BaseResponse deletetask(int id)
        {
            BaseResponse toReturn = new BaseResponse();
            var db = _db;
            var task = db.tasks.Find(id);
            task.enable = false;
            if (db.SaveChanges() > 0)
            {
                toReturn.developerMessage = "Task deletetion successfully";
                toReturn.status = 1;
            }
            else
            {
                toReturn.developerMessage = "Unable to delete Task";
                toReturn.status = -1;
            }
            return toReturn;
        }

        public BaseResponse assigntask(AssignReq req)
        {
            BaseResponse toReturn = new BaseResponse();
            var db = _db;
            var task = db.tasks.Where(m=>m.id==req.task_id).Include(m=>m.services_employee).ThenInclude(m=>m.selectedservice).FirstOrDefault();
            task.comments=(req.comments!=null)?req.comments:"";
            foreach (var entity in req.service_employee)
            {
                var emp = db.employee.Find(entity);
                 task.services_employee.Where(m=>m.taskid==req.task_id)
                 .FirstOrDefault().employee=emp;     
            }

            if (db.SaveChanges() > 0)
            {
                toReturn.developerMessage = "Task Assigned successfully";
                toReturn.status = 1;
            }
            else
            {
                toReturn.developerMessage = "Unable to Assign Task";
                toReturn.status = -1;
            }
            return toReturn;
        }

        //
        public BaseResponse updateAssignedTask(AssignReq req)
        {

            BaseResponse toReturn = new BaseResponse();
            var db = _db;
            var task = db.tasks.Where(m=>m.id==req.task_id).Include(m=>m.services_employee).ThenInclude(m=>m.selectedservice).FirstOrDefault();
            task.comments=(req.comments!=null)?req.comments:"";
            
            foreach (var entity in req.service_employee)
            {
                var emp = db.employee.Find(entity);
                 task.services_employee.Where(m=>m.taskid==req.task_id)
                 .FirstOrDefault().employee=emp;     
            }

            if (db.SaveChanges() > 0)
            {
                toReturn.developerMessage = "Task Assigned successfully";
                toReturn.status = 1;
            }
            else
            {
                toReturn.developerMessage = "Unable to Assign Task";
                toReturn.status = -1;
            }
            return toReturn;
        }


public BaseResponse sendQuote(QuoteReq req)
{
    BaseResponse toReturn=new BaseResponse();


//create an html page
 
var body = "Address:</h3><h4>"+req.address+"</h4><h3>Services:</h3><h4>"+req.service+"</h4><h3>Amount:</h3><h4>"+req.amount+"</h4><h3>Message:</h3><h4>"+req.message+"</h4></body></html>";
var name="Quick-Fix";
    if(Utils.Email.sendEmail(name,body,req.sendTo))
    {
        toReturn.developerMessage="Quatation send success";
        toReturn.status=1;
    }
    else
    {
        toReturn.developerMessage="Unable to send Quatation";
        toReturn.status=2;
    }
    return toReturn;
}


         public BaseResponse sendEmail(EmailReq req){
            BaseResponse toReturn =new BaseResponse();
            var db=_db;
            List<Models.Employee> employee=new List<Models.Employee>();
            for(int i=0; i<req.employee.Count;i++)
            {
                employee.Add(db.employee.Where(m=>m.id==req.employee[i]).FirstOrDefault());
                if(employee[i].email==null)
            {
                continue;
            }
            else
            {
               string body=req.email;
              string to=employee[i].email;
            //string to="abdul.muqeet@khi.iba.edu.pk";//employee.email;
            string from="Quick Fix";
            if(Utils.Email.sendEmail(from,body,to))
            {
                toReturn.status=1;
                toReturn.developerMessage="Email has been send";
            }
            else{
                toReturn.status=0;
                toReturn.developerMessage="Unable to send the email";
            } 
            }
            } 
            
            
            return toReturn;
        }

    }
}