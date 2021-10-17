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
    public class TextTests
    {
        [TestMethod()]
        public void TextTest()
        {
            // Arrange
            Text entry = new Text();

            // Act
            // Assert
            Assert.IsNotNull(entry);
            Assert.IsNotNull(entry.Reader);

            Assert.AreEqual("", entry.ID);
            Assert.IsNull(entry.Content);
            Assert.IsNull(entry.Language);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);

            Assert.IsNull(entry.Authors);
            Assert.IsNull(entry.Sources);
        }

        [TestMethod()]
        public void TextTest_withID()
        {
            // Arrange
            Text entry = new Text("_xxx");

            // Act
            // Assert
            Assert.IsNotNull(entry);
            Assert.IsNotNull(entry.Reader);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.IsNull(entry.Content);
            Assert.IsNull(entry.Language);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);

            Assert.IsNull(entry.Authors);
            Assert.IsNull(entry.Sources);
        }

        [TestMethod()]
        public void RetrieveBasicInformationTest_withValidID_BasicInfoOnly()
        {
            // Arrange
            Text entry = new Text("_xxx");

            // Act
            int count = entry.RetrieveBasicInformation(true);

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

        [TestMethod()]
        public void RetrieveBasicInformationTest_withValidID_AdditionalInfo()
        {
            // Arrange
            Text entry = new Text("_xxx");

            // Act
            int count = entry.RetrieveBasicInformation(false);

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

        [TestMethod()]
        public void RetrieveBasicInformationTest_withInvalidID_BasicInfoOnly()
        {
            // Arrange
            Text entry = new Text("_aaa");

            // Act
            int count = entry.RetrieveBasicInformation(true);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aaa", entry.ID);
            Assert.IsNull(entry.Content);
            Assert.IsNull(entry.Language);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);

            Assert.IsNull(entry.Authors);
            Assert.IsNull(entry.Sources);
        }

        [TestMethod()]
        public void RetrieveBasicInformationTest_withInvalidID_AdditionalInfo()
        {
            // Arrange
            Text entry = new Text("_aaa");

            // Act
            int count = entry.RetrieveBasicInformation(false);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aaa", entry.ID);
            Assert.IsNull(entry.Content);
            Assert.IsNull(entry.Language);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);

            Assert.IsNull(entry.Authors);
            Assert.IsNull(entry.Sources);
        }

        [TestMethod()]
        public void RetrieveAdditionalInformationTest_withValidID()
        {
            // Arrange
            Text entry = new Text("_xxx");

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

        [TestMethod()]
        public void RetrieveAdditionalInformationTest_withInvalidID()
        {
            // Arrange
            Text entry = new Text("_aaa");

            // Act
            int count = entry.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod()]
        public void RetrieveTest_withValidID_BasicInfoOnly()
        {
            // Arrange
            Text entry = new Text("_xxx");

            // Act
            int count = entry.Retrieve(true);

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

        [TestMethod()]
        public void RetrieveTest_withValidID_AdditionalInfo()
        {
            // Arrange
            Text entry = new Text("_xxx");

            // Act
            int count = entry.Retrieve(false);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("Text Content X", entry.Content);
            Assert.AreEqual("_xxx", entry.Language.ID);
            Assert.AreEqual("Text Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Text LastUpdated X", entry.LastUpdated);

            Assert.AreEqual(3, entry.Authors.Count);
            Assert.AreEqual("_xx1", entry.Authors[0].ID);
            Assert.AreEqual("_xx2", entry.Authors[1].ID);
            Assert.AreEqual("_xx3", entry.Authors[2].ID);

            Assert.AreEqual(3, entry.Sources.Count);
            Assert.AreEqual("_xx1", entry.Sources[0].ID);
            Assert.AreEqual("_xx2", entry.Sources[1].ID);
            Assert.AreEqual("_xx3", entry.Sources[2].ID);
        }

        [TestMethod()]
        public void RetrieveTest_withInvalidID_BasicInfoOnly()
        {
            // Arrange
            Text entry = new Text("_aaa");

            // Act
            int count = entry.Retrieve(true);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aaa", entry.ID);
            Assert.IsNull(entry.Content);
            Assert.IsNull(entry.Language);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);

            Assert.IsNull(entry.Authors);
            Assert.IsNull(entry.Sources);
        }

        [TestMethod()]
        public void RetrieveTest_withInvalidID_AdditionalInfo()
        {
            // Arrange
            Text entry = new Text("_aaa");

            // Act
            int count = entry.Retrieve(false);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aaa", entry.ID);
            Assert.IsNull(entry.Content);
            Assert.IsNull(entry.Language);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);

            Assert.AreEqual(0, entry.Authors.Count);
            Assert.AreEqual(0, entry.Sources.Count);
        }
    }
}
