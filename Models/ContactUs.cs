namespace Fixit.Models
{
    public class ContactUs:Identity
    {
        public string name {get;set;}
        public string email {get;set;}
        public string address {get;set;}
        public string phone {get;set;}
        public string message {get;set;}
        public string service{get;set;}
    }
}