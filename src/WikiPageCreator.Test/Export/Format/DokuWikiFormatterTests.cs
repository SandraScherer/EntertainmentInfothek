// WikiPageCreator.exe: Creates pages for use with a wiki from the
// EntertainmentInfothek.db using EntertainmentDB.dll
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
using System;

namespace WikiPageCreator.Export.Format.Tests
{
    [TestClass()]
    public class DokuWikiFormatterTests
    {
        [TestMethod()]
        public void DokuWikiFormatterTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            // Assert
            Assert.IsNotNull(formatter);
        }

        [TestMethod()]
        public void AsFilenameTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.AsFilename("THIS IS A TEST+ FOR A FILE/NAME WITH% DIFFERENT* SPECIAL& CHARACTERS! ESPECIALLY# GERMAN= ONES: Ä, Ö, Ü, ß?");

            // Assert
            Assert.AreEqual("this_is_a_test__for_a_file_name_with__different__special__characters__especially__german__ones_a_o_u_s_.txt", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsFilenameTest_withPagenameNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsFilename(null);
        }

        [TestMethod()]
        public void AsBoldTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.AsBold("text");

            // Assert
            Assert.AreEqual("**text**", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsBoldTest_withTextNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsBold(null);
        }

        [TestMethod()]
        public void AsItalicTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.AsItalic("text");

            // Assert
            Assert.AreEqual("//text//", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsItalicTest_withTextNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsItalic(null);
        }

        [TestMethod()]
        public void AsUnderlinedTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.AsUnderlined("text");

            // Assert
            Assert.AreEqual("__text__", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsUnderlinedTest_withTextNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsUnderlined(null);
        }

        [TestMethod()]
        public void AsSubscriptTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.AsSubscript("text");

            // Assert
            Assert.AreEqual("<sub>text</sub>", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsSubscriptTest_withTextNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsSubscript(null);
        }

        [TestMethod()]
        public void AsSuperscriptTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.AsSuperscript("text");

            // Assert
            Assert.AreEqual("<sup>text</sup>", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsSuperscriptTest_withTextNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsSuperscript(null);
        }

        [TestMethod()]
        public void AsDeletedTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.AsDeleted("text");

            // Assert
            Assert.AreEqual("<del>text</del>", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsDeletedTest_withTextNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsDeleted(null);
        }

        [TestMethod()]
        public void AsInternalLink4ParametersTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsInternalLink(path, "pagename", "section", "text");

            // Assert
            Assert.AreEqual("[[path1:path2:pagename#section|text]]", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsInternalLink4ParametersTest_withPathNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsInternalLink(null, "pagename", "section", "text");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsInternalLink4ParametersTest_withPageNameNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsInternalLink(path, null, "section", "text");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsInternalLink4ParametersTest_withSectionNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsInternalLink(path, "pagename", null, "text");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsInternalLink4ParametersTest_withTextNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsInternalLink(path, "pagename", "section", null);
        }

        [TestMethod()]
        public void AsInternalLink3ParametersTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsInternalLink(path, "pagename", "text");

            // Assert
            Assert.AreEqual("[[path1:path2:pagename|text]]", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsInternalLink3ParametersTest_withPathNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string[] path = null;
            string returnstring = formatter.AsInternalLink(path, "pagename", "text");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsInternalLink3ParametersTest_withPagenameNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsInternalLink(path, null, "text");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsInternalLink3ParametersTest_withTextNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsInternalLink(path, "pagename", null);
        }

        [TestMethod()]
        public void AsInternalLink2ParametersTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsInternalLink(path, "pagename");

            // Assert
            Assert.AreEqual("[[path1:path2:pagename]]", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsInternalLink2ParametersTest_withPathNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string[] path = null;
            string returnstring = formatter.AsInternalLink(path, "pagename");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsInternalLink2ParametersTest_withPagenameNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsInternalLink(path, null);
        }

        [TestMethod()]
        public void AsInternalLink3Parameters2Test()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.AsInternalLink("pagename", "section", "text");

            // Assert
            Assert.AreEqual("[[pagename#section|text]]", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsInternalLink3Parameters2Test_withPagenameNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string pagename = null;
            string returnstring = formatter.AsInternalLink(pagename, "section", "text");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsInternalLink3Parameters2Test_withSectionNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsInternalLink("pagename", null, "text");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsInternalLink3Parameters2Test_withTextNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsInternalLink("pagename", "section", null);
        }

