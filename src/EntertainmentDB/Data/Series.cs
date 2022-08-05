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
    public class Series : Article
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
        /// The budget of the series.
        /// </summary>
        public string Budget { get; set; }

        /// <summary>
        /// The worldwide gross of the series.
        /// </summary>
        public string WorldwideGross { get; set; }

        /// <summary>
        /// The corresponding date to the worldwide gross of the series.
        /// </summary>
        public string WorldwideGrossDate { get; set; }

        /// <summary>
        /// The cast status of the series.
        /// </summary>
        public Status CastStatus { get; set; }

        /// <summary>
        /// The crew status of the series.
        /// </summary>
        public Status CrewStatus { get; set; }

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

            Logger.Trace($"Series() with ID = '{id}' created");
        }

        // --- Methods ---

        /// <summary>
        /// Retrieves the basic information of the series from the database.
        /// </summary>
        /// <param name="retrieveBasicInfoOnly">true if only the basic info is to be retrieved; false if also additional data is to be retrieved.</param>
        /// <returns>1 if data record was retrieved; 0 if no data record matched the id.</returns>
        protected override int RetrieveBasicInformation(bool retrieveBasicInfoOnly)
        {
            Reader.Query = $"SELECT ID, OriginalTitle, EnglishTitle, GermanTitle, TypeID, ReleaseDateFirstEpisode, ReleaseDateLastEpisode, NoOfSeasons, NoOfEpisodes, Budget, WorldwideGross, WorldwideGrossDate, CastStatusID, CrewStatusID, ConnectionID, Details, StatusID, LastUpdated " +
                           $"FROM Series " +
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
                ReleaseDateFirstEpisode = row["ReleaseDateFirstEpisode"].ToString();
                ReleaseDateLastEpisode = row["ReleaseDateLastEpisode"].ToString();
                NoOfSeasons = row["NoOfSeasons"].ToString();
                NoOfEpisodes = row["NoOfEpisodes"].ToString();
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
        /// Retrieves the additional information of the series from the database.
        /// </summary>
        /// <returns>The number of data records retrieved.</returns>
        protected override int RetrieveAdditionalInformation()
        {
            int count = 0;
            /*
                        // InfoBox data
                        Genres = GenreItem.RetrieveList(Reader, "Series", ID, "Genre");
                        count += Genres.Count;

                        Certifications = CertificationItem.RetrieveList(Reader, "Series", ID, "Certification");
                        count += Certifications.Count;

                        Countries = CountryItem.RetrieveList(Reader, "Series", ID, "Country");
                        count += Countries.Count;

                        Languages = LanguageItem.RetrieveList(Reader, "Series", ID, "Language");
                        count += Languages.Count;

                        Runtimes = RuntimeItem.RetrieveList(Reader, "Series", ID, "Runtime");
                        count += Runtimes.Count;

                        SoundMixes = SoundMixItem.RetrieveList(Reader, "Series", ID, "SoundMix");
                        count += SoundMixes.Count;

                        Colors = ColorItem.RetrieveList(Reader, "Series", ID, "Color");
                        count += Colors.Count;

                        AspectRatios = AspectRatioItem.RetrieveList(Reader, "Series", ID, "AspectRatio");
                        count += AspectRatios.Count;

                        Cameras = CameraItem.RetrieveList(Reader, "Series", ID, "Camera");
                        count += Cameras.Count;

                        Laboratories = LaboratoryItem.RetrieveList(Reader, "Series", ID, "Laboratory");
                        count += Laboratories.Count;

                        FilmLengths = FilmLengthItem.RetrieveList(Reader, "Series", ID, "FilmLength");
                        count += FilmLengths.Count;

                        NegativeFormats = NegativeFormatItem.RetrieveList(Reader, "Series", ID, "NegativeFormat");
                        count += NegativeFormats.Count;

                        CinematographicProcesses = CinematographicProcessItem.RetrieveList(Reader, "Series", ID, "CinematographicProcess");
                        count += CinematographicProcesses.Count;

                        PrintedFilmFormats = PrintedFilmFormatItem.RetrieveList(Reader, "Series", ID, "PrintedFilmFormat");
                        count += PrintedFilmFormats.Count;

                        // Cast and crew data
                        Directors = PersonItem.RetrieveList(Reader, "Series", ID, "Director");
                        count += Directors.Count;

                        Writers = PersonItem.RetrieveList(Reader, "Series", ID, "Writer");
                        count += Writers.Count;

                        Cast = CastPersonItem.RetrieveList(Reader, "Series", ID, "Cast");
                        count += Cast.Count;

                        Producers = PersonItem.RetrieveList(Reader, "Series", ID, "Producer");
                        count += Producers.Count;

                        Music = PersonItem.RetrieveList(Reader, "Series", ID, "Music");
                        count += Music.Count;

                        Cinematography = PersonItem.RetrieveList(Reader, "Series", ID, "Cinematography");
                        count += Cinematography.Count;

                        FilmEditing = PersonItem.RetrieveList(Reader, "Series", ID, "FilmEditing");
                        count += FilmEditing.Count;

                        Casting = PersonItem.RetrieveList(Reader, "Series", ID, "Casting");
                        count += Casting.Count;

                        ProductionDesign = PersonItem.RetrieveList(Reader, "Series", ID, "ProductionDesign");
                        count += ProductionDesign.Count;

                        ArtDirection = PersonItem.RetrieveList(Reader, "Series", ID, "ArtDirection");
                        count += ArtDirection.Count;

                        SetDecoration = PersonItem.RetrieveList(Reader, "Series", ID, "SetDecoration");
                        count += SetDecoration.Count;

                        CostumeDesign = PersonItem.RetrieveList(Reader, "Series", ID, "CostumeDesign");
                        count += CostumeDesign.Count;

                        MakeupDepartment = PersonItem.RetrieveList(Reader, "Series", ID, "MakeupDepartment");
                        count += MakeupDepartment.Count;

                        ProductionManagement = PersonItem.RetrieveList(Reader, "Series", ID, "ProductionManagement");
                        count += ProductionManagement.Count;

                        AssistantDirectors = PersonItem.RetrieveList(Reader, "Series", ID, "AssistantDirector");
                        count += AssistantDirectors.Count;

                        ArtDepartment = PersonItem.RetrieveList(Reader, "Series", ID, "ArtDepartment");
                        count += ArtDepartment.Count;

                        SoundDepartment = PersonItem.RetrieveList(Reader, "Series", ID, "SoundDepartment");
                        count += SoundDepartment.Count;

                        SpecialEffects = PersonItem.RetrieveList(Reader, "Series", ID, "SpecialEffects");
                        count += SpecialEffects.Count;

                        VisualEffects = PersonItem.RetrieveList(Reader, "Series", ID, "VisualEffects");
                        count += VisualEffects.Count;

                        Stunts = PersonItem.RetrieveList(Reader, "Series", ID, "Stunts");
                        count += Stunts.Count;

                        ElectricalDepartment = PersonItem.RetrieveList(Reader, "Series", ID, "ElectricalDepartment");
                        count += ElectricalDepartment.Count;

                        AnimationDepartment = PersonItem.RetrieveList(Reader, "Series", ID, "AnimationDepartment");
                        count += AnimationDepartment.Count;

                        CastingDepartment = PersonItem.RetrieveList(Reader, "Series", ID, "CastingDepartment");
                        count += CastingDepartment.Count;

                        CostumeDepartment = PersonItem.RetrieveList(Reader, "Series", ID, "CostumeDepartment");
                        count += CostumeDepartment.Count;

                        EditorialDepartment = PersonItem.RetrieveList(Reader, "Series", ID, "EditorialDepartment");
                        count += EditorialDepartment.Count;

                        LocationManagement = PersonItem.RetrieveList(Reader, "Series", ID, "LocationManagement");
                        count += LocationManagement.Count;

                        MusicDepartment = PersonItem.RetrieveList(Reader, "Series", ID, "MusicDepartment");
                        count += MusicDepartment.Count;

                        ContinuityDepartment = PersonItem.RetrieveList(Reader, "Series", ID, "ContinuityDepartment");
                        count += ContinuityDepartment.Count;

                        TransportationDepartment = PersonItem.RetrieveList(Reader, "Series", ID, "TransportationDepartment");
                        count += TransportationDepartment.Count;

                        OtherCrew = PersonItem.RetrieveList(Reader, "Series", ID, "OtherCrew");
                        count += OtherCrew.Count;

                        Thanks = PersonItem.RetrieveList(Reader, "Series", ID, "Thanks");
                        count += Thanks.Count;

                        // Company data
                        ProductionCompanies = CompanyItem.RetrieveList(Reader, "Series", ID, "ProductionCompany");
                        count += ProductionCompanies.Count;

                        Distributors = DistributorCompanyItem.RetrieveList(Reader, "Series", ID, "Distributor");
                        count += Distributors.Count;

                        SpecialEffectsCompanies = CompanyItem.RetrieveList(Reader, "Series", ID, "SpecialEffectsCompany");
                        count += SpecialEffectsCompanies.Count;

                        OtherCompanies = CompanyItem.RetrieveList(Reader, "Series", ID, "OtherCompany");
                        count += OtherCompanies.Count;

                        // Production data
                        FilmingLocations = LocationItem.RetrieveList(Reader, "Series", ID, "FilmingLocation");
                        count += FilmingLocations.Count;

                        FilmingDates = TimespanItem.RetrieveList(Reader, "Series", ID, "FilmingDate");
                        count += FilmingDates.Count;

                        ProductionDates = TimespanItem.RetrieveList(Reader, "Series", ID, "ProductionDate");
                        count += ProductionDates.Count;

                        // Image data
                        Posters = ImageItem.RetrieveList(Reader, "Series", ID, "Poster");
                        count += Posters.Count;

                        Covers = ImageItem.RetrieveList(Reader, "Series", ID, "Cover");
                        count += Covers.Count;

                        Images = ImageItem.RetrieveList(Reader, "Series", ID, "Image");
                        count += Images.Count;

                        // Text data
                        Descriptions = TextItem.RetrieveList(Reader, "Series", ID, "Description");
                        count += Descriptions.Count;

                        Reviews = TextItem.RetrieveList(Reader, "Series", ID, "Review");
                        count += Reviews.Count;

                        // other data
                        Awards = AwardItem.RetrieveList(Reader, "Series", ID, "Award");
                        count += Awards.Count;

                        Weblinks = WeblinkItem.RetrieveList(Reader, "Series", ID, "Weblink");
                        count += Weblinks.Count;
            */
            return count;
        }

        /// <summary>
        /// Retrieves a list of series from the database.
        /// </summary>
        /// <param name="reader">The reader to be used to retrieve the data records.</param>
        /// <param name="status">The status of the series.</param>
        /// <param name="order">The order in which the data records are to be sorted.</param>
        /// <returns>The list of series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given status or order is null.</exception>
        public static List<Series> RetrieveList(DBReader reader, string status, string order = "ID")
        {
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
                           $"WHERE StatusID=\"{status}\"" +
                           $"ORDER BY {order}";

            List<Series> list = new List<Series>();

            if (reader.Retrieve(true) > 0)
            {
                list.Capacity = reader.Table.Rows.Count;

                foreach (DataRow row in reader.Table.Rows)
                {
                    Series item = new Series(reader.New());

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
