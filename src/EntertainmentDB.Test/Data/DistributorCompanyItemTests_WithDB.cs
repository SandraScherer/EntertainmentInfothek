﻿// EntertainmentDB.dll: Provides access to the EntertainmentInfothek.db
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
    public class DistributorCompanyItemTests_WithDB
    {
        const string VALID_ID = "_xx1";
        const string INVALID_ID = "_aa1";

        [TestMethod()]
        public void DistributorCompanyItemTest()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            DistributorCompanyItem item = new DistributorCompanyItem(reader);

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(reader, item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual("", item.TargetTableName);

            Assert.AreEqual("", item.ID);
            Assert.IsNull(item.Company);
            Assert.IsNull(item.Country);
            Assert.IsNull(item.ReleaseDate);
            Assert.IsNull(item.Role);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void DistributorCompanyItemTest_withID(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            DistributorCompanyItem item = new DistributorCompanyItem(reader, id, "BaseTable", "TargetTable");

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(reader, item.Reader);
            Assert.AreEqual("BaseTable", item.BaseTableName);
            Assert.AreEqual("TargetTable", item.TargetTableName);

            Assert.AreEqual(id, item.ID);
            Assert.IsNull(item.Company);
            Assert.IsNull(item.Country);
            Assert.IsNull(item.ReleaseDate);
            Assert.IsNull(item.Role);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DistributorCompanyItemTest_withReaderNull(string id)
        {
            // Arrange, Act, Assert
            DistributorCompanyItem item = new DistributorCompanyItem(null, id, "BaseTable", "TargetTable");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DistributorCompanyItemTest_withIDNull()
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            DistributorCompanyItem item = new DistributorCompanyItem(reader, null, "BaseTable", "TargetTable");
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DistributorCompanyItemTest_withBaseTableNameNull(string id)
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            DistributorCompanyItem item = new DistributorCompanyItem(reader, id, null, "TargetTable");
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DistributorCompanyItemTest_withTargetTableNameNull(string id)
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            DistributorCompanyItem item = new DistributorCompanyItem(reader, id, "BaseTable", null);
        }

        [DataTestMethod()]
        [DataRow("Movie", true)]
        [DataRow("Movie", false)]
        [DataRow("Series", true)]
        [DataRow("Series", false)]
        public void RetrieveTest_withValidID(string baseTableName, bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            DistributorCompanyItem item = new DistributorCompanyItem(reader, VALID_ID, baseTableName, "Distributor");

            // Act
            int count = item.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual(VALID_ID, item.ID);
            Assert.AreEqual("_xxx", item.Company.ID);
            Assert.AreEqual("_xxx", item.Country.ID);
            Assert.AreEqual($"{baseTableName} Distributor ReleaseDate X1", item.ReleaseDate);
            Assert.AreEqual($"{baseTableName} Distributor Role X1", item.Role);
            Assert.AreEqual($"{baseTableName} Distributor Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{baseTableName} Distributor LastUpdated X1", item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", true)]
        [DataRow("Movie", false)]
        [DataRow("Series", true)]
        [DataRow("Series", false)]
        public void RetrieveTest_withInvalidID(string baseTableName, bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            DistributorCompanyItem item = new DistributorCompanyItem(reader, INVALID_ID, baseTableName, "Distributor");

            // Act
            int count = item.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, item.ID);
            Assert.IsNull(item.Company);
            Assert.IsNull(item.Country);
            Assert.IsNull(item.ReleaseDate);
            Assert.IsNull(item.Role);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        [DataRow("Series")]
        public void RetrieveListTest_withValidData(string baseTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();

            // Act
            List<DistributorCompanyItem> list = Data.DistributorCompanyItem.RetrieveList(reader, baseTableName, "_xxx", "Distributor");

            // Assert
            Assert.AreEqual(3, list.Count);

            Assert.AreEqual("_xx1", list[0].ID);
            Assert.AreEqual("_xxx", list[0].Company.ID);
            Assert.AreEqual("_xxx", list[0].Country.ID);
            Assert.AreEqual($"{baseTableName} Distributor ReleaseDate X1", list[0].ReleaseDate);
            Assert.AreEqual($"{baseTableName} Distributor Role X1", list[0].Role);
            Assert.AreEqual($"{baseTableName} Distributor Details X1", list[0].Details);
            Assert.AreEqual("_xxx", list[0].Status.ID);
            Assert.AreEqual($"{baseTableName} Distributor LastUpdated X1", list[0].LastUpdated);

            Assert.AreEqual("_xx2", list[1].ID);
            Assert.AreEqual("_yyy", list[1].Company.ID);
            Assert.AreEqual("_xxx", list[1].Country.ID);
            Assert.AreEqual($"{baseTableName} Distributor ReleaseDate X2", list[1].ReleaseDate);
            Assert.AreEqual($"{baseTableName} Distributor Role X2", list[1].Role);
            Assert.AreEqual($"{baseTableName} Distributor Details X2", list[1].Details);
            Assert.AreEqual("_xxx", list[1].Status.ID);
            Assert.AreEqual($"{baseTableName} Distributor LastUpdated X2", list[1].LastUpdated);

            Assert.AreEqual("_xx3", list[2].ID);
            Assert.AreEqual("_zzz", list[2].Company.ID);
            Assert.AreEqual("_xxx", list[2].Country.ID);
            Assert.AreEqual($"{baseTableName} Distributor ReleaseDate X3", list[2].ReleaseDate);
            Assert.AreEqual($"{baseTableName} Distributor Role X3", list[2].Role);
            Assert.AreEqual($"{baseTableName} Distributor Details X3", list[2].Details);
            Assert.AreEqual("_xxx", list[2].Status.ID);
            Assert.AreEqual($"{baseTableName} Distributor LastUpdated X3", list[2].LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        [DataRow("Series")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RetrieveListTest_withReaderNull(string baseTableName)
        {
            // Arrange, Act, Assert
            List<DistributorCompanyItem> list = Data.DistributorCompanyItem.RetrieveList(null, baseTableName, "_xxx", "Distributor");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RetrieveListTest_withBaseTableNameNull()
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            List<DistributorCompanyItem> list = Data.DistributorCompanyItem.RetrieveList(reader, null, "_xxx", "Distributor");
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        [DataRow("Series")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RetrieveListTest_withBaseTableIDNull(string baseTableName)
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            List<DistributorCompanyItem> list = Data.DistributorCompanyItem.RetrieveList(reader, baseTableName, null, "Distributor");
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        [DataRow("Series")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RetrieveListTest_withTargetTableNameNull(string baseTableName)
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            List<DistributorCompanyItem> list = Data.DistributorCompanyItem.RetrieveList(reader, baseTableName, "_xxx", null);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        [DataRow("Series")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RetrieveListTest_withOrderNull(string baseTableName)
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            List<DistributorCompanyItem> list = Data.DistributorCompanyItem.RetrieveList(reader, baseTableName, "_xxx", "Distributor", null);
        }
    }
}
