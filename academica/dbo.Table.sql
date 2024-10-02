CREATE TABLE [dbo].[materias]
(
	[IdMaterias] INT IDENTITY (1, 1) NOT NULL,
    [codigo] CHAR(10) NOT NULL, 
    [nombre] CHAR(75) NOT NULL, 
    [uv] CHAR(10) NOT NULL
	PRIMARY KEY CLUSTERED ([IdMaterias] ASC)
)
