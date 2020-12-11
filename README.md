## SharePoint CSOM Query Site CAML Example sample

This is a sample to demonstrate how to query SharePoint Online Site lists and how to filter them accordingly (a column that is of type DateTime and Date) with the use of CAML queries.

## How to get it working?

1. In Program.cs:
  1. Change the **siteUrl** to the location of your SharePoint Online site.
  1. Change the list variable to point to your List name instead of SampleList.
  1. In the **query.ViewXML** property, change the column names from **DateTime** and **Date** to match the column names in your site.
    1. Similarly change the column names in the output on line 44.
1. In App.config, change the **ClientId** and **ClientSecret** to match your SharePoint client ID and client secret.
