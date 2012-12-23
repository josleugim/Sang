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
select * from ModelMattresses
select * from Collections
Select * from Newsletters
Select * from Hospitals


INSERT INTO Warranties(SangClientId,WarrantyCode, NAttempts, IsActived, ExpirationDate, RegisterDate)
Values(null,'TEST1231',0,1,getdate(),getdate())

INSERT INTO Hospitals(HospitalName, RegisterDate)
Values('Ninguno', getdate())
INSERT INTO Hospitals(HospitalName, RegisterDate)
Values('Hospital ABC, México, D.F.', getdate())

insert into Collections (CollectionName, RegisterDate)
Values('Lyx resten', getdate())
insert into Collections (CollectionName, RegisterDate)
Values('Eliten resten', getdate())
insert into Collections (CollectionName, RegisterDate)
Values('Överdel resten', getdate())
INSERT INTO ModelMattresses (CollectionId,ModelName, IsActived, RegisterDate)
Values(1,'Livet',1,getdate())
INSERT INTO ModelMattresses (CollectionId,ModelName, IsActived, RegisterDate)
Values(1,'Onskan',1,getdate())
