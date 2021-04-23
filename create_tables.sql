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