﻿// EntertainmentDB.dll: Provides access to the EntertainmentInfothek.db
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


using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntertainmentDB.Data;
using System;
using System.Collections.Generic;
using System.Text;
using EntertainmentDB.DBAccess.Read;

namespace EntertainmentDB.Data.Tests
{
    [TestClass()]
    public class MovieTests
    {
        [TestMethod()]
        public void MovieTest()
        {
            // Arrange
            Movie entry = new Movie();

            // Act
            // Assert
            Assert.IsNotNull(entry);
            Assert.IsNotNull(entry.Reader);

            Assert.AreEqual("", entry.ID);
            Assert.IsNull(entry.OriginalTitle);
            Assert.IsNull(entry.EnglishTitle);
            Assert.IsNull(entry.GermanTitle);
            Assert.IsNull(entry.Type);
            Assert.IsNull(entry.ReleaseDate);
            Assert.IsNull(entry.Budget);
            Assert.IsNull(entry.WorldwideGross);
            Assert.IsNull(entry.WorldwideGrossDate);
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
            Assert.IsNull(entry.AspectRatios);
            Assert.IsNull(entry.Cameras);
            Assert.IsNull(entry.Laboratories);
            Assert.IsNull(entry.FilmLengths);
            Assert.IsNull(entry.NegativeFormats);
            Assert.IsNull(entry.CinematographicProcesses);
            Assert.IsNull(entry.PrintedFilmFormats);

            Assert.IsNull(entry.Directors);
            Assert.IsNull(entry.Writers);
            Assert.IsNull(entry.Cast);
            Assert.IsNull(entry.Producers);
            Assert.IsNull(entry.Music);
            Assert.IsNull(entry.Cinematography);
            Assert.IsNull(entry.FilmEditing);
            Assert.IsNull(entry.Casting);
            Assert.IsNull(entry.ProductionDesign);
            Assert.IsNull(entry.ArtDirection);
            Assert.IsNull(entry.SetDecoration);
            Assert.IsNull(entry.CostumeDesign);
            Assert.IsNull(entry.MakeupDepartment);
            Assert.IsNull(entry.ProductionManagement);
            Assert.IsNull(entry.AssistantDirectors);
            Assert.IsNull(entry.ArtDepartment);
            Assert.IsNull(entry.SoundDepartment);
            Assert.IsNull(entry.SpecialEffects);
            Assert.IsNull(entry.VisualEffects);
            Assert.IsNull(entry.Stunts);
            Assert.IsNull(entry.ElectricalDepartment);
            Assert.IsNull(entry.AnimationDepartment);
            Assert.IsNull(entry.CastingDepartment);
            Assert.IsNull(entry.CostumeDepartment);
            Assert.IsNull(entry.EditorialDepartment);
            Assert.IsNull(entry.LocationManagement);
            Assert.IsNull(entry.MusicDepartment);
            Assert.IsNull(entry.ContinuityDepartment);
        }

        [TestMethod()]
        public void MovieTest_withID()
        {
            // Arrange
            Movie entry = new Movie("_xxx");

            // Act
            // Assert
            Assert.IsNotNull(entry);
            Assert.IsNotNull(entry.Reader);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.IsNull(entry.OriginalTitle);
            Assert.IsNull(entry.EnglishTitle);
            Assert.IsNull(entry.GermanTitle);
            Assert.IsNull(entry.Type);
            Assert.IsNull(entry.ReleaseDate);
            Assert.IsNull(entry.Budget);
            Assert.IsNull(entry.WorldwideGross);
            Assert.IsNull(entry.WorldwideGrossDate);
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
            Assert.IsNull(entry.AspectRatios);
            Assert.IsNull(entry.Cameras);
            Assert.IsNull(entry.Laboratories);
            Assert.IsNull(entry.FilmLengths);
            Assert.IsNull(entry.NegativeFormats);
            Assert.IsNull(entry.CinematographicProcesses);
            Assert.IsNull(entry.PrintedFilmFormats);

            Assert.IsNull(entry.Directors);
            Assert.IsNull(entry.Writers);
            Assert.IsNull(entry.Cast);
            Assert.IsNull(entry.Producers);
            Assert.IsNull(entry.Music);
            Assert.IsNull(entry.Cinematography);
            Assert.IsNull(entry.FilmEditing);
            Assert.IsNull(entry.Casting);
            Assert.IsNull(entry.ProductionDesign);
            Assert.IsNull(entry.ArtDirection);
            Assert.IsNull(entry.SetDecoration);
            Assert.IsNull(entry.CostumeDesign);
            Assert.IsNull(entry.MakeupDepartment);
            Assert.IsNull(entry.ProductionManagement);
            Assert.IsNull(entry.AssistantDirectors);
            Assert.IsNull(entry.ArtDepartment);
            Assert.IsNull(entry.SoundDepartment);
            Assert.IsNull(entry.SpecialEffects);
            Assert.IsNull(entry.VisualEffects);
            Assert.IsNull(entry.Stunts);
            Assert.IsNull(entry.ElectricalDepartment);
            Assert.IsNull(entry.AnimationDepartment);
            Assert.IsNull(entry.CastingDepartment);
            Assert.IsNull(entry.CostumeDepartment);
            Assert.IsNull(entry.EditorialDepartment);
            Assert.IsNull(entry.LocationManagement);
            Assert.IsNull(entry.MusicDepartment);
            Assert.IsNull(entry.ContinuityDepartment);
        }

