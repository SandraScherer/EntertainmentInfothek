﻿// EntertainmentDB.dll: Provides access to the EntertainmentInfothek.db
// Copyright (C) 2020 Sandra Scherer

// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.


using EntertainmentDB.DBAccess.Read;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EntertainmentDB.Data
{
    /// <summary>
    /// Provides a movie.
    /// </summary>
    public class Movie : Entry
    {
        // --- Properties ---

        /// <summary>
        /// The original title of the movie.
        /// </summary>
        public string OriginalTitle { get; set; }

        /// <summary>
        /// The english title of the movie.
        /// </summary>
        public string EnglishTitle { get; set; }

        /// <summary>
        /// The german title of the movie.
        /// </summary>
        public string GermanTitle { get; set; }

        /// <summary>
        /// The type of the movie.
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// The release date of the movie.
        /// </summary>
        public string ReleaseDate { get; set; }

        /// <summary>
        /// The logo of the movie.
        /// </summary>
        public Image Logo { get; set; }

        /// <summary>
        /// The budget of the movie.
        /// </summary>
        public string Budget { get; set; }

        /// <summary>
        /// The worldwide gross of the movie.
        /// </summary>
        public string WorldwideGross { get; set; }

        /// <summary>
        /// The corresponding date to the worldwide gross of the movie.
        /// </summary>
        public string WorldwideGrossDate { get; set; }

        /// <summary>
        /// The cast status of the entry.
        /// </summary>
        public Status CastStatus { get; set; }

        /// <summary>
        /// The crew status of the entry.
        /// </summary>
        public Status CrewStatus { get; set; }

        /// <summary>
        /// The connection of the movie.
        /// </summary>
        public Connection Connection { get; set; }

        /// <summary>
        /// The list of genres of the movie.
        /// </summary>
        public List<GenreItem> Genres { get; set; }

        /// <summary>
        /// The list of certifications of the movie.
        /// </summary>
        public List<CertificationItem> Certifications { get; set; }

        /// <summary>
        /// The list of countries of the movie.
        /// </summary>
        public List<CountryItem> Countries { get; set; }

        /// <summary>
        /// The list of languages of the movie.
        /// </summary>
        public List<LanguageItem> Languages { get; set; }

        /// <summary>
        /// The list of runtimes of the movie.
        /// </summary>
        public List<RuntimeItem> Runtimes { get; set; }

        /// <summary>
        /// The list of sound mixes of the movie.
        /// </summary>
        public List<SoundMixItem> SoundMixes { get; set; }

        /// <summary>
        /// The list of colors of the movie.
        /// </summary>
        public List<ColorItem> Colors { get; set; }

        /// <summary>
        /// The list of aspect ratios of the movie.
        /// </summary>
        public List<AspectRatioItem> AspectRatios { get; set; }

        /// <summary>
        /// The list of cameras of the movie.
        /// </summary>
        public List<CameraItem> Cameras { get; set; }

        /// <summary>
        /// The list of laboratories of the movie.
        /// </summary>
        public List<LaboratoryItem> Laboratories { get; set; }

        /// <summary>
        /// The list of film lengths of the movie.
        /// </summary>
        public List<FilmLengthItem> FilmLengths { get; set; }

        /// <summary>
        /// The list of negative formats of the movie.
        /// </summary>
        public List<NegativeFormatItem> NegativeFormats { get; set; }

        /// <summary>
        /// The list of cinematographic processes of the movie.
        /// </summary>
        public List<CinematographicProcessItem> CinematographicProcesses { get; set; }

        /// <summary>
        /// The list of printed film formats of the movie.
        /// </summary>
        public List<PrintedFilmFormatItem> PrintedFilmFormats { get; set; }

        /// <summary>
        /// The list of directors of the movie.
        /// </summary>
        public List<PersonItem> Directors { get; set; }

        /// <summary>
        /// The list of writers of the movie.
        /// </summary>
        public List<PersonItem> Writers { get; set; }

        /// <summary>
        /// The list of the cast of the movie.
        /// </summary>
        public List<CastPersonItem> Cast { get; set; }

        /// <summary>
        /// The list of producers of the movie.
        /// </summary>
        public List<PersonItem> Producers { get; set; }

        /// <summary>
        /// The list of music responsibles of the movie.
        /// </summary>
        public List<PersonItem> Music { get; set; }

        /// <summary>
        /// The list of cinematography responsibles of the movie.
        /// </summary>
        public List<PersonItem> Cinematography { get; set; }

        /// <summary>
        /// The list of film editing responsibles of the movie.
        /// </summary>
        public List<PersonItem> FilmEditing { get; set; }

        /// <summary>
        /// The list of casting responsibles of the movie.
        /// </summary>
        public List<PersonItem> Casting { get; set; }

        /// <summary>
        /// The list of production design responsibles of the movie.
        /// </summary>
        public List<PersonItem> ProductionDesign { get; set; }

        /// <summary>
        /// The list of art direction responsibles of the movie.
        /// </summary>
        public List<PersonItem> ArtDirection { get; set; }

        /// <summary>
        /// The list of set decoration responsibles of the movie.
        /// </summary>
        public List<PersonItem> SetDecoration { get; set; }

        /// <summary>
        /// The list of costume design responsibles of the movie.
        /// </summary>
        public List<PersonItem> CostumeDesign { get; set; }

        /// <summary>
        /// The list of makeup department members of the movie.
        /// </summary>
        public List<PersonItem> MakeupDepartment { get; set; }

        /// <summary>
        /// The list of production management members of the movie.
        /// </summary>
        public List<PersonItem> ProductionManagement { get; set; }

        /// <summary>
        /// The list of assistant directors of the movie.
        /// </summary>
        public List<PersonItem> AssistantDirectors { get; set; }

        /// <summary>
        /// The list of art department members of the movie.
        /// </summary>
        public List<PersonItem> ArtDepartment { get; set; }

        /// <summary>
        /// The list of sound department members of the movie.
        /// </summary>
        public List<PersonItem> SoundDepartment { get; set; }

        /// <summary>
        /// The list of special effects members of the movie.
        /// </summary>
        public List<PersonItem> SpecialEffects { get; set; }

        /// <summary>
        /// The list of visual effects members of the movie.
        /// </summary>
        public List<PersonItem> VisualEffects { get; set; }

        /// <summary>
        /// The list of stunts members of the movie.
        /// </summary>
        public List<PersonItem> Stunts { get; set; }

        /// <summary>
        /// The list of electrical department members of the movie.
        /// </summary>
        public List<PersonItem> ElectricalDepartment { get; set; }

        /// <summary>
        /// The list of animation department members of the movie.
        /// </summary>
        public List<PersonItem> AnimationDepartment { get; set; }

        /// <summary>
        /// The list of casting department members of the movie.
        /// </summary>
        public List<PersonItem> CastingDepartment { get; set; }

        /// <summary>
        /// The list of costume department members of the movie.
        /// </summary>
        public List<PersonItem> CostumeDepartment { get; set; }

        /// <summary>
        /// The list of editorial department members of the movie.
        /// </summary>
        public List<PersonItem> EditorialDepartment { get; set; }

        /// <summary>
        /// The list of location management members of the movie.
        /// </summary>
        public List<PersonItem> LocationManagement { get; set; }

        /// <summary>
        /// The list of music department members of the movie.
        /// </summary>
        public List<PersonItem> MusicDepartment { get; set; }

        /// <summary>
        /// The list of continuity department members of the movie.
        /// </summary>
        public List<PersonItem> ContinuityDepartment { get; set; }

        /// <summary>
        /// The list of transportation department members of the movie.
        /// </summary>
        public List<PersonItem> TransportationDepartment { get; set; }

        /// <summary>
        /// The list of other crew members of the movie.
        /// </summary>
        public List<PersonItem> OtherCrew { get; set; }

        /// <summary>
        /// The list of thanks of the movie.
        /// </summary>
        public List<PersonItem> Thanks { get; set; }

        /// <summary>
        /// The list of production companies of the movie.
        /// </summary>
        public List<CompanyItem> ProductionCompanies { get; set; }

        /// <summary>
        /// The list of distributors of the movie.
        /// </summary>
        public List<DistributorCompanyItem> Distributors { get; set; }

        /// <summary>
        /// The list of special effects companies of the movie.
        /// </summary>
        public List<CompanyItem> SpecialEffectsCompanies { get; set; }

        /// <summary>
        /// The list of other companies of the movie.
        /// </summary>
        public List<CompanyItem> OtherCompanies { get; set; }

        /// <summary>
        /// The list of filming locations of the movie.
        /// </summary>
        public List<LocationItem> FilmingLocations { get; set; }

        /// <summary>
        /// The list of filming dates of the movie.
        /// </summary>
        public List<TimespanItem> FilmingDates { get; set; }

        /// <summary>
        /// The list of production dates of the movie.
        /// </summary>
        public List<TimespanItem> ProductionDates { get; set; }

        /// <summary>
        /// The list of posters of the movie.
        /// </summary>
        public List<ImageItem> Posters { get; set; }

        /// <summary>
        /// The list of covers of the movie.
        /// </summary>
        public List<ImageItem> Covers { get; set; }

        /// <summary>
        /// The list of images of the movie.
        /// </summary>
        public List<ImageItem> Images { get; set; }

        /// <summary>
        /// The list of descriptions of the movie.
        /// </summary>
        public List<TextItem> Descriptions { get; set; }

        /// <summary>
        /// The list of reviews of the movie.
        /// </summary>
        public List<TextItem> Reviews { get; set; }

        /// <summary>
        /// The list of awards of the movie.
        /// </summary>
        public List<AwardItem> Awards { get; set; }

        /// <summary>
        /// The list of weblinks of the movie.
        /// </summary>
        public List<WeblinkItem>Weblinks { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a movie with an empty id string.
        /// </summary>
        public Movie() : this("")
        {
        }

        /// <summary>
        /// Initializes a movie with the given id string.
        /// </summary>
        /// <param name="id">The id of the movie.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given id is null.</exception>
        public Movie(string id) : base(id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Logger.Trace($"Movie() angelegt");
        }

        // --- Methods ---

        /// <summary>
        /// Retrieves the basic information of the movie from the database.
        /// </summary>
        /// <param name="retrieveBasicInfoOnly">true if only the basic info is to be retrieved; false if also additional data is to be retrieved.</param>
        /// <returns>1 if data record was retrieved; 0 if no data record matched the id.</returns>
        /// <exception cref="NullReferenceException">Thrown when the id is null.</exception>
        public override int RetrieveBasicInformation(bool retrieveBasicInfoOnly)
        {
            Reader.Query = $"SELECT ID, OriginalTitle, EnglishTitle, GermanTitle, TypeID, ReleaseDate, LogoID, Budget, WorldwideGross, WorldwideGrossDate, CastStatusID, CrewStatusID, ConnectionID, Details, StatusID, LastUpdated " +
                           $"FROM Movie " +
                           $"WHERE ID=\"{ID}\"";

            if (Reader.Retrieve(true) == 1)
            {
                DataRow row = Reader.Table.Rows[0];

                ID = row["ID"].ToString();
                OriginalTitle = row["OriginalTitle"].ToString();
                EnglishTitle = row["EnglishTitle"].ToString();
                GermanTitle = row["GermanTitle"].ToString();
                if (!String.IsNullOrEmpty(row["TypeID"].ToString()))
                {
                    Type = new Type();
                    Type.ID = row["TypeID"].ToString();
                    Type.Retrieve(retrieveBasicInfoOnly);
                }
                ReleaseDate = row["ReleaseDate"].ToString();
                if (!String.IsNullOrEmpty(row["LogoID"].ToString()))
                {
                    Logo = new Image();
                    Logo.ID = row["LogoID"].ToString();
                    Logo.Retrieve(retrieveBasicInfoOnly);
                }
                Budget = row["Budget"].ToString();
                WorldwideGross = row["WorldwideGross"].ToString();
                WorldwideGrossDate = row["WorldwideGrossDate"].ToString();
                if (!String.IsNullOrEmpty(row["CastStatusID"].ToString()))
                {
                    CastStatus = new Status();
                    CastStatus.ID = row["CastStatusID"].ToString();
                    CastStatus.Retrieve(retrieveBasicInfoOnly);
                }
                if (!String.IsNullOrEmpty(row["CrewStatusID"].ToString()))
                {
                    CrewStatus = new Status();
                    CrewStatus.ID = row["CrewStatusID"].ToString();
                    CrewStatus.Retrieve(retrieveBasicInfoOnly);
                }
                if (!String.IsNullOrEmpty(row["ConnectionID"].ToString()))
                {
                    Connection = new Connection();
                    Connection.ID = row["ConnectionID"].ToString();
                    Connection.Retrieve(retrieveBasicInfoOnly);
                }
                Details = row["Details"].ToString();
                if (!String.IsNullOrEmpty(row["StatusID"].ToString()))
                {
                    Status = new Status();
                    Status.ID = row["StatusID"].ToString();
                    Status.Retrieve(retrieveBasicInfoOnly);
                }
                LastUpdated = row["LastUpdated"].ToString();
            }
            else
            {
                return 0;
            }

            return 1;
        }

        /// <summary>
        /// Retrieves the additional information of the movie from the database.
        /// </summary>
        /// <returns>The number of data records retrieved.</returns>
        /// <exception cref="NullReferenceException">Thrown when the reader or id is null.</exception>
        public override int RetrieveAdditionalInformation()
        {
            int count = 0;

            // InfoBox data
            Genres = GenreItem.RetrieveList(Reader, $"Movie", ID, "Genre");
            if (Genres != null)
            {
                count += Genres.Count;
            }
            Certifications = CertificationItem.RetrieveList(Reader, $"Movie", ID, "Certification");
            if (Certifications != null)
            {
                count += Certifications.Count;
            }
            Countries = CountryItem.RetrieveList(Reader, $"Movie", ID, "Country");
            if (Countries != null)
            {
                count += Countries.Count;
            }
            Languages = LanguageItem.RetrieveList(Reader, $"Movie", ID, "Language");
            if (Languages != null)
            {
                count += Languages.Count;
            }
            Runtimes = RuntimeItem.RetrieveList(Reader, $"Movie", ID, "Runtime");
            if (Runtimes != null)
            {
                count += Runtimes.Count;
            }
            SoundMixes = SoundMixItem.RetrieveList(Reader, $"Movie", ID, "SoundMix");
            if (SoundMixes != null)
            {
                count += SoundMixes.Count;
            }
            Colors = ColorItem.RetrieveList(Reader, $"Movie", ID, "Color");
            if (Colors != null)
            {
                count += Colors.Count;
            }
            AspectRatios = AspectRatioItem.RetrieveList(Reader, $"Movie", ID, "AspectRatio");
            if (AspectRatios != null)
            {
                count += AspectRatios.Count;
            }
            Cameras = CameraItem.RetrieveList(Reader, $"Movie", ID, "Camera");
            if (Cameras != null)
            {
                count += Cameras.Count;
            }
            Laboratories = LaboratoryItem.RetrieveList(Reader, $"Movie", ID, "Laboratory");
            if (Laboratories != null)
            {
                count += Laboratories.Count;
            }
            FilmLengths = FilmLengthItem.RetrieveList(Reader, $"Movie", ID, "FilmLength");
            if (FilmLengths != null)
            {
                count += FilmLengths.Count;
            }
            NegativeFormats = NegativeFormatItem.RetrieveList(Reader, $"Movie", ID, "NegativeFormat");
            if (NegativeFormats != null)
            {
                count += NegativeFormats.Count;
            }
            CinematographicProcesses = CinematographicProcessItem.RetrieveList(Reader, $"Movie", ID, "CinematographicProcess");
            if (CinematographicProcesses != null)
            {
                count += CinematographicProcesses.Count;
            }
            PrintedFilmFormats = PrintedFilmFormatItem.RetrieveList(Reader, $"Movie", ID, "PrintedFilmFormat");
            if (PrintedFilmFormats != null)
            {
                count += PrintedFilmFormats.Count;
            }

            // Cast and crew data
            Directors = PersonItem.RetrieveList(Reader, $"Movie", ID, "Director");
            if (Directors != null)
            {
                count += Directors.Count;
            }
            Writers = PersonItem.RetrieveList(Reader, $"Movie", ID, "Writer");
            if (Writers != null)
            {
                count += Writers.Count;
            }
            Cast = CastPersonItem.RetrieveList(Reader, $"Movie", ID, "Cast");
            if (Cast != null)
            {
                count += Cast.Count;
            }
            Producers = PersonItem.RetrieveList(Reader, $"Movie", ID, "Producer");
            if (Producers != null)
            {
                count += Producers.Count;
            }
            Music = PersonItem.RetrieveList(Reader, $"Movie", ID, "Music");
            if (Music != null)
            {
                count += Music.Count;
            }
            Cinematography = PersonItem.RetrieveList(Reader, $"Movie", ID, "Cinematography");
            if (Cinematography != null)
            {
                count += Cinematography.Count;
            }
            FilmEditing = PersonItem.RetrieveList(Reader, $"Movie", ID, "FilmEditing");
            if (FilmEditing != null)
            {
                count += FilmEditing.Count;
            }
            Casting = PersonItem.RetrieveList(Reader, $"Movie", ID, "Casting");
            if (Casting != null)
            {
                count += Casting.Count;
            }
            ProductionDesign = PersonItem.RetrieveList(Reader, $"Movie", ID, "ProductionDesign");
            if (ProductionDesign != null)
            {
                count += ProductionDesign.Count;
            }
            ArtDirection = PersonItem.RetrieveList(Reader, $"Movie", ID, "ArtDirection");
            if (ArtDirection != null)
            {
                count += ArtDirection.Count;
            }
            SetDecoration = PersonItem.RetrieveList(Reader, $"Movie", ID, "SetDecoration");
            if (SetDecoration != null)
            {
                count += SetDecoration.Count;
            }
            CostumeDesign = PersonItem.RetrieveList(Reader, $"Movie", ID, "CostumeDesign");
            if (CostumeDesign != null)
            {
                count += CostumeDesign.Count;
            }
            MakeupDepartment = PersonItem.RetrieveList(Reader, $"Movie", ID, "MakeupDepartment");
            if (MakeupDepartment != null)
            {
                count += MakeupDepartment.Count;
            }
            ProductionManagement = PersonItem.RetrieveList(Reader, $"Movie", ID, "ProductionManagement");
            if (ProductionManagement != null)
            {
                count += ProductionManagement.Count;
            }
            AssistantDirectors = PersonItem.RetrieveList(Reader, $"Movie", ID, "AssistantDirector");
            if (AssistantDirectors != null)
            {
                count += AssistantDirectors.Count;
            }
            ArtDepartment = PersonItem.RetrieveList(Reader, $"Movie", ID, "ArtDepartment");
            if (ArtDepartment != null)
            {
                count += ArtDepartment.Count;
            }
            SoundDepartment = PersonItem.RetrieveList(Reader, $"Movie", ID, "SoundDepartment");
            if (SoundDepartment != null)
            {
                count += SoundDepartment.Count;
            }
            SpecialEffects = PersonItem.RetrieveList(Reader, $"Movie", ID, "SpecialEffects");
            if (SpecialEffects != null)
            {
                count += SpecialEffects.Count;
            }
            VisualEffects = PersonItem.RetrieveList(Reader, $"Movie", ID, "VisualEffects");
            if (VisualEffects != null)
            {
                count += VisualEffects.Count;
            }
            Stunts = PersonItem.RetrieveList(Reader, $"Movie", ID, "Stunts");
            if (Stunts != null)
            {
                count += Stunts.Count;
            }
            ElectricalDepartment = PersonItem.RetrieveList(Reader, $"Movie", ID, "ElectricalDepartment");
            if (ElectricalDepartment != null)
            {
                count += ElectricalDepartment.Count;
            }
            AnimationDepartment = PersonItem.RetrieveList(Reader, $"Movie", ID, "AnimationDepartment");
            if (AnimationDepartment != null)
            {
                count += AnimationDepartment.Count;
            }
            CastingDepartment = PersonItem.RetrieveList(Reader, $"Movie", ID, "CastingDepartment");
            if (CastingDepartment != null)
            {
                count += CastingDepartment.Count;
            }
            CostumeDepartment = PersonItem.RetrieveList(Reader, $"Movie", ID, "CostumeDepartment");
            if (CostumeDepartment != null)
            {
                count += CostumeDepartment.Count;
            }
            EditorialDepartment = PersonItem.RetrieveList(Reader, $"Movie", ID, "EditorialDepartment");
            if (EditorialDepartment != null)
            {
                count += EditorialDepartment.Count;
            }
            LocationManagement = PersonItem.RetrieveList(Reader, $"Movie", ID, "LocationManagement");
            if (LocationManagement != null)
            {
                count += LocationManagement.Count;
            }
            MusicDepartment = PersonItem.RetrieveList(Reader, $"Movie", ID, "MusicDepartment");
            if (MusicDepartment != null)
            {
                count += MusicDepartment.Count;
            }
            ContinuityDepartment = PersonItem.RetrieveList(Reader, $"Movie", ID, "ContinuityDepartment");
            if (ContinuityDepartment != null)
            {
                count += ContinuityDepartment.Count;
            }
            TransportationDepartment = PersonItem.RetrieveList(Reader, $"Movie", ID, "TransportationDepartment");
            if (TransportationDepartment != null)
            {
                count += TransportationDepartment.Count;
            }
            OtherCrew = PersonItem.RetrieveList(Reader, $"Movie", ID, "OtherCrew");
            if (OtherCrew != null)
            {
                count += OtherCrew.Count;
            }
            Thanks = PersonItem.RetrieveList(Reader, $"Movie", ID, "Thanks");
            if (Thanks != null)
            {
                count += Thanks.Count;
            }

            // Company data
            ProductionCompanies = CompanyItem.RetrieveList(Reader, $"Movie", ID, "ProductionCompany");
            if (ProductionCompanies != null)
            {
                count += ProductionCompanies.Count;
            }
            Distributors = DistributorCompanyItem.RetrieveList(Reader, $"Movie", ID, "Distributor");
            if (Distributors != null)
            {
                count += Distributors.Count;
            }
            SpecialEffectsCompanies = CompanyItem.RetrieveList(Reader, $"Movie", ID, "SpecialEffectsCompany");
            if (SpecialEffectsCompanies != null)
            {
                count += SpecialEffectsCompanies.Count;
            }
            OtherCompanies = CompanyItem.RetrieveList(Reader, $"Movie", ID, "OtherCompany");
            if (OtherCompanies != null)
            {
                count += OtherCompanies.Count;
            }

            // Production data
            FilmingLocations = LocationItem.RetrieveList(Reader, $"Movie", ID, "FilmingLocation");
            if (FilmingLocations != null)
            {
                count += FilmingLocations.Count;
            }
            FilmingDates = TimespanItem.RetrieveList(Reader, $"Movie", ID, "FilmingDate");
            if (FilmingDates != null)
            {
                count += FilmingDates.Count;
            }
            ProductionDates = TimespanItem.RetrieveList(Reader, $"Movie", ID, "ProductionDate");
            if (ProductionDates != null)
            {
                count += ProductionDates.Count;
            }

            // Image data
            Posters = ImageItem.RetrieveList(Reader, $"Movie", ID, "Poster");
            if (Posters != null)
            {
                count += Posters.Count;
            }
            Covers = ImageItem.RetrieveList(Reader, $"Movie", ID, "Cover");
            if (Covers != null)
            {
                count += Covers.Count;
            }
            Images = ImageItem.RetrieveList(Reader, $"Movie", ID, "Image");
            if (Images != null)
            {
                count += Images.Count;
            }

            // Text data
            Descriptions = TextItem.RetrieveList(Reader, $"Movie", ID, "Description");
            if (Descriptions != null)
            {
                count += Descriptions.Count;
            }
            Reviews = TextItem.RetrieveList(Reader, $"Movie", ID, "Review");
            if (Reviews != null)
            {
                count += Reviews.Count;
            }

            // other data
            Awards = AwardItem.RetrieveList(Reader, $"Movie", ID, "Award");
            if (Awards != null)
            {
                count += Awards.Count;
            }
            Weblinks = WeblinkItem.RetrieveList(Reader, $"Movie", ID, "Weblink");
            if (Weblinks != null)
            {
                count += Weblinks.Count;
            }

            return count;
        }

        /// <summary>
        /// Retrieves a list of movies from the database.
        /// </summary>
        /// <param name="reader">The reader to be used to retrieve the data records.</param>
        /// <param name="status">The status of the movies.</param>
        /// <param name="order">The order in which the data records are to be sorted.</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException">Thrown when the given reader is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the given status or order is null.</exception>
        public static List<Movie> RetrieveList(DBReader reader, string status, string order = "ID")
        {
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }
            if (String.IsNullOrEmpty(status))
            {
                throw new ArgumentNullException(nameof(status));
            }
            if (String.IsNullOrEmpty(order))
            {
                throw new ArgumentNullException(nameof(order));
            }

            // Liste laden

            reader.Query = $"SELECT ID " +
                           $"FROM Movie " +
                           $"WHERE StatusID=\"{status}\"" +
                           $"ORDER BY {order}";

            List<Movie> list = new List<Movie>();

            if (reader.Retrieve(true) > 0)
            {
                list.Capacity = reader.Table.Rows.Count;

                foreach (DataRow row in reader.Table.Rows)
                {
                    Movie item = new Movie();

                    item.ID = row["ID"].ToString();
                    item.Retrieve(true);
                    list.Add(item);
                }
            }
            else
            {
                //  nothing to do
            }

            return list;
        }
    }
}
