# Minimal Web API and SPA .NET Solution

This is a Web application with an ASP.NET Web API back-end and Single Page Application front-end.

#

### Server - ASP.NET Web API
- **Helpful tutorials:** 

[Using Web API 2 with Entity Framework 6](https://docs.microsoft.com/en-us/aspnet/web-api/overview/data/using-web-api-with-entity-framework/part-1)

[ASP.NET - Single-Page Applications: Build Modern, Responsive Web Apps with ASP.NET](https://msdn.microsoft.com/en-us/magazine/dn463786.aspx)


### Client - SPA created with AngulaIS

#

#### * Just a remark - how to set static page as startup in ASP.NET Core Web API: 

  1. Put all static files into root directory;

  2. Modify Configure method in Startup.cs, add:
     ```
     app.UseDefaultFiles();
     app.UseStaticFiles();
     ```
    
  3. Update project properties - clear URL in **Launch browser** or uncheck the box at all.
