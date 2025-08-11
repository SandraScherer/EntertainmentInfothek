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
    public class CompanyItemTests_WithDB
    {
        const string VALID_ID = "_xx1";
        const string INVALID_ID = "_aa1";

        [TestMethod()]
        public void CompanyItemTest()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CompanyItem item = new CompanyItem(reader);

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(reader, item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual("", item.TargetTableName);

            Assert.AreEqual("", item.ID);
            Assert.IsNull(item.Company);
            Assert.IsNull(item.Role);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void CompanyItemTest_withID(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CompanyItem item = new CompanyItem(reader, id, "BaseTable", "TargetTable");

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(reader, item.Reader);
            Assert.AreEqual("BaseTable", item.BaseTableName);
            Assert.AreEqual("TargetTable", item.TargetTableName);

            Assert.AreEqual(id, item.ID);
            Assert.IsNull(item.Company);
            Assert.IsNull(item.Role);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void CompanyItemTest_withReaderNull(string id)
        {
            // Arrange
            CompanyItem item;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => item = new CompanyItem(null, id, "BaseTable", "TargetTable"));
        }

        [TestMethod()]
        public void CompanyItemTest_withIDNull()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CompanyItem item;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => item = new CompanyItem(reader, null, "BaseTable", "TargetTable"));
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void CompanyItemTest_withBaseTableNameNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CompanyItem item;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => item = new CompanyItem(reader, id, null, "TargetTable"));
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void CompanyItemTest_withTargetTableNameNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CompanyItem item;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => item = new CompanyItem(reader, id, "BaseTable", null));
        }

        [TestMethod()]
        [DataRow("Image", "Source", true)]
        [DataRow("Image", "Source", false)]
        [DataRow("Movie", "ProductionCompany", true)]
        [DataRow("Movie", "ProductionCompany", false)]
        [DataRow("Movie", "SpecialEffectsCompany", true)]
        [DataRow("Movie", "SpecialEffectsCompany", false)]
        [DataRow("Movie", "OtherCompany", true)]
        [DataRow("Movie", "OtherCompany", false)]
        [DataRow("Series", "ProductionCompany", true)]
        [DataRow("Series", "ProductionCompany", false)]
        [DataRow("Series", "SpecialEffectsCompany", true)]
        [DataRow("Series", "SpecialEffectsCompany", false)]
        [DataRow("Series", "OtherCompany", true)]
        [DataRow("Series", "OtherCompany", false)]
        public void RetrieveTest_withValidID(string baseTableName, string targetTableName, bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CompanyItem item = new CompanyItem(reader, VALID_ID, baseTableName, targetTableName);

            // Act
            int count = item.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual(VALID_ID, item.ID);
            Assert.AreEqual("_xxx", item.Company.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} Role X1", item.Role);
            Assert.AreEqual($"{baseTableName} {targetTableName} Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} LastUpdated X1", item.LastUpdated);
        }

        [TestMethod()]
        [DataRow("Image", "Source", true)]
        [DataRow("Image", "Source", false)]
        [DataRow("Movie", "ProductionCompany", true)]
        [DataRow("Movie", "ProductionCompany", false)]
        [DataRow("Movie", "SpecialEffectsCompany", true)]
        [DataRow("Movie", "SpecialEffectsCompany", false)]
        [DataRow("Movie", "OtherCompany", true)]
        [DataRow("Movie", "OtherCompany", false)]
        [DataRow("Series", "ProductionCompany", true)]
        [DataRow("Series", "ProductionCompany", false)]
        [DataRow("Series", "SpecialEffectsCompany", true)]
        [DataRow("Series", "SpecialEffectsCompany", false)]
        [DataRow("Series", "OtherCompany", true)]
        [DataRow("Series", "OtherCompany", false)]
        public void RetrieveTest_withInvalidID(string baseTableName, string targetTableName, bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CompanyItem item = new CompanyItem(reader, INVALID_ID, baseTableName, targetTableName);

            // Act
            int count = item.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, item.ID);
            Assert.IsNull(item.Company);
            Assert.IsNull(item.Role);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [TestMethod()]
        [DataRow("Image", "Source")]
        [DataRow("Movie", "ProductionCompany")]
        [DataRow("Movie", "SpecialEffectsCompany")]
        [DataRow("Movie", "OtherCompany")]
        [DataRow("Series", "ProductionCompany")]
        [DataRow("Series", "SpecialEffectsCompany")]
        [DataRow("Series", "OtherCompany")]
        public void RetrieveListTest_withValidData(string baseTableName, string targetTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();

            // Act
            List<CompanyItem> list = Data.CompanyItem.RetrieveList(reader, baseTableName, "_xxx", targetTableName);

            // Assert
            Assert.AreEqual(3, list.Count);

            Assert.AreEqual("_xx1", list[0].ID);
            Assert.AreEqual("_xxx", list[0].Company.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} Role X1", list[0].Role);
            Assert.AreEqual($"{baseTableName} {targetTableName} Details X1", list[0].Details);
            Assert.AreEqual("_xxx", list[0].Status.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} LastUpdated X1", list[0].LastUpdated);

            Assert.AreEqual("_xx2", list[1].ID);
            Assert.AreEqual("_yyy", list[1].Company.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} Role X2", list[1].Role);
            Assert.AreEqual($"{baseTableName} {targetTableName} Details X2", list[1].Details);
            Assert.AreEqual("_xxx", list[1].Status.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} LastUpdated X2", list[1].LastUpdated);

            Assert.AreEqual("_xx3", list[2].ID);
            Assert.AreEqual("_zzz", list[2].Company.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} Role X3", list[2].Role);
            Assert.AreEqual($"{baseTableName} {targetTableName} Details X3", list[2].Details);
            Assert.AreEqual("_xxx", list[2].Status.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} LastUpdated X3", list[2].LastUpdated);
        }

        [TestMethod()]
        [DataRow("Image", "Source")]
        [DataRow("Movie", "ProductionCompany")]
        [DataRow("Movie", "SpecialEffectsCompany")]
        [DataRow("Movie", "OtherCompany")]
        [DataRow("Series", "ProductionCompany")]
        [DataRow("Series", "SpecialEffectsCompany")]
        [DataRow("Series", "OtherCompany")]
        public void RetrieveListTest_withReaderNull(string baseTableName, string targetTableName)
        {
            // Arrange
            List<CompanyItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.CompanyItem.RetrieveList(null, baseTableName, "_xxx", targetTableName));

        }

        [TestMethod()]
        [DataRow("Image", "Source")]
        [DataRow("Movie", "ProductionCompany")]
        [DataRow("Movie", "SpecialEffectsCompany")]
        [DataRow("Movie", "OtherCompany")]
        [DataRow("Series", "ProductionCompany")]
        [DataRow("Series", "SpecialEffectsCompany")]
        [DataRow("Series", "OtherCompany")]
        public void RetrieveListTest_withBaseTableNameNull(string baseTableName, string targetTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<CompanyItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.CompanyItem.RetrieveList(reader, null, "_xxx", targetTableName));
        }

        [TestMethod()]
        [DataRow("Image", "Source")]
        [DataRow("Movie", "ProductionCompany")]
        [DataRow("Movie", "SpecialEffectsCompany")]
        [DataRow("Movie", "OtherCompany")]
        [DataRow("Series", "ProductionCompany")]
        [DataRow("Series", "SpecialEffectsCompany")]
        [DataRow("Series", "OtherCompany")]
        public void RetrieveListTest_withBaseTableIDNull(string baseTableName, string targetTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<CompanyItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.CompanyItem.RetrieveList(reader, baseTableName, null, targetTableName));
        }

        [TestMethod()]
        [DataRow("Image", "Source")]
        [DataRow("Movie", "ProductionCompany")]
        [DataRow("Movie", "SpecialEffectsCompany")]
        [DataRow("Movie", "OtherCompany")]
        [DataRow("Series", "ProductionCompany")]
        [DataRow("Series", "SpecialEffectsCompany")]
        [DataRow("Series", "OtherCompany")]
        public void RetrieveListTest_withTargetTableNameNull(string baseTableName, string targetTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<CompanyItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.CompanyItem.RetrieveList(reader, baseTableName, "_xxx", null));
        }

        [TestMethod()]
        [DataRow("Image", "Source")]
        [DataRow("Movie", "ProductionCompany")]
        [DataRow("Movie", "SpecialEffectsCompany")]
        [DataRow("Movie", "OtherCompany")]
        [DataRow("Series", "ProductionCompany")]
        [DataRow("Series", "SpecialEffectsCompany")]
        [DataRow("Series", "OtherCompany")]
        public void RetrieveListTest_withOrderNull(string baseTableName, string targetTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<CompanyItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.CompanyItem.RetrieveList(reader, baseTableName, "_xxx", targetTableName, null));
        }
    }
}
