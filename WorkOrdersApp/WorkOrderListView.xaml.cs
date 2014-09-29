using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WorkOrdersApp.Models;
using Salesforce.Force;
using Salesforce.Common;
using Salesforce.Common.Models;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json.Linq;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WorkOrdersApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
       
    public partial class WorkOrderListView : Page
    {
        //List<object> workOrderJsonList = new List<object>();
        //protected override void OnLoad(EventArgs e)
        //{
        //    String c = e.ToString();
        //}
        
       // object workOrderList;
        //WorkOrderCollection WOListObj = new WorkOrderCollection();
        List<WorkOrderModel> WOListObj = new List<WorkOrderModel>();
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //base.OnNavigatedFrom(e);
            var param = e.Parameter;
            WOListObj = (List<WorkOrderModel>)param;
           // JsonString = param;
            //=(List<object>) param;
            //workOrderJsonList = param;
            updateView();
            //param();
            
        }
        public void updateView()
        {

            //List<WorkOrderCollection> items = new List<WorkOrderCollection>();
           // List<WorkOrderModel> listItem = new List<WorkOrderModel>();
            //listItem.Add(WOListObj);
            //listItem.Add( WOListObj);
            //lvDataBinding.ItemsSource = items;
            WOList.ItemsSource = WOListObj;
            // Get the Key value pairs from the JSON object

           //if( null!= workOrderJsonList) {
           //    WorkOrderModel mWorkOrderModel = new WorkOrderModel();
           //    mWorkOrderModel= JsonConvert.DeserializeObject<WorkOrderModel>(workOrderJsonList.ToString());

           //}
           // else
           //     new WorkOrderModel();

            //String values = workOrderJsonList[0].ToString();
           // WorkOrderModel mWorkOrderModel = new WorkOrderModel();
            //mWorkOrderModel = JsonConvert.DeserializeObject<dynamic>(values);
            //values.get("WorkOrder_Name__c");
            //ListView listView= new ListView();
            //listView.Items.Add("Item1");
            //listView.Items.Add("Item2");
            //WOList.DataContext = listView;

            //return listView;
            //var value = workOrderJsonList["WorkOrder_Name_c"];
            //mWorkOrderModel=JsonConvert.DeserializeObject<WorkOrderModel>(JsonString);


        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
         {
 	         base.OnNavigatedFrom(e);
        }
        public WorkOrderListView()
        {
            //String accessToken = new Token().AccessToken;
            
            this.InitializeComponent();
        }
        

        
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var message = "Do you want start the Work Order?";
            //var title = "Start WorkOrder?";
            //var result = MessageBox.Show(
            //    message,                  // the message to show
            //    title,                    // the title for the dialog box
            //    MessageBoxButtons.YesNo,  // show two buttons: Yes and No
            //    MessageBoxIcon.Question); // show a question mark icon

            //// the following can be handled as if/else statements as well
            //switch (result)
            //{
            //    case DialogResult.Yes:   // Yes button pressed
            //        MessageBox.Show("You pressed Yes!");
            //        break;
            //    case DialogResult.No:    // No button pressed
            //        MessageBox.Show("You pressed No!");
            //        break;
            //    default:                 // Neither Yes nor No pressed (just in case)
            //        MessageBox.Show("What did you press?");
            //        break;
            //}
            ProgressRing1.IsActive = true;
            this.Frame.Navigate(typeof(WorkOrderDetails), this.WOList.SelectedIndex);
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

    }
}
