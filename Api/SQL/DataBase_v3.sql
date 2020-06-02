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
    "Category" integer NOT NULL,
    CONSTRAINT "PK_Product" PRIMARY KEY ("ID") 
);

-- Insert datas
INSERT INTO "User" ("UserName", "Password", "Role") VALUES ('guilherme', '123456', 1); -- Manager 
INSERT INTO "User" ("UserName", "Password", "Role") VALUES ('henrique', '123456', 0); -- Employee

INSERT INTO Product ("Name", "Description", "Image", "Category") VALUES ('Camiseta show de bola', 'Camiseta 100% algodao', 'camiseta1.jpg', 1);
INSERT INTO Product ("Name", "Description", "Image", "Category") VALUES ('Caneca star bugs', 'Caneca de porcelana', 'caneca1.jpg', 2);
INSERT INTO Product ("Name", "Description", "Image", "Category") VALUES ('Camiseta branca', 'Camiseta de algodão organico', 'camiseta2.jpg', 1);
INSERT INTO Product ("Name", "Description", "Image", "Category") VALUES ('Caneca programador', 'Caneca de qualidade', 'caneca2.jpg', 2);
