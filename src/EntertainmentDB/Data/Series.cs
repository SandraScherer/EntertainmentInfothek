// EntertainmentDB.dll: Provides access to the EntertainmentInfothek.db
// Copyright (C) 2021 Sandra Scherer

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
    /// Provides a series.
    /// </summary>
    public class Series : MovieAndTVArticle
    {
        // --- Properties ---

        /// <summary>
        /// The release date of the first episode (or pilot) of the series.
        /// </summary>
        public string ReleaseDateFirstEpisode
        {
            get
            { return ReleaseDate; }
            set
            { ReleaseDate = value; }
        }

        /// <summary>
        /// The release date of the last episode of the series.
        /// </summary>
        public string ReleaseDateLastEpisode { get; set; }

        /// <summary>
        /// The number of seasons of the series.
        /// </summary>
        public string NoOfSeasons { get; set; }

        /// <summary>
        /// The number of episodes of the series.
        /// </summary>
        public string NoOfEpisodes { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a series with an empty id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the series information from the database.</param>
        public Series(DBReader reader) : this(reader, "")
        {
        }

        /// <summary>
        /// Initializes a series with the given id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the series information from the database.</param>
        /// <param name="id">The id of the series.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given id is null.</exception>
        public Series(DBReader reader, string id) : base(reader, id)
        {
            Logger.Trace($"Series(): Series with ID = '{id}' created");
        }

        // --- Methods ---

        /// <summary>
        /// Retrieves the basic information of the series from the database.
        /// </summary>
        /// <param name="retrieveBasicInfoOnly">true if only the basic info is to be retrieved; false if also additional data is to be retrieved.</param>
        /// <returns>1 if data record was retrieved; 0 if no data record matched the id.</returns>
        protected override int RetrieveBasicInformation(bool retrieveBasicInfoOnly)
        {
            Logger.Trace($"Series.RetrieveBasicInformation()");

            Reader.Query = $"SELECT ID, OriginalTitle, EnglishTitle, GermanTitle, TypeID, ReleaseDateFirstEpisode, ReleaseDateLastEpisode, NoOfSeasons, NoOfEpisodes, Budget, WorldwideGross, WorldwideGrossDate, CastStatusID, CrewStatusID, ConnectionID, Details, StatusID, LastUpdated " +
                           $"FROM Series " +
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
                    Logger.Debug($"Series.TypeID is not null -> retrieve");

                    Type = new Type(Reader.New());
                    Type.ID = row["TypeID"].ToString();
                    Type.Retrieve(retrieveBasicInfoOnly);
                }
                ReleaseDateFirstEpisode = row["ReleaseDateFirstEpisode"].ToString();
                ReleaseDateLastEpisode = row["ReleaseDateLastEpisode"].ToString();
                NoOfSeasons = row["NoOfSeasons"].ToString();
                NoOfEpisodes = row["NoOfEpisodes"].ToString();
                Budget = row["Budget"].ToString();
                WorldwideGross = row["WorldwideGross"].ToString();
                WorldwideGrossDate = row["WorldwideGrossDate"].ToString();
                if (!String.IsNullOrEmpty(row["CastStatusID"].ToString()))
                {
                    Logger.Debug($"Series.CastStatusID is not null -> retrieve");

                    CastStatus = new Status(Reader.New());
                    CastStatus.ID = row["CastStatusID"].ToString();
                    CastStatus.Retrieve(retrieveBasicInfoOnly);
                }
                if (!String.IsNullOrEmpty(row["CrewStatusID"].ToString()))
                {
                    Logger.Debug($"Series.CrewStatusID is not null -> retrieve");

                    CrewStatus = new Status(Reader.New());
                    CrewStatus.ID = row["CrewStatusID"].ToString();
                    CrewStatus.Retrieve(retrieveBasicInfoOnly);
                }
                if (!String.IsNullOrEmpty(row["ConnectionID"].ToString()))
                {
                    Logger.Debug($"Series.ConnectionID is not null -> retrieve");

                    Connection = new Connection(Reader.New());
                    Connection.ID = row["ConnectionID"].ToString();
                    Connection.Retrieve(retrieveBasicInfoOnly);
                }
                Details = row["Details"].ToString();
                if (!String.IsNullOrEmpty(row["StatusID"].ToString()))
                {
                    Logger.Debug($"Series.StatusID is not null -> retrieve");

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
        /// Retrieves the additional information of the series from the database.
        /// </summary>
        /// <returns>The number of data records retrieved.</returns>
        protected override int RetrieveAdditionalInformation()
        {
            Logger.Trace($"Series.RetrieveAdditionalInformation()");

            int noOfDataRecords = 0;

            // InfoBox data
            Genres = GenreItem.RetrieveList(Reader, "Series", ID, "Genre");
            noOfDataRecords += Genres.Count;
            if (Genres.Count == 0)
            {
                Logger.Debug($"Series.Genres.Count == 0 -> null");
                Genres = null;
            }

            Certifications = CertificationItem.RetrieveList(Reader, "Series", ID, "Certification");
            noOfDataRecords += Certifications.Count;
            if (Certifications.Count == 0)
            {
                Logger.Debug($"Series.Certifiations.Count == 0 -> null");
                Certifications = null;
            }

            Countries = CountryItem.RetrieveList(Reader, "Series", ID, "Country");
            noOfDataRecords += Countries.Count;
            if (Countries.Count == 0)
            {
                Logger.Debug($"Series.Countries.Count == 0 -> null");
                Countries = null;
            }

            Languages = LanguageItem.RetrieveList(Reader, "Series", ID, "Language");
            noOfDataRecords += Languages.Count;
            if (Languages.Count == 0)
            {
                Logger.Debug($"Series.Languages.Count == 0 -> null");
                Languages = null;
            }

            Runtimes = RuntimeItem.RetrieveList(Reader, "Series", ID, "Runtime");
            noOfDataRecords += Runtimes.Count;
            if (Runtimes.Count == 0)
            {
                Logger.Debug($"Series.Runtimes.Count == 0 -> null");
                Runtimes = null;
            }

            SoundMixes = SoundMixItem.RetrieveList(Reader, "Series", ID, "SoundMix");
            noOfDataRecords += SoundMixes.Count;
            if (SoundMixes.Count == 0)
            {
                Logger.Debug($"Series.SoundMixes.Count == 0 -> null");
                SoundMixes = null;
            }

            Colors = ColorItem.RetrieveList(Reader, "Series", ID, "Color");
            noOfDataRecords += Colors.Count;
            if (Colors.Count == 0)
            {
                Logger.Debug($"Series.Colors.Count == 0 -> null");
                Colors = null;
            }

            AspectRatios = AspectRatioItem.RetrieveList(Reader, "Series", ID, "AspectRatio");
            noOfDataRecords += AspectRatios.Count;
            if (AspectRatios.Count == 0)
            {
                Logger.Debug($"Series.AspectRatios.Count == 0 -> null");
                AspectRatios = null;
            }

            Cameras = CameraItem.RetrieveList(Reader, "Series", ID, "Camera");
            noOfDataRecords += Cameras.Count;
            if (Cameras.Count == 0)
            {
                Logger.Debug($"Series.Cameras.Count == 0 -> null");
                Cameras = null;
            }

            Laboratories = LaboratoryItem.RetrieveList(Reader, "Series", ID, "Laboratory");
            noOfDataRecords += Laboratories.Count;
            if (Laboratories.Count == 0)
            {
                Logger.Debug($"Series.Laboratories.Count == 0 -> null");
                Laboratories = null;
            }

            FilmLengths = FilmLengthItem.RetrieveList(Reader, "Series", ID, "FilmLength");
            noOfDataRecords += FilmLengths.Count;
            if (FilmLengths.Count == 0)
            {
                Logger.Debug($"Series.FilmLengths.Count == 0 -> null");
                FilmLengths = null;
            }

            NegativeFormats = FilmFormatItem.RetrieveList(Reader, "Series", ID, "NegativeFormat");
            noOfDataRecords += NegativeFormats.Count;
            if (NegativeFormats.Count == 0)
            {
                Logger.Debug($"Series.NegativeFormats.Count == 0 -> null");
                NegativeFormats = null;
            }

            CinematographicProcesses = CinematographicProcessItem.RetrieveList(Reader, "Series", ID, "CinematographicProcess");
            noOfDataRecords += CinematographicProcesses.Count;
            if (CinematographicProcesses.Count == 0)
            {
                Logger.Debug($"Series.CinematographicProcesses.Count == 0 -> null");
                CinematographicProcesses = null;
            }

            PrintedFilmFormats = FilmFormatItem.RetrieveList(Reader, "Series", ID, "PrintedFilmFormat");
            noOfDataRecords += PrintedFilmFormats.Count;
            if (PrintedFilmFormats.Count == 0)
            {
                Logger.Debug($"Series.PrintedFilmFormats.Count == 0 -> null");
                PrintedFilmFormats = null;
            }

            /*
            // Cast and crew data
            Directors = PersonItem.RetrieveList(Reader, "Series", ID, "Director");
            noOfDataRecords += Directors.Count;

            Writers = PersonItem.RetrieveList(Reader, "Series", ID, "Writer");
            noOfDataRecords += Writers.Count;

            Cast = CastPersonItem.RetrieveList(Reader, "Series", ID, "Cast");
            noOfDataRecords += Cast.Count;

            Producers = PersonItem.RetrieveList(Reader, "Series", ID, "Producer");
            noOfDataRecords += Producers.Count;

            Music = PersonItem.RetrieveList(Reader, "Series", ID, "Music");
            noOfDataRecords += Music.Count;

            Cinematography = PersonItem.RetrieveList(Reader, "Series", ID, "Cinematography");
            noOfDataRecords += Cinematography.Count;

            FilmEditing = PersonItem.RetrieveList(Reader, "Series", ID, "FilmEditing");
            noOfDataRecords += FilmEditing.Count;

            Casting = PersonItem.RetrieveList(Reader, "Series", ID, "Casting");
            noOfDataRecords += Casting.Count;

            ProductionDesign = PersonItem.RetrieveList(Reader, "Series", ID, "ProductionDesign");
            noOfDataRecords += ProductionDesign.Count;

            ArtDirection = PersonItem.RetrieveList(Reader, "Series", ID, "ArtDirection");
            noOfDataRecords += ArtDirection.Count;

            SetDecoration = PersonItem.RetrieveList(Reader, "Series", ID, "SetDecoration");
            noOfDataRecords += SetDecoration.Count;

            CostumeDesign = PersonItem.RetrieveList(Reader, "Series", ID, "CostumeDesign");
            noOfDataRecords += CostumeDesign.Count;

            MakeupDepartment = PersonItem.RetrieveList(Reader, "Series", ID, "MakeupDepartment");
            noOfDataRecords += MakeupDepartment.Count;

            ProductionManagement = PersonItem.RetrieveList(Reader, "Series", ID, "ProductionManagement");
            noOfDataRecords += ProductionManagement.Count;

            AssistantDirectors = PersonItem.RetrieveList(Reader, "Series", ID, "AssistantDirector");
            noOfDataRecords += AssistantDirectors.Count;

            ArtDepartment = PersonItem.RetrieveList(Reader, "Series", ID, "ArtDepartment");
            noOfDataRecords += ArtDepartment.Count;

            SoundDepartment = PersonItem.RetrieveList(Reader, "Series", ID, "SoundDepartment");
            noOfDataRecords += SoundDepartment.Count;

            SpecialEffects = PersonItem.RetrieveList(Reader, "Series", ID, "SpecialEffects");
            noOfDataRecords += SpecialEffects.Count;

            VisualEffects = PersonItem.RetrieveList(Reader, "Series", ID, "VisualEffects");
            noOfDataRecords += VisualEffects.Count;

            Stunts = PersonItem.RetrieveList(Reader, "Series", ID, "Stunts");
            noOfDataRecords += Stunts.Count;

            ElectricalDepartment = PersonItem.RetrieveList(Reader, "Series", ID, "ElectricalDepartment");
            noOfDataRecords += ElectricalDepartment.Count;

            AnimationDepartment = PersonItem.RetrieveList(Reader, "Series", ID, "AnimationDepartment");
            noOfDataRecords += AnimationDepartment.Count;

            CastingDepartment = PersonItem.RetrieveList(Reader, "Series", ID, "CastingDepartment");
            noOfDataRecords += CastingDepartment.Count;

            CostumeDepartment = PersonItem.RetrieveList(Reader, "Series", ID, "CostumeDepartment");
            noOfDataRecords += CostumeDepartment.Count;

            EditorialDepartment = PersonItem.RetrieveList(Reader, "Series", ID, "EditorialDepartment");
            noOfDataRecords += EditorialDepartment.Count;

            LocationManagement = PersonItem.RetrieveList(Reader, "Series", ID, "LocationManagement");
            noOfDataRecords += LocationManagement.Count;

            MusicDepartment = PersonItem.RetrieveList(Reader, "Series", ID, "MusicDepartment");
            noOfDataRecords += MusicDepartment.Count;

            ContinuityDepartment = PersonItem.RetrieveList(Reader, "Series", ID, "ContinuityDepartment");
            noOfDataRecords += ContinuityDepartment.Count;

            TransportationDepartment = PersonItem.RetrieveList(Reader, "Series", ID, "TransportationDepartment");
            noOfDataRecords += TransportationDepartment.Count;

            OtherCrew = PersonItem.RetrieveList(Reader, "Series", ID, "OtherCrew");
            noOfDataRecords += OtherCrew.Count;

            Thanks = PersonItem.RetrieveList(Reader, "Series", ID, "Thanks");
            noOfDataRecords += Thanks.Count;

            // Company data
            ProductionCompanies = CompanyItem.RetrieveList(Reader, "Series", ID, "ProductionCompany");
            noOfDataRecords += ProductionCompanies.Count;

            Distributors = DistributorCompanyItem.RetrieveList(Reader, "Series", ID, "Distributor");
            noOfDataRecords += Distributors.Count;

            SpecialEffectsCompanies = CompanyItem.RetrieveList(Reader, "Series", ID, "SpecialEffectsCompany");
            noOfDataRecords += SpecialEffectsCompanies.Count;

            OtherCompanies = CompanyItem.RetrieveList(Reader, "Series", ID, "OtherCompany");
            noOfDataRecords += OtherCompanies.Count;
            */
            // Production data
            FilmingLocations = LocationItem.RetrieveList(Reader, "Series", ID, "FilmingLocation");
            noOfDataRecords += FilmingLocations.Count;
            if (FilmingLocations.Count == 0)
            {
                Logger.Debug($"Series.FilmingLocations.Count == 0 -> null");
                FilmingLocations = null;
            }

            FilmingDates = TimespanItem.RetrieveList(Reader, "Series", ID, "FilmingDate");
            noOfDataRecords += FilmingDates.Count;
            if (FilmingDates.Count == 0)
            {
                Logger.Debug($"Series.FilmingDates.Count == 0 -> null");
                FilmingDates = null;
            }

            ProductionDates = TimespanItem.RetrieveList(Reader, "Series", ID, "ProductionDate");
            noOfDataRecords += ProductionDates.Count;
            if (ProductionDates.Count == 0)
            {
                Logger.Debug($"Series.ProductionDates.Count == 0 -> null");
                ProductionDates = null;
            }
            /*
            // Image data
            Posters = ImageItem.RetrieveList(Reader, "Series", ID, "Poster");
            noOfDataRecords += Posters.Count;

            Covers = ImageItem.RetrieveList(Reader, "Series", ID, "Cover");
            noOfDataRecords += Covers.Count;

            Images = ImageItem.RetrieveList(Reader, "Series", ID, "Image");
            noOfDataRecords += Images.Count;

            // Text data
            Descriptions = TextItem.RetrieveList(Reader, "Series", ID, "Description");
            noOfDataRecords += Descriptions.Count;

            Reviews = TextItem.RetrieveList(Reader, "Series", ID, "Review");
            noOfDataRecords += Reviews.Count;

            // other data
            Awards = AwardItem.RetrieveList(Reader, "Series", ID, "Award");
            noOfDataRecords += Awards.Count;

            Weblinks = WeblinkItem.RetrieveList(Reader, "Series", ID, "Weblink");
            noOfDataRecords += Weblinks.Count;
        */
            return noOfDataRecords;
        }

        /// <summary>
        /// Retrieves a list of series from the database.
        /// </summary>
        /// <param name="reader">The reader to be used to retrieve the data records.</param>
        /// <param name="status">The status of the series.</param>
        /// <param name="order">The order in which the data records are to be sorted.</param>
        /// <returns>The list of series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given reader, status or order is null.</exception>
        public static List<Article> RetrieveList(DBReader reader, string status, string order = "ID")
        {
            Logger.Trace($"Series.RetrieveList()");

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
                           $"FROM Series " +
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
                    Series item = new Series(reader.New());

                    item.ID = row["ID"].ToString();
                    item.Retrieve(true);
                    list.Add(item);
                }
            }

            return list;
        }
    }
}
