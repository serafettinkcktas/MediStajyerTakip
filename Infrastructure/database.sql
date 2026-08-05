CREATE TABLE Roles
(
    Id varchar(50) PRIMARY KEY,
    Name varchar(50) NOT NULL
);

CREATE TABLE Accounts
(
    Id varchar(50) PRIMARY KEY,
    Email varchar(255) NOT NULL,
    Password varchar(255) NOT NULL,
    RoleId varchar(50) FOREIGN KEY REFERENCES Roles(Id),
    IsDeleted bit DEFAULT 0
);

CREATE TABLE UserProfiles
(
    Id varchar(50) PRIMARY KEY,
    AccountId varchar(50) FOREIGN KEY REFERENCES Accounts(Id),
    Name varchar(50) NOT NULL,
    Surname varchar(50) NOT NULL,
    Email varchar(50) NOT NULL,
    PhoneNumber varchar(20),
    PhotoUrl varchar(500),
    CvUrl varchar(500)
);

CREATE TABLE Mentors
(
    Id varchar(50) PRIMARY KEY,
    AccountId varchar(50) FOREIGN KEY REFERENCES Accounts(Id),
    ProfileId varchar(50) FOREIGN KEY REFERENCES UserProfiles(Id),
    InternCount integer,
    IsDeleted bit
);