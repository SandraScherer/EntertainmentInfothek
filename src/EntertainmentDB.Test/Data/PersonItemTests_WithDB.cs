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


using EntertainmentDB.DBAccess.Read;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EntertainmentDB.Data.Tests
{
    [TestClass()]
    public class PersonItemTests_WithDB
    {
        const string VALID_ID = "_xx1";
        const string INVALID_ID = "_aa1";

        [TestMethod()]
        public void PersonItemTest()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            PersonItem item = new PersonItem(reader);

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(reader, item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual("", item.TargetTableName);

            Assert.AreEqual("", item.ID);
            Assert.IsNull(item.Person);
            Assert.IsNull(item.Role);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void PersonItemTest_withID(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            PersonItem item = new PersonItem(reader, id, "BaseTable", "TargetTable");

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(reader, item.Reader);
            Assert.AreEqual("BaseTable", item.BaseTableName);
            Assert.AreEqual("TargetTable", item.TargetTableName);

            Assert.AreEqual(id, item.ID);
            Assert.IsNull(item.Person);
            Assert.IsNull(item.Role);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonItemTest_withReaderNull(string id)
        {
            // Arrange, Act, Assert
            PersonItem item = new PersonItem(null, id, "BaseTable", "TargetTable");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonItemTest_withIDNull()
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            PersonItem item = new PersonItem(reader, null, "BaseTable", "TargetTable");
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonItemTest_withBaseTableNameNull(string id)
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            PersonItem item = new PersonItem(reader, id, null, "TargetTable");
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonItemTest_withTargetTableNameNull(string id)
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            PersonItem item = new PersonItem(reader, id, "BaseTable", null);
        }

        [DataTestMethod()]
        [DataRow("Movie", "Director", true)]
        [DataRow("Movie", "Director", false)]
        [DataRow("Movie", "Writer", true)]
        [DataRow("Movie", "Writer", false)]
        [DataRow("Movie", "Producer", true)]
        [DataRow("Movie", "Producer", false)]
        [DataRow("Movie", "Music", true)]
        [DataRow("Movie", "Music", false)]
        [DataRow("Movie", "Cinematography", true)]
        [DataRow("Movie", "Cinematography", false)]
        [DataRow("Movie", "FilmEditing", true)]
        [DataRow("Movie", "FilmEditing", false)]
        [DataRow("Movie", "Casting", true)]
        [DataRow("Movie", "Casting", false)]
        [DataRow("Movie", "ProductionDesign", true)]
        [DataRow("Movie", "ProductionDesign", false)]
        [DataRow("Movie", "ArtDirection", true)]
        [DataRow("Movie", "ArtDirection", false)]
        [DataRow("Movie", "SetDecoration", true)]
        [DataRow("Movie", "SetDecoration", false)]
        [DataRow("Movie", "CostumeDesign", true)]
        [DataRow("Movie", "CostumeDesign", false)]
        [DataRow("Movie", "MakeupDepartment", true)]
        [DataRow("Movie", "MakeupDepartment", false)]
        [DataRow("Movie", "ProductionManagement", true)]
        [DataRow("Movie", "ProductionManagement", false)]
        [DataRow("Movie", "AssistantDirector", true)]
        [DataRow("Movie", "AssistantDirector", false)]
        [DataRow("Movie", "ArtDepartment", true)]
        [DataRow("Movie", "ArtDepartment", false)]
        [DataRow("Movie", "SoundDepartment", true)]
        [DataRow("Movie", "SoundDepartment", false)]
        [DataRow("Movie", "SpecialEffects", true)]
        [DataRow("Movie", "SpecialEffects", false)]
        [DataRow("Movie", "VisualEffects", true)]
        [DataRow("Movie", "VisualEffects", false)]
        [DataRow("Movie", "Stunts", true)]
        [DataRow("Movie", "Stunts", false)]
        [DataRow("Movie", "ElectricalDepartment", true)]
        [DataRow("Movie", "ElectricalDepartment", false)]
        [DataRow("Movie", "AnimationDepartment", true)]
        [DataRow("Movie", "AnimationDepartment", false)]
        [DataRow("Movie", "CastingDepartment", true)]
        [DataRow("Movie", "CastingDepartment", false)]
        [DataRow("Movie", "CostumeDepartment", true)]
        [DataRow("Movie", "CostumeDepartment", false)]
        [DataRow("Movie", "EditorialDepartment", true)]
        [DataRow("Movie", "EditorialDepartment", false)]
        [DataRow("Movie", "LocationManagement", true)]
        [DataRow("Movie", "LocationManagement", false)]
        [DataRow("Movie", "MusicDepartment", true)]
        [DataRow("Movie", "MusicDepartment", false)]
        [DataRow("Movie", "ContinuityDepartment", true)]
        [DataRow("Movie", "ContinuityDepartment", false)]
        [DataRow("Movie", "TransportationDepartment", true)]
        [DataRow("Movie", "TransportationDepartment", false)]
        [DataRow("Movie", "OtherCrew", true)]
        [DataRow("Movie", "OtherCrew", false)]
        public void RetrieveTest_withValidID(string baseTableName, string targetTableName, bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            PersonItem item = new PersonItem(reader, VALID_ID, baseTableName, targetTableName);

            // Act
            int count = item.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual(VALID_ID, item.ID);
            Assert.AreEqual("_xxx", item.Person.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} Role X1", item.Role);
            Assert.AreEqual($"{baseTableName} {targetTableName} Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} LastUpdated X1", item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "Director", true)]
        [DataRow("Movie", "Director", false)]
        [DataRow("Movie", "Writer", true)]
        [DataRow("Movie", "Writer", false)]
        [DataRow("Movie", "Producer", true)]
        [DataRow("Movie", "Producer", false)]
        [DataRow("Movie", "Music", true)]
        [DataRow("Movie", "Music", false)]
        [DataRow("Movie", "Cinematography", true)]
        [DataRow("Movie", "Cinematography", false)]
        [DataRow("Movie", "FilmEditing", true)]
        [DataRow("Movie", "FilmEditing", false)]
        [DataRow("Movie", "Casting", true)]
        [DataRow("Movie", "Casting", false)]
        [DataRow("Movie", "ProductionDesign", true)]
        [DataRow("Movie", "ProductionDesign", false)]
        [DataRow("Movie", "ArtDirection", true)]
        [DataRow("Movie", "ArtDirection", false)]
        [DataRow("Movie", "SetDecoration", true)]
        [DataRow("Movie", "SetDecoration", false)]
        [DataRow("Movie", "CostumeDesign", true)]
        [DataRow("Movie", "CostumeDesign", false)]
        [DataRow("Movie", "MakeupDepartment", true)]
        [DataRow("Movie", "MakeupDepartment", false)]
        [DataRow("Movie", "ProductionManagement", true)]
        [DataRow("Movie", "ProductionManagement", false)]
        [DataRow("Movie", "AssistantDirector", true)]
        [DataRow("Movie", "AssistantDirector", false)]
        [DataRow("Movie", "ArtDepartment", true)]
        [DataRow("Movie", "ArtDepartment", false)]
        [DataRow("Movie", "SoundDepartment", true)]
        [DataRow("Movie", "SoundDepartment", false)]
        [DataRow("Movie", "SpecialEffects", true)]
        [DataRow("Movie", "SpecialEffects", false)]
        [DataRow("Movie", "VisualEffects", true)]
        [DataRow("Movie", "VisualEffects", false)]
        [DataRow("Movie", "Stunts", true)]
        [DataRow("Movie", "Stunts", false)]
        [DataRow("Movie", "ElectricalDepartment", true)]
        [DataRow("Movie", "ElectricalDepartment", false)]
        [DataRow("Movie", "AnimationDepartment", true)]
        [DataRow("Movie", "AnimationDepartment", false)]
        [DataRow("Movie", "CastingDepartment", true)]
        [DataRow("Movie", "CastingDepartment", false)]
        [DataRow("Movie", "CostumeDepartment", true)]
        [DataRow("Movie", "CostumeDepartment", false)]
        [DataRow("Movie", "EditorialDepartment", true)]
        [DataRow("Movie", "EditorialDepartment", false)]
        [DataRow("Movie", "LocationManagement", true)]
        [DataRow("Movie", "LocationManagement", false)]
        [DataRow("Movie", "MusicDepartment", true)]
        [DataRow("Movie", "MusicDepartment", false)]
        [DataRow("Movie", "ContinuityDepartment", true)]
        [DataRow("Movie", "ContinuityDepartment", false)]
        [DataRow("Movie", "TransportationDepartment", true)]
        [DataRow("Movie", "TransportationDepartment", false)]
        [DataRow("Movie", "OtherCrew", true)]
        [DataRow("Movie", "OtherCrew", false)]
        public void RetrieveTest_withInvalidID(string baseTableName, string targetTableName, bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            PersonItem item = new PersonItem(reader, INVALID_ID, baseTableName, targetTableName);

            // Act
            int count = item.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, item.ID);
            Assert.IsNull(item.Person);
            Assert.IsNull(item.Role);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "Director")]
        [DataRow("Movie", "Writer")]
        [DataRow("Movie", "Producer")]
        [DataRow("Movie", "Music")]
        [DataRow("Movie", "Cinematography")]
        [DataRow("Movie", "FilmEditing")]
        [DataRow("Movie", "Casting")]
        [DataRow("Movie", "ProductionDesign")]
        [DataRow("Movie", "ArtDirection")]
        [DataRow("Movie", "SetDecoration")]
        [DataRow("Movie", "CostumeDesign")]
        [DataRow("Movie", "MakeupDepartment")]
        [DataRow("Movie", "ProductionManagement")]
        [DataRow("Movie", "AssistantDirector")]
        [DataRow("Movie", "ArtDepartment")]
        [DataRow("Movie", "SoundDepartment")]
        [DataRow("Movie", "SpecialEffects")]
        [DataRow("Movie", "VisualEffects")]
        [DataRow("Movie", "Stunts")]
        [DataRow("Movie", "ElectricalDepartment")]
        [DataRow("Movie", "AnimationDepartment")]
        [DataRow("Movie", "CastingDepartment")]
        [DataRow("Movie", "CostumeDepartment")]
        [DataRow("Movie", "EditorialDepartment")]
        [DataRow("Movie", "LocationManagement")]
        [DataRow("Movie", "MusicDepartment")]
        [DataRow("Movie", "ContinuityDepartment")]
        [DataRow("Movie", "TransportationDepartment")]
        [DataRow("Movie", "OtherCrew")]
        public void RetrieveListTest_withValidData(string baseTableName, string targetTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();

            // Act
            List<PersonItem> list = Data.PersonItem.RetrieveList(reader, baseTableName, "_xxx", targetTableName.Replace(" ", ""));

            // Assert
            Assert.AreEqual(3, list.Count);

            Assert.AreEqual("_xx1", list[0].ID);
            Assert.AreEqual("_xxx", list[0].Person.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} Role X1", list[0].Role);
            Assert.AreEqual($"{baseTableName} {targetTableName} Details X1", list[0].Details);
            Assert.AreEqual("_xxx", list[0].Status.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} LastUpdated X1", list[0].LastUpdated);

            Assert.AreEqual("_xx2", list[1].ID);
            Assert.AreEqual("_yyy", list[1].Person.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} Role X2", list[1].Role);
            Assert.AreEqual($"{baseTableName} {targetTableName} Details X2", list[1].Details);
            Assert.AreEqual("_xxx", list[1].Status.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} LastUpdated X2", list[1].LastUpdated);

            Assert.AreEqual("_xx3", list[2].ID);
            Assert.AreEqual("_zzz", list[2].Person.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} Role X3", list[2].Role);
            Assert.AreEqual($"{baseTableName} {targetTableName} Details X3", list[2].Details);
            Assert.AreEqual("_xxx", list[2].Status.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} LastUpdated X3", list[2].LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "Director")]
        [DataRow("Movie", "Writer")]
        [DataRow("Movie", "Producer")]
        [DataRow("Movie", "Music")]
        [DataRow("Movie", "Cinematography")]
        [DataRow("Movie", "FilmEditing")]
        [DataRow("Movie", "Casting")]
        [DataRow("Movie", "ProductionDesign")]
        [DataRow("Movie", "ArtDirection")]
        [DataRow("Movie", "SetDecoration")]
        [DataRow("Movie", "CostumeDesign")]
        [DataRow("Movie", "MakeupDepartment")]
        [DataRow("Movie", "ProductionManagement")]
        [DataRow("Movie", "AssistantDirector")]
        [DataRow("Movie", "ArtDepartment")]
        [DataRow("Movie", "SoundDepartment")]
        [DataRow("Movie", "SpecialEffects")]
        [DataRow("Movie", "VisualEffects")]
        [DataRow("Movie", "Stunts")]
        [DataRow("Movie", "ElectricalDepartment")]
        [DataRow("Movie", "AnimationDepartment")]
        [DataRow("Movie", "CastingDepartment")]
        [DataRow("Movie", "CostumeDepartment")]
        [DataRow("Movie", "EditorialDepartment")]
        [DataRow("Movie", "LocationManagement")]
        [DataRow("Movie", "MusicDepartment")]
        [DataRow("Movie", "ContinuityDepartment")]
        [DataRow("Movie", "TransportationDepartment")]
        [DataRow("Movie", "OtherCrew")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RetrieveListTest_withReaderNull(string baseTableName, string targetTableName)
        {
            // Arrange, Act, Assert
            List<PersonItem> list = Data.PersonItem.RetrieveList(null, baseTableName, "_xxx", targetTableName.Replace(" ", ""));

        }

        [DataTestMethod()]
        [DataRow("Movie", "Director")]
        [DataRow("Movie", "Writer")]
        [DataRow("Movie", "Producer")]
        [DataRow("Movie", "Music")]
        [DataRow("Movie", "Cinematography")]
        [DataRow("Movie", "FilmEditing")]
        [DataRow("Movie", "Casting")]
        [DataRow("Movie", "ProductionDesign")]
        [DataRow("Movie", "ArtDirection")]
        [DataRow("Movie", "SetDecoration")]
        [DataRow("Movie", "CostumeDesign")]
        [DataRow("Movie", "MakeupDepartment")]
        [DataRow("Movie", "ProductionManagement")]
        [DataRow("Movie", "AssistantDirector")]
        [DataRow("Movie", "ArtDepartment")]
        [DataRow("Movie", "SoundDepartment")]
        [DataRow("Movie", "SpecialEffects")]
        [DataRow("Movie", "VisualEffects")]
        [DataRow("Movie", "Stunts")]
        [DataRow("Movie", "ElectricalDepartment")]
        [DataRow("Movie", "AnimationDepartment")]
        [DataRow("Movie", "CastingDepartment")]
        [DataRow("Movie", "CostumeDepartment")]
        [DataRow("Movie", "EditorialDepartment")]
        [DataRow("Movie", "LocationManagement")]
        [DataRow("Movie", "MusicDepartment")]
        [DataRow("Movie", "ContinuityDepartment")]
        [DataRow("Movie", "TransportationDepartment")]
        [DataRow("Movie", "OtherCrew")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RetrieveListTest_withBaseTableNameNull(string baseTableName, string targetTableName)
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            List<PersonItem> list = Data.PersonItem.RetrieveList(reader, null, "_xxx", targetTableName.Replace(" ", ""));
        }

        [DataTestMethod()]
        [DataRow("Movie", "Director")]
        [DataRow("Movie", "Writer")]
        [DataRow("Movie", "Producer")]
        [DataRow("Movie", "Music")]
        [DataRow("Movie", "Cinematography")]
        [DataRow("Movie", "FilmEditing")]
        [DataRow("Movie", "Casting")]
        [DataRow("Movie", "ProductionDesign")]
        [DataRow("Movie", "ArtDirection")]
        [DataRow("Movie", "SetDecoration")]
        [DataRow("Movie", "CostumeDesign")]
        [DataRow("Movie", "MakeupDepartment")]
        [DataRow("Movie", "ProductionManagement")]
        [DataRow("Movie", "AssistantDirector")]
        [DataRow("Movie", "ArtDepartment")]
        [DataRow("Movie", "SoundDepartment")]
        [DataRow("Movie", "SpecialEffects")]
        [DataRow("Movie", "VisualEffects")]
        [DataRow("Movie", "Stunts")]
        [DataRow("Movie", "ElectricalDepartment")]
        [DataRow("Movie", "AnimationDepartment")]
        [DataRow("Movie", "CastingDepartment")]
        [DataRow("Movie", "CostumeDepartment")]
        [DataRow("Movie", "EditorialDepartment")]
        [DataRow("Movie", "LocationManagement")]
        [DataRow("Movie", "MusicDepartment")]
        [DataRow("Movie", "ContinuityDepartment")]
        [DataRow("Movie", "TransportationDepartment")]
        [DataRow("Movie", "OtherCrew")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RetrieveListTest_withBaseTableIDNull(string baseTableName, string targetTableName)
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            List<PersonItem> list = Data.PersonItem.RetrieveList(reader, baseTableName, null, targetTableName.Replace(" ", ""));
        }

        [DataTestMethod()]
        [DataRow("Movie", "Director")]
        [DataRow("Movie", "Writer")]
        [DataRow("Movie", "Producer")]
        [DataRow("Movie", "Music")]
        [DataRow("Movie", "Cinematography")]
        [DataRow("Movie", "FilmEditing")]
        [DataRow("Movie", "Casting")]
        [DataRow("Movie", "ProductionDesign")]
        [DataRow("Movie", "ArtDirection")]
        [DataRow("Movie", "SetDecoration")]
        [DataRow("Movie", "CostumeDesign")]
        [DataRow("Movie", "MakeupDepartment")]
        [DataRow("Movie", "ProductionManagement")]
        [DataRow("Movie", "AssistantDirector")]
        [DataRow("Movie", "ArtDepartment")]
        [DataRow("Movie", "SoundDepartment")]
        [DataRow("Movie", "SpecialEffects")]
        [DataRow("Movie", "VisualEffects")]
        [DataRow("Movie", "Stunts")]
        [DataRow("Movie", "ElectricalDepartment")]
        [DataRow("Movie", "AnimationDepartment")]
        [DataRow("Movie", "CastingDepartment")]
        [DataRow("Movie", "CostumeDepartment")]
        [DataRow("Movie", "EditorialDepartment")]
        [DataRow("Movie", "LocationManagement")]
        [DataRow("Movie", "MusicDepartment")]
        [DataRow("Movie", "ContinuityDepartment")]
        [DataRow("Movie", "TransportationDepartment")]
        [DataRow("Movie", "OtherCrew")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RetrieveListTest_withTargetTableNameNull(string baseTableName, string targetTableName)
        {
            DBReader reader = new SQLiteReader();
            List<PersonItem> list = Data.PersonItem.RetrieveList(reader, baseTableName, "_xxx", null);
        }

        [DataTestMethod()]
        [DataRow("Movie", "Director")]
        [DataRow("Movie", "Writer")]
        [DataRow("Movie", "Producer")]
        [DataRow("Movie", "Music")]
        [DataRow("Movie", "Cinematography")]
        [DataRow("Movie", "FilmEditing")]
        [DataRow("Movie", "Casting")]
        [DataRow("Movie", "ProductionDesign")]
        [DataRow("Movie", "ArtDirection")]
        [DataRow("Movie", "SetDecoration")]
        [DataRow("Movie", "CostumeDesign")]
        [DataRow("Movie", "MakeupDepartment")]
        [DataRow("Movie", "ProductionManagement")]
        [DataRow("Movie", "AssistantDirector")]
        [DataRow("Movie", "ArtDepartment")]
        [DataRow("Movie", "SoundDepartment")]
        [DataRow("Movie", "SpecialEffects")]
        [DataRow("Movie", "VisualEffects")]
        [DataRow("Movie", "Stunts")]
        [DataRow("Movie", "ElectricalDepartment")]
        [DataRow("Movie", "AnimationDepartment")]
        [DataRow("Movie", "CastingDepartment")]
        [DataRow("Movie", "CostumeDepartment")]
        [DataRow("Movie", "EditorialDepartment")]
        [DataRow("Movie", "LocationManagement")]
        [DataRow("Movie", "MusicDepartment")]
        [DataRow("Movie", "ContinuityDepartment")]
        [DataRow("Movie", "TransportationDepartment")]
        [DataRow("Movie", "OtherCrew")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RetrieveListTest_withOrderNull(string baseTableName, string targetTableName)
        {
            DBReader reader = new SQLiteReader();
            List<PersonItem> list = Data.PersonItem.RetrieveList(reader, baseTableName, "_xxx", targetTableName.Replace(" ", ""), null);
        }
    }
}
