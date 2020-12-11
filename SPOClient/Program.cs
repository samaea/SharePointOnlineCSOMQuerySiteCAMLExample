using Microsoft.SharePoint.Client;
using System;

namespace SPOClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string siteUrl = "https://m365samofthings.sharepoint.com/sites/samofthings3";

            //Get the realm for the URL
            string realm = TokenHelper.GetRealmFromTargetUrl(new Uri(siteUrl));

            //Get the access token for the URL.  
            string accessToken = TokenHelper.GetAppOnlyAccessToken(TokenHelper.SharePointPrincipal, new Uri(siteUrl).Authority, realm).AccessToken;

            //Create a client context object based on the retrieved access token
            using (ClientContext cc = TokenHelper.GetClientContextWithAccessToken(siteUrl, accessToken))
            {
                cc.Load(cc.Web, p => p.Title);
                cc.ExecuteQuery();
                Console.WriteLine(cc.Web.Title);
                Console.ReadLine();
            }
        }
    }
}