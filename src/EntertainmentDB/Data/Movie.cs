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
    public class Movie : Article
    {
        // --- Properties ---

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
        public List<WeblinkItem> Weblinks { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

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
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }
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
                    Type = new Type(Reader.New());
                    Type.ID = row["TypeID"].ToString();
                    Type.Retrieve(retrieveBasicInfoOnly);
                }
                ReleaseDate = row["ReleaseDate"].ToString();
                if (!String.IsNullOrEmpty(row["LogoID"].ToString()))
                {
                    Logo = new Image(Reader.New());
                    Logo.ID = row["LogoID"].ToString();
                    Logo.Retrieve(retrieveBasicInfoOnly);
                }
                Budget = row["Budget"].ToString();
                WorldwideGross = row["WorldwideGross"].ToString();
                WorldwideGrossDate = row["WorldwideGrossDate"].ToString();
                if (!String.IsNullOrEmpty(row["CastStatusID"].ToString()))
                {
                    CastStatus = new Status(Reader.New());
                    CastStatus.ID = row["CastStatusID"].ToString();
                    CastStatus.Retrieve(retrieveBasicInfoOnly);
                }
                if (!String.IsNullOrEmpty(row["CrewStatusID"].ToString()))
                {
                    CrewStatus = new Status(Reader.New());
                    CrewStatus.ID = row["CrewStatusID"].ToString();
                    CrewStatus.Retrieve(retrieveBasicInfoOnly);
                }
                if (!String.IsNullOrEmpty(row["ConnectionID"].ToString()))
                {
                    Connection = new Connection(Reader.New());
                    Connection.ID = row["ConnectionID"].ToString();
                    Connection.Retrieve(retrieveBasicInfoOnly);
                }
                Details = row["Details"].ToString();
                if (!String.IsNullOrEmpty(row["StatusID"].ToString()))
                {
                    Status = new Status(Reader.New());
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
        public override int RetrieveAdditionalInformation()
        {
            int count = 0;

            // InfoBox data
            Genres = GenreItem.RetrieveList(Reader, "Movie", ID, "Genre");
            if (Genres.Count == 0)
            {
                Genres = null;
            }
            else
            {
                count += Genres.Count;
            }

            Certifications = CertificationItem.RetrieveList(Reader, "Movie", ID, "Certification");
            if (Certifications.Count == 0)
            {
                Certifications = null;
            }
            else
            {
                count += Certifications.Count;
            }

            Countries = CountryItem.RetrieveList(Reader, "Movie", ID, "Country");
            if (Countries.Count == 0)
            {
                Countries = null;
            }
            else
            {
                count += Countries.Count;
            }

            Languages = LanguageItem.RetrieveList(Reader, "Movie", ID, "Language");
            if (Languages.Count == 0)
            {
                Languages = null;
            }
            else
            {
                count += Languages.Count;
            }

            Runtimes = RuntimeItem.RetrieveList(Reader, "Movie", ID, "Runtime");
            if (Runtimes.Count == 0)
            {
                Runtimes = null;
            }
            else
            {
                count += Runtimes.Count;
            }

            SoundMixes = SoundMixItem.RetrieveList(Reader, "Movie", ID, "SoundMix");
            if (SoundMixes.Count == 0)
            {
                SoundMixes = null;
            }
            else
            {
                count += SoundMixes.Count;
            }

            Colors = ColorItem.RetrieveList(Reader, "Movie", ID, "Color");
            if (Colors.Count == 0)
            {
                Colors = null;
            }
            else
            {
                count += Colors.Count;
            }

            AspectRatios = AspectRatioItem.RetrieveList(Reader, "Movie", ID, "AspectRatio");
            if (AspectRatios.Count == 0)
            {
                AspectRatios = null;
            }
            else
            {
                count += AspectRatios.Count;
            }

            Cameras = CameraItem.RetrieveList(Reader, "Movie", ID, "Camera");
            if (Cameras.Count == 0)
            {
                Cameras = null;
            }
            else
            {
                count += Cameras.Count;
            }

            Laboratories = LaboratoryItem.RetrieveList(Reader, "Movie", ID, "Laboratory");
            if (Laboratories.Count == 0)
            {
                Laboratories = null;
            }
            else
            {
                count += Laboratories.Count;
            }

            FilmLengths = FilmLengthItem.RetrieveList(Reader, "Movie", ID, "FilmLength");
            if (FilmLengths.Count == 0)
            {
                FilmLengths = null;
            }
            else
            {
                count += FilmLengths.Count;
            }

            NegativeFormats = NegativeFormatItem.RetrieveList(Reader, "Movie", ID, "NegativeFormat");
            if (NegativeFormats.Count == 0)
            {
                NegativeFormats = null;
            }
            else
            {
                count += NegativeFormats.Count;
            }

            CinematographicProcesses = CinematographicProcessItem.RetrieveList(Reader, "Movie", ID, "CinematographicProcess");
            if (CinematographicProcesses.Count == 0)
            {
                CinematographicProcesses = null;
            }
            else
            {
                count += CinematographicProcesses.Count;
            }

            PrintedFilmFormats = PrintedFilmFormatItem.RetrieveList(Reader, "Movie", ID, "PrintedFilmFormat");
            if (PrintedFilmFormats.Count == 0)
            {
                PrintedFilmFormats = null;
            }
            else
            {
                count += PrintedFilmFormats.Count;
            }

            // Cast and crew data
            Directors = PersonItem.RetrieveList(Reader, "Movie", ID, "Director");
            if (Directors.Count == 0)
            {
                Directors = null;
            }
            else
            {
                count += Directors.Count;
            }

            Writers = PersonItem.RetrieveList(Reader, "Movie", ID, "Writer");
            if (Writers.Count == 0)
            {
                Writers = null;
            }
            else
            {
                count += Writers.Count;
            }

            Cast = CastPersonItem.RetrieveList(Reader, "Movie", ID, "Cast");
            if (Cast.Count == 0)
            {
                Cast = null;
            }
            else
            {
                count += Cast.Count;
            }

            Producers = PersonItem.RetrieveList(Reader, "Movie", ID, "Producer");
            if (Producers.Count == 0)
            {
                Producers = null;
            }
            else
            {
                count += Producers.Count;
            }

            Music = PersonItem.RetrieveList(Reader, "Movie", ID, "Music");
            if (Music.Count == 0)
            {
                Music = null;
            }
            else
            {
                count += Music.Count;
            }

            Cinematography = PersonItem.RetrieveList(Reader, "Movie", ID, "Cinematography");
            if (Cinematography.Count == 0)
            {
                Cinematography = null;
            }
            else
            {
                count += Cinematography.Count;
            }

            FilmEditing = PersonItem.RetrieveList(Reader, "Movie", ID, "FilmEditing");
            if (FilmEditing.Count == 0)
            {
                FilmEditing = null;
            }
            else
            {
                count += FilmEditing.Count;
            }

            Casting = PersonItem.RetrieveList(Reader, "Movie", ID, "Casting");
            if (Casting.Count == 0)
            {
                Casting = null;
            }
            else
            {
                count += Casting.Count;
            }

            ProductionDesign = PersonItem.RetrieveList(Reader, "Movie", ID, "ProductionDesign");
            if (ProductionDesign.Count == 0)
            {
                ProductionDesign = null;
            }
            else
            {
                count += ProductionDesign.Count;
            }

            ArtDirection = PersonItem.RetrieveList(Reader, "Movie", ID, "ArtDirection");
            if (ArtDirection.Count == 0)
            {
                ArtDirection = null;
            }
            else
            {
                count += ArtDirection.Count;
            }

            SetDecoration = PersonItem.RetrieveList(Reader, "Movie", ID, "SetDecoration");
            if (SetDecoration.Count == 0)
            {
                SetDecoration = null;
            }
            else
            {
                count += SetDecoration.Count;
            }

            CostumeDesign = PersonItem.RetrieveList(Reader, "Movie", ID, "CostumeDesign");
            if (CostumeDesign.Count == 0)
            {
                CostumeDesign = null;
            }
            else
            {
                count += CostumeDesign.Count;
            }

            MakeupDepartment = PersonItem.RetrieveList(Reader, "Movie", ID, "MakeupDepartment");
            if (MakeupDepartment.Count == 0)
            {
                MakeupDepartment = null;
            }
            else
            {
                count += MakeupDepartment.Count;
            }

            ProductionManagement = PersonItem.RetrieveList(Reader, "Movie", ID, "ProductionManagement");
            if (ProductionManagement.Count == 0)
            {
                ProductionManagement = null;
            }
            else
            {
                count += ProductionManagement.Count;
            }

            AssistantDirectors = PersonItem.RetrieveList(Reader, "Movie", ID, "AssistantDirector");
            if (AssistantDirectors.Count == 0)
            {
                AssistantDirectors = null;
            }
            else
            {
                count += AssistantDirectors.Count;
            }

            ArtDepartment = PersonItem.RetrieveList(Reader, "Movie", ID, "ArtDepartment");
            if (ArtDepartment.Count == 0)
            {
                ArtDepartment = null;
            }
            else
            {
                count += ArtDepartment.Count;
            }

            SoundDepartment = PersonItem.RetrieveList(Reader, "Movie", ID, "SoundDepartment");
            if (SoundDepartment.Count == 0)
            {
                SoundDepartment = null;
            }
            else
            {
                count += SoundDepartment.Count;
            }

            SpecialEffects = PersonItem.RetrieveList(Reader, "Movie", ID, "SpecialEffects");
            if (SpecialEffects.Count == 0)
            {
                SpecialEffects = null;
            }
            else
            {
                count += SpecialEffects.Count;
            }

            VisualEffects = PersonItem.RetrieveList(Reader, "Movie", ID, "VisualEffects");
            if (VisualEffects.Count == 0)
            {
                VisualEffects = null;
            }
            else
            {
                count += VisualEffects.Count;
            }

            Stunts = PersonItem.RetrieveList(Reader, "Movie", ID, "Stunts");
            if (Stunts.Count == 0)
            {
                Stunts = null;
            }
            else
            {
                count += Stunts.Count;
            }

            ElectricalDepartment = PersonItem.RetrieveList(Reader, "Movie", ID, "ElectricalDepartment");
            if (ElectricalDepartment.Count == 0)
            {
                ElectricalDepartment = null;
            }
            else
            {
                count += ElectricalDepartment.Count;
            }

            AnimationDepartment = PersonItem.RetrieveList(Reader, "Movie", ID, "AnimationDepartment");
            if (AnimationDepartment.Count == 0)
            {
                AnimationDepartment = null;
            }
            else
            {
                count += AnimationDepartment.Count;
            }

            CastingDepartment = PersonItem.RetrieveList(Reader, "Movie", ID, "CastingDepartment");
            if (CastingDepartment.Count == 0)
            {
                CastingDepartment = null;
            }
            else
            {
                count += CastingDepartment.Count;
            }

            CostumeDepartment = PersonItem.RetrieveList(Reader, "Movie", ID, "CostumeDepartment");
            if (CostumeDepartment.Count == 0)
            {
                CostumeDepartment = null;
            }
            else
            {
                count += CostumeDepartment.Count;
            }

            EditorialDepartment = PersonItem.RetrieveList(Reader, "Movie", ID, "EditorialDepartment");
            if (EditorialDepartment.Count == 0)
            {
                EditorialDepartment = null;
            }
            else
            {
                count += EditorialDepartment.Count;
            }

            LocationManagement = PersonItem.RetrieveList(Reader, "Movie", ID, "LocationManagement");
            if (LocationManagement.Count == 0)
            {
                LocationManagement = null;
            }
            else
            {
                count += LocationManagement.Count;
            }

            MusicDepartment = PersonItem.RetrieveList(Reader, "Movie", ID, "MusicDepartment");
            if (MusicDepartment.Count == 0)
            {
                MusicDepartment = null;
            }
            else
            {
                count += MusicDepartment.Count;
            }

            ContinuityDepartment = PersonItem.RetrieveList(Reader, "Movie", ID, "ContinuityDepartment");
            if (ContinuityDepartment.Count == 0)
            {
                ContinuityDepartment = null;
            }
            else
            {
                count += ContinuityDepartment.Count;
            }

            TransportationDepartment = PersonItem.RetrieveList(Reader, "Movie", ID, "TransportationDepartment");
            if (TransportationDepartment.Count == 0)
            {
                TransportationDepartment = null;
            }
            else
            {
                count += TransportationDepartment.Count;
            }

            OtherCrew = PersonItem.RetrieveList(Reader, "Movie", ID, "OtherCrew");
            if (OtherCrew.Count == 0)
            {
                OtherCrew = null;
            }
            else
            {
                count += OtherCrew.Count;
            }

            Thanks = PersonItem.RetrieveList(Reader, "Movie", ID, "Thanks");
            if (Thanks.Count == 0)
            {
                Thanks = null;
            }
            else
            {
                count += Thanks.Count;
            }

            // Company data
            ProductionCompanies = CompanyItem.RetrieveList(Reader, "Movie", ID, "ProductionCompany");
            if (ProductionCompanies.Count == 0)
            {
                ProductionCompanies = null;
            }
            else
            {
                count += ProductionCompanies.Count;
            }

            Distributors = DistributorCompanyItem.RetrieveList(Reader, "Movie", ID, "Distributor");
            if (Distributors.Count == 0)
            {
                Distributors = null;
            }
            else
            {
                count += Distributors.Count;
            }

            SpecialEffectsCompanies = CompanyItem.RetrieveList(Reader, "Movie", ID, "SpecialEffectsCompany");
            if (SpecialEffectsCompanies.Count == 0)
            {
                SpecialEffectsCompanies = null;
            }
            else
            {
                count += SpecialEffectsCompanies.Count;
            }

            OtherCompanies = CompanyItem.RetrieveList(Reader, "Movie", ID, "OtherCompany");
            if (OtherCompanies.Count == 0)
            {
                OtherCompanies = null;
            }
            else
            {
                count += OtherCompanies.Count;
            }

            // Production data
            FilmingLocations = LocationItem.RetrieveList(Reader, "Movie", ID, "FilmingLocation");
            if (FilmingLocations.Count == 0)
            {
                FilmingLocations = null;
            }
            else
            {
                count += FilmingLocations.Count;
            }

            FilmingDates = TimespanItem.RetrieveList(Reader, "Movie", ID, "FilmingDate");
            if (FilmingDates.Count == 0)
            {
                FilmingDates = null;
            }
            else
            {
                count += FilmingDates.Count;
            }

            ProductionDates = TimespanItem.RetrieveList(Reader, "Movie", ID, "ProductionDate");
            if (ProductionDates.Count == 0)
            {
                ProductionDates = null;
            }
            else
            {
                count += ProductionDates.Count;
            }

            // Image data
            Posters = ImageItem.RetrieveList(Reader, "Movie", ID, "Poster");
            if (Posters.Count == 0)
            {
                Posters = null;
            }
            else
            {
                count += Posters.Count;
            }

            Covers = ImageItem.RetrieveList(Reader, "Movie", ID, "Cover");
            if (Covers.Count == 0)
            {
                Covers = null;
            }
            else
            {
                count += Covers.Count;
            }

            Images = ImageItem.RetrieveList(Reader, "Movie", ID, "Image");
            if (Images.Count == 0)
            {
                Images = null;
            }
            else
            {
                count += Images.Count;
            }

            // Text data
            Descriptions = TextItem.RetrieveList(Reader, "Movie", ID, "Description");
            if (Descriptions.Count == 0)
            {
                Descriptions = null;
            }
            else
            {
                count += Descriptions.Count;
            }

            Reviews = TextItem.RetrieveList(Reader, "Movie", ID, "Review");
            if (Reviews.Count == 0)
            {
                Reviews = null;
            }
            else
            {
                count += Reviews.Count;
            }

            // other data
            Awards = AwardItem.RetrieveList(Reader, "Movie", ID, "Award");
            if (Awards.Count == 0)
            {
                Awards = null;
            }
            else
            {
                count += Awards.Count;
            }

            Weblinks = WeblinkItem.RetrieveList(Reader, "Movie", ID, "Weblink");
            if (Weblinks.Count == 0)
            {
                Weblinks = null;
            }
            else
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
        /// <returns>The list of movies.</returns>
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
                    Movie item = new Movie(reader.New());

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
