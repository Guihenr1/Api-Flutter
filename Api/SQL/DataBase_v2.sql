-- Drop tables existent
DROP TABLE IF EXISTS "User" CASCADE;
DROP TABLE IF EXISTS Product CASCADE;

-- Create tables
CREATE TABLE "User"
(
    "ID" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "UserName" varchar(50) NOT NULL,
    "Password" varchar(15) NOT NULL,
    "Role" int NOT NULL,
    CONSTRAINT "PK_User" PRIMARY KEY ("ID") 
);

CREATE TABLE Product
(
    "ID" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Name" varchar(50) NOT NULL,
    "Description" varchar(100) NOT NULL,
    "Image" varchar(150) NOT NULL,
    CONSTRAINT "PK_Product" PRIMARY KEY ("ID") 
);

-- Insert datas
INSERT INTO "User" ("UserName", "Password", "Role") VALUES ('guilherme', '123456', 1); -- Manager 
INSERT INTO "User" ("UserName", "Password", "Role") VALUES ('henrique', '123456', 0); -- Employee

INSERT INTO Product ("Name", "Description", "Image") VALUES ('Camiseta show de bola', 'Camiseta 100% algodao', 'camiseta1.jpg');
INSERT INTO Product ("Name", "Description", "Image") VALUES ('Caneca star bugs', 'Caneca de porcelana', 'caneca1.jpg');
