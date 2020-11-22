
--Prerequisities to run project
SqlServer running


--How to run the application
On PackageManager Console run commands:
1] Add-Migration initial -Context SqlDbContext -OutputDir "Data\Migrations"
2] Update-Database -Context SqlDbContext
Remark - Initial db data seed will be automatically generated (included in the generated migrations)  
3] Set the version of API you want to run by setting parameter 'ApiVersion' in appsettings.json
Remark - all api versions endpoints are documented on Swagger but 'ApiVersion' attribute influences which version is actually running -- which endpoints can be called via api
4] Run project


--Available Queries
v1
GET https://localhost:44346/api/v1.0/products
GET https://localhost:44346/api/v1.0/products/1
PUT https://localhost:44346/api/v1.0/products/1?productDescr=newDescription 

v2
GET (default page size) https://localhost:44346/api/v2.0/products?pageNr=1
GET https://localhost:44346/api/v2.0/products?pageNr=1&pageSize=2

