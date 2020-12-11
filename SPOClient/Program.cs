using Microsoft.SharePoint.Client;
using System;

namespace SPOClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string siteUrl = "https://m365samofthings.sharepoint.com/sites/samofthings2";

            //Get the realm for the URL
            string realm = TokenHelper.GetRealmFromTargetUrl(new Uri(siteUrl));

            //Get the access token for the URL.  
            string accessToken = TokenHelper.GetAppOnlyAccessToken(TokenHelper.SharePointPrincipal, new Uri(siteUrl).Authority, realm).AccessToken;
            ListItemCollection collListItem;
            //Create a client context object based on the retrieved access token
            ClientContext cc = TokenHelper.GetClientContextWithAccessToken(siteUrl, accessToken);
            // SharePoint List Name called SampleList
            List list = cc.Web.Lists.GetByTitle("SampleList");
            CamlQuery query = new CamlQuery();
            // CAML Query that checks whether the column DateTime is gretaer than 2020-06-20 1200 AND column Date is less than 2021-02-09.
            query.ViewXml = @"<View>
            <Query>
                <Where>
                    <And>
                        <Gt>
                            <FieldRef Name='DateTime' /><Value Type='DateTime'>2020-06-20T12:00:00Z</Value>
                        </Gt>
                        <Lt>
                            <FieldRef Name='Date' /><Value Type='DateTime'>2021-02-09</Value>
                        </Lt>
                    </And>
                </Where>
            </Query>
        </View>";
            collListItem = list.GetItems(query);
            cc.Load(collListItem);
            cc.ExecuteQuery();
            // Iterate through the results
            foreach (ListItem ListItem in collListItem)
            {
                Console.WriteLine("ID: {0} \nTitle: {1} \nDateTime: {2} \nDate: {3}\n", ListItem.Id, ListItem["Title"], ListItem["DateTime"], ListItem["Date"]);
            }
            Console.ReadLine();
        }
    }
}