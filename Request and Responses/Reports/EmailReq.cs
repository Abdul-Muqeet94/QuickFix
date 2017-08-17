using System.Collections.Generic;

namespace Fixit.Request_and_Responses.Reports
{
    public class EmailReq
    {
        public EmailReq()
        {
            employee=new List<int>();
        }
        public List<int> employee {get;set;}
        public int service {get;set;}
        public string email {get;set;}
    }
}