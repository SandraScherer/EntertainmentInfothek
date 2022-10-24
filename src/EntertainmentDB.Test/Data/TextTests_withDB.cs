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

namespace EntertainmentDB.Data.Tests
{
    [TestClass()]
    public class TextTests_withDB
    {
        const string VALID_ID = "_xxx";
        const string INVALID_ID = "_aaa";

        // oblsolete
        [TestMethod()]
        public void TextTest_checkEntry()
        {
            // Arrange
            Text entry = new Text();

            // Act
            // Assert
            Assert.IsNotNull(entry);
        }

        // oblsolete
        [TestMethod()]
        public void TextTest_checkReader()
        {
            // Arrange
            Text entry = new Text();

            // Act
            // Assert
            Assert.IsNotNull(entry.Reader);
        }

        // oblsolete
        [TestMethod()]
        public void TextTest_checkContent()
        {
            // Arrange
            Text entry = new Text();

            // Act
            // Assert
            Assert.IsNull(entry.Content);
        }

        // oblsolete
        [TestMethod()]
        public void TextTest_checkLanguage()
        {
            // Arrange
            Text entry = new Text();

            // Act
            // Assert
            Assert.IsNull(entry.Language);
        }

        // oblsolete
        [TestMethod()]
        public void TextTest_checkDetails()
        {
            // Arrange
            Text entry = new Text();

            // Act
            // Assert
            Assert.IsNull(entry.Details);
        }

        // oblsolete
        [TestMethod()]
        public void TextTest_checkStatus()
        {
            // Arrange
            Text entry = new Text();

            // Act
            // Assert
            Assert.IsNull(entry.Status);
        }

        // oblsolete
        [TestMethod()]
        public void TextTest_checkLastUpdated()
        {
            // Arrange
            Text entry = new Text();

            // Act
            // Assert
            Assert.IsNull(entry.LastUpdated);
        }

        // oblsolete
        [TestMethod()]
        public void TextTest_checkAuthors()
        {
            // Arrange
            Text entry = new Text();

            // Act
            // Assert
            Assert.IsNull(entry.Authors);
        }

        // oblsolete
        [TestMethod()]
        public void TextTest_checkSources()
        {
            // Arrange
            Text entry = new Text();

            // Act
            // Assert
            Assert.IsNull(entry.Sources);
        }

        // oblsolete
        [TestMethod()]
        public void TextTest_withoutID_checkID()
        {
            // Arrange
            Text entry = new Text();

            // Act
            // Assert
            Assert.AreEqual("", entry.ID);
        }

        // oblsolete
        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void TextTest_withID_checkID(string value)
        {
            // Arrange
            Text entry = new Text(value);

            // Act
            // Assert
            Assert.AreEqual(value, entry.ID);
        }

        // oblsolete
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TextTest_withIDnull_checkException()
        {
            // Arrange, Act, Assert
            Text entry = new Text(null);
        }




        // TODO: delete
        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveBasicInformationTest_withValidID(bool value)
        {
            // Arrange
            Text entry = new Text(VALID_ID);

            // Act
            int count = entry.RetrieveBasicInformation(value);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("Text Content X", entry.Content);
            Assert.AreEqual("_xxx", entry.Language.ID);
            Assert.AreEqual("Text Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Text LastUpdated X", entry.LastUpdated);

            Assert.IsNull(entry.Authors);
            Assert.IsNull(entry.Sources);
        }

        // TODO: delete
        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveBasicInformationTest_withInvalidID(bool value)
        {
            // Arrange
            Text entry = new Text(INVALID_ID);

            // Act
            int count = entry.RetrieveBasicInformation(value);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, entry.ID);
            Assert.IsNull(entry.Content);
            Assert.IsNull(entry.Language);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);