        [TestMethod()]
        public void RetrieveBasicInformationTest_withValidID()
        {
            // Arrange
            Movie entry = new Movie("_xxx");

            // Act
            int count = entry.RetrieveBasicInformation();

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("Movie Original Title X", entry.OriginalTitle);
            Assert.AreEqual("Movie English Title X", entry.EnglishTitle);
            Assert.AreEqual("Movie German Title X", entry.GermanTitle);
            Assert.AreEqual("_xxx", entry.Type.ID);
            Assert.AreEqual("Movie Release Date X", entry.ReleaseDate);
            Assert.AreEqual("Movie Budget X", entry.Budget);
            Assert.AreEqual("Movie Worldwide Gross X", entry.WorldwideGross);
            Assert.AreEqual("Movie Worldwide Gross Date X", entry.WorldwideGrossDate);
            Assert.AreEqual("_xxx", entry.Connection.ID);
            Assert.AreEqual("Movie Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Movie Last Updated X", entry.LastUpdated);

            Assert.IsNull(entry.Genres);
            Assert.IsNull(entry.Certifications);
            Assert.IsNull(entry.Countries);
            Assert.IsNull(entry.Languages);
            Assert.IsNull(entry.Runtimes);
            Assert.IsNull(entry.SoundMixes);
            Assert.IsNull(entry.Colors);
            Assert.IsNull(entry.AspectRatios);
            Assert.IsNull(entry.Cameras);
            Assert.IsNull(entry.Laboratories);
            Assert.IsNull(entry.FilmLengths);
            Assert.IsNull(entry.NegativeFormats);
            Assert.IsNull(entry.CinematographicProcesses);
            Assert.IsNull(entry.PrintedFilmFormats);

            Assert.IsNull(entry.Directors);
            Assert.IsNull(entry.Writers);
            Assert.IsNull(entry.Cast);
            Assert.IsNull(entry.Producers);
            Assert.IsNull(entry.Music);
            Assert.IsNull(entry.Cinematography);
            Assert.IsNull(entry.FilmEditing);
            Assert.IsNull(entry.Casting);
            Assert.IsNull(entry.ProductionDesign);
            Assert.IsNull(entry.ArtDirection);
            Assert.IsNull(entry.SetDecoration);
            Assert.IsNull(entry.CostumeDesign);
            Assert.IsNull(entry.MakeupDepartment);
            Assert.IsNull(entry.ProductionManagement);
            Assert.IsNull(entry.AssistantDirectors);
            Assert.IsNull(entry.ArtDepartment);
            Assert.IsNull(entry.SoundDepartment);
            Assert.IsNull(entry.SpecialEffects);
            Assert.IsNull(entry.VisualEffects);
            Assert.IsNull(entry.Stunts);
            Assert.IsNull(entry.ElectricalDepartment);
            Assert.IsNull(entry.AnimationDepartment);
            Assert.IsNull(entry.CastingDepartment);
            Assert.IsNull(entry.CostumeDepartment);
            Assert.IsNull(entry.EditorialDepartment);
            Assert.IsNull(entry.LocationManagement);
            Assert.IsNull(entry.MusicDepartment);
            Assert.IsNull(entry.ContinuityDepartment);
        }

