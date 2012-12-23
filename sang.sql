use sangdbadmin
go

Select * from Warranties
select * from SangUsers

update SangUsers
Set Email = 'Notjmiguel@mipipol.com.mx'
Where SangUserID = 1

--Update Warranties
--Set IsActived = 1
--Where WarrantyID = 2

--Update SangClients
--Set Email = 'xxxx'
--Where WarrantyID = 2

select * from SangClients
select * from SangChilds
select * from ModelMattresses
select * from Collections
Select * from Newsletters
Select * from Hospitals


INSERT INTO Warranties(SangClientId,WarrantyCode, NAttempts, IsActived, ExpirationDate, RegisterDate)
Values(null,'TEST1231',0,1,getdate(),getdate())

insert into Collections (CollectionName, RegisterDate)
Values('Lyx resten', getdate())
insert into Collections (CollectionName, RegisterDate)
Values('Eliten resten', getdate())
insert into Collections (CollectionName, RegisterDate)
Values('Överdel resten', getdate())
INSERT INTO ModelMattresses (CollectionId,ModelName, MattressSize, IsActived, RegisterDate)
Values(1,'Livet','x',1,getdate())
INSERT INTO ModelMattresses (CollectionId,ModelName, MattressSize, IsActived, RegisterDate)
Values(1,'Onskan','x',1,getdate())
