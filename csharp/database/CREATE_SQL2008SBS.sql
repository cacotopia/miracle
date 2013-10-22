--创建实例数据库SQL2008SBS
/*
create database SQL2008SBS on primary
(
name=N'SQL2008SBS',
filename = N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\SQL2008SBS.mdf',
size = 3MB,maxsize=unlimited,filegrowth =10%
),
FILEGROUP fg1 default 
(
name =N'SQL2008SBSFG1_DATA1',
FILENAME =N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\SQL2008SBS_1.ndf',
size = 2MB, maxsize=unlimited,filegrowth = 2MB
),
(
name =N'SQL2008SBSFG1_DATA2',
FILENAME =N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\SQL2008SBS_2.ndf',
size = 2MB,MAXSIZE=unlimited,FILEGROWTH = 2MB
),
(
name =N'SQL2008SBSFG1_DATA3',
FILENAME =N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\SQL2008SBS_3.ndf',
size = 2MB,MAXSIZE=unlimited,FILEGROWTH = 2MB
)
LOG ON 
(
name = N'SQL2008SBS_LOG',
FILENAME=N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\SQL2008SBS.ldf',
size =2MB,maxsize = unlimited,filegrowth = 5MB
)
go
--创建实例数据库SQL2008SBSFS --FILESTREAM
create database SQL2008SBSFS on primary
(
name= N'SQL2008SBSFS',
filename=N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\SQL2008SBSFS.mdf',
size =3MB,maxsize = unlimited,filegrowth = 10%
),
filegroup DocumentFileStreamGroup contains filestream
(
name = N'FileStreamDocuments',
filename=N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\SQL2008SBSFS'
)
log on
(
name = N'SQL2008SBSFS_LOG',
filename= N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\SQL2008SBSFS.ldf',
size = 2MB,maxsize = unlimited,filegrowth=10%
)
go
*/
use SQL2008SBS
/*
go
create schema Customer authorization dbo
go
create schema Orders authorization dbo
go
create schema Products authorization dbo
go
create schema LoolupTables authorization dbo
go
*/
declare @fixedlength char(10),
        @variablelength varchar(10)
set  @fixedlength ='Text'
set @variablelength ='Text'
select DATALENGTH(@fixedlength)
select DATALENGTH(@variablelength)      

