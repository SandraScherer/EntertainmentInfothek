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
            Logger.Trace($"'WikiPageCreator' aufgerufen");

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

            Logger.Trace($"Ausgabeordner: {outputFolder}");

            // Target language
            string targetLanguageCodeUser = "de";

            Logger.Trace($"Zielsprache: {targetLanguageCodeUser}");

            // TODO: which DB reader is to be used should be defined in configuration
            SQLiteReader reader = new SQLiteReader();

            // ID
            string idUser;

            do
            {
                // Output Type
                string outputTypeUser;

                do
                {
                    Console.WriteLine($"");
                    Console.WriteLine($"Bitte geben Sie ein, wofür Sie eine Wiki-Seite erstellen wollen (oder 'q' für Beenden):");
                    Console.WriteLine($"1 - Film");
                    Console.WriteLine($"2 - Serie");

                    outputTypeUser = Console.ReadLine();
                }
                while (String.IsNullOrEmpty(outputTypeUser));

                if (outputTypeUser.Equals("q") || outputTypeUser.Equals("Q"))
                {
                    break;
                }

                if (outputTypeUser.Equals("1"))
                {
                    do
                    {
                        Console.WriteLine($"");
                        Console.WriteLine($"Bitte geben Sie die ID des Films ein, für den eine Wiki-Seite erstellt werden soll (oder 'q' für Beenden):");

                        idUser = Console.ReadLine();
                    }
                    while (String.IsNullOrEmpty(idUser));

                    if (idUser.Equals("q") || idUser.Equals("Q"))
                    {
                        break;
                    }

                    Logger.Trace($"Film ID: {idUser}");

                    // do work
                    if (idUser.Equals("*"))
                    {
                        List<Movie> list = Movie.RetrieveList(reader, "ok");

                        foreach (Movie item in list)
                        {
                            CreateMoviePage(item.ID, targetLanguageCodeUser, outputFolder);
                            Console.WriteLine($"Seitenerstellung für ID: {item.ID} erfolgreich beendet.");
                        }
                    }
                    else
                    {
                        CreateMoviePage(idUser, targetLanguageCodeUser, outputFolder);
                        Console.WriteLine($"Seitenerstellung für ID: {idUser} erfolgreich beendet.");
                    }

                    // End
                    Console.WriteLine($"");
                    Console.WriteLine($"Alle Film-Seiten erfolgreich erstellt.");
                    Console.ReadLine();
                }

                else if (outputTypeUser.Equals("2"))
                {
                    do
                    {
                        Console.WriteLine($"");
                        Console.WriteLine($"Bitte geben Sie die ID der Serie ein, für den eine Wiki-Seite erstellt werden soll (oder 'q' für Beenden):");

                        idUser = Console.ReadLine();
                    }
                    while (String.IsNullOrEmpty(idUser));

                    if (idUser.Equals("q") || idUser.Equals("Q"))
                    {
                        break;
                    }

                    Logger.Trace($"Serien ID: {idUser}");

                    // do work
                    if (idUser.Equals("*"))
                    {
                        List<Series> list = Series.RetrieveList(reader, "ok");

                        foreach (Series item in list)
                        {
                            CreateSeriesPage(item.ID, targetLanguageCodeUser, outputFolder);
                            Console.WriteLine($"Seitenerstellung für ID: {item.ID} erfolgreich beendet.");
                        }
                    }
                    else
                    {
                        CreateSeriesPage(idUser, targetLanguageCodeUser, outputFolder);
                        Console.WriteLine($"Seitenerstellung für ID: {idUser} erfolgreich beendet.");
                    }

                    // End
                    Console.WriteLine($"");
                    Console.WriteLine($"Alle Serien-Seiten erfolgreich erstellt.");
                    Console.ReadLine();
                }
            }
            while (true);

            Logger.Trace($"'WikiPageCreator' beendet");
        }

        /// <summary>
        /// Creates a movie page with the specified parameters.
        /// </summary>
        /// <param name="id">The id of the movie.</param>
        /// <param name="targetLanguageCode">The target language for the page.</param>
        /// <param name="outputFolder">The output folder for the page.</param>
        private static void CreateMoviePage(string id, string targetLanguageCode, string outputFolder)
        {
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, id);
            movie.Retrieve(false);

            MovieContentCreator creator = new MovieContentCreator();
            List<string> content = new List<string>();
            Formatter formatter = new DokuWikiFormatter();

            content.AddRange(creator.CreateFileContent(movie, targetLanguageCode, formatter));

            FileWriter writer = new FileWriter();
            writer.WriteToFile(outputFolder + "\\" + targetLanguageCode + "\\cinema_and_television_movie\\", creator.GetFileName(movie, formatter), content);
        }

        /// <summary>
        /// Creates a series page with the specified parameters.
        /// </summary>
        /// <param name="id">The id of the series.</param>
        /// <param name="targetLanguageCode">The target language for the page.</param>
        /// <param name="outputFolder">The output folder for the page.</param>
        private static void CreateSeriesPage(string id, string targetLanguageCode, string outputFolder)
        {
            DBReader reader = new SQLiteReader();
            Series series = new Series(reader, id);
            series.Retrieve(false);

            SeriesContentCreator creator = new SeriesContentCreator();
            List<string> content = new List<string>();
            Formatter formatter = new DokuWikiFormatter();

            content.AddRange(creator.CreateFileContent(series, targetLanguageCode, formatter));

            FileWriter writer = new FileWriter();
            writer.WriteToFile(outputFolder + "\\" + targetLanguageCode + "\\cinema_and_television_series\\", creator.GetFileName(series, formatter), content);
        }
    }
}
