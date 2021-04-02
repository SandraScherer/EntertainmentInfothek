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
        public Movie(string id)
        {
            if (id == null)
            {
                throw new NullReferenceException(nameof(ID));
            }

            Logger.Trace($"Movie() angelegt");

            ID = id;
        }

        // --- Methods ---

        /// <summary>
        /// Retrieves the basic information of the movie from the database.
        /// </summary>
        /// <returns>1 if data record was retrieved; 0 if no data record matched the id.</returns>
        /// <exception cref="NullReferenceException">Thrown when the id is null.</exception>
        public override int RetrieveBasicInformation()
        {
            if (String.IsNullOrEmpty(ID))
            {
                throw new NullReferenceException(nameof(ID));
            }

            Reader.Query = $"SELECT ID, OriginalTitle, EnglishTitle, GermanTitle, TypeID, ReleaseDate, Budget, WorldwideGross, WorldwideGrossDate, ConnectionID, Details, StatusID, LastUpdated " +
                           $"FROM Movie " +
                           $"WHERE ID=\"{ID}\"";

            if (1 == Reader.Retrieve())
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
                    Type.RetrieveBasicInformation();
                }
                ReleaseDate = row["ReleaseDate"].ToString();
                Budget = row["Budget"].ToString();
                WorldwideGross = row["WorldwideGross"].ToString();
                WorldwideGrossDate = row["WorldwideGrossDate"].ToString();
                if (!String.IsNullOrEmpty(row["ConnectionID"].ToString()))
                {
                    Connection = new Connection();
                    Connection.ID = row["ConnectionID"].ToString();
                    Connection.RetrieveBasicInformation();
                }
                Details = row["Details"].ToString();
                if (!String.IsNullOrEmpty(row["StatusID"].ToString()))
                {
                    Status = new Status();
                    Status.ID = row["StatusID"].ToString();
                    Status.RetrieveBasicInformation();
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
        /// Retrieves the additional information of the movie from the database (none available).
        /// </summary>
        /// <returns>The number of data records retrieved.</returns>
        /// <exception cref="NullReferenceException">Thrown when the reader or id is null.</exception>
        public override int RetrieveAdditionalInformation()
        {
            if (Reader == null)
            {
                throw new NullReferenceException(nameof(Reader));
            }
            if (String.IsNullOrEmpty(ID))
            {
                throw new NullReferenceException(nameof(ID));
            }

            // InfoBox data
            Genres = GenreItem.RetrieveList(Reader, $"Movie", ID, "Genre") ?? Genres;
            Certifications = CertificationItem.RetrieveList(Reader, $"Movie", ID, "Certification") ?? Certifications;
            Countries = CountryItem.RetrieveList(Reader, $"Movie", ID, "Country") ?? Countries;
            Languages = LanguageItem.RetrieveList(Reader, $"Movie", ID, "Language") ?? Languages;
            Runtimes = RuntimeItem.RetrieveList(Reader, $"Movie", ID, "Runtime") ?? Runtimes;
            SoundMixes = SoundMixItem.RetrieveList(Reader, $"Movie", ID, "SoundMix") ?? SoundMixes;
            Colors = ColorItem.RetrieveList(Reader, $"Movie", ID, "Color") ?? Colors;
            AspectRatios = AspectRatioItem.RetrieveList(Reader, $"Movie", ID, "AspectRatio") ?? AspectRatios;
            Cameras = CameraItem.RetrieveList(Reader, $"Movie", ID, "Camera") ?? Cameras;
            Laboratories = LaboratoryItem.RetrieveList(Reader, $"Movie", ID, "Laboratory") ?? Laboratories;
            FilmLengths = FilmLengthItem.RetrieveList(Reader, $"Movie", ID, "FilmLength") ?? FilmLengths;
            NegativeFormats = NegativeFormatItem.RetrieveList(Reader, $"Movie", ID, "NegativeFormat") ?? NegativeFormats;
            CinematographicProcesses = CinematographicProcessItem.RetrieveList(Reader, $"Movie", ID, "CinematographicProcess") ?? CinematographicProcesses;
            PrintedFilmFormats = PrintedFilmFormatItem.RetrieveList(Reader, $"Movie", ID, "PrintedFilmFormat") ?? PrintedFilmFormats;

            // Cast and crew data
            Directors = PersonItem.RetrieveList(Reader, $"Movie", ID, "Director") ?? Directors;
            Writers = PersonItem.RetrieveList(Reader, $"Movie", ID, "Writer") ?? Writers;
            Cast = CastPersonItem.RetrieveList(Reader, $"Movie", ID, "Cast") ?? Cast;

            return Genres.Count +
                   Certifications.Count +
                   Countries.Count +
                   Languages.Count +
                   Runtimes.Count +
                   SoundMixes.Count +
                   Colors.Count +
                   AspectRatios.Count +
                   Cameras.Count +
                   Laboratories.Count +
                   FilmLengths.Count +
                   NegativeFormats.Count +
                   CinematographicProcesses.Count +
                   PrintedFilmFormats.Count +

                   Directors.Count +
                   Writers.Count +
                   Cast.Count;
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
                throw new NullReferenceException(nameof(reader));
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

            if (reader.Retrieve() > 0)
            {
                list.Capacity = reader.Table.Rows.Count;

                foreach (DataRow row in reader.Table.Rows)
                {
                    Movie item = new Movie();

                    item.ID = row["ID"].ToString();
                    item.RetrieveBasicInformation();
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
