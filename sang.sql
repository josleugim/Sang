use sangdbadmin
go

--INSERT INTO Hospitals(HospitalName, RegisterDate)
--Values('Ninguno', getdate())

--INSERT INTO Hospitals(HospitalName, HospitalAddress, HospitalLogo, DoctorName, RegisterDate)
--Values('Hospital ABC, México, D.F.', 'Tel. (55) 1664-7100 y 04 Centro Médico ABC, Santa Fe, México D.F.', '../../Content/images/ABC.jpg', '../../Content/images/DrABC.jpg', getdate())
--INSERT INTO Hospitals(HospitalName, HospitalAddress, HospitalLogo, DoctorName, RegisterDate)
--Values('Hospital Angeles Pedregal, D.F.', 'Clínica del Sueño de la Clínica de Neurofisiología, Hospital Ángeles del pedegral, Consultorio 151. Camino a Santa Teresa 1055, Col. Héroes de Padierna, México, D.F., C.P. 10700. uniner@gmail.com', '../../Content/images/Hospital-Angeles.jpg', '../../Content/images/DrAngeles.jpg', getdate())
--INSERT INTO Hospitals(HospitalName, HospitalAddress, HospitalLogo, DoctorName, RegisterDate)
--Values('Hospital Español, México, D.F.','Clínica del Sueño del Laboratorio de Neurofisiología Clínica del Hospital Español. Tel. (55) 5254-0909 Hospital Español. Ejército Nacional 613 PB, Col. Granada, México D.F.', '../../Content/images/Hospital-Espanol.jpg', '../../Content/images/DrEspanol.jpg', getdate())
--INSERT INTO Hospitals(HospitalName, HospitalAddress, HospitalLogo, DoctorName, RegisterDate)
--Values('Clínica del Ronquido y Apnea del Sueño, Guadalajara, Jal.', 'Torre de especialidades del Hospital Ángeles del Carmen. Tel. (33) 3648-3466 Tarascos 3473, piso 8, int. 830, Fracc. Monraz, Guadalajara Jal. www.ronquido.mx', '../../Content/images/Guadalajara.jpg', '../../Content/images/DrGuadalajara.jpg', getdate())

select * from Hospitals

--UPDATE Hospitals
--SET DoctorName = '../../Content/images/DrABC.jpg'
--WHERE HospitalID = 1

--insert into Collections (CollectionName, RegisterDate)
--Values('Lyx resten', getdate())
--insert into Collections (CollectionName, RegisterDate)
--Values('Eliten resten', getdate())
--insert into Collections (CollectionName, RegisterDate)
--Values('Överdel resten', getdate())
--INSERT INTO ModelMattresses (CollectionId,ModelName, IsActived, RegisterDate)
--Values(1,'Livet',1,getdate())
--INSERT INTO ModelMattresses (CollectionId,ModelName, IsActived, RegisterDate)
--Values(1,'Onskan',1,getdate())

--update SangUsers
--Set Email = 'blank@mipipol.com.mx'
--Where SangUserID = 1

--Update Warranties
--Set IsActived = 1
--Where WarrantyID = 2

--Update SangClients
--Set Email = 'xxxx'
--Where WarrantyID = 2

Select * from Warranties
select * from SangUsers
select * from SangClients
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
Values(null,'TEST0005',0,1,getdate(),getdate())