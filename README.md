# SignalRSqlServerChangeNotification
##Configure connection string
Change connection string in web.config with your own connection string
```
<connectionStrings>  
    <add name="SqlServerConnection" connectionString="Data Source=SANDIP;Initial Catalog=DemoCRM;Integrated Security=True" providerName="System.Data.SqlClient" />
</connectionStrings>
```


##Create Database
Run Following script in Sql Server
```
Create Database DemoCRM
Go

Use DemoCRM
Go

CREATE TABLE DevTest(
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CampaignName] [varchar](255) NULL,
	[Date] [datetime] NULL,
	[Clicks] [int] NULL,
	[Conversions] [int] NULL,
	[Impressions] [int] NULL,
	[AffiliateName] [varchar](255) NULL
) ON [PRIMARY]
GO
```
##Project Setup in Visual Studio
* Open project in Visual Studio 2015
* Restore nuget packages by right click on solution and click on Restore Nuget Packages
* Run the project and Enjoy!