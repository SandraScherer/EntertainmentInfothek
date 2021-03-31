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
    public class RuntimeItemTests
    {
        [TestMethod()]
        public void RuntimeItemTest()
        {
            // Arrange
            RuntimeItem item = new RuntimeItem();

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.IsNotNull(item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual("Runtime", item.TargetTableName);

            Assert.AreEqual("", item.ID);
            Assert.AreEqual(0, item.Runtime);
            Assert.IsNull(item.Edition);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [TestMethod()]
        public void RuntimeItemTest_withID()
        {
            // Arrange
            RuntimeItem item = new RuntimeItem("_xx1");

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.IsNotNull(item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual("Runtime", item.TargetTableName);

            Assert.AreEqual("_xx1", item.ID);
            Assert.AreEqual(0, item.Runtime);
            Assert.IsNull(item.Edition);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveBasicInformationTest_withValidID(string value)
        {
            // Arrange
            RuntimeItem item = new RuntimeItem("_xx1");
            item.BaseTableName = value;

            // Act
            int count = item.RetrieveBasicInformation();

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xx1", item.ID);
            Assert.AreEqual(1, item.Runtime);
            Assert.AreEqual("_xxx", item.Edition.ID);
            Assert.AreEqual($"{value} Runtime Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{value} Runtime Last Updated X1", item.LastUpdated);
        }


        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveBasicInformationTest_withInvalidID(string value)
        {
            // Arrange
            RuntimeItem item = new RuntimeItem("_aa1");
            item.BaseTableName = value;

            // Act
            int count = item.RetrieveBasicInformation();

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aa1", item.ID);
            Assert.AreEqual(0, item.Runtime);
            Assert.IsNull(item.Edition);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveAdditionalInformationTest_withValidID(string value)
        {
            // Arrange
            RuntimeItem item = new RuntimeItem("_xx1");
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
            RuntimeItem item = new RuntimeItem("_aa1");
            item.BaseTableName = value;

            // Act
            int count = item.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(0, count);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveTest_withValidID(string value)
        {
            // Arrange
            RuntimeItem item = new RuntimeItem("_xx1");
            item.BaseTableName = value;

            // Act
            int count = item.Retrieve();

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xx1", item.ID);
            Assert.AreEqual(1, item.Runtime);
            Assert.AreEqual("_xxx", item.Edition.ID);
            Assert.AreEqual($"{value} Runtime Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{value} Runtime Last Updated X1", item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveTest_withInvalidID(string value)
        {
            // Arrange
            RuntimeItem item = new RuntimeItem("_aa1");
            item.BaseTableName = value;

            // Act
            int count = item.Retrieve();

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aa1", item.ID);
            Assert.AreEqual(0, item.Runtime);
            Assert.IsNull(item.Edition);
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
            List<RuntimeItem> list = Data.RuntimeItem.RetrieveList(reader, value, "_xxx");

            // Assert
            Assert.AreEqual(3, list.Count);

            Assert.AreEqual("_xx1", list[0].ID);
            Assert.AreEqual(1, list[0].Runtime);
            Assert.AreEqual("_xxx", list[0].Edition.ID);
            Assert.AreEqual($"{value} Runtime Details X1", list[0].Details);
            Assert.AreEqual("_xxx", list[0].Status.ID);
            Assert.AreEqual($"{value} Runtime Last Updated X1", list[0].LastUpdated);

            Assert.AreEqual("_xx2", list[1].ID);
            Assert.AreEqual(0, list[1].Runtime);
            Assert.AreEqual("_yyy", list[1].Edition.ID);
            Assert.AreEqual($"{value} Runtime Details X2", list[1].Details);
            Assert.AreEqual("_xxx", list[1].Status.ID);
            Assert.AreEqual($"{value} Runtime Last Updated X2", list[1].LastUpdated);

            Assert.AreEqual("_xx3", list[2].ID);
            Assert.AreEqual(0, list[2].Runtime);
            Assert.AreEqual("_zzz", list[2].Edition.ID);
            Assert.AreEqual($"{value} Runtime Details X3", list[2].Details);
            Assert.AreEqual("_xxx", list[2].Status.ID);
            Assert.AreEqual($"{value} Runtime Last Updated X3", list[2].LastUpdated);
        }
    }
}
