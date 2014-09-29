using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace WorkOrdersApp.Models
{
    public partial class WorkOrderModel 
    {
        //List<String,String> attList=new List<String,String>();
        //List<AttributeList> attrList= new List<AttributeList>();
       public Dictionary<string, string> Attributes { get; set; }
       public String Name { get; set; }
       public String Customer_Name__c { get; set; }
       public String Assigned_To__c { get; set; }
       public String Address__c { get; set; }
       public String State__c { get; set; }
       public String Country__c { get; set; }
       public String Comments__c { get; set; }
       //public String Assigned_To__c { get; set; }
       public String City__c { get; set; }
      // public String WorkOrder_Name__c { get;set; }
       public String Id { get; set; }
       public String Work_Status__c { get; set; }
       public DateTime WorkOrder_Start_Date__c { get; set; }
       

    }
    

}
