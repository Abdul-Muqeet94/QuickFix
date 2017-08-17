using System.Collections.Generic;
using System.Linq;
using Fixit.Models;
using Fixit.Request_and_Responses;
using Fixit.Request_and_Responses.ContactUS;

namespace Fixit.BLL.ContactUs
{
    public class ContactUs
    {
        public readonly FixitContext _db;
        public ContactUs(FixitContext context)
        {
            _db=context;
        }
        public BaseResponse create(ContactUsReq req)
        {
            BaseResponse toReturn=new BaseResponse();
            var db=_db;
            db.contactUs.Add(new Models.ContactUs {
                name=req.name,
                address=req.address,
                email=req.email,
                phone=req.phone,
                message=req.comments,
                service=req.service,
                enable=true
            });
            if(db.SaveChanges()>0)
            {
                toReturn.status=1;
                toReturn.developerMessage="values have been saved successfully";
            }
            else
            {
                toReturn.status=-1;
                toReturn.developerMessage="unable to save";
            }
            return toReturn;
        }

        public List<ContactUsRes> view(int id)
        {
            List<ContactUsRes> toReturn=new List<ContactUsRes>();
            List<Models.ContactUs> listOfContacts=new List<Models.ContactUs>();
            var db=_db;
            if(id==0)
            {
                listOfContacts =db.contactUs.Where(m=>m.enable==true).ToList();
            }
            else
            {
                listOfContacts =db.contactUs.Where(m=>m.enable==true).ToList();
            }
            foreach(var entity in listOfContacts)
            {
                toReturn.Add(new ContactUsRes{
                    name=entity.name,
                    email=entity.email,
                    address=entity.address,
                    phone=entity.phone,
                    comments=entity.message,
                    service=entity.service,
                    id=entity.id
                });
            }
            return toReturn;
        }
        public BaseResponse delete(int id)
        {
            var db=_db;
            BaseResponse toReturn=new BaseResponse();
            var contactUs=db.contactUs.Where(m=>m.id==id).FirstOrDefault();
            contactUs.enable=false;
            if(db.SaveChanges()>0)
            {
                toReturn.status=1;
                toReturn.developerMessage="Deleted Successfully";
            }
            else
            {
                toReturn.status=0;
                toReturn.developerMessage="Unable to delete";
            }
            return toReturn;
        }
    }
}