        [TestMethod()]
        public void AsInternalLink2Parameters2Test()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.AsInternalLink("pagename", "text");

            // Assert
            Assert.AreEqual("[[pagename|text]]", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsInternalLink2Parameters2Test_withPagenameNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string pagename = null;
            string returnstring = formatter.AsInternalLink(pagename, "text");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsInternalLink2Parameters2Test_withTextNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsInternalLink("pagename", null);
        }

        [TestMethod()]
        public void AsInternalLink1ParameterTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.AsInternalLink("pagename");

            // Assert
            Assert.AreEqual("[[pagename]]", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsInternalLink1ParameterTest_withPagenameNul()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsInternalLink(null);
        }

        [TestMethod()]
        public void AsExternalLink2ParametersTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.AsExternalLink("link", "text");

            // Assert
            Assert.AreEqual("[[link|text]]", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsExternalLink2ParametersTest_withLinkNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsExternalLink(null, "text");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsExternalLink2ParametersTest_withTextNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsExternalLink("link", null);
        }

        [TestMethod()]
        public void AsExternalLink1ParameterTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.AsExternalLink("link");

            // Assert
            Assert.AreEqual("[[link]]", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsExternalLink1ParameterTest_withLinkNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsExternalLink(null);
        }

        [TestMethod()]
        public void AsEMailTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.AsEMail("mail");

            // Assert
            Assert.AreEqual("<mail>", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsEMailTest_withMailNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsEMail(null);
        }

        [TestMethod()]
        public void AsHeading1Test()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.AsHeading1("heading");

            // Assert
            Assert.AreEqual("====== heading ======", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsHeading1Test_withTextNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsHeading1(null);
        }

        [TestMethod()]
        public void AsHeading2Test()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.AsHeading2("heading");

            // Assert
            Assert.AreEqual("===== heading =====", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsHeading2Test_withTextNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsHeading2(null);
        }

