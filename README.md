# Blazor CRUD
Voorbeeldcode horend bij Blog artikel https://www.mrasoft.nl/blazor-crud

Hier staat een ASP .NET Core hosted Blazor WebAssembly App. Voor de solution is de Visual Studio 2019 IDE gebruikt. Het gebruikte .Net Framework is .Net 5.0.

De voorbeeldcode bevat een implementatie die gebruik maakt van een SQL Server database. De SQL Server database zit niet in deze GitHub respository. Maak hiervoor op je SQL Server een database aan met de naam **VOORBEELD** en creëer in die database een tabel met de naam **EIGENAAR**. Neem de volgende velden op in de tabel:
- ID (int, not null, primary key - Identity Specification, Identity increment: 1, Identity Seed: 1)
- omschrijving (nvarchar(MAX) - Allow Nulls)
- regio (nvarchar(50) - Allow Nulls)
- achternaam (nvarchar(50) - Allow Nulls)
- voornaam (nvarchar (50) - Allow Nulls) 

Pas ten slotte de connectiestring aan in configuratiebestand **appsettings.json** in je .server project.

T-SQL dat je kunt gebruiken voor de aanmaak van tabel **EIGENAAR**:
```sql
USE [VOORBEELD]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EIGENAAR](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[omschrijving] [nvarchar](max) NULL,
	[regio] [nvarchar](50) NULL,
	[achternaam] [nvarchar](50) NULL,
	[voornaam] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblEigenaar] PRIMARY KEY CLUSTERED 
 (
	[ID] ASC
 )
 WITH (PAD_INDEX = OFF, 
       STATISTICS_NORECOMPUTE = OFF, 
       IGNORE_DUP_KEY = OFF, 
       ALLOW_ROW_LOCKS = ON, 
       ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
```
Lees ook mijn [blog](https://www.mrasoft.nl) over C# en Blazor.
