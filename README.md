## SharePoint CSOM Query Site CAML Example sample

This is a sample to demonstrate how to query SharePoint Online Site lists and how to filter them accordingly (a column that is of type DateTime and Date) with the use of CAML queries.

## How to get it working?

1. In Program.cs:
  - Change the **siteUrl** to the location of your SharePoint Online site.
  - Change the list variable to point to your List name instead of **SampleList**.
  - In the **query.ViewXML** property, change the column names from **DateTime** and **Date** to match the column names in your site.
    - Similarly change the column names in the output on line 44.
2. In App.config, change the **ClientId** and **ClientSecret** to match your SharePoint client ID and client secret.
3. Run the Visual Studio solution.