        [TestMethod()]
        public void AsHeading3Test()
        {
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.AsHeading3("heading");

            // Assert
            Assert.AreEqual("==== heading ====", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsHeading3Test_withTextNull()
        {
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsHeading3(null);
        }

        [TestMethod()]
        public void AsHeading4Test()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.AsHeading4("heading");

            // Assert
            Assert.AreEqual("=== heading ===", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsHeading4Test_withTextNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsHeading4(null);
        }

        [TestMethod()]
        public void AsHeading5Test()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.AsHeading5("heading");

            // Assert
            Assert.AreEqual("== heading ==", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsHeading5Test_withTextNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsHeading5(null);
        }

        [TestMethod()]
        public void AsImage5ParametersTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsImage(path, "filename.jpg", 50, 100, "text");

            // Assert
            Assert.AreEqual("{{path1:path2:filename.jpg?50x100|text}}", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage5ParametersTest_withPathNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsImage(null, "filename.jpg", 50, 100, "text");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage5ParametersTest_withFilenameNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsImage(path, null, 50, 100, "text");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage5ParametersTest_withWidthNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsImage(path, "filename.jpg", 0, 100, "text");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage5ParametersTest_withHeightNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsImage(path, "filename.jpg", 50, 0, "text");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage5ParametersTest_withTextNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsImage(path, "filename.jpg", 50, 100, null);
        }

        [TestMethod()]
        public void AsImage4ParametersTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsImage(path, "filename.jpg", 50, 100);

            // Assert
            Assert.AreEqual("{{path1:path2:filename.jpg?50x100}}", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage4ParametersTest_withPathNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsImage(null, "filename.jpg", 50, 100);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage4ParametersTest_withFilenameNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsImage(path, null, 50, 100);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage4ParametersTest_withWidthNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsImage(path, "filename.jpg", 0, 100);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage4ParametersTest_withHeightNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsImage(path, "filename.jpg", 50, 0);
        }

        [TestMethod()]
        public void AsImage4Parameters2Test()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsImage(path, "filename.jpg", 50, "text");

            // Assert
            Assert.AreEqual("{{path1:path2:filename.jpg?50|text}}", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage4Parameters2Test_withPathNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsImage(null, "filename.jpg", 50, "text");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage4Parameters2Test_withFilenameNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsImage(path, null, 50, "text");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage4Parameters2Test_withWidthNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsImage(path, "filename.jpg", 0, "text");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage4Parameters2Test_withTextNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsImage(path, "filename.jpg", 50, null);
        }

        [TestMethod()]
        public void AsImage3ParametersTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsImage(path, "filename.jpg", 50);

            // Assert
            Assert.AreEqual("{{path1:path2:filename.jpg?50}}", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage3ParametersTest_withPathNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsImage(null, "filename.jpg", 50);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage3ParametersTest_withFilenameNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsImage(path, null, 50);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage3ParametersTest_withWidthNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsImage(path, "filename.jpg", 0);
        }

        [TestMethod()]
        public void AsImage3Parameters2Test()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsImage(path, "filename.jpg", "text");

            // Assert
            Assert.AreEqual("{{path1:path2:filename.jpg|text}}", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage3Parameters2Test_withPathNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsImage(null, "filename.jpg", "text");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage3Parameters2Test_withFilenameNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsImage(path, null, "text");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage3Parameters2Test_withTextNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsImage(path, "filename.jpg", null);
        }

        [TestMethod()]
        public void AsImage2ParametersTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsImage(path, "filename.jpg");

            // Assert
            Assert.AreEqual("{{path1:path2:filename.jpg}}", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage2ParametersTest_withPathNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string[] path = null;
            string returnstring = formatter.AsImage(path, "filename.jpg");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage2ParametersTest_withFilenameNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsImage(path, null);
        }

        [TestMethod()]
        public void AsImage4Parameters3Test()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.AsImage("filename.jpg", 50, 100, "text");

            // Assert
            Assert.AreEqual("{{filename.jpg?50x100|text}}", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage4Parameters3Test_withFilenameNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsImage(null, 50, 100, "text");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage4Parameters3Test_withWidthNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsImage("filename.jpg", 0, 100, "text");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage4Parameters3Test_withHeightNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsImage("filename.jpg", 50, 0, "text");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage4Parameters3Test_withTextNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsImage("filename.jpg", 50, 100, null);
        }

        [TestMethod()]
        public void AsImage3Parameters3Test()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.AsImage("filename.jpg", 50, 100);

            // Assert
            Assert.AreEqual("{{filename.jpg?50x100}}", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage3Parameters3Test_withFilenameNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsImage(null, 50, 100);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage3Parameters3Test_withWidthNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsImage("filename.jpg", 0, 100);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage3Parameters3Test_withHeightNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsImage("filename.jpg", 50, 0);
        }

        [TestMethod()]
        public void AsImage3Parameters4Test()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.AsImage("filename.jpg", 50, "text");

            // Assert
            Assert.AreEqual("{{filename.jpg?50|text}}", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage3Parameters4Test_withFilenameNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsImage(null, 50, "text");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage3Parameters4Test_withWidthNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsImage("filename.jpg", 0, "text");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage3Parameters4Test_withTextNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsImage("filename.jpg", 50, null);
        }

        [TestMethod()]
        public void AsImage2Parameters2Test()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.AsImage("filename.jpg", 50);

            // Assert
            Assert.AreEqual("{{filename.jpg?50}}", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage2Parameters2Test_withFilenameNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsImage(null, 50);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage2Parameters2Test_withWidthNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsImage("filename.jpg", 0);
        }

        [TestMethod()]
        public void AsImage2Parameters3Test()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.AsImage("filename.jpg", "text");

            // Assert
            Assert.AreEqual("{{filename.jpg|text}}", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage2Parameters3Test_withFilenameNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string filename = null;
            string returnstring = formatter.AsImage(filename, "text");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage2Parameters3Test_withTextNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsImage("filename.jpg", 0);
        }

        [TestMethod()]
        public void AsImage1ParameterTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.AsImage("filename.jpg");

            // Assert
            Assert.AreEqual("{{filename.jpg}}", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImage1ParameterTest_withFilenameNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsImage(null);
        }

        [TestMethod()]
        public void AsImageBoxTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.AsImageBox("imagelink");

            // Assert
            Assert.AreEqual("[imagelink]", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsImageBoxTest_withImageLinkNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsImageBox(null);
        }

        [TestMethod()]
        public void AlignImageTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring1 = formatter.AlignImage("[[link]]", Alignment.Left);
            string returnstring2 = formatter.AlignImage("[[link]]", Alignment.Centered);
            string returnstring3 = formatter.AlignImage("[[link]]", Alignment.Right);

            // Assert
            Assert.AreEqual("[[link ]]", returnstring1);
            Assert.AreEqual("[[ link ]]", returnstring2);
            Assert.AreEqual("[[ link]]", returnstring3);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AlignImageTest_withImageLinkNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AlignImage(null, Alignment.Left);
        }

        [TestMethod()]
        public void ForceNewLineTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.ForceNewLine();

            // Assert
            Assert.AreEqual("\\\\", returnstring);
        }

