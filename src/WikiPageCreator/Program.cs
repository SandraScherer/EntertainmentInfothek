using EntertainmentDB.Data;
using System;
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
            string outputFolder = ".\\Output";
            string outputFolderUser;

            Console.WriteLine($"");
            Console.WriteLine($"Bitte geben Sie den Ordner für die Dateiausgabe an (oder Enter für voreingestellten Pfad):");
            Console.WriteLine($"(voreingestellter Pfad ist '{outputFolder}'");

            outputFolderUser = Console.ReadLine();

            if (String.IsNullOrEmpty(outputFolderUser))
            {
                outputFolderUser = outputFolder;
            }
            Console.WriteLine($"");
            Console.WriteLine($"Ihr ausgewählter Ausgabe-Ordner ist '{outputFolderUser}'");

            Logger.Trace($"Ausgabeordner: {outputFolderUser}");

            // Target language
            string targetLanguageCodeUser = "de";

            Logger.Trace($"Zielsprache: {targetLanguageCodeUser}");

            // ID
            string idUser;

            do
            {
                Console.WriteLine($"");
                Console.WriteLine($"Bitte geben Sie die ID des Films ein, für den eine Wiki-Seite erstellt werden soll:");

                idUser = Console.ReadLine();
            }
            while (String.IsNullOrEmpty(idUser));

            Logger.Trace($"Film ID: {idUser}");

            CreateMoviePage(idUser, targetLanguageCodeUser, outputFolderUser);

            // End
            Console.WriteLine($"");
            Console.WriteLine($"Seitenerstellung erfolgreich beendet.");
            Console.ReadLine();

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
            movie.Retrieve();

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);
            creator.CreateContent(targetLanguageCode);

            FileWriter writer = new FileWriter();
            writer.WriteToFile(outputFolder + "\\" + targetLanguageCode + "\\movies_and_tv_films\\", creator.GetFileName(), creator.Content);
        }
    }
}