        [TestMethod()]
        public void RetrieveBasicInformationTest_withInvalidID()
        {
            // Arrange
            Movie entry = new Movie("_aaa");

            // Act
            int count = entry.RetrieveBasicInformation();

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aaa", entry.ID);
            Assert.IsNull(entry.OriginalTitle);
            Assert.IsNull(entry.EnglishTitle);
            Assert.IsNull(entry.GermanTitle);
            Assert.IsNull(entry.Type);
            Assert.IsNull(entry.ReleaseDate);
            Assert.IsNull(entry.Budget);
            Assert.IsNull(entry.WorldwideGross);
            Assert.IsNull(entry.WorldwideGrossDate);
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
            Assert.IsNull(entry.AspectRatios);
            Assert.IsNull(entry.Cameras);
            Assert.IsNull(entry.Laboratories);
            Assert.IsNull(entry.FilmLengths);
            Assert.IsNull(entry.NegativeFormats);
            Assert.IsNull(entry.CinematographicProcesses);
            Assert.IsNull(entry.PrintedFilmFormats);

            Assert.IsNull(entry.Directors);
            Assert.IsNull(entry.Writers);
            Assert.IsNull(entry.Cast);
            Assert.IsNull(entry.Producers);
            Assert.IsNull(entry.Music);
            Assert.IsNull(entry.Cinematography);
            Assert.IsNull(entry.FilmEditing);
            Assert.IsNull(entry.Casting);
            Assert.IsNull(entry.ProductionDesign);
            Assert.IsNull(entry.ArtDirection);
            Assert.IsNull(entry.SetDecoration);
            Assert.IsNull(entry.CostumeDesign);
            Assert.IsNull(entry.MakeupDepartment);
            Assert.IsNull(entry.ProductionManagement);
            Assert.IsNull(entry.AssistantDirectors);
            Assert.IsNull(entry.ArtDepartment);
            Assert.IsNull(entry.SoundDepartment);
            Assert.IsNull(entry.SpecialEffects);
            Assert.IsNull(entry.VisualEffects);
            Assert.IsNull(entry.Stunts);
            Assert.IsNull(entry.ElectricalDepartment);
            Assert.IsNull(entry.AnimationDepartment);
            Assert.IsNull(entry.CastingDepartment);
            Assert.IsNull(entry.CostumeDepartment);
            Assert.IsNull(entry.EditorialDepartment);
            Assert.IsNull(entry.LocationManagement);
            Assert.IsNull(entry.MusicDepartment);
            Assert.IsNull(entry.ContinuityDepartment);
        }

