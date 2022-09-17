// WikiPageCreator.exe: Creates pages for use with a wiki from the
// EntertainmentInfothek.db using EntertainmentDB.dll
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


using EntertainmentDB.Data;
using EntertainmentDB.DBAccess.Read;
using System;
using System.Collections.Generic;
using WikiPageCreator.Export.Create;
using WikiPageCreator.Export.Format;
using WikiPageCreator.Export.Write;

namespace WikiPageCreator
{
    public static class Program
    {
        // --- Properties ---

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Methods ---

        static void Main(string[] args)
        {
            Logger.Trace($"Main()");

            Console.WriteLine($"Willkommen beim WikiPage Creator!");

            // Output-Folder
            string outputFolderDefault = ".\\output";
            string outputFolder;

            Console.WriteLine($"");
            Console.WriteLine($"Bitte geben Sie den Ordner für die Dateiausgabe an (oder Enter für voreingestellten Pfad):");
            Console.WriteLine($"(voreingestellter Pfad ist '{outputFolderDefault}'");

            outputFolder = Console.ReadLine();

            if (String.IsNullOrEmpty(outputFolder))
            {
                outputFolder = outputFolderDefault;
            }
            Console.WriteLine($"");
            Console.WriteLine($"Ihr ausgewählter Ausgabe-Ordner ist '{outputFolder}'");

            Logger.Debug($"Output folder is set to '{outputFolder}'");

            // Target language
            string targetLanguageCodeUser = "de";

            Logger.Debug($"Target language is set to '{targetLanguageCodeUser}'");

            // TODO: which DB reader is to be used should be defined in configuration
            SQLiteReader reader = new SQLiteReader();

            // ID
            string idUser;

            do
            {
                // Output Type
                string pageTypeUser;

                do
                {
                    Console.WriteLine($"");
                    Console.WriteLine($"Bitte geben Sie ein, wofür Sie eine Wiki-Seite erstellen wollen (oder 'q' für Beenden):");
                    Console.WriteLine($"{(int)PageType.Movie} - Film");
                    Console.WriteLine($"{(int)PageType.Series} - Serie");

                    pageTypeUser = Console.ReadLine();
                }
                while (String.IsNullOrEmpty(pageTypeUser));

                if (pageTypeUser.Equals("q") || pageTypeUser.Equals("Q"))
                {
                    break;
                }

                Logger.Debug($"Type is set to '{pageTypeUser}'");

                do
                {
                    Console.WriteLine($"");
                    Console.WriteLine($"Bitte geben Sie die ID des Datensatzes ein, für den eine Wiki-Seite erstellt werden soll (oder 'q' für Beenden):");

                    idUser = Console.ReadLine();
                }
                while (String.IsNullOrEmpty(idUser));

                if (idUser.Equals("q") || idUser.Equals("Q"))
                {
                    break;
                }

                Logger.Debug($"ID is set to '{idUser}'");


                // TODO: change if..else if to a better solution

                if (pageTypeUser.Equals(((int)PageType.Movie).ToString()))
                {
                    List<Movie> list = new List<Movie>();
                    
                    if (idUser.Equals("*"))
                    {
                        list = Movie.RetrieveList(reader, "ok");
                    }
                    else
                    {
                        list.Add(new Movie(reader, idUser));
                    }

                    foreach (Movie item in list)
                    {
                        CreateMoviePage(item.ID, targetLanguageCodeUser, outputFolder);
                        Console.WriteLine($"Seitenerstellung für ID: {item.ID} erfolgreich beendet.");

                        Logger.Info($"Movie page for ID '{item.ID}' successfully created");
                    }
                }
                else if (pageTypeUser.Equals(((int)PageType.Series).ToString()))
                {
                    List<Series> list = new List<Series>();

                    if (idUser.Equals("*"))
                    {
                        list = Series.RetrieveList(reader, "ok");

                    }
                    else
                    {
                        list.Add(new Series(reader, idUser));
                    }

                    foreach (Series item in list)
                    {
                        CreateSeriesPage(item.ID, targetLanguageCodeUser, outputFolder);
                        Console.WriteLine($"Seitenerstellung für ID: {item.ID} erfolgreich beendet.");

                        Logger.Info($"Series page for ID '{item.ID}' successfully created");
                    }
                }

                // End
                Console.WriteLine($"");
                Console.WriteLine($"Alle Seiten erfolgreich erstellt.");
                Console.ReadLine();
            }
            while (true);

            Logger.Trace($"Main() done");
        }

        /// <summary>
        /// Creates a movie page with the specified parameters.
        /// </summary>
        /// <param name="id">The id of the movie.</param>
        /// <param name="targetLanguageCode">The target language for the page.</param>
        /// <param name="outputFolder">The output folder for the page.</param>
        private static void CreateMoviePage(string id, string targetLanguageCode, string outputFolder)
        {
            Logger.Trace($"CreateMoviePage()");

            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, id);
            movie.Retrieve(false);
            Formatter formatter = new DokuWikiFormatter();
            MovieContentCreator creator = new MovieContentCreator(movie, formatter, targetLanguageCode);

            List<string> content = new List<string>();

            content.AddRange(creator.CreatePageContent());

            FileWriter writer = new FileWriter();
            writer.WriteToFile(outputFolder + "\\" + targetLanguageCode + "\\cinema_and_television_movie\\", creator.GetPageName(), content);

            Logger.Trace($"CreateMoviePage() done");
        }

        /// <summary>
        /// Creates a series page with the specified parameters.
        /// </summary>
        /// <param name="id">The id of the series.</param>
        /// <param name="targetLanguageCode">The target language for the page.</param>
        /// <param name="outputFolder">The output folder for the page.</param>
        private static void CreateSeriesPage(string id, string targetLanguageCode, string outputFolder)
        {
            Logger.Trace($"CreateSeriesPage()");

            DBReader reader = new SQLiteReader();
            Series series = new Series(reader, id);
            series.Retrieve(false);
            Formatter formatter = new DokuWikiFormatter();
            SeriesContentCreator creator = new SeriesContentCreator(series, formatter, targetLanguageCode);

            List<string> content = new List<string>();

            content.AddRange(creator.CreatePageContent());

            FileWriter writer = new FileWriter();
            writer.WriteToFile(outputFolder + "\\" + targetLanguageCode + "\\cinema_and_television_series\\", creator.GetPageName(), content);

            Logger.Trace($"CreateSeriesPage() done");
        }
    }
}
