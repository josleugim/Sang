use sangdbadmin
go

--INSERT INTO Hospitals(HospitalName, RegisterDate)
--Values('Ninguno', getdate())

--INSERT INTO Hospitals(HospitalName, HospitalAddress, HospitalLogo, DoctorName, RegisterDate)
--Values('Hospital ABC, M�xico, D.F.', '', '../../Content/images/ABC.jpg', '', getdate())
--INSERT INTO Hospitals(HospitalName, HospitalAddress, HospitalLogo, DoctorName, RegisterDate)
--Values('Hospital Angeles Pedregal', 'Cl�nica del Sue�o de la Cl�nica de Neurofisiolog�a, Hospital �ngeles del pedegral, Consultorio 151. Camino a Santa Teresa 1055, Col. H�roes de Padierna, M�xico, D.F., C.P. 10700.', '../../Content/images/Hospital-Angeles.jpg', 'Doctor name', getdate())
--INSERT INTO Hospitals(HospitalName, HospitalAddress, HospitalLogo, DoctorName, RegisterDate)
--Values('Hospital Espa�ol, M�xico, D.F.','', '../../Content/images/Hospital-Espanol.jpg', '', getdate())
--INSERT INTO Hospitals(HospitalName, HospitalAddress, HospitalLogo, DoctorName, RegisterDate)
--Values('Cl�nica del Ronquido y Apnea del Sue�o, Guadalajara, Jal.', '', '../../Content/images/Guadalajara.jpg', '', getdate())

--insert into Collections (CollectionName, RegisterDate)
--Values('Lyx resten', getdate())
--insert into Collections (CollectionName, RegisterDate)
--Values('Eliten resten', getdate())
--insert into Collections (CollectionName, RegisterDate)
--Values('�verdel resten', getdate())
--INSERT INTO ModelMattresses (CollectionId,ModelName, IsActived, RegisterDate)
--Values(1,'Livet',1,getdate())
--INSERT INTO ModelMattresses (CollectionId,ModelName, IsActived, RegisterDate)
--Values(1,'Onskan',1,getdate())

update SangUsers
Set Email = 'blank@mipipol.com.mx'
Where SangUserID = 1

--Update Warranties
--Set IsActived = 1
--Where WarrantyID = 2

--Update SangClients
--Set Email = 'xxxx'
--Where WarrantyID = 2

Select * from Warranties
select * from SangUsers
select * from SangClients
Where SangUserId = 1
select * from SangChilds
select * from ModelMattresses
select * from Collections
Select * from Newsletters
Select * from Hospitals
select * from Purchases
Select * from Coupons

--Delete from SangUsers
--Delete From ModelMattresses
--Delete From Collections
--Delete from Warranties

--drop table Collections
--drop table ModelMattresses
--drop table SangUsers
--drop table SangClients
--drop table SangChilds
--drop table Warranties
--drop table Purchases

INSERT INTO Warranties(SangClientId,WarrantyCode, NAttempts, IsActived, ExpirationDate, RegisterDate)
Values(null,'TEST1234',0,1,getdate(),getdate())