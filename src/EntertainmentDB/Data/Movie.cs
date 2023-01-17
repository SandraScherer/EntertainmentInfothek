// EntertainmentDB.dll: Provides access to the EntertainmentInfothek.db
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

namespace EntertainmentDB.Data
{
    /// <summary>
    /// Provides a movie.
    /// </summary>
    public class Movie : MovieAndTVArticle
    {
        // --- Properties ---

        /// <summary>
        /// The logo of the movie.
        /// </summary>
        public Image Logo { get; set; }

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
        public List<FilmFormatItem> NegativeFormats { get; set; }

        /// <summary>
        /// The list of cinematographic processes of the movie.
        /// </summary>
        public List<CinematographicProcessItem> CinematographicProcesses { get; set; }

        /// <summary>
        /// The list of printed film formats of the movie.
        /// </summary>
        public List<FilmFormatItem> PrintedFilmFormats { get; set; }

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
        public List<WeblinkItem> Weblinks { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a movie with an empty id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the movie information from the database.</param>
        public Movie(DBReader reader) : this(reader, "")
        {
        }

        /// <summary>
        /// Initializes a movie with the given id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the movie information from the database.</param>
        /// <param name="id">The id of the movie.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given id is null.</exception>
        public Movie(DBReader reader, string id) : base(reader, id)
        {
            Logger.Trace($"Movie()");

            if (reader == null)
            {
                Logger.Fatal($"DBReader not specified");
                throw new ArgumentNullException(nameof(reader));
            }
            if (id == null)
            {
                Logger.Fatal($"ID not specified");
                throw new ArgumentNullException(nameof(id));
            }

            Logger.Trace($"Movie(): Movie with ID = '{id}' created");
        }

        // --- Methods ---

        /// <summary>
        /// Retrieves the basic information of the movie from the database.
        /// </summary>
        /// <param name="retrieveBasicInfoOnly">true if only the basic info is to be retrieved; false if also additional data is to be retrieved.</param>
        /// <returns>1 if data record was retrieved; 0 if no data record matched the id.</returns>
        protected override int RetrieveBasicInformation(bool retrieveBasicInfoOnly)
        {
            Logger.Trace($"Movie.RetrieveBasicInformation()");

            Reader.Query = $"SELECT ID, OriginalTitle, EnglishTitle, GermanTitle, TypeID, ReleaseDate, LogoID, Budget, WorldwideGross, WorldwideGrossDate, CastStatusID, CrewStatusID, ConnectionID, Details, StatusID, LastUpdated " +
                           $"FROM Movie " +
                           $"WHERE ID='{ID}'";

            Logger.Debug($"Retrieve from DB: {Reader.Query}");

            int noOfDataRecords = Reader.Retrieve(true);
            if (noOfDataRecords == 1)
            {
                Logger.Debug($"Retrieved data records: '{noOfDataRecords}'");

                DataRow row = Reader.Table.Rows[0];

                ID = row["ID"].ToString();
                OriginalTitle = row["OriginalTitle"].ToString();
                EnglishTitle = row["EnglishTitle"].ToString();
                GermanTitle = row["GermanTitle"].ToString();
                if (!String.IsNullOrEmpty(row["TypeID"].ToString()))
                {
                    Logger.Debug($"Movie.TypeID is not null -> retrieve");

                    Type = new Type(Reader.New());
                    Type.ID = row["TypeID"].ToString();
                    Type.Retrieve(retrieveBasicInfoOnly);
                }
                ReleaseDate = row["ReleaseDate"].ToString();
                if (!String.IsNullOrEmpty(row["LogoID"].ToString()))
                {
                    Logger.Debug($"Movie.LogoID is not null -> retrieve");

                    Logo = new Image(Reader.New());
                    Logo.ID = row["LogoID"].ToString();
                    Logo.Retrieve(retrieveBasicInfoOnly);
                }
                Budget = row["Budget"].ToString();
                WorldwideGross = row["WorldwideGross"].ToString();
                WorldwideGrossDate = row["WorldwideGrossDate"].ToString();
                if (!String.IsNullOrEmpty(row["CastStatusID"].ToString()))
                {
                    Logger.Debug($"Movie.CastStatusID is not null -> retrieve");

                    CastStatus = new Status(Reader.New());
                    CastStatus.ID = row["CastStatusID"].ToString();
                    CastStatus.Retrieve(retrieveBasicInfoOnly);
                }
                if (!String.IsNullOrEmpty(row["CrewStatusID"].ToString()))
                {
                    Logger.Debug($"Movie.CrewStatusID is not null -> retrieve");

                    CrewStatus = new Status(Reader.New());
                    CrewStatus.ID = row["CrewStatusID"].ToString();
                    CrewStatus.Retrieve(retrieveBasicInfoOnly);
                }
                if (!String.IsNullOrEmpty(row["ConnectionID"].ToString()))
                {
                    Logger.Debug($"Movie.ConnectionID is not null -> retrieve");

                    Connection = new Connection(Reader.New());
                    Connection.ID = row["ConnectionID"].ToString();
                    Connection.Retrieve(retrieveBasicInfoOnly);
                }
                Details = row["Details"].ToString();
                if (!String.IsNullOrEmpty(row["StatusID"].ToString()))
                {
                    Logger.Debug($"Movie.StatusID is not null -> retrieve");

                    Status = new Status(Reader.New());
                    Status.ID = row["StatusID"].ToString();
                    Status.Retrieve(retrieveBasicInfoOnly);
                }
                LastUpdated = row["LastUpdated"].ToString();
            }
            else
            {
                Logger.Debug($"Retrieved data records: '{noOfDataRecords}'");
                return 0;
            }

            return 1;
        }

        /// <summary>
        /// Retrieves the additional information of the movie from the database.
        /// </summary>
        /// <returns>The number of data records retrieved.</returns>
        protected override int RetrieveAdditionalInformation()
        {
            Logger.Trace($"Movie.RetrieveAdditionalInformation()");

            int noOfDataRecords = 0;

            // InfoBox data
            Genres = GenreItem.RetrieveList(Reader, "Movie", ID, "Genre");
            noOfDataRecords += Genres.Count;
            if (Genres.Count == 0)
            {
                Logger.Debug($"Movie.Genres.Count == 0 -> null");
                Genres = null;
            }

            Certifications = CertificationItem.RetrieveList(Reader, "Movie", ID, "Certification");
            noOfDataRecords += Certifications.Count;
            if (Certifications.Count == 0)
            {
                Logger.Debug($"Movie.Certifications.Count == 0 -> null");
                Certifications = null;
            }

            Countries = CountryItem.RetrieveList(Reader, "Movie", ID, "Country");
            noOfDataRecords += Countries.Count;
            if (Countries.Count == 0)
            {
                Logger.Debug($"Movie.Countries.Count == 0 -> null");
                Countries = null;
            }

            Languages = LanguageItem.RetrieveList(Reader, "Movie", ID, "Language");
            noOfDataRecords += Languages.Count;
            if (Languages.Count == 0)
            {
                Logger.Debug($"Movie.Languages.Count == 0 -> null");
                Languages = null;
            }

            Runtimes = RuntimeItem.RetrieveList(Reader, "Movie", ID, "Runtime");
            noOfDataRecords += Runtimes.Count;
            if (Runtimes.Count == 0)
            {
                Logger.Debug($"Movie.Runtimes.Count == 0 -> null");
                Runtimes = null;
            }

            SoundMixes = SoundMixItem.RetrieveList(Reader, "Movie", ID, "SoundMix");
            noOfDataRecords += SoundMixes.Count;
            if (SoundMixes.Count == 0)
            {
                Logger.Debug($"Movie.SoundMixes.Count == 0 -> null");
                SoundMixes = null;
            }

            Colors = ColorItem.RetrieveList(Reader, "Movie", ID, "Color");
            noOfDataRecords += Colors.Count;
            if (Colors.Count == 0)
            {
                Logger.Debug($"Movie.Colors.Count == 0 -> null");
                Colors = null;
            }

            AspectRatios = AspectRatioItem.RetrieveList(Reader, "Movie", ID, "AspectRatio");
            noOfDataRecords += AspectRatios.Count;
            if (AspectRatios.Count == 0)
            {
                Logger.Debug($"Movie.AspectRatios.Count == 0 -> null");
                AspectRatios = null;
            }

            Cameras = CameraItem.RetrieveList(Reader, "Movie", ID, "Camera");
            noOfDataRecords += Cameras.Count;
            if (Cameras.Count == 0)
            {
                Logger.Debug($"Movie.Cameras.Count == 0 -> null");
                Cameras = null;
            }

            Laboratories = LaboratoryItem.RetrieveList(Reader, "Movie", ID, "Laboratory");
            noOfDataRecords += Laboratories.Count;
            if (Laboratories.Count == 0)
            {
                Logger.Debug($"Movie.Laboratories.Count == 0 -> null");
                Laboratories = null;
            }

            FilmLengths = FilmLengthItem.RetrieveList(Reader, "Movie", ID, "FilmLength");
            noOfDataRecords += FilmLengths.Count;
            if (FilmLengths.Count == 0)
            {
                Logger.Debug($"Movie.FilmLengths.Count == 0 -> null");
                FilmLengths = null;
            }

            NegativeFormats = FilmFormatItem.RetrieveList(Reader, "Movie", ID, "NegativeFormat");
            noOfDataRecords += NegativeFormats.Count;
            if (NegativeFormats.Count == 0)
            {
                Logger.Debug($"Movie.NegativeFormats.Count == 0 -> null");
                NegativeFormats = null;
            }

            CinematographicProcesses = CinematographicProcessItem.RetrieveList(Reader, "Movie", ID, "CinematographicProcess");
            noOfDataRecords += CinematographicProcesses.Count;
            if (CinematographicProcesses.Count == 0)
            {
                Logger.Debug($"Movie.CinematographicProcesses.Count == 0 -> null");
                CinematographicProcesses = null;
            }

            PrintedFilmFormats = FilmFormatItem.RetrieveList(Reader, "Movie", ID, "PrintedFilmFormat");
            noOfDataRecords += PrintedFilmFormats.Count;
            if (PrintedFilmFormats.Count == 0)
            {
                Logger.Debug($"Movie.PrintedFilmFormats.Count == 0 -> null");
                PrintedFilmFormats = null;
            }

            // Cast and crew data
            Directors = PersonItem.RetrieveList(Reader, "Movie", ID, "Director");
            noOfDataRecords += Directors.Count;
            if (Directors.Count == 0)
            {
                Logger.Debug($"Movie.Directors.Count == 0 -> null");
                Directors = null;
            }

            Writers = PersonItem.RetrieveList(Reader, "Movie", ID, "Writer");
            noOfDataRecords += Writers.Count;
            if (Writers.Count == 0)
            {
                Logger.Debug($"Movie.Writers.Count == 0 -> null");
                Writers = null;
            }

            Cast = CastPersonItem.RetrieveList(Reader, "Movie", ID, "Cast");
            noOfDataRecords += Cast.Count;
            if (Cast.Count == 0)
            {
                Logger.Debug($"Movie.Cast.Count == 0 -> null");
                Cast = null;
            }

            Producers = PersonItem.RetrieveList(Reader, "Movie", ID, "Producer");
            noOfDataRecords += Producers.Count;
            if (Producers.Count == 0)
            {
                Logger.Debug($"Movie.Producers.Count == 0 -> null");
                Producers = null;
            }

            Music = PersonItem.RetrieveList(Reader, "Movie", ID, "Music");
            noOfDataRecords += Music.Count;
            if (Music.Count == 0)
            {
                Logger.Debug($"Movie.Music.Count == 0 -> null");
                Music = null;
            }

            Cinematography = PersonItem.RetrieveList(Reader, "Movie", ID, "Cinematography");
            noOfDataRecords += Cinematography.Count;
            if (Cinematography.Count == 0)
            {
                Logger.Debug($"Movie.Cinematography.Count == 0 -> null");
                Cinematography = null;
            }

            FilmEditing = PersonItem.RetrieveList(Reader, "Movie", ID, "FilmEditing");
            noOfDataRecords += FilmEditing.Count;
            if (FilmEditing.Count == 0)
            {
                Logger.Debug($"Movie.FilmEditing.Count == 0 -> null");
                FilmEditing = null;
            }

            Casting = PersonItem.RetrieveList(Reader, "Movie", ID, "Casting");
            noOfDataRecords += Casting.Count;
            if (Casting.Count == 0)
            {
                Logger.Debug($"Movie.Casting.Count == 0 -> null");
                Casting = null;
            }

            ProductionDesign = PersonItem.RetrieveList(Reader, "Movie", ID, "ProductionDesign");
            noOfDataRecords += ProductionDesign.Count;
            if (ProductionDesign.Count == 0)
            {
                Logger.Debug($"Movie.ProductionDesign.Count == 0 -> null");
                ProductionDesign = null;
            }

            ArtDirection = PersonItem.RetrieveList(Reader, "Movie", ID, "ArtDirection");
            noOfDataRecords += ArtDirection.Count;
            if (ArtDirection.Count == 0)
            {
                Logger.Debug($"Movie.ArtDirection.Count == 0 -> null");
                ArtDirection = null;
            }

            SetDecoration = PersonItem.RetrieveList(Reader, "Movie", ID, "SetDecoration");
            noOfDataRecords += SetDecoration.Count;
            if (SetDecoration.Count == 0)
            {
                Logger.Debug($"Movie.SetDecoration.Count == 0 -> null");
                SetDecoration = null;
            }

            CostumeDesign = PersonItem.RetrieveList(Reader, "Movie", ID, "CostumeDesign");
            noOfDataRecords += CostumeDesign.Count;
            if (CostumeDesign.Count == 0)
            {
                Logger.Debug($"Movie.CostumeDesign.Count == 0 -> null");
                CostumeDesign = null;
            }

            MakeupDepartment = PersonItem.RetrieveList(Reader, "Movie", ID, "MakeupDepartment");
            noOfDataRecords += MakeupDepartment.Count;
            if (MakeupDepartment.Count == 0)
            {
                Logger.Debug($"Movie.MakeupDepartment.Count == 0 -> null");
                MakeupDepartment = null;
            }

            ProductionManagement = PersonItem.RetrieveList(Reader, "Movie", ID, "ProductionManagement");
            noOfDataRecords += ProductionManagement.Count;
            if (ProductionManagement.Count == 0)
            {
                Logger.Debug($"Movie.ProductionManagement.Count == 0 -> null");
                ProductionManagement = null;
            }

            AssistantDirectors = PersonItem.RetrieveList(Reader, "Movie", ID, "AssistantDirector");
            noOfDataRecords += AssistantDirectors.Count;
            if (AssistantDirectors.Count == 0)
            {
                Logger.Debug($"Movie.AssistantDirectors.Count == 0 -> null");
                AssistantDirectors = null;
            }

            ArtDepartment = PersonItem.RetrieveList(Reader, "Movie", ID, "ArtDepartment");
            noOfDataRecords += ArtDepartment.Count;
            if (ArtDepartment.Count == 0)
            {
                Logger.Debug($"Movie.ArtDepartment.Count == 0 -> null");
                ArtDepartment = null;
            }

            SoundDepartment = PersonItem.RetrieveList(Reader, "Movie", ID, "SoundDepartment");
            noOfDataRecords += SoundDepartment.Count;
            if (SoundDepartment.Count == 0)
            {
                Logger.Debug($"Movie.SoundDepartment.Count == 0 -> null");
                SoundDepartment = null;
            }

            SpecialEffects = PersonItem.RetrieveList(Reader, "Movie", ID, "SpecialEffects");
            noOfDataRecords += SpecialEffects.Count;
            if (SpecialEffects.Count == 0)
            {
                Logger.Debug($"Movie.SpecialEffects.Count == 0 -> null");
                SpecialEffects = null;
            }

            VisualEffects = PersonItem.RetrieveList(Reader, "Movie", ID, "VisualEffects");
            noOfDataRecords += VisualEffects.Count;
            if (VisualEffects.Count == 0)
            {
                Logger.Debug($"Movie.VisualEffects.Count == 0 -> null");
                VisualEffects = null;
            }

            Stunts = PersonItem.RetrieveList(Reader, "Movie", ID, "Stunts");
            noOfDataRecords += Stunts.Count;
            if (Stunts.Count == 0)
            {
                Logger.Debug($"Movie.Stunts.Count == 0 -> null");
                Stunts = null;
            }

            ElectricalDepartment = PersonItem.RetrieveList(Reader, "Movie", ID, "ElectricalDepartment");
            noOfDataRecords += ElectricalDepartment.Count;
            if (ElectricalDepartment.Count == 0)
            {
                Logger.Debug($"Movie.ElectricalDepartment.Count == 0 -> null");
                ElectricalDepartment = null;
            }

            AnimationDepartment = PersonItem.RetrieveList(Reader, "Movie", ID, "AnimationDepartment");
            noOfDataRecords += AnimationDepartment.Count;
            if (AnimationDepartment.Count == 0)
            {
                Logger.Debug($"Movie.AnimationDepartment.Count == 0 -> null");
                AnimationDepartment = null;
            }

            CastingDepartment = PersonItem.RetrieveList(Reader, "Movie", ID, "CastingDepartment");
            noOfDataRecords += CastingDepartment.Count;
            if (CastingDepartment.Count == 0)
            {
                Logger.Debug($"Movie.CastingDepartment.Count == 0 -> null");
                CastingDepartment = null;
            }

            CostumeDepartment = PersonItem.RetrieveList(Reader, "Movie", ID, "CostumeDepartment");
            noOfDataRecords += CostumeDepartment.Count;
            if (CostumeDepartment.Count == 0)
            {
                Logger.Debug($"Movie.CostumeDepartment.Count == 0 -> null");
                CostumeDepartment = null;
            }

            EditorialDepartment = PersonItem.RetrieveList(Reader, "Movie", ID, "EditorialDepartment");
            noOfDataRecords += EditorialDepartment.Count;
            if (EditorialDepartment.Count == 0)
            {
                Logger.Debug($"Movie.EditorialDepartment.Count == 0 -> null");
                EditorialDepartment = null;
            }

            LocationManagement = PersonItem.RetrieveList(Reader, "Movie", ID, "LocationManagement");
            noOfDataRecords += LocationManagement.Count;
            if (LocationManagement.Count == 0)
            {
                Logger.Debug($"Movie.LocationManagement.Count == 0 -> null");
                LocationManagement = null;
            }

            MusicDepartment = PersonItem.RetrieveList(Reader, "Movie", ID, "MusicDepartment");
            noOfDataRecords += MusicDepartment.Count;
            if (MusicDepartment.Count == 0)
            {
                Logger.Debug($"Movie.MusicDepartment.Count == 0 -> null");
                MusicDepartment = null;
            }

            ContinuityDepartment = PersonItem.RetrieveList(Reader, "Movie", ID, "ContinuityDepartment");
            noOfDataRecords += ContinuityDepartment.Count;
            if (ContinuityDepartment.Count == 0)
            {
                Logger.Debug($"Movie.ContinuityDepartment.Count == 0 -> null");
                ContinuityDepartment = null;
            }

            TransportationDepartment = PersonItem.RetrieveList(Reader, "Movie", ID, "TransportationDepartment");
            noOfDataRecords += TransportationDepartment.Count;
            if (TransportationDepartment.Count == 0)
            {
                Logger.Debug($"Movie.TransportationDepartment.Count == 0 -> null");
                TransportationDepartment = null;
            }

            OtherCrew = PersonItem.RetrieveList(Reader, "Movie", ID, "OtherCrew");
            noOfDataRecords += OtherCrew.Count;
            if (OtherCrew.Count == 0)
            {
                Logger.Debug($"Movie.OtherCrew.Count == 0 -> null");
                OtherCrew = null;
            }

            Thanks = PersonItem.RetrieveList(Reader, "Movie", ID, "Thanks");
            noOfDataRecords += Thanks.Count;
            if (Thanks.Count == 0)
            {
                Logger.Debug($"Movie.Thanks.Count == 0 -> null");
                Thanks = null;
            }

            // Company data
            ProductionCompanies = CompanyItem.RetrieveList(Reader, "Movie", ID, "ProductionCompany");
            noOfDataRecords += ProductionCompanies.Count;
            if (ProductionCompanies.Count == 0)
            {
                Logger.Debug($"Movie.ProductionCompanies.Count == 0 -> null");
                ProductionCompanies = null;
            }

            Distributors = DistributorCompanyItem.RetrieveList(Reader, "Movie", ID, "Distributor");
            noOfDataRecords += Distributors.Count;
            if (Distributors.Count == 0)
            {
                Logger.Debug($"Movie.Distributors.Count == 0 -> null");
                Distributors = null;
            }

            SpecialEffectsCompanies = CompanyItem.RetrieveList(Reader, "Movie", ID, "SpecialEffectsCompany");
            noOfDataRecords += SpecialEffectsCompanies.Count;
            if (SpecialEffectsCompanies.Count == 0)
            {
                Logger.Debug($"Movie.SpecialEffectsCompanies.Count == 0 -> null");
                SpecialEffectsCompanies = null;
            }

            OtherCompanies = CompanyItem.RetrieveList(Reader, "Movie", ID, "OtherCompany");
            noOfDataRecords += OtherCompanies.Count;
            if (OtherCompanies.Count == 0)
            {
                Logger.Debug($"Movie.OtherCompanies.Count == 0 -> null");
                OtherCompanies = null;
            }

            // Production data
            FilmingLocations = LocationItem.RetrieveList(Reader, "Movie", ID, "FilmingLocation");
            noOfDataRecords += FilmingLocations.Count;
            if (FilmingLocations.Count == 0)
            {
                Logger.Debug($"Movie.FilmingLocations.Count == 0 -> null");
                FilmingLocations = null;
            }

            FilmingDates = TimespanItem.RetrieveList(Reader, "Movie", ID, "FilmingDate");
            noOfDataRecords += FilmingDates.Count;
            if (FilmingDates.Count == 0)
            {
                Logger.Debug($"Movie.FilmingDates.Count == 0 -> null");
                FilmingDates = null;
            }

            ProductionDates = TimespanItem.RetrieveList(Reader, "Movie", ID, "ProductionDate");
            noOfDataRecords += ProductionDates.Count;
            if (ProductionDates.Count == 0)
            {
                Logger.Debug($"Movie.ProductionDates.Count == 0 -> null");
                ProductionDates = null;
            }

            // Image data
            Posters = ImageItem.RetrieveList(Reader, "Movie", ID, "Poster");
            noOfDataRecords += Posters.Count;
            if (Posters.Count == 0)
            {
                Logger.Debug($"Movie.Posters.Count == 0 -> null");
                Posters = null;
            }

            Covers = ImageItem.RetrieveList(Reader, "Movie", ID, "Cover");
            noOfDataRecords += Covers.Count;
            if (Covers.Count == 0)
            {
                Logger.Debug($"Movie.Covers.Count == 0 -> null");
                Covers = null;
            }

            Images = ImageItem.RetrieveList(Reader, "Movie", ID, "Image");
            noOfDataRecords += Images.Count;
            if (Images.Count == 0)
            {
                Logger.Debug($"Movie.Images.Count == 0 -> null");
                Images = null;
            }

            // Text data
            Descriptions = TextItem.RetrieveList(Reader, "Movie", ID, "Description");
            noOfDataRecords += Descriptions.Count;
            if (Descriptions.Count == 0)
            {
                Logger.Debug($"Movie.Descriptions.Count == 0 -> null");
                Descriptions = null;
            }

            Reviews = TextItem.RetrieveList(Reader, "Movie", ID, "Review");
            noOfDataRecords += Reviews.Count;
            if (Reviews.Count == 0)
            {
                Logger.Debug($"Movie.Reviews.Count == 0 -> null");
                Reviews = null;
            }

            // other data
            Awards = AwardItem.RetrieveList(Reader, "Movie", ID, "Award");
            noOfDataRecords += Awards.Count;
            if (Awards.Count == 0)
            {
                Logger.Debug($"Movie.Awards.Count == 0 -> null");
                Awards = null;
            }

            Weblinks = WeblinkItem.RetrieveList(Reader, "Movie", ID, "Weblink");
            noOfDataRecords += Weblinks.Count;
            if (Weblinks.Count == 0)
            {
                Logger.Debug($"Movie.Weblinks.Count == 0 -> null");
                Weblinks = null;
            }

            return noOfDataRecords;
        }

        /// <summary>
        /// Retrieves a list of movies from the database.
        /// </summary>
        /// <param name="reader">The reader to be used to retrieve the data records.</param>
        /// <param name="status">The status of the movies.</param>
        /// <param name="order">The order in which the data records are to be sorted.</param>
        /// <returns>The list of movies.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given status or order is null.</exception>
        public static List<Article> RetrieveList(DBReader reader, string status, string order = "ID")
        {
            Logger.Trace($"Movie.RetrieveList()");

            if (reader == null)
            {
                Logger.Fatal($"DBReader not specified");
                throw new ArgumentNullException(nameof(reader));
            }
            if (String.IsNullOrEmpty(status))
            {
                Logger.Fatal($"Status not specified");
                throw new ArgumentNullException(nameof(status));
            }
            if (String.IsNullOrEmpty(order))
            {
                Logger.Fatal($"Order not specified");
                throw new ArgumentNullException(nameof(order));
            }

            // Liste laden

            reader.Query = $"SELECT ID " +
                           $"FROM Movie " +
                           $"WHERE StatusID='{status}'" +
                           $"ORDER BY {order}";

            Logger.Debug($"Retrieve from DB: {reader.Query}");

            List<Article> list = new List<Article>();

            int noOfDataRecords = reader.Retrieve(true);
            if (noOfDataRecords > 0)
            {
                Logger.Debug($"Retrieved data records: '{noOfDataRecords}'");

                list.Capacity = reader.Table.Rows.Count;

                foreach (DataRow row in reader.Table.Rows)
                {
                    Movie item = new Movie(reader.New());

                    item.ID = row["ID"].ToString();
                    item.Retrieve(true);
                    list.Add(item);
                }
            }

            return list;
        }
    }
}