        [TestMethod()]
        public void RetrieveAdditionalInformationTest_withValidID()
        {
            // Arrange
            Movie entry = new Movie("_xxx");

            // Act
            int count = entry.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual((41 * 3 + 1), count);

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

            Assert.AreEqual(3, entry.AspectRatios.Count);
            Assert.AreEqual("_xx1", entry.AspectRatios[0].ID);
            Assert.AreEqual("_xx2", entry.AspectRatios[1].ID);
            Assert.AreEqual("_xx3", entry.AspectRatios[2].ID);

            Assert.AreEqual(3, entry.Cameras.Count);
            Assert.AreEqual("_xx1", entry.Cameras[0].ID);
            Assert.AreEqual("_xx2", entry.Cameras[1].ID);
            Assert.AreEqual("_xx3", entry.Cameras[2].ID);

            Assert.AreEqual(3, entry.Laboratories.Count);
            Assert.AreEqual("_xx1", entry.Laboratories[0].ID);
            Assert.AreEqual("_xx2", entry.Laboratories[1].ID);
            Assert.AreEqual("_xx3", entry.Laboratories[2].ID);

            // TODO: Adjust test expectations after changing database content
            Assert.AreEqual(1, entry.FilmLengths.Count);
            Assert.AreEqual("_xxx", entry.FilmLengths[0].ID);
            //Assert.AreEqual("_xx2", entry.FilmLengths[1].ID);
            //Assert.AreEqual("_xx3", entry.FilmLengths[2].ID);

            Assert.AreEqual(3, entry.NegativeFormats.Count);
            Assert.AreEqual("_xx1", entry.NegativeFormats[0].ID);
            Assert.AreEqual("_xx2", entry.NegativeFormats[1].ID);
            Assert.AreEqual("_xx3", entry.NegativeFormats[2].ID);

            Assert.AreEqual(3, entry.CinematographicProcesses.Count);
            Assert.AreEqual("_xx1", entry.CinematographicProcesses[0].ID);
            Assert.AreEqual("_xx2", entry.CinematographicProcesses[1].ID);
            Assert.AreEqual("_xx3", entry.CinematographicProcesses[2].ID);

            Assert.AreEqual(3, entry.PrintedFilmFormats.Count);
            Assert.AreEqual("_xx1", entry.PrintedFilmFormats[0].ID);
            Assert.AreEqual("_xx2", entry.PrintedFilmFormats[1].ID);
            Assert.AreEqual("_xx3", entry.PrintedFilmFormats[2].ID);

            Assert.AreEqual(3, entry.Directors.Count);
            Assert.AreEqual("_xx1", entry.Directors[0].ID);
            Assert.AreEqual("_xx2", entry.Directors[1].ID);
            Assert.AreEqual("_xx3", entry.Directors[2].ID);

            Assert.AreEqual(3, entry.Writers.Count);
            Assert.AreEqual("_xx1", entry.Writers[0].ID);
            Assert.AreEqual("_xx2", entry.Writers[1].ID);
            Assert.AreEqual("_xx3", entry.Writers[2].ID);

            Assert.AreEqual(3, entry.Cast.Count);
            Assert.AreEqual("_xx1", entry.Cast[0].ID);
            Assert.AreEqual("_xx2", entry.Cast[1].ID);
            Assert.AreEqual("_xx3", entry.Cast[2].ID);

            Assert.AreEqual(3, entry.Producers.Count);
            Assert.AreEqual("_xx1", entry.Producers[0].ID);
            Assert.AreEqual("_xx2", entry.Producers[1].ID);
            Assert.AreEqual("_xx3", entry.Producers[2].ID);

            Assert.AreEqual(3, entry.Music.Count);
            Assert.AreEqual("_xx1", entry.Music[0].ID);
            Assert.AreEqual("_xx2", entry.Music[1].ID);
            Assert.AreEqual("_xx3", entry.Music[2].ID);

            Assert.AreEqual(3, entry.Cinematography.Count);
            Assert.AreEqual("_xx1", entry.Cinematography[0].ID);
            Assert.AreEqual("_xx2", entry.Cinematography[1].ID);
            Assert.AreEqual("_xx3", entry.Cinematography[2].ID);

            Assert.AreEqual(3, entry.FilmEditing.Count);
            Assert.AreEqual("_xx1", entry.FilmEditing[0].ID);
            Assert.AreEqual("_xx2", entry.FilmEditing[1].ID);
            Assert.AreEqual("_xx3", entry.FilmEditing[2].ID);

            Assert.AreEqual(3, entry.Casting.Count);
            Assert.AreEqual("_xx1", entry.Casting[0].ID);
            Assert.AreEqual("_xx2", entry.Casting[1].ID);
            Assert.AreEqual("_xx3", entry.Casting[2].ID);

            Assert.AreEqual(3, entry.ProductionDesign.Count);
            Assert.AreEqual("_xx1", entry.ProductionDesign[0].ID);
            Assert.AreEqual("_xx2", entry.ProductionDesign[1].ID);
            Assert.AreEqual("_xx3", entry.ProductionDesign[2].ID);

            Assert.AreEqual(3, entry.ArtDirection.Count);
            Assert.AreEqual("_xx1", entry.ArtDirection[0].ID);
            Assert.AreEqual("_xx2", entry.ArtDirection[1].ID);
            Assert.AreEqual("_xx3", entry.ArtDirection[2].ID);

            Assert.AreEqual(3, entry.SetDecoration.Count);
            Assert.AreEqual("_xx1", entry.SetDecoration[0].ID);
            Assert.AreEqual("_xx2", entry.SetDecoration[1].ID);
            Assert.AreEqual("_xx3", entry.SetDecoration[2].ID);

            Assert.AreEqual(3, entry.CostumeDesign.Count);
            Assert.AreEqual("_xx1", entry.CostumeDesign[0].ID);
            Assert.AreEqual("_xx2", entry.CostumeDesign[1].ID);
            Assert.AreEqual("_xx3", entry.CostumeDesign[2].ID);

            Assert.AreEqual(3, entry.MakeupDepartment.Count);
            Assert.AreEqual("_xx1", entry.MakeupDepartment[0].ID);
            Assert.AreEqual("_xx2", entry.MakeupDepartment[1].ID);
            Assert.AreEqual("_xx3", entry.MakeupDepartment[2].ID);

            Assert.AreEqual(3, entry.ProductionManagement.Count);
            Assert.AreEqual("_xx1", entry.ProductionManagement[0].ID);
            Assert.AreEqual("_xx2", entry.ProductionManagement[1].ID);
            Assert.AreEqual("_xx3", entry.ProductionManagement[2].ID);

            Assert.AreEqual(3, entry.AssistantDirectors.Count);
            Assert.AreEqual("_xx1", entry.AssistantDirectors[0].ID);
            Assert.AreEqual("_xx2", entry.AssistantDirectors[1].ID);
            Assert.AreEqual("_xx3", entry.AssistantDirectors[2].ID);

            Assert.AreEqual(3, entry.ArtDepartment.Count);
            Assert.AreEqual("_xx1", entry.ArtDepartment[0].ID);
            Assert.AreEqual("_xx2", entry.ArtDepartment[1].ID);
            Assert.AreEqual("_xx3", entry.ArtDepartment[2].ID);

            Assert.AreEqual(3, entry.SoundDepartment.Count);
            Assert.AreEqual("_xx1", entry.SoundDepartment[0].ID);
            Assert.AreEqual("_xx2", entry.SoundDepartment[1].ID);
            Assert.AreEqual("_xx3", entry.SoundDepartment[2].ID);

            Assert.AreEqual(3, entry.SpecialEffects.Count);
            Assert.AreEqual("_xx1", entry.SpecialEffects[0].ID);
            Assert.AreEqual("_xx2", entry.SpecialEffects[1].ID);
            Assert.AreEqual("_xx3", entry.SpecialEffects[2].ID);

            Assert.AreEqual(3, entry.VisualEffects.Count);
            Assert.AreEqual("_xx1", entry.VisualEffects[0].ID);
            Assert.AreEqual("_xx2", entry.VisualEffects[1].ID);
            Assert.AreEqual("_xx3", entry.VisualEffects[2].ID);

            Assert.AreEqual(3, entry.Stunts.Count);
            Assert.AreEqual("_xx1", entry.Stunts[0].ID);
            Assert.AreEqual("_xx2", entry.Stunts[1].ID);
            Assert.AreEqual("_xx3", entry.Stunts[2].ID);

            Assert.AreEqual(3, entry.ElectricalDepartment.Count);
            Assert.AreEqual("_xx1", entry.ElectricalDepartment[0].ID);
            Assert.AreEqual("_xx2", entry.ElectricalDepartment[1].ID);
            Assert.AreEqual("_xx3", entry.ElectricalDepartment[2].ID);

            Assert.AreEqual(3, entry.AnimationDepartment.Count);
            Assert.AreEqual("_xx1", entry.AnimationDepartment[0].ID);
            Assert.AreEqual("_xx2", entry.AnimationDepartment[1].ID);
            Assert.AreEqual("_xx3", entry.AnimationDepartment[2].ID);

            Assert.AreEqual(3, entry.CastingDepartment.Count);
            Assert.AreEqual("_xx1", entry.CastingDepartment[0].ID);
            Assert.AreEqual("_xx2", entry.CastingDepartment[1].ID);
            Assert.AreEqual("_xx3", entry.CastingDepartment[2].ID);

            Assert.AreEqual(3, entry.CostumeDepartment.Count);
            Assert.AreEqual("_xx1", entry.CostumeDepartment[0].ID);
            Assert.AreEqual("_xx2", entry.CostumeDepartment[1].ID);
            Assert.AreEqual("_xx3", entry.CostumeDepartment[2].ID);

            Assert.AreEqual(3, entry.EditorialDepartment.Count);
            Assert.AreEqual("_xx1", entry.EditorialDepartment[0].ID);
            Assert.AreEqual("_xx2", entry.EditorialDepartment[1].ID);
            Assert.AreEqual("_xx3", entry.EditorialDepartment[2].ID);

            Assert.AreEqual(3, entry.LocationManagement.Count);
            Assert.AreEqual("_xx1", entry.LocationManagement[0].ID);
            Assert.AreEqual("_xx2", entry.LocationManagement[1].ID);
            Assert.AreEqual("_xx3", entry.LocationManagement[2].ID);

            Assert.AreEqual(3, entry.MusicDepartment.Count);
            Assert.AreEqual("_xx1", entry.MusicDepartment[0].ID);
            Assert.AreEqual("_xx2", entry.MusicDepartment[1].ID);
            Assert.AreEqual("_xx3", entry.MusicDepartment[2].ID);

            Assert.AreEqual(3, entry.ContinuityDepartment.Count);
            Assert.AreEqual("_xx1", entry.ContinuityDepartment[0].ID);
            Assert.AreEqual("_xx2", entry.ContinuityDepartment[1].ID);
            Assert.AreEqual("_xx3", entry.ContinuityDepartment[2].ID);
        }

