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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EntertainmentDB.Data.Tests
{
    [TestClass()]
    public class SeriesTests
    {
        const string VALID_ID = "_xxx";
        const string INVALID_ID = "_aaa";

        [TestMethod()]
        public void SeriesTest()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Series entry = new Series(reader);

            // Act
            // Assert
            Assert.IsNotNull(entry);
            Assert.AreEqual(reader, entry.Reader);

            Assert.AreEqual("", entry.ID);
            Assert.IsNull(entry.OriginalTitle);
            Assert.IsNull(entry.EnglishTitle);
            Assert.IsNull(entry.GermanTitle);
            Assert.IsNull(entry.Type);
            Assert.IsNull(entry.ReleaseDateFirstEpisode);
            Assert.IsNull(entry.ReleaseDateLastEpisode);
            Assert.IsNull(entry.NoOfSeasons);
            Assert.IsNull(entry.NoOfEpisodes);
            Assert.IsNull(entry.Budget);
            Assert.IsNull(entry.WorldwideGross);
            Assert.IsNull(entry.WorldwideGrossDate);
            Assert.IsNull(entry.CastStatus);
            Assert.IsNull(entry.CrewStatus);
            Assert.IsNull(entry.Connection);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);

            Assert.IsNull(entry.Genres);
            Assert.IsNull(entry.Certifications);
            Assert.IsNull(entry.Countries);
            Assert.IsNull(entry.Languages);
            Assert.IsNull(entry.Runtimes);
            Assert.IsNull(entry.SoundMixes);
            Assert.IsNull(entry.Colors);
            //Assert.IsNull(entry.AspectRatios);
            //Assert.IsNull(entry.Cameras);
            //Assert.IsNull(entry.Laboratories);
            //Assert.IsNull(entry.FilmLengths);
            //Assert.IsNull(entry.NegativeFormats);
            //Assert.IsNull(entry.CinematographicProcesses);
            //Assert.IsNull(entry.PrintedFilmFormats);

            //Assert.IsNull(entry.Creators);
            //Assert.IsNull(entry.Directors);
            //Assert.IsNull(entry.Writers);
            //Assert.IsNull(entry.Cast);
            //Assert.IsNull(entry.Producers);
            //Assert.IsNull(entry.Music);
            //Assert.IsNull(entry.Cinematography);
            //Assert.IsNull(entry.FilmEditing);
            //Assert.IsNull(entry.Casting);
            //Assert.IsNull(entry.ProductionDesign);
            //Assert.IsNull(entry.ArtDirection);
            //Assert.IsNull(entry.SetDecoration);
            //Assert.IsNull(entry.CostumeDesign);
            //Assert.IsNull(entry.MakeupDepartment);
            //Assert.IsNull(entry.ProductionManagement);
            //Assert.IsNull(entry.AssistantDirectors);
            //Assert.IsNull(entry.ArtDepartment);
            //Assert.IsNull(entry.SoundDepartment);
            //Assert.IsNull(entry.SpecialEffects);
            //Assert.IsNull(entry.VisualEffects);
            //Assert.IsNull(entry.Stunts);
            //Assert.IsNull(entry.ElectricalDepartment);
            //Assert.IsNull(entry.AnimationDepartment);
            //Assert.IsNull(entry.CastingDepartment);
            //Assert.IsNull(entry.CostumeDepartment);
            //Assert.IsNull(entry.EditorialDepartment);
            //Assert.IsNull(entry.LocationManagement);
            //Assert.IsNull(entry.MusicDepartment);
            //Assert.IsNull(entry.ContinuityDepartment);
            //Assert.IsNull(entry.TransportationDepartment);
            //Assert.IsNull(entry.OtherCrew);

            //Assert.IsNull(entry.ProductionCompanies);
            //Assert.IsNull(entry.Distributors);
            //Assert.IsNull(entry.SpecialEffectsCompanies);
            //Assert.IsNull(entry.OtherCompanies);

            //Assert.IsNull(entry.FilmingLocations);
            //Assert.IsNull(entry.FilmingDates);
            //Assert.IsNull(entry.ProductionDates);

            //Assert.IsNull(entry.Posters);
            //Assert.IsNull(entry.Covers);
            //Assert.IsNull(entry.Images);

            //Assert.IsNull(entry.Descriptions);
            //Assert.IsNull(entry.Reviews);

            //Assert.IsNull(entry.Awards);
            //Assert.IsNull(entry.Weblinks);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void SeriesTest_withID(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Series entry = new Series(reader, id);

            // Act
            // Assert
            Assert.IsNotNull(entry);
            Assert.AreEqual(reader, entry.Reader);

            Assert.AreEqual(id, entry.ID);
            Assert.IsNull(entry.OriginalTitle);
            Assert.IsNull(entry.EnglishTitle);
            Assert.IsNull(entry.GermanTitle);
            Assert.IsNull(entry.Type);
            Assert.IsNull(entry.ReleaseDateFirstEpisode);
            Assert.IsNull(entry.ReleaseDateLastEpisode);
            Assert.IsNull(entry.NoOfSeasons);
            Assert.IsNull(entry.NoOfEpisodes);
            Assert.IsNull(entry.Budget);
            Assert.IsNull(entry.WorldwideGross);
            Assert.IsNull(entry.WorldwideGrossDate);
            Assert.IsNull(entry.CastStatus);
            Assert.IsNull(entry.CrewStatus);
            Assert.IsNull(entry.Connection);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);

            Assert.IsNull(entry.Genres);
            Assert.IsNull(entry.Certifications);
            Assert.IsNull(entry.Countries);
            Assert.IsNull(entry.Languages);
            Assert.IsNull(entry.Runtimes);
            Assert.IsNull(entry.SoundMixes);
            Assert.IsNull(entry.Colors);
            //Assert.IsNull(entry.AspectRatios);
            //Assert.IsNull(entry.Cameras);
            //Assert.IsNull(entry.Laboratories);
            //Assert.IsNull(entry.FilmLengths);
            //Assert.IsNull(entry.NegativeFormats);
            //Assert.IsNull(entry.CinematographicProcesses);
            //Assert.IsNull(entry.PrintedFilmFormats);

            //Assert.IsNull(entry.Creators);
            //Assert.IsNull(entry.Directors);
            //Assert.IsNull(entry.Writers);
            //Assert.IsNull(entry.Cast);
            //Assert.IsNull(entry.Producers);
            //Assert.IsNull(entry.Music);
            //Assert.IsNull(entry.Cinematography);
            //Assert.IsNull(entry.FilmEditing);
            //Assert.IsNull(entry.Casting);
            //Assert.IsNull(entry.ProductionDesign);
            //Assert.IsNull(entry.ArtDirection);
            //Assert.IsNull(entry.SetDecoration);
            //Assert.IsNull(entry.CostumeDesign);
            //Assert.IsNull(entry.MakeupDepartment);
            //Assert.IsNull(entry.ProductionManagement);
            //Assert.IsNull(entry.AssistantDirectors);
            //Assert.IsNull(entry.ArtDepartment);
            //Assert.IsNull(entry.SoundDepartment);
            //Assert.IsNull(entry.SpecialEffects);
            //Assert.IsNull(entry.VisualEffects);
            //Assert.IsNull(entry.Stunts);
            //Assert.IsNull(entry.ElectricalDepartment);
            //Assert.IsNull(entry.AnimationDepartment);
            //Assert.IsNull(entry.CastingDepartment);
            //Assert.IsNull(entry.CostumeDepartment);
            //Assert.IsNull(entry.EditorialDepartment);
            //Assert.IsNull(entry.LocationManagement);
            //Assert.IsNull(entry.MusicDepartment);
            //Assert.IsNull(entry.ContinuityDepartment);
            //Assert.IsNull(entry.TransportationDepartment);
            //Assert.IsNull(entry.OtherCrew);

            //Assert.IsNull(entry.ProductionCompanies);
            //Assert.IsNull(entry.Distributors);
            //Assert.IsNull(entry.SpecialEffectsCompanies);
            //Assert.IsNull(entry.OtherCompanies);

            //Assert.IsNull(entry.FilmingLocations);
            //Assert.IsNull(entry.FilmingDates);
            //Assert.IsNull(entry.ProductionDates);

            //Assert.IsNull(entry.Posters);
            //Assert.IsNull(entry.Covers);
            //Assert.IsNull(entry.Images);

            //Assert.IsNull(entry.Descriptions);
            //Assert.IsNull(entry.Reviews);

            //Assert.IsNull(entry.Awards);
            //Assert.IsNull(entry.Weblinks);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SeriesTest_withReaderNull(string id)
        {
            // Arrange, Act, Assert
            Series entry = new Series(null, id);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SeriesTest_withIDNull()
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            Series entry = new Series(reader, null);
        }

        [TestMethod()]
        public void RetrieveTest_withValidID_BasicInfoOnly()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Series entry = new Series(reader, VALID_ID);

            // Act
            int count = entry.Retrieve(true);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual(VALID_ID, entry.ID);
            Assert.AreEqual("Series OriginalTitle X", entry.OriginalTitle);
            Assert.AreEqual("Series EnglishTitle X", entry.EnglishTitle);
            Assert.AreEqual("Series GermanTitle X", entry.GermanTitle);
            Assert.AreEqual("_xxx", entry.Type.ID);
            Assert.AreEqual("Series ReleaseDateFirstEpisode X", entry.ReleaseDateFirstEpisode);
            Assert.AreEqual("Series ReleaseDateLastEpisode X", entry.ReleaseDateLastEpisode);
            Assert.AreEqual("Series NoOfSeasons X", entry.NoOfSeasons);
            Assert.AreEqual("Series NoOfEpisodes X", entry.NoOfEpisodes);
            Assert.AreEqual("Series Budget X", entry.Budget);
            Assert.AreEqual("Series WorldwideGross X", entry.WorldwideGross);
            Assert.AreEqual("Series WorldwideGrossDate X", entry.WorldwideGrossDate);
            Assert.AreEqual("_xxx", entry.CastStatus.ID);
            Assert.AreEqual("_xxx", entry.CrewStatus.ID);
            Assert.AreEqual("_xxx", entry.Connection.ID);
            Assert.AreEqual("Series Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Series LastUpdated X", entry.LastUpdated);

            Assert.IsNull(entry.Genres);
            Assert.IsNull(entry.Certifications);
            Assert.IsNull(entry.Countries);
            Assert.IsNull(entry.Languages);
            Assert.IsNull(entry.Runtimes);
            Assert.IsNull(entry.SoundMixes);
            Assert.IsNull(entry.Colors);
            //Assert.IsNull(entry.AspectRatios);
            //Assert.IsNull(entry.Cameras);
            //Assert.IsNull(entry.Laboratories);
            //Assert.IsNull(entry.FilmLengths);
            //Assert.IsNull(entry.NegativeFormats);
            //Assert.IsNull(entry.CinematographicProcesses);
            //Assert.IsNull(entry.PrintedFilmFormats);

            //Assert.IsNull(entry.Creators);
            //Assert.IsNull(entry.Directors);
            //Assert.IsNull(entry.Writers);
            //Assert.IsNull(entry.Cast);
            //Assert.IsNull(entry.Producers);
            //Assert.IsNull(entry.Music);
            //Assert.IsNull(entry.Cinematography);
            //Assert.IsNull(entry.FilmEditing);
            //Assert.IsNull(entry.Casting);
            //Assert.IsNull(entry.ProductionDesign);
            //Assert.IsNull(entry.ArtDirection);
            //Assert.IsNull(entry.SetDecoration);
            //Assert.IsNull(entry.CostumeDesign);
            //Assert.IsNull(entry.MakeupDepartment);
            //Assert.IsNull(entry.ProductionManagement);
            //Assert.IsNull(entry.AssistantDirectors);
            //Assert.IsNull(entry.ArtDepartment);
            //Assert.IsNull(entry.SoundDepartment);
            //Assert.IsNull(entry.SpecialEffects);
            //Assert.IsNull(entry.VisualEffects);
            //Assert.IsNull(entry.Stunts);
            //Assert.IsNull(entry.ElectricalDepartment);
            //Assert.IsNull(entry.AnimationDepartment);
            //Assert.IsNull(entry.CastingDepartment);
            //Assert.IsNull(entry.CostumeDepartment);
            //Assert.IsNull(entry.EditorialDepartment);
            //Assert.IsNull(entry.LocationManagement);
            //Assert.IsNull(entry.MusicDepartment);
            //Assert.IsNull(entry.ContinuityDepartment);
            //Assert.IsNull(entry.TransportationDepartment);
            //Assert.IsNull(entry.OtherCrew);

            //Assert.IsNull(entry.ProductionCompanies);
            //Assert.IsNull(entry.Distributors);
            //Assert.IsNull(entry.SpecialEffectsCompanies);
            //Assert.IsNull(entry.OtherCompanies);

            //Assert.IsNull(entry.FilmingLocations);
            //Assert.IsNull(entry.FilmingDates);
            //Assert.IsNull(entry.ProductionDates);

            //Assert.IsNull(entry.Posters);
            //Assert.IsNull(entry.Covers);
            //Assert.IsNull(entry.Images);

            //Assert.IsNull(entry.Descriptions);
            //Assert.IsNull(entry.Reviews);

            //Assert.IsNull(entry.Awards);
            //Assert.IsNull(entry.Weblinks);
        }

        [TestMethod()]
        public void RetrieveTest_withValidID_AdditionalInfo()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Series entry = new Series(reader, VALID_ID);

            // Act
            int count = entry.Retrieve(false);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual(VALID_ID, entry.ID);
            Assert.AreEqual("Series OriginalTitle X", entry.OriginalTitle);
            Assert.AreEqual("Series EnglishTitle X", entry.EnglishTitle);
            Assert.AreEqual("Series GermanTitle X", entry.GermanTitle);
            Assert.AreEqual("_xxx", entry.Type.ID);
            Assert.AreEqual("Series ReleaseDateFirstEpisode X", entry.ReleaseDateFirstEpisode);
            Assert.AreEqual("Series ReleaseDateLastEpisode X", entry.ReleaseDateLastEpisode);
            Assert.AreEqual("Series NoOfSeasons X", entry.NoOfSeasons);
            Assert.AreEqual("Series NoOfEpisodes X", entry.NoOfEpisodes);
            Assert.AreEqual("Series Budget X", entry.Budget);
            Assert.AreEqual("Series WorldwideGross X", entry.WorldwideGross);
            Assert.AreEqual("Series WorldwideGrossDate X", entry.WorldwideGrossDate);
            Assert.AreEqual("_xxx", entry.CastStatus.ID);
            Assert.AreEqual("_xxx", entry.CrewStatus.ID);
            Assert.AreEqual("_xxx", entry.Connection.ID);
            Assert.AreEqual("Series Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Series LastUpdated X", entry.LastUpdated);

            Assert.AreEqual(3, entry.Genres.Count);
            Assert.AreEqual("_xx1", entry.Genres[0].ID);
            Assert.AreEqual("_xx2", entry.Genres[1].ID);
            Assert.AreEqual("_xx3", entry.Genres[2].ID);

            Assert.AreEqual(3, entry.Certifications.Count);
            Assert.AreEqual("_xx1", entry.Certifications[0].ID);
            Assert.AreEqual("_xx2", entry.Certifications[1].ID);
            Assert.AreEqual("_xx3", entry.Certifications[2].ID);

            Assert.AreEqual(3, entry.Countries.Count);
            Assert.AreEqual("_xx1", entry.Countries[0].ID);
            Assert.AreEqual("_xx2", entry.Countries[1].ID);
            Assert.AreEqual("_xx3", entry.Countries[2].ID);

            Assert.AreEqual(3, entry.Languages.Count);
            Assert.AreEqual("_xx1", entry.Languages[0].ID);
            Assert.AreEqual("_xx2", entry.Languages[1].ID);
            Assert.AreEqual("_xx3", entry.Languages[2].ID);

            Assert.AreEqual(3, entry.Runtimes.Count);
            Assert.AreEqual("_xx1", entry.Runtimes[0].ID);
            Assert.AreEqual("_xx2", entry.Runtimes[1].ID);
            Assert.AreEqual("_xx3", entry.Runtimes[2].ID);

            Assert.AreEqual(3, entry.SoundMixes.Count);
            Assert.AreEqual("_xx1", entry.SoundMixes[0].ID);
            Assert.AreEqual("_xx2", entry.SoundMixes[1].ID);
            Assert.AreEqual("_xx3", entry.SoundMixes[2].ID);

            Assert.AreEqual(3, entry.Colors.Count);
            Assert.AreEqual("_xx1", entry.Colors[0].ID);
            Assert.AreEqual("_xx2", entry.Colors[1].ID);
            Assert.AreEqual("_xx3", entry.Colors[2].ID);

            //Assert.AreEqual(3, entry.AspectRatios.Count);
            //Assert.AreEqual("_xx1", entry.AspectRatios[0].ID);
            //Assert.AreEqual("_xx2", entry.AspectRatios[1].ID);
            //Assert.AreEqual("_xx3", entry.AspectRatios[2].ID);

            //Assert.AreEqual(3, entry.Cameras.Count);
            //Assert.AreEqual("_xx1", entry.Cameras[0].ID);
            //Assert.AreEqual("_xx2", entry.Cameras[1].ID);
            //Assert.AreEqual("_xx3", entry.Cameras[2].ID);

            //Assert.AreEqual(3, entry.Laboratories.Count);
            //Assert.AreEqual("_xx1", entry.Laboratories[0].ID);
            //Assert.AreEqual("_xx2", entry.Laboratories[1].ID);
            //Assert.AreEqual("_xx3", entry.Laboratories[2].ID);

            //Assert.AreEqual(3, entry.FilmLengths.Count);
            //Assert.AreEqual("_xx1", entry.FilmLengths[0].ID);
            //Assert.AreEqual("_xx2", entry.FilmLengths[1].ID);
            //Assert.AreEqual("_xx3", entry.FilmLengths[2].ID);

            //Assert.AreEqual(3, entry.NegativeFormats.Count);
            //Assert.AreEqual("_xx1", entry.NegativeFormats[0].ID);
            //Assert.AreEqual("_xx2", entry.NegativeFormats[1].ID);
            //Assert.AreEqual("_xx3", entry.NegativeFormats[2].ID);

            //Assert.AreEqual(3, entry.CinematographicProcesses.Count);
            //Assert.AreEqual("_xx1", entry.CinematographicProcesses[0].ID);
            //Assert.AreEqual("_xx2", entry.CinematographicProcesses[1].ID);
            //Assert.AreEqual("_xx3", entry.CinematographicProcesses[2].ID);

            //Assert.AreEqual(3, entry.PrintedFilmFormats.Count);
            //Assert.AreEqual("_xx1", entry.PrintedFilmFormats[0].ID);
            //Assert.AreEqual("_xx2", entry.PrintedFilmFormats[1].ID);
            //Assert.AreEqual("_xx3", entry.PrintedFilmFormats[2].ID);

            //Assert.AreEqual(3, entry.Creators.Count);
            //Assert.AreEqual("_xx1", entry.Creators[0].ID);
            //Assert.AreEqual("_xx2", entry.Creators[1].ID);
            //Assert.AreEqual("_xx3", entry.Creators[2].ID);

            //Assert.AreEqual(3, entry.Directors.Count);
            //Assert.AreEqual("_xx1", entry.Directors[0].ID);
            //Assert.AreEqual("_xx2", entry.Directors[1].ID);
            //Assert.AreEqual("_xx3", entry.Directors[2].ID);

            //Assert.AreEqual(3, entry.Writers.Count);
            //Assert.AreEqual("_xx1", entry.Writers[0].ID);
            //Assert.AreEqual("_xx2", entry.Writers[1].ID);
            //Assert.AreEqual("_xx3", entry.Writers[2].ID);

            //Assert.AreEqual(3, entry.Cast.Count);
            //Assert.AreEqual("_xx1", entry.Cast[0].ID);
            //Assert.AreEqual("_xx2", entry.Cast[1].ID);
            //Assert.AreEqual("_xx3", entry.Cast[2].ID);

            //Assert.AreEqual(3, entry.Producers.Count);
            //Assert.AreEqual("_xx1", entry.Producers[0].ID);
            //Assert.AreEqual("_xx2", entry.Producers[1].ID);
            //Assert.AreEqual("_xx3", entry.Producers[2].ID);

            //Assert.AreEqual(3, entry.Music.Count);
            //Assert.AreEqual("_xx1", entry.Music[0].ID);
            //Assert.AreEqual("_xx2", entry.Music[1].ID);
            //Assert.AreEqual("_xx3", entry.Music[2].ID);

            //Assert.AreEqual(3, entry.Cinematography.Count);
            //Assert.AreEqual("_xx1", entry.Cinematography[0].ID);
            //Assert.AreEqual("_xx2", entry.Cinematography[1].ID);
            //Assert.AreEqual("_xx3", entry.Cinematography[2].ID);

            //Assert.AreEqual(3, entry.FilmEditing.Count);
            //Assert.AreEqual("_xx1", entry.FilmEditing[0].ID);
            //Assert.AreEqual("_xx2", entry.FilmEditing[1].ID);
            //Assert.AreEqual("_xx3", entry.FilmEditing[2].ID);

            //Assert.AreEqual(3, entry.Casting.Count);
            //Assert.AreEqual("_xx1", entry.Casting[0].ID);
            //Assert.AreEqual("_xx2", entry.Casting[1].ID);
            //Assert.AreEqual("_xx3", entry.Casting[2].ID);

            //Assert.AreEqual(3, entry.ProductionDesign.Count);
            //Assert.AreEqual("_xx1", entry.ProductionDesign[0].ID);
            //Assert.AreEqual("_xx2", entry.ProductionDesign[1].ID);
            //Assert.AreEqual("_xx3", entry.ProductionDesign[2].ID);

            //Assert.AreEqual(3, entry.ArtDirection.Count);
            //Assert.AreEqual("_xx1", entry.ArtDirection[0].ID);
            //Assert.AreEqual("_xx2", entry.ArtDirection[1].ID);
            //Assert.AreEqual("_xx3", entry.ArtDirection[2].ID);

            //Assert.AreEqual(3, entry.SetDecoration.Count);
            //Assert.AreEqual("_xx1", entry.SetDecoration[0].ID);
            //Assert.AreEqual("_xx2", entry.SetDecoration[1].ID);
            //Assert.AreEqual("_xx3", entry.SetDecoration[2].ID);

            //Assert.AreEqual(3, entry.CostumeDesign.Count);
            //Assert.AreEqual("_xx1", entry.CostumeDesign[0].ID);
            //Assert.AreEqual("_xx2", entry.CostumeDesign[1].ID);
            //Assert.AreEqual("_xx3", entry.CostumeDesign[2].ID);

            //Assert.AreEqual(3, entry.MakeupDepartment.Count);
            //Assert.AreEqual("_xx1", entry.MakeupDepartment[0].ID);
            //Assert.AreEqual("_xx2", entry.MakeupDepartment[1].ID);
            //Assert.AreEqual("_xx3", entry.MakeupDepartment[2].ID);

            //Assert.AreEqual(3, entry.ProductionManagement.Count);
            //Assert.AreEqual("_xx1", entry.ProductionManagement[0].ID);
            //Assert.AreEqual("_xx2", entry.ProductionManagement[1].ID);
            //Assert.AreEqual("_xx3", entry.ProductionManagement[2].ID);

            //Assert.AreEqual(3, entry.AssistantDirectors.Count);
            //Assert.AreEqual("_xx1", entry.AssistantDirectors[0].ID);
            //Assert.AreEqual("_xx2", entry.AssistantDirectors[1].ID);
            //Assert.AreEqual("_xx3", entry.AssistantDirectors[2].ID);

            //Assert.AreEqual(3, entry.ArtDepartment.Count);
            //Assert.AreEqual("_xx1", entry.ArtDepartment[0].ID);
            //Assert.AreEqual("_xx2", entry.ArtDepartment[1].ID);
            //Assert.AreEqual("_xx3", entry.ArtDepartment[2].ID);

            //Assert.AreEqual(3, entry.SoundDepartment.Count);
            //Assert.AreEqual("_xx1", entry.SoundDepartment[0].ID);
            //Assert.AreEqual("_xx2", entry.SoundDepartment[1].ID);
            //Assert.AreEqual("_xx3", entry.SoundDepartment[2].ID);

            //Assert.AreEqual(3, entry.SpecialEffects.Count);
            //Assert.AreEqual("_xx1", entry.SpecialEffects[0].ID);
            //Assert.AreEqual("_xx2", entry.SpecialEffects[1].ID);
            //Assert.AreEqual("_xx3", entry.SpecialEffects[2].ID);

            //Assert.AreEqual(3, entry.VisualEffects.Count);
            //Assert.AreEqual("_xx1", entry.VisualEffects[0].ID);
            //Assert.AreEqual("_xx2", entry.VisualEffects[1].ID);
            //Assert.AreEqual("_xx3", entry.VisualEffects[2].ID);

            //Assert.AreEqual(3, entry.Stunts.Count);
            //Assert.AreEqual("_xx1", entry.Stunts[0].ID);
            //Assert.AreEqual("_xx2", entry.Stunts[1].ID);
            //Assert.AreEqual("_xx3", entry.Stunts[2].ID);

            //Assert.AreEqual(3, entry.ElectricalDepartment.Count);
            //Assert.AreEqual("_xx1", entry.ElectricalDepartment[0].ID);
            //Assert.AreEqual("_xx2", entry.ElectricalDepartment[1].ID);
            //Assert.AreEqual("_xx3", entry.ElectricalDepartment[2].ID);

            //Assert.AreEqual(3, entry.AnimationDepartment.Count);
            //Assert.AreEqual("_xx1", entry.AnimationDepartment[0].ID);
            //Assert.AreEqual("_xx2", entry.AnimationDepartment[1].ID);
            //Assert.AreEqual("_xx3", entry.AnimationDepartment[2].ID);

            //Assert.AreEqual(3, entry.CastingDepartment.Count);
            //Assert.AreEqual("_xx1", entry.CastingDepartment[0].ID);
            //Assert.AreEqual("_xx2", entry.CastingDepartment[1].ID);
            //Assert.AreEqual("_xx3", entry.CastingDepartment[2].ID);

            //Assert.AreEqual(3, entry.CostumeDepartment.Count);
            //Assert.AreEqual("_xx1", entry.CostumeDepartment[0].ID);
            //Assert.AreEqual("_xx2", entry.CostumeDepartment[1].ID);
            //Assert.AreEqual("_xx3", entry.CostumeDepartment[2].ID);

            //Assert.AreEqual(3, entry.EditorialDepartment.Count);
            //Assert.AreEqual("_xx1", entry.EditorialDepartment[0].ID);
            //Assert.AreEqual("_xx2", entry.EditorialDepartment[1].ID);
            //Assert.AreEqual("_xx3", entry.EditorialDepartment[2].ID);

            //Assert.AreEqual(3, entry.LocationManagement.Count);
            //Assert.AreEqual("_xx1", entry.LocationManagement[0].ID);
            //Assert.AreEqual("_xx2", entry.LocationManagement[1].ID);
            //Assert.AreEqual("_xx3", entry.LocationManagement[2].ID);

            //Assert.AreEqual(3, entry.MusicDepartment.Count);
            //Assert.AreEqual("_xx1", entry.MusicDepartment[0].ID);
            //Assert.AreEqual("_xx2", entry.MusicDepartment[1].ID);
            //Assert.AreEqual("_xx3", entry.MusicDepartment[2].ID);

            //Assert.AreEqual(3, entry.ContinuityDepartment.Count);
            //Assert.AreEqual("_xx1", entry.ContinuityDepartment[0].ID);
            //Assert.AreEqual("_xx2", entry.ContinuityDepartment[1].ID);
            //Assert.AreEqual("_xx3", entry.ContinuityDepartment[2].ID);

            //Assert.AreEqual(3, entry.TransportationDepartment.Count);
            //Assert.AreEqual("_xx1", entry.TransportationDepartment[0].ID);
            //Assert.AreEqual("_xx2", entry.TransportationDepartment[1].ID);
            //Assert.AreEqual("_xx3", entry.TransportationDepartment[2].ID);

            //Assert.AreEqual(3, entry.OtherCrew.Count);
            //Assert.AreEqual("_xx1", entry.OtherCrew[0].ID);
            //Assert.AreEqual("_xx2", entry.OtherCrew[1].ID);
            //Assert.AreEqual("_xx3", entry.OtherCrew[2].ID);

            //Assert.AreEqual(3, entry.ProductionCompanies.Count);
            //Assert.AreEqual("_xx1", entry.ProductionCompanies[0].ID);
            //Assert.AreEqual("_xx2", entry.ProductionCompanies[1].ID);
            //Assert.AreEqual("_xx3", entry.ProductionCompanies[2].ID);

            //Assert.AreEqual(3, entry.Distributors.Count);
            //Assert.AreEqual("_xx1", entry.Distributors[0].ID);
            //Assert.AreEqual("_xx2", entry.Distributors[1].ID);
            //Assert.AreEqual("_xx3", entry.Distributors[2].ID);

            //Assert.AreEqual(3, entry.SpecialEffectsCompanies.Count);
            //Assert.AreEqual("_xx1", entry.SpecialEffectsCompanies[0].ID);
            //Assert.AreEqual("_xx2", entry.SpecialEffectsCompanies[1].ID);
            //Assert.AreEqual("_xx3", entry.SpecialEffectsCompanies[2].ID);

            //Assert.AreEqual(3, entry.OtherCompanies.Count);
            //Assert.AreEqual("_xx1", entry.OtherCompanies[0].ID);
            //Assert.AreEqual("_xx2", entry.OtherCompanies[1].ID);
            //Assert.AreEqual("_xx3", entry.OtherCompanies[2].ID);

            //Assert.AreEqual(3, entry.FilmingLocations.Count);
            //Assert.AreEqual("_xx1", entry.FilmingLocations[0].ID);
            //Assert.AreEqual("_xx2", entry.FilmingLocations[1].ID);
            //Assert.AreEqual("_xx3", entry.FilmingLocations[2].ID);

            //Assert.AreEqual(3, entry.FilmingDates.Count);
            //Assert.AreEqual("_xx1", entry.FilmingDates[0].ID);
            //Assert.AreEqual("_xx2", entry.FilmingDates[1].ID);
            //Assert.AreEqual("_xx3", entry.FilmingDates[2].ID);

            //Assert.AreEqual(3, entry.ProductionDates.Count);
            //Assert.AreEqual("_xx1", entry.ProductionDates[0].ID);
            //Assert.AreEqual("_xx2", entry.ProductionDates[1].ID);
            //Assert.AreEqual("_xx3", entry.ProductionDates[2].ID);

            //Assert.AreEqual(3, entry.Posters.Count);
            //Assert.AreEqual("_xx1", entry.Posters[0].ID);
            //Assert.AreEqual("_xx2", entry.Posters[1].ID);
            //Assert.AreEqual("_xx3", entry.Posters[2].ID);

            //Assert.AreEqual(3, entry.Covers.Count);
            //Assert.AreEqual("_xx1", entry.Covers[0].ID);
            //Assert.AreEqual("_xx2", entry.Covers[1].ID);
            //Assert.AreEqual("_xx3", entry.Covers[2].ID);

            //Assert.AreEqual(3, entry.Images.Count);
            //Assert.AreEqual("_xx1", entry.Images[0].ID);
            //Assert.AreEqual("_xx2", entry.Images[1].ID);
            //Assert.AreEqual("_xx3", entry.Images[2].ID);

            //Assert.AreEqual(3, entry.Descriptions.Count);
            //Assert.AreEqual("_xx1", entry.Descriptions[0].ID);
            //Assert.AreEqual("_xx2", entry.Descriptions[1].ID);
            //Assert.AreEqual("_xx3", entry.Descriptions[2].ID);

            //Assert.AreEqual(3, entry.Reviews.Count);
            //Assert.AreEqual("_xx1", entry.Reviews[0].ID);
            //Assert.AreEqual("_xx2", entry.Reviews[1].ID);
            //Assert.AreEqual("_xx3", entry.Reviews[2].ID);

            //Assert.AreEqual(3, entry.Awards.Count);
            //Assert.AreEqual("_xx1", entry.Awards[0].ID);
            //Assert.AreEqual("_xx2", entry.Awards[1].ID);
            //Assert.AreEqual("_xx3", entry.Awards[2].ID);

            //Assert.AreEqual(3, entry.Weblinks.Count);
            //Assert.AreEqual("_xx1", entry.Weblinks[0].ID);
            //Assert.AreEqual("_xx2", entry.Weblinks[1].ID);
            //Assert.AreEqual("_xx3", entry.Weblinks[2].ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID(bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Series entry = new Series(reader, INVALID_ID);

            // Act
            int count = entry.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, entry.ID);
            Assert.IsNull(entry.OriginalTitle);
            Assert.IsNull(entry.EnglishTitle);
            Assert.IsNull(entry.GermanTitle);
            Assert.IsNull(entry.Type);
            Assert.IsNull(entry.ReleaseDateFirstEpisode);
            Assert.IsNull(entry.ReleaseDateLastEpisode);
            Assert.IsNull(entry.NoOfSeasons);
            Assert.IsNull(entry.NoOfEpisodes);
            Assert.IsNull(entry.Budget);
            Assert.IsNull(entry.WorldwideGross);
            Assert.IsNull(entry.WorldwideGrossDate);
            Assert.IsNull(entry.CastStatus);
            Assert.IsNull(entry.CrewStatus);
            Assert.IsNull(entry.Connection);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);

            Assert.IsNull(entry.Genres);
            Assert.IsNull(entry.Certifications);
            Assert.IsNull(entry.Countries);
            Assert.IsNull(entry.Languages);
            Assert.IsNull(entry.Runtimes);
            Assert.IsNull(entry.SoundMixes);
            Assert.IsNull(entry.Colors);
            //Assert.IsNull(entry.AspectRatios);
            //Assert.IsNull(entry.Cameras);
            //Assert.IsNull(entry.Laboratories);
            //Assert.IsNull(entry.FilmLengths);
            //Assert.IsNull(entry.NegativeFormats);
            //Assert.IsNull(entry.CinematographicProcesses);
            //Assert.IsNull(entry.PrintedFilmFormats);

            //Assert.IsNull(entry.Creators);
            //Assert.IsNull(entry.Directors);
            //Assert.IsNull(entry.Writers);
            //Assert.IsNull(entry.Cast);
            //Assert.IsNull(entry.Producers);
            //Assert.IsNull(entry.Music);
            //Assert.IsNull(entry.Cinematography);
            //Assert.IsNull(entry.FilmEditing);
            //Assert.IsNull(entry.Casting);
            //Assert.IsNull(entry.ProductionDesign);
            //Assert.IsNull(entry.ArtDirection);
            //Assert.IsNull(entry.SetDecoration);
            //Assert.IsNull(entry.CostumeDesign);
            //Assert.IsNull(entry.MakeupDepartment);
            //Assert.IsNull(entry.ProductionManagement);
            //Assert.IsNull(entry.AssistantDirectors);
            //Assert.IsNull(entry.ArtDepartment);
            //Assert.IsNull(entry.SoundDepartment);
            //Assert.IsNull(entry.SpecialEffects);
            //Assert.IsNull(entry.VisualEffects);
            //Assert.IsNull(entry.Stunts);
            //Assert.IsNull(entry.ElectricalDepartment);
            //Assert.IsNull(entry.AnimationDepartment);
            //Assert.IsNull(entry.CastingDepartment);
            //Assert.IsNull(entry.CostumeDepartment);
            //Assert.IsNull(entry.EditorialDepartment);
            //Assert.IsNull(entry.LocationManagement);
            //Assert.IsNull(entry.MusicDepartment);
            //Assert.IsNull(entry.ContinuityDepartment);
            //Assert.IsNull(entry.TransportationDepartment);
            //Assert.IsNull(entry.OtherCrew);

            //Assert.IsNull(entry.ProductionCompanies);
            //Assert.IsNull(entry.Distributors);
            //Assert.IsNull(entry.SpecialEffectsCompanies);
            //Assert.IsNull(entry.OtherCompanies);

            //Assert.IsNull(entry.FilmingLocations);
            //Assert.IsNull(entry.FilmingDates);
            //Assert.IsNull(entry.ProductionDates);

            //Assert.IsNull(entry.Posters);
            //Assert.IsNull(entry.Covers);
            //Assert.IsNull(entry.Images);

            //Assert.IsNull(entry.Descriptions);
            //Assert.IsNull(entry.Reviews);

            //Assert.IsNull(entry.Awards);
            //Assert.IsNull(entry.Weblinks);
        }


        [TestMethod()]
        public void RetrieveListTest_withValidData()
        {
            // Arrange
            DBReader reader = new SQLiteReader();

            // Act
            List<Article> list = Series.RetrieveList(reader, "_xxx");

            // Assert
            Assert.AreEqual(1, list.Count);

            Assert.AreEqual("_xxx", list[0].ID);
        }
    }
}