        [TestMethod()]
        public void ListItemUnsortedTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.ListItemUnsorted();

            // Assert
            Assert.AreEqual("* ", returnstring);
        }

        [TestMethod()]
        public void ListItemSortedTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.ListItemSorted();

            // Assert
            Assert.AreEqual("- ", returnstring);
        }

        [TestMethod()]
        public void ListItemIndentTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.ListItemIndent();

            // Assert
            Assert.AreEqual("  ", returnstring);
        }

        [TestMethod()]
        public void AsInsertPage2ParametersTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsInsertPage(path, "pagename");

            // Assert
            Assert.AreEqual("{{page>path1:path2:pagename}}", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsInsertPage2ParametersTest_withPathNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsInsertPage(null, "pagename.md");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsInsertPage2ParametersTest_withPagenameNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsInsertPage(path, null);
        }

        [TestMethod()]
        public void AsInsertPage1ParameterTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.AsInsertPage("pagename");

            // Assert
            Assert.AreEqual("{{page>pagename}}", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsInsertPage1ParameterTest_withPagenameNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsInsertPage(null);
        }

        [TestMethod()]
        public void DisableTOCTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.DisableTOC();

            // Assert
            Assert.AreEqual("~~NOTOC~~", returnstring);
        }

        [TestMethod()]
        public void DisableCacheTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.DisableCache();

            // Assert
            Assert.AreEqual("~~NOCACHE~~", returnstring);
        }

        [TestMethod()]
        public void BeginCommentTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.BeginComment();

            // Assert
            Assert.AreEqual("/* ", returnstring);
        }

        [TestMethod()]
        public void EndCommentTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.EndComment();

            // Assert
            Assert.AreEqual(" */", returnstring);
        }

        [TestMethod()]
        public void DefineTableTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            int[] width = { 10, 20, 30, 40 };
            string returnstring = formatter.DefineTable(500, width);

            // Assert
            Assert.AreEqual("|<   500px   10%   20%   30%   40%   >|", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DefineTableTest_withSizeNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            int[] width = { 10, 20, 30, 40 };
            string returnstring = formatter.DefineTable(0, width);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DefineTableTest_withWidthNul()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.DefineTable(500, null);
        }

        [TestMethod()]
        public void AsTableTitleTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string[] data = { "title", "title" };
            string returnstring = formatter.AsTableTitle(data);

            // Assert
            Assert.AreEqual("^ title ^ title ^", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsTableTitleTest_withDataNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsTableTitle(null);
        }

        [TestMethod()]
        public void CellSpanVerticallyTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.CellSpanVertically();

            // Assert
            Assert.AreEqual(":::", returnstring);
        }

        [TestMethod()]
        public void AsTableRow3ItemsTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string[] data = { "data1", "data2", "data3" };
            string returnstring = formatter.AsTableRow(data);

            // Assert
            Assert.AreEqual("| data1 | data2 | data3 |", returnstring);
        }

        [TestMethod()]
        public void AsTableRow2ItemsTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string[] data = { "data1", "data2", null };
            string returnstring = formatter.AsTableRow(data);

            // Assert
            Assert.AreEqual("| data1 | data2 ||", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsTableRowTest_withDataNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.AsTableRow(null);
        }

        [TestMethod()]
        public void BeginBoxTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.BeginBox(500, Alignment.Left);

            // Assert
            Assert.AreEqual("<WRAP box 500px Left>", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BeginBoxTest_withSizeNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.BeginBox(0, Alignment.Left);
        }

        [TestMethod()]
        public void EndBoxTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.EndBox();

            // Assert
            Assert.AreEqual("</WRAP>", returnstring);
        }

        [TestMethod()]
        public void BeginDataEntryTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.BeginDataEntry("name");

            // Assert
            Assert.AreEqual("---- dataentry name ----", returnstring);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BeginDataEntryTest_withNameNull()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act, Assert
            string returnstring = formatter.BeginDataEntry(null);
        }

        [TestMethod()]
        public void EndDataEntryTest()
        {
            // Arrange
            DokuWikiFormatter formatter = new DokuWikiFormatter();

            // Act
            string returnstring = formatter.EndDataEntry();

            // Assert
            Assert.AreEqual("----", returnstring);
        }
    }
}
