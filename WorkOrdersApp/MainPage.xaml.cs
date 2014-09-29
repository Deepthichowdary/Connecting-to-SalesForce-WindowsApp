using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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
using Salesforce.Force;
using Salesforce.Common;
using Salesforce.Common.Models;
using System.Threading.Tasks;
using WorkOrdersApp.Models;
using Newtonsoft.Json;
using System.Linq.Expressions;
using Newtonsoft.Json.Linq;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WorkOrdersApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private  string SFAuthorizationEndpointUrl = "https://login.salesforce.com/services/oauth2/authorize";
        private string myConsumerKey = "3MVG9xOCXq4ID1uHC1doqqoPd_WllFJrDKwVBXdpngM9pbOa5dfsBom67oeoBteBStPDehGWmo2dEphXviF16";
        private  string myCallbackUrl = "sfdc://success";
        //private Token _token;
        private String environment = "https://na17.salesforce.com";
        List<WorkOrderModel> WorkOrdrList = new List<WorkOrderModel>();
        List<dynamic> QueryResultList = new List<dynamic>();
        //private QueryResult<dynamic> WorkOrders;
        public MainPage()
        {
            this.InitializeComponent();
            
        }

        private async void login_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                await GetToken();
               
               this.Frame.Navigate(typeof(SplitPage1));
            }
            catch (Exception ex)
            {
               String exception= ex.Message;
               //Debug.WriteLine();
                
            }
           
        }
       
        /*public async Task<dynamic> getWorkOrders()
        {
            string clientId = _token.Id;
            string mclientID = "'" + clientId.Split(new char[] { @"\"[0], "/"[0] }).Last() + "'";
            var client = new ForceClient(_token.InstanceUrl, _token.AccessToken, "v31.0");
            String query = "select WorkOrder_Name__c,Id,Work_Status__c,WorkOrder_Start_Date__c from WorkOrder__c where Assigned_To__c = " + mclientID;
            QueryResult<dynamic> WorkOrders = await client.QueryAsync<dynamic>(query);
            return WorkOrders.records;
               
        } */
        private async Task GetToken()
        {
            //var token = new Token();
            var token1 = new AuthToken();
            var app = (Application.Current as App);
            var startUrl = Common.FormatAuthUrl(SFAuthorizationEndpointUrl, ResponseTypes.Token, myConsumerKey,
                WebUtility.UrlEncode(myCallbackUrl), DisplayTypes.Popup);
            var startUri = new Uri(startUrl);
            var endUri = new Uri(CallbackUrl);
            var webAuthenticationResult =
                await Windows.Security.Authentication.Web.WebAuthenticationBroker.AuthenticateAsync(
                    Windows.Security.Authentication.Web.WebAuthenticationOptions.None,
                    startUri,
                    endUri);

            switch (webAuthenticationResult.ResponseStatus)
            {
                case Windows.Security.Authentication.Web.WebAuthenticationStatus.Success:
                    var responseData = webAuthenticationResult.ResponseData;
                    var responseUri = new Uri(responseData);
                    var decoder = new WwwFormUrlDecoder(responseUri.Fragment.Replace("#", "?"));


                    app.AccessToken = decoder.GetFirstValueByName("access_token");
                    // Tokens.AccessToken = "ABC";
                    Token.AccessToken = app.AccessToken;
                    app.RefreshToken = decoder.GetFirstValueByName("refresh_token");
                    Token.RefreshToken = app.RefreshToken;
                    app.InstanceUrl = WebUtility.UrlDecode(decoder.GetFirstValueByName("instance_url"));
                    Token.InstanceUrl = app.InstanceUrl;
                    Token.Id = decoder.GetFirstValueByName("id");

                    return;

                case Windows.Security.Authentication.Web.WebAuthenticationStatus.ErrorHttp:
                    throw new Exception(webAuthenticationResult.ResponseErrorDetail.ToString());

                default:
                    throw new Exception(webAuthenticationResult.ResponseData);
            }
        }

        private async Task RefreshToken()
        {
            var auth = new AuthenticationClient();
            await auth.TokenRefreshAsync(ConsumerKey, Token.RefreshToken);

            Token.AccessToken = auth.AccessToken;
        }

    }
}
