OrderInfo Sample
================

This sample demonstrates passing TEMP-TABLEs as input and ouput 
parameters to a persistent procedure. 

The application uses the Progress .NET Open Client to obtain Customer and  
Order records from an Progress AppServer that is connected to a sports2000 
database.


Steps to run the sample:
========================  

1) Run ProxyGen (Start->Programs->OpenEdge->Proxy Generator)
   a) Open the file OrderInfo.xpxg found in: 
	<yourInstallDir>\samples\open4gl\dotnet\AppService\OrderInfo

   b) Select File->Generate and press OK. 
      This will generate the .NET proxy dll in 
	<yourInstallDir>\samples\dotnet\OrderInfo\OrderProxy\OrderInfo.dll

   	If your install directory is different than C:\Progress\OpenEdge, you 	
   	need to do the following changes before generating:

	- Select Tools->Change Propath
	  Change the propath component
		C:\Progress\OpenEdge\src\samples\dotnet\AppService
	  to:
		<yourInstallDir>\samples\dotnet\AppService

   	- Change the Output dir on the General tab of the Generate dialog to
		<yourInstallDir>\samples\dotnet\OrderInfo\

2) Setup a Progress AppServer that is connected to a 
   sports2000 database.

3) Copy the .p files from the ..\AppService\OrderInfo directory 
   into the AppServer's work directory - typically C:\OpenEdge\WRK. 
   Keep the 4GL files in the OrderInfo subdirectory.

4) Open the 'OrderInfoDemo.sln' in Visual Studio .NET

5) Update the references in the project if necessary. This sample
   assumes that OpenEdge was installed to the default location
   C:\Progress\OpenEdge. If your install directory is different, 
   you must remove and re-add the following references:
	<yourInstallDir>\samples\dotnet\OrderInfo\OrderProxy\Progress.o4glrt.dll
	<yourInstallDir>\samples\dotnet\OrderInfo\OrderProxy\OrderInfo.dll


5) Build & run the sample.
 



Related Files:
==============


.NET Solution/Project Files
	OrderInfoDemo.sln
	OrderInfoDemo.suo
	OrderInfoDemo.vbproj

.NET Client Code
	Demo.vb
	Demo.resx

Proxy Files (built in step 1)
	OrderProxy\OrderInfo.dll	
		Contains the .NET Open Client Object classes in the 
		OrderProxy namespace:
		  	CustomerOrder
		  	OrderInfo

		This also includes the .NET Strongly-typed DataTable class
		in the OrderProxy.StrongTypesNS namespace:
			OrderDetailsDataTable

4GL Files:
	<yourInstallDir>\samples\open4gl\dotnet\AppService\OrderInfo\*


Open Client Runtime
	<yourInstallDir>\dotnet\deploy\signed\*
		Open Client Runetime files needed for deployment.
		By default OpenEdge is installed to C:\Progress\OpenEdge

