BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Status" (
	"ID"	TEXT NOT NULL,
	"EnglishTitle"	TEXT,
	"GermanTitle"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Color" (
	"ID"	TEXT NOT NULL,
	"EnglishTitle"	TEXT,
	"GermanTitle"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Connection" (
	"ID"	TEXT NOT NULL,
	"Title"	TEXT,
	"ConnectionID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID"),
	FOREIGN KEY("ConnectionID") REFERENCES "Connection"("ID")
);
CREATE TABLE IF NOT EXISTS "Country" (
	"ID"	TEXT NOT NULL,
	"OriginalName"	TEXT,
	"EnglishName"	TEXT,
	"GermanName"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Genre" (
	"ID"	TEXT NOT NULL,
	"EnglishTitle"	TEXT,
	"GermanTitle"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Language" (
	"ID"	TEXT NOT NULL,
	"OriginalName"	TEXT,
	"EnglishName"	TEXT,
	"GermanName"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Person" (
	"ID"	TEXT NOT NULL,
	"FirstName"	TEXT,
	"LastName"	TEXT,
	"NameAddOn"	TEXT,
	"BirthName"	TEXT,
	"DateOfBirth"	TEXT,
	"DateOfDeath"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Type" (
	"ID"	TEXT NOT NULL,
	"EnglishTitle"	TEXT,
	"GermanTitle"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie" (
	"ID"	TEXT NOT NULL,
	"OriginalTitle"	TEXT,
	"EnglishTitle"	TEXT,
	"GermanTitle"	TEXT,
	"TypeID"	TEXT,
	"ReleaseDate"	TEXT,
	"ConnectionID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("TypeID") REFERENCES "Type"("ID"),
	FOREIGN KEY("ConnectionID") REFERENCES "Connection"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_Color" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"ColorID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("ColorID") REFERENCES "Color"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_Country" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"CountryID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("CountryID") REFERENCES "Country"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_Genre" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"GenreID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("GenreID") REFERENCES "Genre"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_Language" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"LanguageID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("LanguageID") REFERENCES "Language"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_Director" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"PersonID"	TEXT,
	"Role"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("PersonID") REFERENCES "Person"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
COMMIT;
