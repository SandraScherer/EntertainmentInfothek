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
    public class AwardItemTests
    {
        public void AwardItemTest()
        {
            // Arrange
            AwardItem item = new AwardItem();

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.IsNotNull(item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual("Award", item.TargetTableName);

            Assert.AreEqual("", item.ID);
            Assert.IsNull(item.Award);
            Assert.IsNull(item.Category);
            Assert.IsNull(item.Year);
            Assert.IsNull(item.Winner);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);

            Assert.IsNull(item.Persons);
        }

        [TestMethod()]
        public void AwardItemTest_withID()
        {
            // Arrange
            AwardItem item = new AwardItem("_xx1");

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.IsNotNull(item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual("Award", item.TargetTableName);

            Assert.AreEqual("_xx1", item.ID);
            Assert.IsNull(item.Award);
            Assert.IsNull(item.Category);
            Assert.IsNull(item.Year);
            Assert.IsNull(item.Winner);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);

            Assert.IsNull(item.Persons);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveBasicInformationTest_withValidID_BasicInfoOnly(string value)
        {
            // Arrange
            AwardItem item = new AwardItem("_xx1");
            item.BaseTableName = value;

            // Act
            int count = item.RetrieveBasicInformation(true);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xx1", item.ID);
            Assert.AreEqual("_xxx", item.Award.ID);
            Assert.AreEqual($"{value} Award Category X1", item.Category);
            Assert.AreEqual($"{value} Award Year X1", item.Year);
            Assert.AreEqual($"1", item.Winner);
            Assert.AreEqual($"{value} Award Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{value} Award Last Updated X1", item.LastUpdated);

            Assert.IsNull(item.Persons);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveBasicInformationTest_withValidID_AdditionalInfo(string value)
        {
            // Arrange
            AwardItem item = new AwardItem("_xx1");
            item.BaseTableName = value;

            // Act
            int count = item.RetrieveBasicInformation(false);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xx1", item.ID);
            Assert.AreEqual("_xxx", item.Award.ID);
            Assert.AreEqual($"{value} Award Category X1", item.Category);
            Assert.AreEqual($"{value} Award Year X1", item.Year);
            Assert.AreEqual($"1", item.Winner);
            Assert.AreEqual($"{value} Award Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{value} Award Last Updated X1", item.LastUpdated);

            Assert.IsNull(item.Persons);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveBasicInformationTest_withInvalidID_BasicInfoOnly(string value)
        {
            // Arrange
            AwardItem item = new AwardItem("_aa1");
            item.BaseTableName = value;

            // Act
            int count = item.RetrieveBasicInformation(true);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aa1", item.ID);
            Assert.IsNull(item.Award);
            Assert.IsNull(item.Category);
            Assert.IsNull(item.Year);
            Assert.IsNull(item.Winner);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);

            Assert.IsNull(item.Persons);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveBasicInformationTest_withInvalidID_AdditionalInfo(string value)
        {
            // Arrange
            AwardItem item = new AwardItem("_aa1");
            item.BaseTableName = value;

            // Act
            int count = item.RetrieveBasicInformation(false);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aa1", item.ID);
            Assert.IsNull(item.Award);
            Assert.IsNull(item.Category);
            Assert.IsNull(item.Year);
            Assert.IsNull(item.Winner);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);

            Assert.IsNull(item.Persons);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveAdditionalInformationTest_withValidID(string value)
        {
            // Arrange
            AwardItem item = new AwardItem("_xx1");
            item.BaseTableName = value;

            // Act
            int count = item.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(3, count);

            Assert.AreEqual(3, item.Persons.Count);
            Assert.AreEqual("_x11", item.Persons[0].ID);
            Assert.AreEqual("_x12", item.Persons[1].ID);
            Assert.AreEqual("_x13", item.Persons[2].ID);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveAdditionalInformationTest_withInvalidID(string value)
        {
            // Arrange
            AwardItem item = new AwardItem("_aa1");
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
            AwardItem item = new AwardItem("_xx1");
            item.BaseTableName = value;

            // Act
            int count = item.Retrieve(true);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xx1", item.ID);
            Assert.AreEqual("_xxx", item.Award.ID);
            Assert.AreEqual($"{value} Award Category X1", item.Category);
            Assert.AreEqual($"{value} Award Year X1", item.Year);
            Assert.AreEqual($"1", item.Winner);
            Assert.AreEqual($"{value} Award Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{value} Award Last Updated X1", item.LastUpdated);

            Assert.IsNull(item.Persons);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveTest_withValidID_AdditionalInfo(string value)
        {
            // Arrange
            AwardItem item = new AwardItem("_xx1");
            item.BaseTableName = value;

            // Act
            int count = item.Retrieve(false);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xx1", item.ID);
            Assert.AreEqual("_xxx", item.Award.ID);
            Assert.AreEqual($"{value} Award Category X1", item.Category);
            Assert.AreEqual($"{value} Award Year X1", item.Year);
            Assert.AreEqual($"1", item.Winner);
            Assert.AreEqual($"{value} Award Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{value} Award Last Updated X1", item.LastUpdated);

            Assert.AreEqual(3, item.Persons.Count);
            Assert.AreEqual("_x11", item.Persons[0].ID);
            Assert.AreEqual("_x12", item.Persons[1].ID);
            Assert.AreEqual("_x13", item.Persons[2].ID);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveTest_withInvalidID_BasicInfoOnly(string value)
        {
            // Arrange
            AwardItem item = new AwardItem("_aa1");
            item.BaseTableName = value;

            // Act
            int count = item.Retrieve(true);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aa1", item.ID);
            Assert.IsNull(item.Award);
            Assert.IsNull(item.Category);
            Assert.IsNull(item.Year);
            Assert.IsNull(item.Winner);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);

            Assert.IsNull(item.Persons);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveTest_withInvalidID_AdditionalInfo(string value)
        {
            // Arrange
            AwardItem item = new AwardItem("_aa1");
            item.BaseTableName = value;

            // Act
            int count = item.Retrieve(false);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aa1", item.ID);
            Assert.IsNull(item.Award);
            Assert.IsNull(item.Category);
            Assert.IsNull(item.Year);
            Assert.IsNull(item.Winner);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);

            Assert.AreEqual(0, item.Persons.Count);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveListTest_withValidData(string value)
        {
            // Arrange
            DBReader reader = new SQLiteReader();

            // Act
            List<AwardItem> list = Data.AwardItem.RetrieveList(reader, value, "_xxx");

            // Assert
            Assert.AreEqual(3, list.Count);

            Assert.AreEqual("_xx1", list[0].ID);
            Assert.AreEqual("_xxx", list[0].Award.ID);
            Assert.AreEqual($"{value} Award Category X1", list[0].Category);
            Assert.AreEqual($"{value} Award Year X1", list[0].Year);
            Assert.AreEqual($"1", list[0].Winner);
            Assert.AreEqual($"{value} Award Details X1", list[0].Details);
            Assert.AreEqual("_xxx", list[0].Status.ID);
            Assert.AreEqual($"{value} Award Last Updated X1", list[0].LastUpdated);

            Assert.AreEqual(3, list[0].Persons.Count);
            Assert.AreEqual("_x11", list[0].Persons[0].ID);
            Assert.AreEqual("_x12", list[0].Persons[1].ID);
            Assert.AreEqual("_x13", list[0].Persons[2].ID);

            Assert.AreEqual("_xx2", list[1].ID);
            Assert.AreEqual("_yyy", list[1].Award.ID);
            Assert.AreEqual($"{value} Award Category X2", list[1].Category);
            Assert.AreEqual($"{value} Award Year X2", list[1].Year);
            Assert.AreEqual($"0", list[1].Winner);
            Assert.AreEqual($"{value} Award Details X2", list[1].Details);
            Assert.AreEqual("_xxx", list[1].Status.ID);
            Assert.AreEqual($"{value} Award Last Updated X2", list[1].LastUpdated);

            Assert.AreEqual(3, list[1].Persons.Count);
            Assert.AreEqual("_x21", list[1].Persons[0].ID);
            Assert.AreEqual("_x22", list[1].Persons[1].ID);
            Assert.AreEqual("_x23", list[1].Persons[2].ID);

            Assert.AreEqual("_xx3", list[2].ID);
            Assert.AreEqual("_zzz", list[2].Award.ID);
            Assert.AreEqual($"{value} Award Category X3", list[2].Category);
            Assert.AreEqual($"{value} Award Year X3", list[2].Year);
            Assert.AreEqual($"0", list[2].Winner);
            Assert.AreEqual($"{value} Award Details X3", list[2].Details);
            Assert.AreEqual("_xxx", list[2].Status.ID);
            Assert.AreEqual($"{value} Award Last Updated X3", list[2].LastUpdated);

            Assert.AreEqual(3, list[2].Persons.Count);
            Assert.AreEqual("_x31", list[2].Persons[0].ID);
            Assert.AreEqual("_x32", list[2].Persons[1].ID);
            Assert.AreEqual("_x33", list[2].Persons[2].ID);
        }
    }
}
