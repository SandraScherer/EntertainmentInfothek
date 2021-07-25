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


using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntertainmentDB.Data;
using System;
using System.Collections.Generic;
using System.Text;
using EntertainmentDB.DBAccess.Read;

namespace EntertainmentDB.Data.Tests
{
    [TestClass()]
    public class FilmLengthItemTests
    {
        [TestMethod()]
        public void FilmLengthItemTest()
        {
            // Arrange
            FilmLengthItem item = new FilmLengthItem();

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.IsNotNull(item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual("FilmLength", item.TargetTableName);

            Assert.AreEqual("", item.ID);
            Assert.IsNull(item.Length);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [TestMethod()]
        public void FilmLengthItemTest_withID()
        {
            // Arrange
            FilmLengthItem item = new FilmLengthItem("_xx1");

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.IsNotNull(item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual("FilmLength", item.TargetTableName);

            Assert.AreEqual("_xx1", item.ID);
            Assert.IsNull(item.Length);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveBasicInformationTest_withValidID_BasicInfoOnly(string value)
        {
            // Arrange
            FilmLengthItem item = new FilmLengthItem("_xxx");
            item.BaseTableName = value;

            // Act
            int count = item.RetrieveBasicInformation(true);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", item.ID);
            Assert.AreEqual($"{value} Film Length X", item.Length);
            Assert.AreEqual($"{value} Film Length Details X", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{value} Film Length Last Updated X", item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveBasicInformationTest_withValidID_AdditionalInfo(string value)
        {
            // Arrange
            FilmLengthItem item = new FilmLengthItem("_xxx");
            item.BaseTableName = value;

            // Act
            int count = item.RetrieveBasicInformation(false);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", item.ID);
            Assert.AreEqual($"{value} Film Length X", item.Length);
            Assert.AreEqual($"{value} Film Length Details X", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{value} Film Length Last Updated X", item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveBasicInformationTest_withInvalidID_BasicInfoOnly(string value)
        {
            // Arrange
            FilmLengthItem item = new FilmLengthItem("_aaa");
            item.BaseTableName = value;

            // Act
            int count = item.RetrieveBasicInformation(true);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aaa", item.ID);
            Assert.IsNull(item.Length);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveBasicInformationTest_withInvalidID_AdditionalInfo(string value)
        {
            // Arrange
            FilmLengthItem item = new FilmLengthItem("_aaa");
            item.BaseTableName = value;

            // Act
            int count = item.RetrieveBasicInformation(false);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aaa", item.ID);
            Assert.IsNull(item.Length);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveAdditionalInformationTest_withValidID(string value)
        {
            // Arrange
            FilmLengthItem item = new FilmLengthItem("_xxx");
            item.BaseTableName = value;

            // Act
            int count = item.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(0, count);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveAdditionalInformationTest_withInvalidID(string value)
        {
            // Arrange
            FilmLengthItem item = new FilmLengthItem("_aaa");
            item.BaseTableName = value;

            // Act
            int count = item.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(0, count);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveTest_withValidID_BasicInfoOnly(string value)
        {
            // Arrange
            FilmLengthItem item = new FilmLengthItem("_xxx");
            item.BaseTableName = value;

            // Act
            int count = item.Retrieve(true);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", item.ID);
            Assert.AreEqual($"{value} Film Length X", item.Length);
            Assert.AreEqual($"{value} Film Length Details X", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{value} Film Length Last Updated X", item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveTest_withValidID_AdditionalInfo(string value)
        {
            // Arrange
            FilmLengthItem item = new FilmLengthItem("_xxx");
            item.BaseTableName = value;

            // Act
            int count = item.Retrieve(false);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", item.ID);
            Assert.AreEqual($"{value} Film Length X", item.Length);
            Assert.AreEqual($"{value} Film Length Details X", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{value} Film Length Last Updated X", item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveTest_withInvalidID_BasicInfoOnly(string value)
        {
            // Arrange
            FilmLengthItem item = new FilmLengthItem("_aaa");
            item.BaseTableName = value;

            // Act
            int count = item.Retrieve(true);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aaa", item.ID);
            Assert.IsNull(item.Length);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveTest_withInvalidID_AdditionalInfo(string value)
        {
            // Arrange
            FilmLengthItem item = new FilmLengthItem("_aaa");
            item.BaseTableName = value;

            // Act
            int count = item.Retrieve(false);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aaa", item.ID);
            Assert.IsNull(item.Length);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveListTest_withValidData(string value)
        {
            // Arrange
            DBReader reader = new SQLiteReader();

            // Act
            List<FilmLengthItem> list = Data.FilmLengthItem.RetrieveList(reader, value, "_xxx");

            // Assert
            Assert.AreEqual(1, list.Count);

            Assert.AreEqual("_xxx", list[0].ID);
            Assert.AreEqual($"{value} Film Length X", list[0].Length);
            Assert.AreEqual($"{value} Film Length Details X", list[0].Details);
            Assert.AreEqual("_xxx", list[0].Status.ID);
            Assert.AreEqual($"{value} Film Length Last Updated X", list[0].LastUpdated);
        }
    }
}
