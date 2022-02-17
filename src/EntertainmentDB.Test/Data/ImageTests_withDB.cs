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
    public class ImageTests_withDB
    {
        const string VALID_ID = "_xxx";
        const string INVALID_ID = "_aaa";

        // oblsolete
        [TestMethod()]
        public void ImageTest_checkEntry()
        {
            // Arrange
            Image entry = new Image();

            // Act
            // Assert
            Assert.IsNotNull(entry);
        }

        // oblsolete
        [TestMethod()]
        public void ImageTest_checkReader()
        {
            // Arrange
            Image entry = new Image();

            // Act
            // Assert
            Assert.IsNotNull(entry.Reader);
        }

        // oblsolete
        [TestMethod()]
        public void ImageTest_checkFileName()
        {
            // Arrange
            Image entry = new Image();

            // Act
            // Assert
            Assert.IsNull(entry.FileName);
        }

        // oblsolete
        [TestMethod()]
        public void ImageTest_checkDescription()
        {
            // Arrange
            Image entry = new Image();

            // Act
            // Assert
            Assert.IsNull(entry.Description);
        }

        // oblsolete
        [TestMethod()]
        public void ImageTest_checkType()
        {
            // Arrange
            Image entry = new Image();

            // Act
            // Assert
            Assert.IsNull(entry.Type);
        }

        // oblsolete
        [TestMethod()]
        public void ImageTest_checkCountry()
        {
            // Arrange
            Image entry = new Image();

            // Act
            // Assert
            Assert.IsNull(entry.Country);
        }

        // oblsolete
        [TestMethod()]
        public void ImageTest_checkDetails()
        {
            // Arrange
            Image entry = new Image();

            // Act
            // Assert
            Assert.IsNull(entry.Details);
        }

        // oblsolete
        [TestMethod()]
        public void ImageTest_checkStatus()
        {
            // Arrange
            Image entry = new Image();

            // Act
            // Assert
            Assert.IsNull(entry.Status);
        }

        // oblsolete
        [TestMethod()]
        public void ImageTest_checkLastUpdated()
        {
            // Arrange
            Image entry = new Image();

            // Act
            // Assert
            Assert.IsNull(entry.LastUpdated);
        }

        // oblsolete
        [TestMethod()]
        public void ImageTest_checkSources()
        {
            // Arrange
            Image entry = new Image();

            // Act
            // Assert
            Assert.IsNull(entry.Sources);
        }

        // oblsolete
        [TestMethod()]
        public void ImageTest_withoutID_checkID()
        {
            // Arrange
            Image entry = new Image();

            // Act
            // Assert
            Assert.AreEqual("", entry.ID);
        }

        // oblsolete
        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void ImageTest_withID_checkID(string value)
        {
            // Arrange
            Image entry = new Image(value);

            // Act
            // Assert
            Assert.AreEqual(value, entry.ID);
        }

        // oblsolete
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ImageTest_withIDnull_checkException()
        {
            // Arrange, Act, Assert
            Image entry = new Image(null);
        }

        // TODO: delete
        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveBasicInformationTest_withValidID(bool value)
        {
            // Arrange
            Image entry = new Image(VALID_ID);

            // Act
            int count = entry.RetrieveBasicInformation(value);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("Image FileName X", entry.FileName);
            Assert.AreEqual("Image Description X", entry.Description);
            Assert.AreEqual("_xxx", entry.Type.ID);
            Assert.AreEqual("_xxx", entry.Country.ID);
            Assert.AreEqual("Image Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Image LastUpdated X", entry.LastUpdated);

            Assert.IsNull(entry.Sources);
        }

        // TODO: delete
        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveBasicInformationTest_withInvalidID(bool value)
        {
            // Arrange
            Image entry = new Image(INVALID_ID);

            // Act
            int count = entry.RetrieveBasicInformation(value);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, entry.ID);
            Assert.IsNull(entry.FileName);
            Assert.IsNull(entry.Description);
            Assert.IsNull(entry.Type);
            Assert.IsNull(entry.Country);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);

            Assert.IsNull(entry.Sources);
        }

        // TODO: delete
        [TestMethod()]
        public void RetrieveAdditionalInformationTest_withValidID()
        {
            // Arrange
            Image entry = new Image(VALID_ID);

            // Act
            int count = entry.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(3, count);

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
            Image entry = new Image(INVALID_ID);

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
            Image entry = new Image(VALID_ID);

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
            Image entry = new Image(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("_xxx", entry.ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkFileName(bool value)
        {
            // Arrange
            Image entry = new Image(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Image FileName X", entry.FileName);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkDescription(bool value)
        {
            // Arrange
            Image entry = new Image(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Image Description X", entry.Description);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkType(bool value)
        {
            // Arrange
            Image entry = new Image(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("_xxx", entry.Type.ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkCountry(bool value)
        {
            // Arrange
            Image entry = new Image(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("_xxx", entry.Country.ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkDetails(bool value)
        {
            // Arrange
            Image entry = new Image(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Image Details X", entry.Details);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkStatus(bool value)
        {
            // Arrange
            Image entry = new Image(VALID_ID);

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
            Image entry = new Image(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Image LastUpdated X", entry.LastUpdated);
        }

        [TestMethod()]
        public void RetrieveTest_withValidID_BasicInfoOnly_checkSources()
        {
            // Arrange
            Image entry = new Image(VALID_ID);

            // Act
            int count = entry.Retrieve(true);

            // Assert
            Assert.IsNull(entry.Sources);
        }

        [TestMethod()]
        public void RetrieveTest_withValidID_AdditionalInfo_checkSources_checkCount()
        {
            // Arrange
            Image entry = new Image(VALID_ID);

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
            Image entry = new Image(VALID_ID);

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
            Image entry = new Image(INVALID_ID);

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
            Image entry = new Image(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual(INVALID_ID, entry.ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkFileName(bool value)
        {
            // Arrange
            Image entry = new Image(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.FileName);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkDescription(bool value)
        {
            // Arrange
            Image entry = new Image(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.Description);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkType(bool value)
        {
            // Arrange
            Image entry = new Image(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.Type);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkCountry(bool value)
        {
            // Arrange
            Image entry = new Image(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.Country);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkDetails(bool value)
        {
            // Arrange
            Image entry = new Image(INVALID_ID);

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
            Image entry = new Image(INVALID_ID);

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
            Image entry = new Image(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkSources(bool value)
        {
            // Arrange
            Image entry = new Image(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.Sources);   // TODO: empty list may be assigned; is that really the right thing?
        }
    }
}
