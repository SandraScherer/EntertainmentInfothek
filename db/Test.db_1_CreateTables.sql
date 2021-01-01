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
CREATE TABLE IF NOT EXISTS "AspectRatio" (
	"ID"	TEXT NOT NULL,
	"Ratio"	TEXT,
	"Name"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Camera" (
	"ID"	TEXT NOT NULL,
	"Name"	TEXT,
	"Lense"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "CinematographicProcess" (
	"ID"	TEXT NOT NULL,
	"Name"	TEXT,
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
	FOREIGN KEY("ConnectionID") REFERENCES "Connection"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
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
CREATE TABLE IF NOT EXISTS "Edition" (
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
CREATE TABLE IF NOT EXISTS "FilmFormat" (
	"ID"	TEXT NOT NULL,
	"Name"	TEXT,
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
CREATE TABLE IF NOT EXISTS "Laboratory" (
	"ID"	TEXT NOT NULL,
	"Name"	TEXT,
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
CREATE TABLE IF NOT EXISTS "Priority" (
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
CREATE TABLE IF NOT EXISTS "SoundMix" (
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
CREATE TABLE IF NOT EXISTS "Company" (
	"ID"	TEXT NOT NULL,
	"Name"	TEXT,
	"NameAddOn"	TEXT,
	"TypeID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("TypeID") REFERENCES "Type"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Award" (
	"ID"	TEXT NOT NULL,
	"Name"	TEXT,
	"PresenterID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("PresenterID") REFERENCES "Company"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Image" (
	"ID"	TEXT NOT NULL,
	"FileName"	TEXT,
	"Description"	TEXT,
	"TypeID"	TEXT,
	"CountryID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("TypeID") REFERENCES "Type"("ID"),
	FOREIGN KEY("CountryID") REFERENCES "Country"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Image_Source" (
	"ID"	TEXT NOT NULL,
	"ImageID"	TEXT,
	"CompanyID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("ImageID") REFERENCES "Image"("ID"),
	FOREIGN KEY("CompanyID") REFERENCES "Company"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Certification" (
	"ID"	TEXT NOT NULL,
	"Name"	TEXT,
	"ImageID"	TEXT,
	"CountryID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("ImageID") REFERENCES "Image"("ID"),
	FOREIGN KEY("CountryID") REFERENCES "Country"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Location" (
	"ID"	TEXT NOT NULL,
	"Location"	TEXT,
	"CountryID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("CountryID") REFERENCES "Country"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Person" (
	"ID"	TEXT NOT NULL,
	"FirstName"	TEXT,
	"LastName"	TEXT,
	"NameAddOn"	TEXT,
	"BirthName"	TEXT,
	"DateOfBirth"	TEXT,
	"LocationOfBirthID"	TEXT,
	"DateOfDeath"	TEXT,
	"LocationOfDeathID"	TEXT,
	"CauseOfDeath"	TEXT,
	"EmployerID"	TEXT,
	"TypeID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("LocationOfBirthID") REFERENCES "Location"("ID"),
	FOREIGN KEY("LocationOfDeathID") REFERENCES "Location"("ID"),
	FOREIGN KEY("EmployerID") REFERENCES "Company"("ID"),
	FOREIGN KEY("TypeID") REFERENCES "Type"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Text" (
	"ID"	TEXT NOT NULL,
	"Content"	TEXT,
	"LanguageID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("LanguageID") REFERENCES "Language"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Text_Author" (
	"ID"	TEXT NOT NULL,
	"TextID"	TEXT,
	"PersonID"	TEXT,
	"Role"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("TextID") REFERENCES "Text"("ID"),
	FOREIGN KEY("PersonID") REFERENCES "Person"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Text_Source" (
	"ID"	TEXT NOT NULL,
	"TextID"	TEXT,
	"CompanyID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("TextID") REFERENCES "Text"("ID"),
	FOREIGN KEY("CompanyID") REFERENCES "Company"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Weblink" (
	"ID"	TEXT NOT NULL,
	"URL"	TEXT,
	"EnglishTitle"	TEXT,
	"GermanTitle"	TEXT,
	"LanguageID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("LanguageID") REFERENCES "Language"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "User" (
	"ID"	TEXT NOT NULL,
	"UserName"	TEXT,
	"EMail"	TEXT,
	"PersonID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("PersonID") REFERENCES "Person"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie" (
	"ID"	TEXT NOT NULL,
	"OriginalTitle"	TEXT,
	"EnglishTitle"	TEXT,
	"GermanTitle"	TEXT,
	"TypeID"	TEXT,
	"ReleaseDate"	TEXT,
	"LogoID"	TEXT,
	"Budget"	TEXT,
	"WorldwideGross"	TEXT,
	"WorldwideGrossDate"	TEXT,
	"CastStatusID"	TEXT,
	"CrewStatusID"	TEXT,
	"ConnectionID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("TypeID") REFERENCES "Type"("ID"),
	FOREIGN KEY("LogoID") REFERENCES "Image"("ID"),
	FOREIGN KEY("CastStatusID") REFERENCES "Status"("ID"),
	FOREIGN KEY("CrewStatusID") REFERENCES "Status"("ID"),
	FOREIGN KEY("ConnectionID") REFERENCES "Connection"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_AnimationDepartment" (
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
CREATE TABLE IF NOT EXISTS "Movie_ArtDepartment" (
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
CREATE TABLE IF NOT EXISTS "Movie_ArtDirector" (
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
CREATE TABLE IF NOT EXISTS "Movie_AspectRatio" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"AspectRatioID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("AspectRatioID") REFERENCES "AspectRatio"("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_AssistantDirector" (
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
CREATE TABLE IF NOT EXISTS "Movie_Award" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"AwardID"	TEXT,
	"Category"	TEXT,
	"Year"	TEXT,
	"Winner"	INTEGER,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("AwardID") REFERENCES "Award"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_Award_Person" (
	"ID"	TEXT NOT NULL,
	"Movie_AwardID"	TEXT,
	"PersonID"	TEXT,
	"Role"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("Movie_AwardID") REFERENCES "Movie_Award"("ID"),
	FOREIGN KEY("PersonID") REFERENCES "Person"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_Camera" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"CameraID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("CameraID") REFERENCES "Camera"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_Cast" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"ActorID"	TEXT,
	"DubberID"	TEXT,
	"Character"	TEXT,
	"CharacterID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("ActorID") REFERENCES "Person"("ID"),
	FOREIGN KEY("DubberID") REFERENCES "Person"("ID"),
	FOREIGN KEY("CharacterID") REFERENCES "Person"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_Casting" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"PersonID"	TEXT,
	"Role"	TEXT,
	"Details"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("PersonID") REFERENCES "Person"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_CastingDepartment" (
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
CREATE TABLE IF NOT EXISTS "Movie_Certification" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"CertificationID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("CertificationID") REFERENCES "Certification"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_Cinematographer" (
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
CREATE TABLE IF NOT EXISTS "Movie_CinematographicProcess" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"CinematographicProcessID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("CinematographicProcessID") REFERENCES "CinematographicProcess"("ID"),
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
CREATE TABLE IF NOT EXISTS "Movie_ContinuityDepartment" (
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
CREATE TABLE IF NOT EXISTS "Movie_CostumeDepartment" (
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
CREATE TABLE IF NOT EXISTS "Movie_CostumeDesigner" (
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
CREATE TABLE IF NOT EXISTS "Movie_Cover" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"ImageID"	TEXT,
	"EditionID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("ImageID") REFERENCES "Image"("ID"),
	FOREIGN KEY("EditionID") REFERENCES "Edition"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_Description" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"TextID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("TextID") REFERENCES "Text"("ID"),
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
CREATE TABLE IF NOT EXISTS "Movie_Distributor" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"CompanyID"	TEXT,
	"CountryID"	TEXT,
	"ReleaseDate"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("CompanyID") REFERENCES "Company"("ID"),
	FOREIGN KEY("CountryID") REFERENCES "Country"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_EditorialDepartment" (
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
CREATE TABLE IF NOT EXISTS "Movie_ElectricalDepartment" (
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
CREATE TABLE IF NOT EXISTS "Movie_FilmEditor" (
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
CREATE TABLE IF NOT EXISTS "Movie_FilmLength" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"Length"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_FilmingDate" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"StartDate"	TEXT,
	"EndDate"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_FilmingLocation" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"LocationID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("LocationID") REFERENCES "Location"("ID"),
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
CREATE TABLE IF NOT EXISTS "Movie_Image" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"ImageID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("ImageID") REFERENCES "Image"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_Laboratory" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"LaboratoryID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("LaboratoryID") REFERENCES "Laboratory"("ID"),
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
CREATE TABLE IF NOT EXISTS "Movie_LocationManagement" (
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
CREATE TABLE IF NOT EXISTS "Movie_MakeupDepartment" (
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
CREATE TABLE IF NOT EXISTS "Movie_MusicDepartment" (
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
CREATE TABLE IF NOT EXISTS "Movie_Musician" (
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
CREATE TABLE IF NOT EXISTS "Movie_NegativeFormat" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"FilmFormatID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("FilmFormatID") REFERENCES "FilmFormat"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_OtherCompany" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"CompanyID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("CompanyID") REFERENCES "Company"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_OtherCrew" (
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
CREATE TABLE IF NOT EXISTS "Movie_Poster" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"ImageID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("ImageID") REFERENCES "Image"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_PrintedFilmFormat" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"FilmFormatID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("FilmFormatID") REFERENCES "FilmFormat"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_Producer" (
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
CREATE TABLE IF NOT EXISTS "Movie_ProductionCompany" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"CompanyID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("CompanyID") REFERENCES "Company"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_ProductionDate" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"StartDate"	TEXT,
	"EndDate"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_ProductionDesigner" (
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
CREATE TABLE IF NOT EXISTS "Movie_ProductionManagement" (
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
CREATE TABLE IF NOT EXISTS "Movie_Review" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"TextID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("TextID") REFERENCES "Text"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_Runtime" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"Runtime"	INTEGER,
	"EditionID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("EditionID") REFERENCES "Edition"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_SetDecorator" (
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
CREATE TABLE IF NOT EXISTS "Movie_SoundDepartment" (
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
CREATE TABLE IF NOT EXISTS "Movie_SoundMix" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"SoundMixID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("SoundMixID") REFERENCES "SoundMix"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_SpecialEffects" (
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
CREATE TABLE IF NOT EXISTS "Movie_SpecialEffectsCompany" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"CompanyID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("CompanyID") REFERENCES "Company"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_Stunts" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"PersonID"	TEXT,
	"Role"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("PersonID") REFERENCES "Person"("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_Thanks" (
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
CREATE TABLE IF NOT EXISTS "Movie_TransportationDepartment" (
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
CREATE TABLE IF NOT EXISTS "Movie_User" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"UserID"	TEXT,
	"EditionID"	TEXT,
	"UserStatusID"	TEXT,
	"PriorityID"	TEXT,
	"Explanation"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("UserID") REFERENCES "User"("ID"),
	FOREIGN KEY("EditionID") REFERENCES "Edition"("ID"),
	FOREIGN KEY("UserStatusID") REFERENCES "Status"("ID"),
	FOREIGN KEY("PriorityID") REFERENCES "Priority"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_VisualEffects" (
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
CREATE TABLE IF NOT EXISTS "Movie_Weblink" (
	"ID"	TEXT NOT NULL,
	"MovieID"	TEXT,
	"WeblinkID"	TEXT,
	"Details"	TEXT,
	"Notes"	TEXT,
	"StatusID"	TEXT,
	"LastUpdated"	TEXT,
	PRIMARY KEY("ID"),
	FOREIGN KEY("MovieID") REFERENCES "Movie"("ID"),
	FOREIGN KEY("WeblinkID") REFERENCES "Weblink"("ID"),
	FOREIGN KEY("StatusID") REFERENCES "Status"("ID")
);
CREATE TABLE IF NOT EXISTS "Movie_Writer" (
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