        [TestMethod()]
        public void RetrieveAdditionalInformationTest_withInvalidID()
        {
            // Arrange
            Movie entry = new Movie("_aaa");

            // Act
            int count = entry.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod()]
        public void RetrieveTest_withValidID()
        {
            // Arrange
            Movie entry = new Movie("_xxx");

            // Act
            int count = entry.Retrieve();

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("Movie Original Title X", entry.OriginalTitle);
            Assert.AreEqual("Movie English Title X", entry.EnglishTitle);
            Assert.AreEqual("Movie German Title X", entry.GermanTitle);
            Assert.AreEqual("_xxx", entry.Type.ID);
            Assert.AreEqual("Movie Release Date X", entry.ReleaseDate);
            Assert.AreEqual("Movie Budget X", entry.Budget);
            Assert.AreEqual("Movie Worldwide Gross X", entry.WorldwideGross);
            Assert.AreEqual("Movie Worldwide Gross Date X", entry.WorldwideGrossDate);
            Assert.AreEqual("_xxx", entry.Connection.ID);
            Assert.AreEqual("Movie Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Movie Last Updated X", entry.LastUpdated);

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

            Assert.AreEqual(3, entry.AspectRatios.Count);
            Assert.AreEqual("_xx1", entry.AspectRatios[0].ID);
            Assert.AreEqual("_xx2", entry.AspectRatios[1].ID);
            Assert.AreEqual("_xx3", entry.AspectRatios[2].ID);

            Assert.AreEqual(3, entry.Cameras.Count);
            Assert.AreEqual("_xx1", entry.Cameras[0].ID);
            Assert.AreEqual("_xx2", entry.Cameras[1].ID);
            Assert.AreEqual("_xx3", entry.Cameras[2].ID);

            Assert.AreEqual(3, entry.Laboratories.Count);
            Assert.AreEqual("_xx1", entry.Laboratories[0].ID);
            Assert.AreEqual("_xx2", entry.Laboratories[1].ID);
            Assert.AreEqual("_xx3", entry.Laboratories[2].ID);

            // TODO: Adjust test expectations after changing database content
            Assert.AreEqual(1, entry.FilmLengths.Count);
            Assert.AreEqual("_xxx", entry.FilmLengths[0].ID);
            //Assert.AreEqual("_xx2", entry.FilmLengths[1].ID);
            //Assert.AreEqual("_xx3", entry.FilmLengths[2].ID);

            Assert.AreEqual(3, entry.NegativeFormats.Count);
            Assert.AreEqual("_xx1", entry.NegativeFormats[0].ID);
            Assert.AreEqual("_xx2", entry.NegativeFormats[1].ID);
            Assert.AreEqual("_xx3", entry.NegativeFormats[2].ID);

            Assert.AreEqual(3, entry.CinematographicProcesses.Count);
            Assert.AreEqual("_xx1", entry.CinematographicProcesses[0].ID);
            Assert.AreEqual("_xx2", entry.CinematographicProcesses[1].ID);
            Assert.AreEqual("_xx3", entry.CinematographicProcesses[2].ID);

            Assert.AreEqual(3, entry.PrintedFilmFormats.Count);
            Assert.AreEqual("_xx1", entry.PrintedFilmFormats[0].ID);
            Assert.AreEqual("_xx2", entry.PrintedFilmFormats[1].ID);
            Assert.AreEqual("_xx3", entry.PrintedFilmFormats[2].ID);

            Assert.AreEqual(3, entry.Directors.Count);
            Assert.AreEqual("_xx1", entry.Directors[0].ID);
            Assert.AreEqual("_xx2", entry.Directors[1].ID);
            Assert.AreEqual("_xx3", entry.Directors[2].ID);

            Assert.AreEqual(3, entry.Writers.Count);
            Assert.AreEqual("_xx1", entry.Writers[0].ID);
            Assert.AreEqual("_xx2", entry.Writers[1].ID);
            Assert.AreEqual("_xx3", entry.Writers[2].ID);

            Assert.AreEqual(3, entry.Cast.Count);
            Assert.AreEqual("_xx1", entry.Cast[0].ID);
            Assert.AreEqual("_xx2", entry.Cast[1].ID);
            Assert.AreEqual("_xx3", entry.Cast[2].ID);

            Assert.AreEqual(3, entry.Producers.Count);
            Assert.AreEqual("_xx1", entry.Producers[0].ID);
            Assert.AreEqual("_xx2", entry.Producers[1].ID);
            Assert.AreEqual("_xx3", entry.Producers[2].ID);

            Assert.AreEqual(3, entry.Music.Count);
            Assert.AreEqual("_xx1", entry.Music[0].ID);
            Assert.AreEqual("_xx2", entry.Music[1].ID);
            Assert.AreEqual("_xx3", entry.Music[2].ID);

            Assert.AreEqual(3, entry.Cinematography.Count);
            Assert.AreEqual("_xx1", entry.Cinematography[0].ID);
            Assert.AreEqual("_xx2", entry.Cinematography[1].ID);
            Assert.AreEqual("_xx3", entry.Cinematography[2].ID);

            Assert.AreEqual(3, entry.FilmEditing.Count);
            Assert.AreEqual("_xx1", entry.FilmEditing[0].ID);
            Assert.AreEqual("_xx2", entry.FilmEditing[1].ID);
            Assert.AreEqual("_xx3", entry.FilmEditing[2].ID);

            Assert.AreEqual(3, entry.Casting.Count);
            Assert.AreEqual("_xx1", entry.Casting[0].ID);
            Assert.AreEqual("_xx2", entry.Casting[1].ID);
            Assert.AreEqual("_xx3", entry.Casting[2].ID);

            Assert.AreEqual(3, entry.ProductionDesign.Count);
            Assert.AreEqual("_xx1", entry.ProductionDesign[0].ID);
            Assert.AreEqual("_xx2", entry.ProductionDesign[1].ID);
            Assert.AreEqual("_xx3", entry.ProductionDesign[2].ID);

            Assert.AreEqual(3, entry.ArtDirection.Count);
            Assert.AreEqual("_xx1", entry.ArtDirection[0].ID);
            Assert.AreEqual("_xx2", entry.ArtDirection[1].ID);
            Assert.AreEqual("_xx3", entry.ArtDirection[2].ID);

            Assert.AreEqual(3, entry.SetDecoration.Count);
            Assert.AreEqual("_xx1", entry.SetDecoration[0].ID);
            Assert.AreEqual("_xx2", entry.SetDecoration[1].ID);
            Assert.AreEqual("_xx3", entry.SetDecoration[2].ID);

            Assert.AreEqual(3, entry.CostumeDesign.Count);
            Assert.AreEqual("_xx1", entry.CostumeDesign[0].ID);
            Assert.AreEqual("_xx2", entry.CostumeDesign[1].ID);
            Assert.AreEqual("_xx3", entry.CostumeDesign[2].ID);

            Assert.AreEqual(3, entry.MakeupDepartment.Count);
            Assert.AreEqual("_xx1", entry.MakeupDepartment[0].ID);
            Assert.AreEqual("_xx2", entry.MakeupDepartment[1].ID);
            Assert.AreEqual("_xx3", entry.MakeupDepartment[2].ID);

            Assert.AreEqual(3, entry.ProductionManagement.Count);
            Assert.AreEqual("_xx1", entry.ProductionManagement[0].ID);
            Assert.AreEqual("_xx2", entry.ProductionManagement[1].ID);
            Assert.AreEqual("_xx3", entry.ProductionManagement[2].ID);

            Assert.AreEqual(3, entry.AssistantDirectors.Count);
            Assert.AreEqual("_xx1", entry.AssistantDirectors[0].ID);
            Assert.AreEqual("_xx2", entry.AssistantDirectors[1].ID);
            Assert.AreEqual("_xx3", entry.AssistantDirectors[2].ID);

            Assert.AreEqual(3, entry.ArtDepartment.Count);
            Assert.AreEqual("_xx1", entry.ArtDepartment[0].ID);
            Assert.AreEqual("_xx2", entry.ArtDepartment[1].ID);
            Assert.AreEqual("_xx3", entry.ArtDepartment[2].ID);

            Assert.AreEqual(3, entry.SoundDepartment.Count);
            Assert.AreEqual("_xx1", entry.SoundDepartment[0].ID);
            Assert.AreEqual("_xx2", entry.SoundDepartment[1].ID);
            Assert.AreEqual("_xx3", entry.SoundDepartment[2].ID);

            Assert.AreEqual(3, entry.SpecialEffects.Count);
            Assert.AreEqual("_xx1", entry.SpecialEffects[0].ID);
            Assert.AreEqual("_xx2", entry.SpecialEffects[1].ID);
            Assert.AreEqual("_xx3", entry.SpecialEffects[2].ID);

            Assert.AreEqual(3, entry.VisualEffects.Count);
            Assert.AreEqual("_xx1", entry.VisualEffects[0].ID);
            Assert.AreEqual("_xx2", entry.VisualEffects[1].ID);
            Assert.AreEqual("_xx3", entry.VisualEffects[2].ID);

            Assert.AreEqual(3, entry.Stunts.Count);
            Assert.AreEqual("_xx1", entry.Stunts[0].ID);
            Assert.AreEqual("_xx2", entry.Stunts[1].ID);
            Assert.AreEqual("_xx3", entry.Stunts[2].ID);

            Assert.AreEqual(3, entry.ElectricalDepartment.Count);
            Assert.AreEqual("_xx1", entry.ElectricalDepartment[0].ID);
            Assert.AreEqual("_xx2", entry.ElectricalDepartment[1].ID);
            Assert.AreEqual("_xx3", entry.ElectricalDepartment[2].ID);

            Assert.AreEqual(3, entry.AnimationDepartment.Count);
            Assert.AreEqual("_xx1", entry.AnimationDepartment[0].ID);
            Assert.AreEqual("_xx2", entry.AnimationDepartment[1].ID);
            Assert.AreEqual("_xx3", entry.AnimationDepartment[2].ID);

            Assert.AreEqual(3, entry.CastingDepartment.Count);
            Assert.AreEqual("_xx1", entry.CastingDepartment[0].ID);
            Assert.AreEqual("_xx2", entry.CastingDepartment[1].ID);
            Assert.AreEqual("_xx3", entry.CastingDepartment[2].ID);

            Assert.AreEqual(3, entry.CostumeDepartment.Count);
            Assert.AreEqual("_xx1", entry.CostumeDepartment[0].ID);
            Assert.AreEqual("_xx2", entry.CostumeDepartment[1].ID);
            Assert.AreEqual("_xx3", entry.CostumeDepartment[2].ID);

            Assert.AreEqual(3, entry.EditorialDepartment.Count);
            Assert.AreEqual("_xx1", entry.EditorialDepartment[0].ID);
            Assert.AreEqual("_xx2", entry.EditorialDepartment[1].ID);
            Assert.AreEqual("_xx3", entry.EditorialDepartment[2].ID);

            Assert.AreEqual(3, entry.LocationManagement.Count);
            Assert.AreEqual("_xx1", entry.LocationManagement[0].ID);
            Assert.AreEqual("_xx2", entry.LocationManagement[1].ID);
            Assert.AreEqual("_xx3", entry.LocationManagement[2].ID);

            Assert.AreEqual(3, entry.MusicDepartment.Count);
            Assert.AreEqual("_xx1", entry.MusicDepartment[0].ID);
            Assert.AreEqual("_xx2", entry.MusicDepartment[1].ID);
            Assert.AreEqual("_xx3", entry.MusicDepartment[2].ID);

            Assert.AreEqual(3, entry.ContinuityDepartment.Count);
            Assert.AreEqual("_xx1", entry.ContinuityDepartment[0].ID);
            Assert.AreEqual("_xx2", entry.ContinuityDepartment[1].ID);
            Assert.AreEqual("_xx3", entry.ContinuityDepartment[2].ID);
        }

        [TestMethod()]
        public void RetrieveTest_withInvalidID()
        {
            // Arrange
            Movie entry = new Movie("_aaa");

            // Act
            int count = entry.Retrieve();

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aaa", entry.ID);
            Assert.IsNull(entry.OriginalTitle);
            Assert.IsNull(entry.EnglishTitle);
            Assert.IsNull(entry.GermanTitle);
            Assert.IsNull(entry.Type);
            Assert.IsNull(entry.ReleaseDate);
            Assert.IsNull(entry.Budget);
            Assert.IsNull(entry.WorldwideGross);
            Assert.IsNull(entry.WorldwideGrossDate);
            Assert.IsNull(entry.Connection);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }

        [DataTestMethod()]
        public void RetrieveListTest_withValidData()
        {
            // Arrange
            // TODO: which DB reader is to be used should be defined in configuration
            DBReader reader = new SQLiteReader();

            // Act
            List<Movie> list = Data.Movie.RetrieveList(reader, "_xxx");

            // Assert
            Assert.AreEqual(1, list.Count);

            Assert.AreEqual("_xxx", list[0].ID);
        }
    }
}
