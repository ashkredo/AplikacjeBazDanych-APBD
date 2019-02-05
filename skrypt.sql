CREATE TABLE Owner
(
    IdOwner INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    BirthDate DATETIME NOT NULL,
    RegisterDate DATETIME NOT NULL
);
GO

INSERT INTO Owner(FirstName, LastName, BirthDate, RegisterDate)
VALUES
('John', 'Smith', '1980/02/13', GETDATE()),
('John', 'Malkovich', '1972/2/06', GETDATE()),
('Anna', 'Malewska', '1982/12/05', GETDATE()),
('Andrzej', 'Lubelska', '1980/12/04', GETDATE()),
('Julian', 'Lenowicz', '1981/4/01', GETDATE()),
('Marta', 'Kub³owska', '1989/11/08', GETDATE())
GO

CREATE TABLE AnimalType
(
    IdAnimalType INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50) NOT NULL
)
GO

INSERT INTO AnimalType(Name)
VALUES
('Cat'),
('Dog'),
('Elephant'),
('Snake')
GO

CREATE TABLE Animal
(
    IdAnimal INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50) NOT NULL,
    IdAnimalType INT REFERENCES AnimalType,
    IdOwner INT REFERENCES Owner
)
GO

INSERT INTO Animal(Name, IdAnimalType, IdOwner)
VALUES ('Max', 2, 1),
('Fluffy', 1, 1),
('Robin', 1, 2),
('Fido', 3, 1),
('Shirley', 4, 3)
GO