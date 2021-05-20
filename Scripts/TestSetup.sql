create database GeorgiaTechLibraryTest;

BEGIN TRAN create_tables;

CREATE TABLE Address (
    id int IDENTITY(1,1) PRIMARY KEY,
    city varchar(255),
    street varchar(255),
    type varchar(255) NOT NULL CHECK (type IN('campus', 'private')),
    floor smallint,
    apartment smallint,
);

CREATE TABLE Member (
    id int IDENTITY(1,1) PRIMARY KEY,
    ssn varchar(255) UNIQUE,
    campus_address_id int FOREIGN KEY REFERENCES Address(id),
    private_address_id int FOREIGN KEY REFERENCES Address(id),
    fname varchar(255),
    minit varchar(255),
    lname varchar(255),
    phone varchar(255),
    email varchar(255),
    entry_date date,
    card_expiry_date date,
    type varchar(255) NOT NULL CHECK (type IN('student', 'professor')),
);

CREATE TABLE Book (
    id int IDENTITY(1,1) PRIMARY KEY,
	isbn varchar(255),
    title varchar(255),
    year smallint,
    language varchar(255),
    edition smallint,
    binding varchar(255),
    can_lend bit NOT NULL,
    is_interesting bit NOT NULL,
);

CREATE TABLE Author (
    id int IDENTITY(1,1) PRIMARY KEY,
    fname varchar(255),
    minit varchar(255),
    lname varchar(255),
);

CREATE TABLE Library (
    id int IDENTITY(1,1) PRIMARY KEY,
    name varchar(256),
    agreement text,
);

CREATE TABLE Volume (
    id int NOT NULL,
    book_id int NOT NULL FOREIGN KEY REFERENCES Book(id),
    PRIMARY KEY (id, book_id),
    source_library_id int FOREIGN KEY REFERENCES Library(id),
    acquiry_date date,
);

CREATE TABLE BookAuthor (
    book_id int NOT NULL FOREIGN KEY REFERENCES Book(id),
    author_id int NOT NULL FOREIGN KEY REFERENCES Author(id),
    PRIMARY KEY (book_id, author_id),
);

CREATE TABLE Loan (
    member_id int NOT NULL FOREIGN KEY REFERENCES Member(id),
    volume_id int NOT NULL,
    book_id int NOT NULL,
    FOREIGN KEY (volume_id, book_id) REFERENCES Volume(id, book_id),
    PRIMARY KEY (member_id, volume_id, book_id),
    loan_date date NOT NULL,
    return_date date,
    due_date date,
);

COMMIT TRAN create_tables;

insert into Author (fname, minit, lname) values ('Halimeda', 'W', 'Jerrold');
insert into Author (fname, minit, lname) values ('Sioux', 'U', 'Gregersen');
insert into Author (fname, minit, lname) values ('Conney', 'Z', 'Mixhel');
insert into Author (fname, minit, lname) values ('Peg', 'I', 'Lobell');
insert into Author (fname, minit, lname) values ('Flint', 'W', 'Rappoport');
insert into Author (fname, minit, lname) values ('Tobin', 'B', 'Moens');
insert into Author (fname, minit, lname) values ('Colene', 'Z', 'Agates');
insert into Author (fname, minit, lname) values ('Kara-lynn', 'G', 'Biggar');
insert into Author (fname, minit, lname) values ('Conny', 'W', 'Tocher');
insert into Author (fname, minit, lname) values ('Thomas', 'X', 'Stranieri');
insert into Author (fname, minit, lname) values ('Cassy', 'K', 'Aubri');
insert into Author (fname, minit, lname) values ('Nicolais', 'V', 'Fenlon');
insert into Author (fname, minit, lname) values ('Minna', 'H', 'O''Cuddie');
insert into Author (fname, minit, lname) values ('Junia', 'G', 'Christofle');
insert into Author (fname, minit, lname) values ('Adrienne', 'Y', 'Jowett');
insert into Author (fname, minit, lname) values ('Karlan', 'E', 'Ohlsen');
insert into Author (fname, minit, lname) values ('Dar', 'S', 'Darree');
insert into Author (fname, minit, lname) values ('Packston', 'T', 'Eidelman');
insert into Author (fname, minit, lname) values ('Tansy', 'U', 'Spaice');
insert into Author (fname, minit, lname) values ('Roddy', 'G', 'Code');
insert into Author (fname, minit, lname) values ('Jerald', 'S', 'Watling');