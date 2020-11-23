--Basic info about the application
Demo project showing basic concepts of API functionality with Swagger documentation and unit tests (xUnit)
Project is composed of two subprojects:
1.RestApiDemo .. api with Swagger 
2.RestApiDemo.Test .. unit tests (xUnit)

--available REST endpoints
v1
GET https://localhost:44346/api/v1.0/products
GET https://localhost:44346/api/v1.0/products/1
PUT https://localhost:44346/api/v1.0/products/1?productDescr=newDescription 

v2
GET (using default page size) https://localhost:44346/api/v2.0/products?pageNr=1
GET https://localhost:44346/api/v2.0/products?pageNr=1&pageSize=2


--Prerequisities to run project
MS SqlServer
IIS Express
.NET Core SDK v3.1.10
(Visual Studio)


--How to run the project / access api
a] From Visual Studio
  1] Via PackageManager Console apply migrations to db: Update-Database -Context SqlDbContext
  Remark - Initial db data seed will be automatically generated (included in the generated migrations)  
  2] Set the version of API you want to run by setting parameter 'ApiVersion' in appsettings.json (allowed values: [1,2])
  Remark - all api versions endpoints are documented on Swagger but 'ApiVersion' attribute influences which version is actually running -- which set of endpoints can be called via api
  3] Run project: ctrl + F5 (when RestApiDemo is set as Startup project)

b] From command line
  1] run cmd
  2] set working directory to ..\RestApiDemo-master\RestApiDemo
  3] apply migrations to db: dotnet ef database update
  Remark - Initial db data seed will be automatically generated (included in the generated migrations)  
  4] Set the version of API you want to run by setting parameter 'ApiVersion' in appsettings.json (allowed values: [1,2])
  Remark - all api versions endpoints are documented on Swagger but 'ApiVersion' attribute influences which version is actually running -- which set of endpoints can be called via api
  5] Run project: dotnet run
     Now you are able access Swagger: https://localhost:5001/swagger/index.html
 

--How to run unit tests: RestApiDemo.Test
1] Select which data source you want to use by setting constant ProductServiceTests.DATA_SOURCE to "DB" or "MEMORY"
Remark - before first switching to "DB" make sure that migration was generated and applied to local test db in order to be populated with initial data -- see section above - how to run (apply migrations)
Remark - if you use "DB" option -> update the ProductServiceTests.DB_CONNECTION_STRING according to the test db you want to connect to for making tests
Remark - if you use "DB" option -> for unit tests to work properly make sure that the test db is seeded with exactly the same data defined in TestData.DemoProducts
2] Run tests
  a] Run tests via Visual Studio by using Test Explorer
  b] Run tests on cmd:
     i] run cmd
     ii] set working directory to ..\RestApiDemo-master\RestApiDemo.Test
     iii] Run tests: dotnet test

