USE AdventureWorksOBP
GO

/*----------------  USERS, LOGIN, REGISTER   -------------------*/

CREATE TABLE Users(
Username NVARCHAR(50) UNIQUE NOT NULL,
Password NVARCHAR(50) NOT NULL
)
GO

INSERT INTO Users(Username, Password)
VALUES ('admin@admin.admin', 'admin')
GO

CREATE PROCEDURE Login
@username NVARCHAR(50),
@password NVARCHAR(50)
AS
BEGIN
SELECT COUNT(*) FROM Users as u
WHERE u.Username = @username AND u.Password = @password
END
GO

CREATE PROCEDURE Register
@username NVARCHAR(50),
@password NVARCHAR(50)
AS
BEGIN 

IF 
(SELECT COUNT(*) FROM Users as u
WHERE u.Username = @username) > 0 
BEGIN
SELECT 1
END

ELSE
BEGIN
INSERT INTO Users(Username, Password)
VALUES (@username, @password)
SELECT 0
END

END
GO

/*----------------  SELECT   -------------------*/

CREATE PROCEDURE GetDrzave
AS
BEGIN 
SELECT * FROM DRZAVA
END
GO

CREATE PROCEDURE GetGradoviFromDrzava
@drzavaID int
AS
BEGIN 
SELECT * FROM Grad as g
WHERE g.DrzavaID = @drzavaID
END
GO

CREATE PROCEDURE GetRacuni
@kupacid INT
AS
BEGIN
SELECT * FROM Racun as r
WHERE r.KupacID = @kupacid
END
GO

CREATE PROCEDURE GetKupci
AS
BEGIN
SELECT * FROM Kupac 
END
GO

CREATE PROCEDURE GetKomercijalist
@IDKomercijalist INT
AS
BEGIN
SELECT * FROM Komercijalist as k
WHERE k.IDKomercijalist = @IDKomercijalist
END
GO

CREATE PROCEDURE GetKreditnaKartica
@IDKreditnaKartica INT
AS
BEGIN
SELECT * FROM KreditnaKartica as kk
WHERE kk.IDKreditnaKartica = @IDKreditnaKartica
END
GO

CREATE PROCEDURE GetStavke
@IDRacun INT
AS
BEGIN
SELECT * FROM Stavka as s
WHERE s.RacunID = @IDRacun
END
GO

ALTER PROCEDURE GetStavkeVM
@IDRacun INT
AS
BEGIN
SELECT *,
pk.Naziv as 'PotkategorijaNaziv',
k.Naziv as 'KategorijaNaziv',
pz.Naziv as 'ProizvodNaziv'
FROM Stavka as s
INNER JOIN Proizvod as pz
ON pz.IDProizvod = s.ProizvodID
INNER JOIN Potkategorija as pk
ON pk.IDPotkategorija = pz.PotkategorijaID
INNER JOIN Kategorija as k
ON k.IDKategorija = pk.KategorijaID
WHERE s.RacunID = @IDRacun
END
GO

CREATE PROCEDURE GetKategorije
AS
BEGIN
SELECT * FROM Kategorija
END
GO

CREATE PROCEDURE GetPotkategorije
AS
BEGIN
SELECT * FROM Potkategorija
END
GO

CREATE PROCEDURE GetProizvod
@IDProizvod INT
AS
BEGIN
SELECT * FROM Proizvod as p
WHERE p.IDProizvod = @IDProizvod
END
GO

CREATE PROCEDURE GetPotkategorija
@IDPotkategorija INT
AS
BEGIN
SELECT * FROM Potkategorija as p
WHERE p.IDPotkategorija = @IDPotkategorija
END
GO

CREATE PROCEDURE GetKategorija
@IDKategorija INT
AS
BEGIN
SELECT * FROM Kategorija as k
WHERE k.IDKategorija = @IDKategorija
END
GO

/*----------------  DELETE   -------------------*/
CREATE PROCEDURE DeleteProizvod
@IDProizvod INT
AS
BEGIN
DELETE FROM Stavka
WHERE ProizvodID = @IDProizvod
DELETE FROM Proizvod
WHERE IDProizvod = @IDProizvod
END
GO