            Assert.IsNull(entry.Authors);
            Assert.IsNull(entry.Sources);
        }

        // TODO: delete
        [TestMethod()]
        public void RetrieveAdditionalInformationTest_withValidID()
        {
            // Arrange
            Text entry = new Text(VALID_ID);

            // Act
            int count = entry.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(2*3, count);

            Assert.AreEqual(3, entry.Authors.Count);
            Assert.AreEqual("_xx1", entry.Authors[0].ID);
            Assert.AreEqual("_xx2", entry.Authors[1].ID);
            Assert.AreEqual("_xx3", entry.Authors[2].ID);

            Assert.AreEqual(3, entry.Sources.Count);
            Assert.AreEqual("_xx1", entry.Sources[0].ID);
            Assert.AreEqual("_xx2", entry.Sources[1].ID);
            Assert.AreEqual("_xx3", entry.Sources[2].ID);
        }

        // TODO: delete
        [TestMethod()]
        public void RetrieveAdditionalInformationTest_withInvalidID()
        {
            // Arrange
            Text entry = new Text(INVALID_ID);

            // Act
            int count = entry.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(0, count);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkCount(bool value)
        {
            // Arrange
            Text entry = new Text(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual(1, count);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkID(bool value)
        {
            // Arrange
            Text entry = new Text(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("_xxx", entry.ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkContent(bool value)
        {
            // Arrange
            Text entry = new Text(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Text Content X", entry.Content);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkLanguage(bool value)
        {
            // Arrange
            Text entry = new Text(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("_xxx", entry.Language.ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkDetails(bool value)
        {
            // Arrange
            Text entry = new Text(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Text Details X", entry.Details);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkStatus(bool value)
        {
            // Arrange
            Text entry = new Text(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("_xxx", entry.Status.ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkLastUpdated(bool value)
        {
            // Arrange
            Text entry = new Text(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Text LastUpdated X", entry.LastUpdated);
        }

        [TestMethod()]
        public void RetrieveTest_withValidID_BasicInfoOnly_checkAuthors()
        {
            // Arrange
            Text entry = new Text(VALID_ID);

            // Act
            int count = entry.Retrieve(true);

            // Assert
            Assert.IsNull(entry.Authors);
        }

        [TestMethod()]
        public void RetrieveTest_withValidID_AdditionalInfo_checkAuthors_checkCount()
        {
            // Arrange
            Text entry = new Text(VALID_ID);

            // Act
            int count = entry.Retrieve(false);

            // Assert
            Assert.AreEqual(3, entry.Authors.Count);
        }

        [DataTestMethod()]
        [DataRow(0, "_xx1")]
        [DataRow(1, "_xx2")]
        [DataRow(2, "_xx3")]
        public void RetrieveTest_withValidID_AdditionalInfo_checkAuthors_checkIDs(int value1, string value2)
        {
            // Arrange
            Text entry = new Text(VALID_ID);

            // Act
            int count = entry.Retrieve(false);

            // Assert
            Assert.AreEqual(value2, entry.Authors[value1].ID);
        }

        [TestMethod()]
        public void RetrieveTest_withValidID_BasicInfoOnly_checkSources()
        {
            // Arrange
            Text entry = new Text(VALID_ID);

            // Act
            int count = entry.Retrieve(true);

            // Assert
            Assert.IsNull(entry.Sources);
        }

        [TestMethod()]
        public void RetrieveTest_withValidID_AdditionalInfo_checkSources_checkCount()
        {
            // Arrange
            Text entry = new Text(VALID_ID);

            // Act
            int count = entry.Retrieve(false);

            // Assert
            Assert.AreEqual(3, entry.Sources.Count);
        }

        [DataTestMethod()]
        [DataRow(0, "_xx1")]
        [DataRow(1, "_xx2")]
        [DataRow(2, "_xx3")]
        public void RetrieveTest_withValidID_AdditionalInfo_checkSources_checkIDs(int value1, string value2)
        {
            // Arrange
            Text entry = new Text(VALID_ID);

            // Act
            int count = entry.Retrieve(false);

            // Assert
            Assert.AreEqual(value2, entry.Sources[value1].ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkCount(bool value)
        {
            // Arrange
            Text entry = new Text(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual(0, count);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkID(bool value)
        {
            // Arrange
            Text entry = new Text(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual(INVALID_ID, entry.ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkContent(bool value)
        {
            // Arrange
            Text entry = new Text(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.Content);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkLanguage(bool value)
        {
            // Arrange
            Text entry = new Text(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.Language);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkDetails(bool value)
        {
            // Arrange
            Text entry = new Text(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.Details);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkStatus(bool value)
        {
            // Arrange
            Text entry = new Text(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.Status);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkLastUpdated(bool value)
        {
            // Arrange
            Text entry = new Text(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkAuthors(bool value)
        {
            // Arrange
            Text entry = new Text(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.Authors);   // TODO: empty list may be assigned; is that really the right thing?
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkSources(bool value)
        {
            // Arrange
            Text entry = new Text(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.Sources);   // TODO: empty list may be assigned; is that really the right thing?
        }
    }
}
