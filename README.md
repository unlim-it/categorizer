# Categorizer Project

### Requirements

 * Visual Studio 2013
 * MS SQL Server 2008 +

### Folow this steps to run application

* Change Categorizer.Services\Web.config connection string

``` 
...
<connectionStrings>
    <add name="CategorizerData" connectionString="Data Source=.\SQLEXPRESS; Initial Catalog=CategorizerData; ...
</connectionStrings>
...
```

* Rebuild each project separately
* Run 'Categorizer.Services' project
* Run 'Categorizer.Web' project 


