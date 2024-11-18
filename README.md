# ICUK API Console

I completed these projects for a UK based ISP where I worked on upgrading a legacy XML broadband provisioning API to a modern C# ASP.NET Web API with a documentation system and API test request console.

Here are some screenshots of the website:

<img align='left' src='https://drive.google.com/uc?id=1oNXQobJY1URCQ1TycjYwJpa9UevOUwGn' width='240'>
<img align='left' src='https://drive.google.com/uc?id=1RUgtmnpQ2zioDJU7wLnvjLA8CYbJM7wd' width='240'>
<img src='https://drive.google.com/uc?id=1f5vq-LOds0bnmDe8XihKMts44Os1ZAa4' width='240'>

Restore the database
====================

First you will need to restore the API test database:

1. Open SQL Server Management Studio
2. Right click Databases in the Object Explorer and then New Database...
3. Name the database icuk_api
4. Place the icuk_api.bak file in a folder e.g. C:\Data\
5. Right click on the database and select Tasks -> Restore -> Database...
6. Select Source -> Device and press the ... button then Add
7. Browse to the C:\Data\icuk_api.bak file and press OK
8. Select Options and check Restore options -> Overwrite the existing database and uncheck Take tail-log backup

Before you open the project
===========================

1. Install the AspNetMVC4Setup.exe which you can download [here](https://drive.google.com/file/d/1yGZwV-atWUC5XKtU-vJD63RwO4xBfzrB/view?usp=sharing)
2. Download the microsoft.netframework.referenceassemblies.net45.1.0.3.zip file from [here](https://drive.google.com/file/d/1FJtsMtOY3UQRHm6tWnh_MdwLOTdLKtck/view?usp=sharing)
3. Extract microsoft.netframework.referenceassemblies.net45.1.0.3.zip
4. Copy the files from build\.NETFramework\v4.5\ to C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5

Database Context
================

You must define the connection string for the database. In the Solution explorer expand the API project and open the Core\Database.cs file. 

On line. 15 you will find the connection string which should look like this:

`private static string devConnString = @"Data Source=YOUR_SERVER_NAME;Initial Catalog=icuk_api;Persist Security Info=True;User ID=YOUR_USERNAME;Password=YOUR_PASSWORD";`

Replace the data source, user id and password with your own database account credentials.

System.Web References
=====================

If there are errors with references to System.Web follow these instructions:

1. Open the API project
2. Right click on References
3. Select Add Reference...
4. Select Assemblies
5. Uncheck:  
   -System.Web  
   -System.Web.Routing  
   -System.Net.Http

6. Select Browse...
7. Open the C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5 folder
8. Add:  
   -System.Web.dll  
   -System.Web.Routing  
   -System.Net.Http

# Running the Project

To run the website project in development mode you must first right click on API project in the Solution Explorer then press run.