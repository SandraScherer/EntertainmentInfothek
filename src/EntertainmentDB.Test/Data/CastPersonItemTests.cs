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
    public class CastPersonItemTests
    {
        [TestMethod()]
        public void CastPersonItemTest()
        {
            // Arrange
            CastPersonItem item = new CastPersonItem();

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.IsNotNull(item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual("", item.TargetTableName);

            Assert.AreEqual("", item.ID);
            Assert.IsNull(item.Actor);
            Assert.IsNull(item.GermanDubber);
            Assert.IsNull(item.Character);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [TestMethod()]
        public void CastPersonItemTest_withID()
        {
            // Arrange
            CastPersonItem item = new CastPersonItem("_xx1", "");

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.IsNotNull(item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual("", item.TargetTableName);

            Assert.AreEqual("_xx1", item.ID);
            Assert.IsNull(item.Actor);
            Assert.IsNull(item.GermanDubber);
            Assert.IsNull(item.Character);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "Cast")]
        public void RetrieveBasicInformationTest_withValidID_BasicInfoOnly(string value, string value2)
        {
            // Arrange
            CastPersonItem item = new CastPersonItem("_xx1", value2);
            item.BaseTableName = value;

            // Act
            int count = item.RetrieveBasicInformation(true);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xx1", item.ID);
            Assert.AreEqual("_xxx", item.Actor.ID);
            Assert.AreEqual("_xxx", item.GermanDubber.ID);
            Assert.AreEqual($"{value} {value2} Character X1", item.Character);
            Assert.AreEqual($"{value} {value2} Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{value} {value2} LastUpdated X1", item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "Cast")]
        public void RetrieveBasicInformationTest_withValidID_AdditionalInfo(string value, string value2)
        {
            // Arrange
            CastPersonItem item = new CastPersonItem("_xx1", value2);
            item.BaseTableName = value;

            // Act
            int count = item.RetrieveBasicInformation(false);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xx1", item.ID);
            Assert.AreEqual("_xxx", item.Actor.ID);
            Assert.AreEqual("_xxx", item.GermanDubber.ID);
            Assert.AreEqual($"{value} {value2} Character X1", item.Character);
            Assert.AreEqual($"{value} {value2} Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{value} {value2} LastUpdated X1", item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "Cast")]
        public void RetrieveBasicInformationTest_withInvalidID_BasicInfoOnly(string value, string value2)
        {
            // Arrange
            CastPersonItem item = new CastPersonItem("_aa1", value2);
            item.BaseTableName = value;

            // Act
            int count = item.RetrieveBasicInformation(true);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aa1", item.ID);
            Assert.IsNull(item.Actor);
            Assert.IsNull(item.GermanDubber);
            Assert.IsNull(item.Character);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "Cast")]
        public void RetrieveBasicInformationTest_withInvalidID_AdditionalInfo(string value, string value2)
        {
            // Arrange
            CastPersonItem item = new CastPersonItem("_aa1", value2);
            item.BaseTableName = value;

            // Act
            int count = item.RetrieveBasicInformation(false);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aa1", item.ID);
            Assert.IsNull(item.Actor);
            Assert.IsNull(item.GermanDubber);
            Assert.IsNull(item.Character);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "Cast")]
        public void RetrieveAdditionalInformationTest_withValidID(string value, string value2)
        {
            // Arrange
            CastPersonItem item = new CastPersonItem("_xx1", value2);
            item.BaseTableName = value;

            // Act
            int count = item.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(0, count);
        }

        [DataTestMethod()]
        [DataRow("Movie", "Cast")]
        public void RetrieveAdditionalInformationTest_withInvalidID(string value, string value2)
        {
            // Arrange
            CastPersonItem item = new CastPersonItem("_aa1", value2);
            item.BaseTableName = value;

            // Act
            int count = item.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(0, count);
        }

        [DataTestMethod()]
        [DataRow("Movie", "Cast")]
        public void RetrieveTest_withValidID_BasicInfoOnly(string value, string value2)
        {
            // Arrange
            CastPersonItem item = new CastPersonItem("_xx1", value2);
            item.BaseTableName = value;

            // Act
            int count = item.Retrieve(true);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xx1", item.ID);
            Assert.AreEqual("_xxx", item.Actor.ID);
            Assert.AreEqual("_xxx", item.GermanDubber.ID);
            Assert.AreEqual($"{value} {value2} Character X1", item.Role);
            Assert.AreEqual($"{value} {value2} Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{value} {value2} LastUpdated X1", item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "Cast")]
        public void RetrieveTest_withValidID_AdditionalInfo(string value, string value2)
        {
            // Arrange
            CastPersonItem item = new CastPersonItem("_xx1", value2);
            item.BaseTableName = value;

            // Act
            int count = item.Retrieve(false);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xx1", item.ID);
            Assert.AreEqual("_xxx", item.Actor.ID);
            Assert.AreEqual("_xxx", item.GermanDubber.ID);
            Assert.AreEqual($"{value} {value2} Character X1", item.Role);
            Assert.AreEqual($"{value} {value2} Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{value} {value2} LastUpdated X1", item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "Cast")]
        public void RetrieveTest_withInvalidID_BasicInfoOnly(string value, string value2)
        {
            // Arrange
            CastPersonItem item = new CastPersonItem("_aa1", value2);
            item.BaseTableName = value;

            // Act
            int count = item.Retrieve(true);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aa1", item.ID);
            Assert.IsNull(item.Actor);
            Assert.IsNull(item.GermanDubber);
            Assert.IsNull(item.Character);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "Cast")]
        public void RetrieveTest_withInvalidID_AdditionalInfo(string value, string value2)
        {
            // Arrange
            CastPersonItem item = new CastPersonItem("_aa1", value2);
            item.BaseTableName = value;

            // Act
            int count = item.Retrieve(false);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aa1", item.ID);
            Assert.IsNull(item.Actor);
            Assert.IsNull(item.GermanDubber);
            Assert.IsNull(item.Character);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "Cast")]
        public void RetrieveListTest_withValidData(string value, string value2)
        {
            // Arrange
            DBReader reader = new SQLiteReader();

            // Act
            List<CastPersonItem> list = Data.CastPersonItem.RetrieveList(reader, value, "_xxx", value2);

            // Assert
            Assert.AreEqual(3, list.Count);

            Assert.AreEqual("_xx1", list[0].ID);
            Assert.AreEqual("_xxx", list[0].Actor.ID);
            Assert.AreEqual("_xxx", list[0].GermanDubber.ID);
            Assert.AreEqual($"{value} {value2} Character X1", list[0].Character);
            Assert.AreEqual($"{value} {value2} Details X1", list[0].Details);
            Assert.AreEqual("_xxx", list[0].Status.ID);
            Assert.AreEqual($"{value} {value2} LastUpdated X1", list[0].LastUpdated);

            Assert.AreEqual("_xx2", list[1].ID);
            Assert.AreEqual("_yyy", list[1].Actor.ID);
            Assert.AreEqual("_xxx", list[1].GermanDubber.ID);
            Assert.AreEqual($"{value} {value2} Character X2", list[1].Character);
            Assert.AreEqual($"{value} {value2} Details X2", list[1].Details);
            Assert.AreEqual("_xxx", list[1].Status.ID);
            Assert.AreEqual($"{value} {value2} LastUpdated X2", list[1].LastUpdated);

            Assert.AreEqual("_xx3", list[2].ID);
            Assert.AreEqual("_zzz", list[2].Actor.ID);
            Assert.AreEqual("_xxx", list[2].GermanDubber.ID);
            Assert.AreEqual($"{value} {value2} Character X3", list[2].Character);
            Assert.AreEqual($"{value} {value2} Details X3", list[2].Details);
            Assert.AreEqual("_xxx", list[2].Status.ID);
            Assert.AreEqual($"{value} {value2} LastUpdated X3", list[2].LastUpdated);
        }
    }
}
