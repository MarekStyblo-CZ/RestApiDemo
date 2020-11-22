
--Prerequisities to run project
SqlServer running


--How to run the application
On PackageManager Console run commands:
1] Add-Migration initial -Context SqlDbContext -OutputDir "Data\Migrations"
2] Update-Database -Context SqlDbContext
Remark - Initial db data will be automatically generated (included in the generated migrations)  

