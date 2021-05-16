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
    public class CompanyItemTests
    {
        [TestMethod()]
        public void CompanyItemTest()
        {
            // Arrange
            CompanyItem item = new CompanyItem();

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.IsNotNull(item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual("", item.TargetTableName);

            Assert.AreEqual("", item.ID);
            Assert.IsNull(item.Company);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [TestMethod()]
        public void CompanyItemTest_withID()
        {
            // Arrange
            CompanyItem item = new CompanyItem("_xx1", "");

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.IsNotNull(item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual("", item.TargetTableName);

            Assert.AreEqual("_xx1", item.ID);
            Assert.IsNull(item.Company);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Company")]
        [DataRow("Source")]
        public void CompanyItemTest_withIDAndTargetTableName(string value)
        {
            // Arrange
            CompanyItem item = new CompanyItem("_xx1", value);

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.IsNotNull(item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual(value, item.TargetTableName);

            Assert.AreEqual("_xx1", item.ID);
            Assert.IsNull(item.Company);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Image", "Source")]
        [DataRow("Movie", "Production Company")]
        // TODO: Add more tests
        public void RetrieveBasicInformationTest_withValidID(string value1, string value2)
        {
            // Arrange
            CompanyItem item = new CompanyItem("_xx1", "");
            item.BaseTableName = value1;
            item.TargetTableName = value2.Replace(" ", "");

            // Act
            int count = item.RetrieveBasicInformation();

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xx1", item.ID);
            Assert.AreEqual("_xxx", item.Company.ID);
            Assert.AreEqual($"{value1} {value2} Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{value1} {value2} Last Updated X1", item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Image", "Source")]
        [DataRow("Movie", "Production Company")]
        // TODO: Add more tests
        public void RetrieveBasicInformationTest_withInvalidID(string value1, string value2)
        {
            // Arrange
            CompanyItem item = new CompanyItem("_aa1", "");
            item.BaseTableName = value1;
            item.TargetTableName = value2.Replace(" ", "");

            // Act
            int count = item.RetrieveBasicInformation();

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aa1", item.ID);
            Assert.IsNull(item.Company);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Image", "Source")]
        [DataRow("Movie", "Production Company")]
        // TODO: Add more tests
        public void RetrieveAdditionalInformationTest_withValidID(string value1, string value2)
        {
            // Arrange
            CompanyItem item = new CompanyItem("_xx1", "");
            item.BaseTableName = value1;
            item.TargetTableName = value2.Replace(" ", "");

            // Act
            int count = item.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(0, count);
        }

        [DataTestMethod()]
        [DataRow("Image", "Source")]
        [DataRow("Movie", "Production Company")]
        // TODO: Add more tests
        public void RetrieveAdditionalInformationTest_withInvalidID(string value1, string value2)
        {
            // Arrange
            CompanyItem item = new CompanyItem("_aa1", "");
            item.BaseTableName = value1;
            item.TargetTableName = value2.Replace(" ", "");

            // Act
            int count = item.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(0, count);
        }

        [DataTestMethod()]
        [DataRow("Image", "Source")]
        [DataRow("Movie", "Production Company")]
        // TODO: Add more tests
        public void RetrieveTest_withValidID(string value1, string value2)
        {
            // Arrange
            CompanyItem item = new CompanyItem("_xx1", "");
            item.BaseTableName = value1;
            item.TargetTableName = value2.Replace(" ", "");

            // Act
            int count = item.Retrieve();

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xx1", item.ID);
            Assert.AreEqual("_xxx", item.Company.ID);
            Assert.AreEqual($"{value1} {value2} Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{value1} {value2} Last Updated X1", item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Image", "Source")]
        [DataRow("Movie", "Production Company")]
        // TODO: Add more tests
        public void RetrieveTest_withInvalidID(string value1, string value2)
        {
            // Arrange
            CompanyItem item = new CompanyItem("_aa1", "");
            item.BaseTableName = value1;
            item.TargetTableName = value2.Replace(" ", "");

            // Act
            int count = item.Retrieve();

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aa1", item.ID);
            Assert.IsNull(item.Company);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Image", "Source")]
        [DataRow("Movie", "Production Company")]
        // TODO: Add more tests
        public void RetrieveListTest_withValidData(string value1, string value2)
        {
            // Arrange
            DBReader reader = new SQLiteReader();

            // Act
            List<CompanyItem> list = Data.CompanyItem.RetrieveList(reader, value1, "_xxx", value2.Replace(" ", ""));

            // Assert
            Assert.AreEqual(3, list.Count);

            Assert.AreEqual("_xx1", list[0].ID);
            Assert.AreEqual("_xxx", list[0].Company.ID);
            Assert.AreEqual($"{value1} {value2} Details X1", list[0].Details);
            Assert.AreEqual("_xxx", list[0].Status.ID);
            Assert.AreEqual($"{value1} {value2} Last Updated X1", list[0].LastUpdated);

            Assert.AreEqual("_xx2", list[1].ID);
            Assert.AreEqual("_yyy", list[1].Company.ID);
            Assert.AreEqual($"{value1} {value2} Details X2", list[1].Details);
            Assert.AreEqual("_xxx", list[1].Status.ID);
            Assert.AreEqual($"{value1} {value2} Last Updated X2", list[1].LastUpdated);

            Assert.AreEqual("_xx3", list[2].ID);
            Assert.AreEqual("_zzz", list[2].Company.ID);
            Assert.AreEqual($"{value1} {value2} Details X3", list[2].Details);
            Assert.AreEqual("_xxx", list[2].Status.ID);
            Assert.AreEqual($"{value1} {value2} Last Updated X3", list[2].LastUpdated);
        }
    }
}