CREATE PROC DeleteKategorija
@IDKategorija int
AS
BEGIN
DELETE FROM Stavka WHERE ProizvodID IN
(SELECT IDProizvod FROM Proizvod WHERE PotkategorijaID IN
(SELECT IDPotkategorija FROM Potkategorija WHERE KategorijaID = @IDKategorija))
DELETE FROM Proizvod WHERE PotkategorijaID IN
(SELECT IDPotkategorija FROM Potkategorija WHERE KategorijaID = @IDKategorija)
DELETE FROM Potkategorija WHERE KategorijaID = @IDKategorija
DELETE FROM Kategorija WHERE IDKategorija = @IDKategorija
END
GO

CREATE PROC DeletePotkategorija
@IDPotkategorija int
AS
BEGIN
DELETE FROM Stavka WHERE ProizvodID IN
(SELECT IDProizvod FROM Proizvod WHERE PotkategorijaID = @IDPotkategorija)
DELETE FROM Proizvod WHERE PotkategorijaID = @IDPotkategorija
DELETE FROM Potkategorija WHERE IDPotkategorija = @IDPotkategorija
END
GO

/*----------------  UPDATE   -------------------*/
CREATE PROCEDURE UpdateProizvod
@IDProizvod INT,
@PotkategorijaID INT,
@Naziv NVARCHAR(50),
@BrojProizvoda NVARCHAR(50),
@Boja NVARCHAR(50),
@MinimalnaKolicinaNaSkladistu INT,
@CijenaBezPDV FLOAT
AS
BEGIN
UPDATE Proizvod 
SET
Naziv = @Naziv,
PotkategorijaID = @PotkategorijaID, 
BrojProizvoda = @BrojProizvoda,
Boja = @Boja,
MinimalnaKolicinaNaSkladistu = @MinimalnaKolicinaNaSkladistu,
CijenaBezPDV = @CijenaBezPDV
WHERE IDProizvod = @IDProizvod
END
GO

CREATE PROCEDURE UpdatePotkategorija
@IDPotkategorija INT,
@KategorijaID INT,
@Naziv NVARCHAR(50)
AS
BEGIN
UPDATE Potkategorija 
SET
Naziv = @Naziv,
KategorijaID = @KategorijaID
WHERE IDPotkategorija = @IDPotkategorija
END
GO

CREATE PROCEDURE UpdateKategorija
@IDKategorija INT,
@Naziv NVARCHAR(50)
AS
BEGIN
UPDATE Kategorija 
SET
Naziv = @Naziv
WHERE IDKategorija = @IDKategorija
END
GO

/*----------------  INSERT   -------------------*/

CREATE PROCEDURE InsertProizvod
@PotkategorijaID INT,
@Naziv NVARCHAR(50),
@BrojProizvoda NVARCHAR(50),
@Boja NVARCHAR(50),
@MinimalnaKolicinaNaSkladistu INT,
@CijenaBezPDV FLOAT
AS
BEGIN
INSERT INTO Proizvod(PotkategorijaID, Naziv, BrojProizvoda, Boja, MinimalnaKolicinaNaSkladistu, CijenaBezPDV)
VALUES(@PotkategorijaID, @Naziv, @BrojProizvoda, @Boja, @MinimalnaKolicinaNaSkladistu, @CijenaBezPDV)
END
GO

CREATE PROCEDURE InsertPotkategorija
@KategorijaID INT,
@Naziv NVARCHAR(50)
AS
BEGIN
INSERT INTO Potkategorija(KategorijaID, Naziv)
VALUES(@KategorijaID, @Naziv)
END
GO

CREATE PROCEDURE InsertKategorija
@Naziv NVARCHAR(50)
AS
BEGIN
INSERT INTO Kategorija(Naziv)
VALUES(@Naziv)
END
GO

/*----------------  TESTS   -------------------*/

SELECT * FROM Kupac WHERE IDKupac = 1
SELECT * FROM Racun WHERE KupacID = 1

SELECT * FROM Stavka
SELECT * FROM Proizvod WHERE IDProizvod = 778
SELECT * FROM Potkategorija WHERE IDPotkategorija = 12
SELECT * FROM Kategorija

