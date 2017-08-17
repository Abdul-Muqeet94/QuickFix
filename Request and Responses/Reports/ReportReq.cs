using System;

namespace Fixit.Request_and_Responses.Reports
{
    public class ReportReq
    {
        public DateTime fromDate {get;set;}
        public DateTime toDate{get;set;}
        public int orderId {get;set;}
        public int employeeId {get;set;}
        public int serviceId {get;set;}
        public int featureId {get;set;}
    }
}