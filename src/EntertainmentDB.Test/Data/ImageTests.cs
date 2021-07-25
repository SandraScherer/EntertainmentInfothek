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
    public class ImageTests
    {
        [TestMethod()]
        public void ImageTest()
        {
            // Arrange
            Image entry = new Image();

            // Act
            // Assert
            Assert.IsNotNull(entry);
            Assert.IsNotNull(entry.Reader);

            Assert.AreEqual("", entry.ID);
            Assert.IsNull(entry.FileName);
            Assert.IsNull(entry.Description);
            Assert.IsNull(entry.Type);
            Assert.IsNull(entry.Country);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);

            Assert.IsNull(entry.Sources);
        }

        [TestMethod()]
        public void ImageTest_withID()
        {
            // Arrange
            Image entry = new Image("_xxx");

            // Act
            // Assert
            Assert.IsNotNull(entry);
            Assert.IsNotNull(entry.Reader);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.IsNull(entry.FileName);
            Assert.IsNull(entry.Description);
            Assert.IsNull(entry.Type);
            Assert.IsNull(entry.Country);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);

            Assert.IsNull(entry.Sources);
        }

        [TestMethod()]
        public void RetrieveBasicInformationTest_withValidID_BasicInfoOnly()
        {
            // Arrange
            Image entry = new Image("_xxx");

            // Act
            int count = entry.RetrieveBasicInformation(true);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("Image File Name X", entry.FileName);
            Assert.AreEqual("Image Description X", entry.Description);
            Assert.AreEqual("_xxx", entry.Type.ID);
            Assert.AreEqual("_xxx", entry.Country.ID);
            Assert.AreEqual("Image Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Image Last Updated X", entry.LastUpdated);

            Assert.IsNull(entry.Sources);
        }

        [TestMethod()]
        public void RetrieveBasicInformationTest_withValidID_AdditionalInfo()
        {
            // Arrange
            Image entry = new Image("_xxx");

            // Act
            int count = entry.RetrieveBasicInformation(false);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("Image File Name X", entry.FileName);
            Assert.AreEqual("Image Description X", entry.Description);
            Assert.AreEqual("_xxx", entry.Type.ID);
            Assert.AreEqual("_xxx", entry.Country.ID);
            Assert.AreEqual("Image Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Image Last Updated X", entry.LastUpdated);

            Assert.IsNull(entry.Sources);
        }

        [TestMethod()]
        public void RetrieveBasicInformationTest_withInvalidID_BasicInfoOnly()
        {
            // Arrange
            Image entry = new Image("_aaa");

            // Act
            int count = entry.RetrieveBasicInformation(true);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aaa", entry.ID);
            Assert.IsNull(entry.FileName);
            Assert.IsNull(entry.Description);
            Assert.IsNull(entry.Type);
            Assert.IsNull(entry.Country);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);

            Assert.IsNull(entry.Sources);
        }

        [TestMethod()]
        public void RetrieveBasicInformationTest_withInvalidID_AdditionalInfo()
        {
            // Arrange
            Image entry = new Image("_aaa");

            // Act
            int count = entry.RetrieveBasicInformation(false);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aaa", entry.ID);
            Assert.IsNull(entry.FileName);
            Assert.IsNull(entry.Description);
            Assert.IsNull(entry.Type);
            Assert.IsNull(entry.Country);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);

            Assert.IsNull(entry.Sources);
        }

        [TestMethod()]
        public void RetrieveAdditionalInformationTest_withValidID()
        {
            // Arrange
            Image entry = new Image("_xxx");

            // Act
            int count = entry.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(3, count);

            Assert.AreEqual(3, entry.Sources.Count);
            Assert.AreEqual("_xx1", entry.Sources[0].ID);
            Assert.AreEqual("_xx2", entry.Sources[1].ID);
            Assert.AreEqual("_xx3", entry.Sources[2].ID);
        }

        [TestMethod()]
        public void RetrieveAdditionalInformationTest_withInvalidID()
        {
            // Arrange
            Image entry = new Image("_aaa");

            // Act
            int count = entry.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod()]
        public void RetrieveTest_withValidID_BasicInfoOnly()
        {
            // Arrange
            Image entry = new Image("_xxx");

            // Act
            int count = entry.Retrieve(true);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("Image File Name X", entry.FileName);
            Assert.AreEqual("Image Description X", entry.Description);
            Assert.AreEqual("_xxx", entry.Type.ID);
            Assert.AreEqual("_xxx", entry.Country.ID);
            Assert.AreEqual("Image Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Image Last Updated X", entry.LastUpdated);

            Assert.IsNull(entry.Sources);
        }

        [TestMethod()]
        public void RetrieveTest_withValidID_AdditionalInfo()
        {
            // Arrange
            Image entry = new Image("_xxx");

            // Act
            int count = entry.Retrieve(false);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("Image File Name X", entry.FileName);
            Assert.AreEqual("Image Description X", entry.Description);
            Assert.AreEqual("_xxx", entry.Type.ID);
            Assert.AreEqual("_xxx", entry.Country.ID);
            Assert.AreEqual("Image Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Image Last Updated X", entry.LastUpdated);

            Assert.AreEqual(3, entry.Sources.Count);
            Assert.AreEqual("_xx1", entry.Sources[0].ID);
            Assert.AreEqual("_xx2", entry.Sources[1].ID);
            Assert.AreEqual("_xx3", entry.Sources[2].ID);
        }

        [TestMethod()]
        public void RetrieveTest_withInvalidID_BasicInfoOnly()
        {
            // Arrange
            Image entry = new Image("_aaa");

            // Act
            int count = entry.Retrieve(true);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aaa", entry.ID);
            Assert.IsNull(entry.FileName);
            Assert.IsNull(entry.Description);
            Assert.IsNull(entry.Type);
            Assert.IsNull(entry.Country);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }

        [TestMethod()]
        public void RetrieveTest_withInvalidID_AdditionalInfo()
        {
            // Arrange
            Image entry = new Image("_aaa");

            // Act
            int count = entry.Retrieve(false);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aaa", entry.ID);
            Assert.IsNull(entry.FileName);
            Assert.IsNull(entry.Description);
            Assert.IsNull(entry.Type);
            Assert.IsNull(entry.Country);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }
    }
}
