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
using WikiPageCreator.Export.Write;

namespace WikiPageCreator
{
    public class Program
    {
        // --- Properties ---

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Methods ---

        static void Main(string[] args)
        {
            Logger.Trace($"'WikiPageCreator' aufgerufen");

            Console.WriteLine($"Willkommen beim WikiPage Creator!");

            // Output-Folder
            string outputFolderDefault = ".\\Output";
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

            // ID
            string idUser;

            do
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
                // TODO: which DB reader is to be used should be defined in configuration
                SQLiteReader reader = new SQLiteReader();

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
                Console.WriteLine($"Alle Seiten erfolgreich erstellt.");
                Console.ReadLine();
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
            Movie movie = new Movie(id);
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);
            creator.CreateContent(targetLanguageCode);

            FileWriter writer = new FileWriter();
            writer.WriteToFile(outputFolder + "\\" + targetLanguageCode + "\\cinema_and_television_movie\\", creator.GetFileName(), creator.Content);
        }
    }
}
