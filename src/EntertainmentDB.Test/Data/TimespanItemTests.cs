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
    public class TimespanItemTests
    {
        [TestMethod()]
        public void TimespanItemTest()
        {
            TimespanItem item = new TimespanItem();

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.IsNotNull(item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual("", item.TargetTableName);

            Assert.AreEqual("", item.ID);
            Assert.IsNull(item.StartDate);
            Assert.IsNull(item.EndDate);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [TestMethod()]
        public void TimespanItemTest_withID()
        {
            // Arrange
            TimespanItem item = new TimespanItem("_xx1", "");

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.IsNotNull(item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual("", item.TargetTableName);

            Assert.AreEqual("_xx1", item.ID);
            Assert.IsNull(item.StartDate);
            Assert.IsNull(item.EndDate);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Timespan")]
        public void TimespanItemTest_withIDAndTargetTableName(string value)
        {
            // Arrange
            TimespanItem item = new TimespanItem("_xx1", value);

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.IsNotNull(item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual(value, item.TargetTableName);

            Assert.AreEqual("_xx1", item.ID);
            Assert.IsNull(item.StartDate);
            Assert.IsNull(item.EndDate);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "FilmingDate")]
        [DataRow("Movie", "ProductionDate")]
        public void RetrieveBasicInformationTest_withValidID_BasicInfoOnly(string value1, string value2)
        {
            // Arrange
            TimespanItem item = new TimespanItem("_xx1", "");
            item.BaseTableName = value1;
            item.TargetTableName = value2.Replace(" ", "");

            // Act
            int count = item.RetrieveBasicInformation(true);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xx1", item.ID);
            Assert.AreEqual($"{value1} {value2} StartDate X1", item.StartDate);
            Assert.AreEqual($"{value1} {value2} EndDate X1", item.EndDate);
            Assert.AreEqual($"{value1} {value2} Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{value1} {value2} LastUpdated X1", item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "FilmingDate")]
        [DataRow("Movie", "ProductionDate")]
        public void RetrieveBasicInformationTest_withValidID_AdditionalInfo(string value1, string value2)
        {
            // Arrange
            TimespanItem item = new TimespanItem("_xx1", "");
            item.BaseTableName = value1;
            item.TargetTableName = value2.Replace(" ", "");

            // Act
            int count = item.RetrieveBasicInformation(false);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xx1", item.ID);
            Assert.AreEqual($"{value1} {value2} StartDate X1", item.StartDate);
            Assert.AreEqual($"{value1} {value2} EndDate X1", item.EndDate);
            Assert.AreEqual($"{value1} {value2} Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{value1} {value2} LastUpdated X1", item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "FilmingDate")]
        [DataRow("Movie", "ProductionDate")]
        public void RetrieveBasicInformationTest_withInvalidID_BasicInfoOnly(string value1, string value2)
        {
            // Arrange
            TimespanItem item = new TimespanItem("_aa1", "");
            item.BaseTableName = value1;
            item.TargetTableName = value2.Replace(" ", "");

            // Act
            int count = item.RetrieveBasicInformation(true);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aa1", item.ID);
            Assert.IsNull(item.StartDate);
            Assert.IsNull(item.EndDate);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "FilmingDate")]
        [DataRow("Movie", "ProductionDate")]
        public void RetrieveBasicInformationTest_withInvalidID_AdditionalInfo(string value1, string value2)
        {
            // Arrange
            TimespanItem item = new TimespanItem("_aa1", "");
            item.BaseTableName = value1;
            item.TargetTableName = value2.Replace(" ", "");

            // Act
            int count = item.RetrieveBasicInformation(false);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aa1", item.ID);
            Assert.IsNull(item.StartDate);
            Assert.IsNull(item.EndDate);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "FilmingDate")]
        [DataRow("Movie", "ProductionDate")]
        public void RetrieveAdditionalInformationTest_withValidID(string value1, string value2)
        {
            // Arrange
            TimespanItem item = new TimespanItem("_xx1", "");
            item.BaseTableName = value1;
            item.TargetTableName = value2.Replace(" ", "");

            // Act
            int count = item.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(0, count);
        }

        [DataTestMethod()]
        [DataRow("Movie", "FilmingDate")]
        [DataRow("Movie", "ProductionDate")]
        public void RetrieveAdditionalInformationTest_withInvalidID(string value1, string value2)
        {
            // Arrange
            TimespanItem item = new TimespanItem("_aa1", "");
            item.BaseTableName = value1;
            item.TargetTableName = value2.Replace(" ", "");

            // Act
            int count = item.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(0, count);
        }

        [DataTestMethod()]
        [DataRow("Movie", "FilmingDate")]
        [DataRow("Movie", "ProductionDate")]
        public void RetrieveTest_withValidID_BasicInfoOnly(string value1, string value2)
        {
            // Arrange
            TimespanItem item = new TimespanItem("_xx1", "");
            item.BaseTableName = value1;
            item.TargetTableName = value2.Replace(" ", "");

            // Act
            int count = item.Retrieve(true);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xx1", item.ID);
            Assert.AreEqual($"{value1} {value2} StartDate X1", item.StartDate);
            Assert.AreEqual($"{value1} {value2} EndDate X1", item.EndDate);
            Assert.AreEqual($"{value1} {value2} Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{value1} {value2} LastUpdated X1", item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "FilmingDate")]
        [DataRow("Movie", "ProductionDate")]
        public void RetrieveTest_withValidID_AdditionalInfo(string value1, string value2)
        {
            // Arrange
            TimespanItem item = new TimespanItem("_xx1", "");
            item.BaseTableName = value1;
            item.TargetTableName = value2.Replace(" ", "");

            // Act
            int count = item.Retrieve(false);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xx1", item.ID);
            Assert.AreEqual($"{value1} {value2} StartDate X1", item.StartDate);
            Assert.AreEqual($"{value1} {value2} EndDate X1", item.EndDate);
            Assert.AreEqual($"{value1} {value2} Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{value1} {value2} LastUpdated X1", item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "FilmingDate")]
        [DataRow("Movie", "ProductionDate")]
        public void RetrieveTest_withInvalidID_BasicInfoOnly(string value1, string value2)
        {
            // Arrange
            TimespanItem item = new TimespanItem("_aa1", "");
            item.BaseTableName = value1;
            item.TargetTableName = value2.Replace(" ", "");

            // Act
            int count = item.Retrieve(true);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aa1", item.ID);
            Assert.IsNull(item.StartDate);
            Assert.IsNull(item.EndDate);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "FilmingDate")]
        [DataRow("Movie", "ProductionDate")]
        public void RetrieveTest_withInvalidID_AdditionalInfo(string value1, string value2)
        {
            // Arrange
            TimespanItem item = new TimespanItem("_aa1", "");
            item.BaseTableName = value1;
            item.TargetTableName = value2.Replace(" ", "");

            // Act
            int count = item.Retrieve(false);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aa1", item.ID);
            Assert.IsNull(item.StartDate);
            Assert.IsNull(item.EndDate);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "FilmingDate")]
        [DataRow("Movie", "ProductionDate")]
        public void RetrieveListTest_withValidData(string value1, string value2)
        {
            // Arrange
            DBReader reader = new SQLiteReader();

            // Act
            List<TimespanItem> list = Data.TimespanItem.RetrieveList(reader, value1, "_xxx", value2.Replace(" ", ""));

            // Assert
            Assert.AreEqual(3, list.Count);

            Assert.AreEqual("_xx1", list[0].ID);
            Assert.AreEqual($"{value1} {value2} StartDate X1", list[0].StartDate);
            Assert.AreEqual($"{value1} {value2} EndDate X1", list[0].EndDate);
            Assert.AreEqual($"{value1} {value2} Details X1", list[0].Details);
            Assert.AreEqual("_xxx", list[0].Status.ID);
            Assert.AreEqual($"{value1} {value2} LastUpdated X1", list[0].LastUpdated);

            Assert.AreEqual("_xx2", list[1].ID);
            Assert.AreEqual($"{value1} {value2} StartDate X2", list[1].StartDate);
            Assert.AreEqual($"{value1} {value2} EndDate X2", list[1].EndDate);
            Assert.AreEqual($"{value1} {value2} Details X2", list[1].Details);
            Assert.AreEqual("_xxx", list[1].Status.ID);
            Assert.AreEqual($"{value1} {value2} LastUpdated X2", list[1].LastUpdated);

            Assert.AreEqual("_xx3", list[2].ID);
            Assert.AreEqual($"{value1} {value2} StartDate X3", list[2].StartDate);
            Assert.AreEqual($"{value1} {value2} EndDate X3", list[2].EndDate);
            Assert.AreEqual($"{value1} {value2} Details X3", list[2].Details);
            Assert.AreEqual("_xxx", list[2].Status.ID);
            Assert.AreEqual($"{value1} {value2} LastUpdated X3", list[2].LastUpdated);
        }
    }
}
