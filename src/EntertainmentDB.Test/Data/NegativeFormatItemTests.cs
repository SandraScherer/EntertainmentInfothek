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
    public class NegativeFormatItemTests
    {
        [TestMethod()]
        public void NegativeFormatItemTest()
        {
            // Arrange
            NegativeFormatItem item = new NegativeFormatItem();

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.IsNotNull(item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual("", item.TargetTableName);

            Assert.AreEqual("", item.ID);
            Assert.IsNull(item.FilmFormat);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [TestMethod()]
        public void NegativeFormatItemTest_withValidID()
        {
            // Arrange
            NegativeFormatItem item = new NegativeFormatItem("_xx1", "NegativeFormat");

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.IsNotNull(item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual("NegativeFormat", item.TargetTableName);

            Assert.AreEqual("_xx1", item.ID);
            Assert.IsNull(item.FilmFormat);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveBasicInformationTest_withValidID_BasicInfoOnly(string value)
        {
            // Arrange
            NegativeFormatItem item = new NegativeFormatItem("_xx1", "NegativeFormat");
            item.BaseTableName = value;

            // Act
            int count = item.RetrieveBasicInformation(true);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xx1", item.ID);
            Assert.AreEqual("_xxx", item.FilmFormat.ID);
            Assert.AreEqual($"{value} NegativeFormat Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{value} NegativeFormat LastUpdated X1", item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveBasicInformationTest_withValidID_AdditonalInfo(string value)
        {
            // Arrange
            NegativeFormatItem item = new NegativeFormatItem("_xx1", "NegativeFormat");
            item.BaseTableName = value;

            // Act
            int count = item.RetrieveBasicInformation(false);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xx1", item.ID);
            Assert.AreEqual("_xxx", item.FilmFormat.ID);
            Assert.AreEqual($"{value} NegativeFormat Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{value} NegativeFormat LastUpdated X1", item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveBasicInformationTest_withInvalidID_BasicInfoOnly(string value)
        {
            // Arrange
            NegativeFormatItem item = new NegativeFormatItem("_aa1", "NegativeFormat");
            item.BaseTableName = value;

            // Act
            int count = item.RetrieveBasicInformation(true);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aa1", item.ID);
            Assert.IsNull(item.FilmFormat);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveBasicInformationTest_withInvalidID_AdditionalInfo(string value)
        {
            // Arrange
            NegativeFormatItem item = new NegativeFormatItem("_aa1", "NegativeFormat");
            item.BaseTableName = value;

            // Act
            int count = item.RetrieveBasicInformation(false);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aa1", item.ID);
            Assert.IsNull(item.FilmFormat);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveAdditionalInformationTest_withValidID(string value)
        {
            // Arrange
            NegativeFormatItem item = new NegativeFormatItem("_xx1", "NegativeFormat");
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
            NegativeFormatItem item = new NegativeFormatItem("_aa1", "NegativeFormat");
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
            NegativeFormatItem item = new NegativeFormatItem("_xx1", "NegativeFormat");
            item.BaseTableName = value;

            // Act
            int count = item.Retrieve(true);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xx1", item.ID);
            Assert.AreEqual("_xxx", item.FilmFormat.ID);
            Assert.AreEqual($"{value} NegativeFormat Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{value} NegativeFormat LastUpdated X1", item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveTest_withValidID_AdditionalInfo(string value)
        {
            // Arrange
            NegativeFormatItem item = new NegativeFormatItem("_xx1", "NegativeFormat");
            item.BaseTableName = value;

            // Act
            int count = item.Retrieve(false);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xx1", item.ID);
            Assert.AreEqual("_xxx", item.FilmFormat.ID);
            Assert.AreEqual($"{value} NegativeFormat Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{value} NegativeFormat LastUpdated X1", item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveTest_withInvalidID_BasicInfoOnly(string value)
        {
            // Arrange
            NegativeFormatItem item = new NegativeFormatItem("_aa1", "NegativeFormat");
            item.BaseTableName = value;

            // Act
            int count = item.Retrieve(true);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aa1", item.ID);
            Assert.IsNull(item.FilmFormat);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveTest_withInvalidID_AdditionalInfo(string value)
        {
            // Arrange
            NegativeFormatItem item = new NegativeFormatItem("_aa1", "NegativeFormat");
            item.BaseTableName = value;

            // Act
            int count = item.Retrieve(false);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aa1", item.ID);
            Assert.IsNull(item.FilmFormat);
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
            List<NegativeFormatItem> list = Data.NegativeFormatItem.RetrieveList(reader, value, "_xxx", "NegativeFormat");

            // Assert
            Assert.AreEqual(3, list.Count);

            Assert.AreEqual("_xx1", list[0].ID);
            Assert.AreEqual("_xxx", list[0].FilmFormat.ID);
            Assert.AreEqual($"{value} NegativeFormat Details X1", list[0].Details);
            Assert.AreEqual("_xxx", list[0].Status.ID);
            Assert.AreEqual($"{value} NegativeFormat LastUpdated X1", list[0].LastUpdated);

            Assert.AreEqual("_xx2", list[1].ID);
            Assert.AreEqual("_yyy", list[1].FilmFormat.ID);
            Assert.AreEqual($"{value} NegativeFormat Details X2", list[1].Details);
            Assert.AreEqual("_xxx", list[1].Status.ID);
            Assert.AreEqual($"{value} NegativeFormat LastUpdated X2", list[1].LastUpdated);

            Assert.AreEqual("_xx3", list[2].ID);
            Assert.AreEqual("_zzz", list[2].FilmFormat.ID);
            Assert.AreEqual($"{value} NegativeFormat Details X3", list[2].Details);
            Assert.AreEqual("_xxx", list[2].Status.ID);
            Assert.AreEqual($"{value} NegativeFormat LastUpdated X3", list[2].LastUpdated);
        }
    }
}
