// WikiPageCreator.exe: Creates pages for use with a wiki from the
// EntertainmentInfothek.db using EntertainmentDB.dll
// Copyright (C) 2024 Sandra Scherer

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

namespace WikiPageCreator.Export.Format.Tests
{
    [TestClass()]
    public class ObsidianFormatterTests
    {
        [TestMethod()]
        public void ObsidianFormatterTest()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            // Assert
            Assert.IsNotNull(formatter);
        }

        [TestMethod()]
        public void AsPagenameTest()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.AsFilename("THIS IS A TEST+ FOR A FILE/NAME WITH% DIFFERENT* SPECIAL& CHARACTERS! ESPECIALLY# GERMAN= ONES: Ä, Ö, Ü, ß?");

            // Assert
            Assert.AreEqual("this_is_a_test__for_a_file_name_with__different__special__characters__especially__german__ones_a_o_u_s_.txt", returnstring);
        }

        [TestMethod()]
        public void AsBoldTest()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.AsBold("text");

            // Assert
            Assert.AreEqual("**text**", returnstring);
        }

        [TestMethod()]
        public void AsItalicTest()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.AsItalic("text");

            // Assert
            Assert.AreEqual("//text//", returnstring);
        }

        [TestMethod()]
        public void AsUnderlinedTest()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.AsUnderlined("text");

            // Assert
            Assert.AreEqual("__text__", returnstring);
        }

        [TestMethod()]
        public void AsSubscriptTest()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.AsSubscript("text");

            // Assert
            Assert.AreEqual("<sub>text</sub>", returnstring);
        }

        [TestMethod()]
        public void AsSuperscriptTest()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.AsSuperscript("text");

            // Assert
            Assert.AreEqual("<sup>text</sup>", returnstring);
        }

        [TestMethod()]
        public void AsDeletedTest()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.AsDeleted("text");

            // Assert
            Assert.AreEqual("<del>text</del>", returnstring);
        }

        [TestMethod()]
        public void AsInternalLink1Test()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsInternalLink(path, "pagename.txt", "section", "text");

            // Assert
            Assert.AreEqual("[[path1:path2:pagename.txt#section|text]]", returnstring);
        }

        [TestMethod()]
        public void AsInternalLink2Test()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsInternalLink(path, "pagename.txt", "text");

            // Assert
            Assert.AreEqual("[[path1:path2:pagename.txt|text]]", returnstring);
        }

        [TestMethod()]
        public void AsInternalLink3Test()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.AsInternalLink("pagename.txt", "section", "text");

            // Assert
            Assert.AreEqual("[[pagename.txt#section|text]]", returnstring);
        }

        [TestMethod()]
        public void AsInternalLink4Test()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.AsInternalLink("pagename.txt", "text");

            // Assert
            Assert.AreEqual("[[pagename.txt|text]]", returnstring);
        }

        [TestMethod()]
        public void AsInternalLink5Test()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.AsInternalLink("pagename.txt");

            // Assert
            Assert.AreEqual("[[pagename.txt]]", returnstring);
        }

        [TestMethod()]
        public void AsExternalLink1Test()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.AsExternalLink("link", "text");

            // Assert
            Assert.AreEqual("[[link|text]]", returnstring);
        }

        [TestMethod()]
        public void AsExternalLink2Test()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.AsExternalLink("link");

            // Assert
            Assert.AreEqual("[[link]]", returnstring);
        }

        [TestMethod()]
        public void AsEMailTest()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.AsEMail("mail");

            // Assert
            Assert.AreEqual("<mail>", returnstring);
        }

        [TestMethod()]
        public void AsHeading1Test()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.AsHeading1("heading");

            // Assert
            Assert.AreEqual("====== heading ======", returnstring);
        }

        [TestMethod()]
        public void AsHeading2Test()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.AsHeading2("heading");

            // Assert
            Assert.AreEqual("===== heading =====", returnstring);
        }

        [TestMethod()]
        public void AsHeading3Test()
        {
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.AsHeading3("heading");

            // Assert
            Assert.AreEqual("==== heading ====", returnstring);
        }

        [TestMethod()]
        public void AsHeading4Test()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.AsHeading4("heading");

            // Assert
            Assert.AreEqual("=== heading ===", returnstring);
        }

        [TestMethod()]
        public void AsHeading5Test()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.AsHeading5("heading");

            // Assert
            Assert.AreEqual("== heading ==", returnstring);
        }

        [TestMethod()]
        public void AsImage1Test()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsImage(path, "filename.jpg", 50, 100);

            // Assert
            Assert.AreEqual("{{path1:path2:filename.jpg?50x100}}", returnstring);
        }

        [TestMethod()]
        public void AsImage2Test()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsImage(path, "filename.jpg", 50, 100, "text");

            // Assert
            Assert.AreEqual("{{path1:path2:filename.jpg?50x100|text}}", returnstring);
        }

        [TestMethod()]
        public void AsImage3Test()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsImage(path, "filename.jpg", 50);

            // Assert
            Assert.AreEqual("{{path1:path2:filename.jpg?50}}", returnstring);
        }

        [TestMethod()]
        public void AsImage4Test()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsImage(path, "filename.jpg", 50, "text");

            // Assert
            Assert.AreEqual("{{path1:path2:filename.jpg?50|text}}", returnstring);
        }

        [TestMethod()]
        public void AsImage5Test()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsImage(path, "filename.jpg");

            // Assert
            Assert.AreEqual("{{path1:path2:filename.jpg}}", returnstring);
        }

        [TestMethod()]
        public void AsImage6Test()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsImage(path, "filename.jpg", "text");

            // Assert
            Assert.AreEqual("{{path1:path2:filename.jpg|text}}", returnstring);
        }

        [TestMethod()]
        public void AsImage7Test()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.AsImage("filename.jpg", 50, 100);

            // Assert
            Assert.AreEqual("{{filename.jpg?50x100}}", returnstring);
        }

        [TestMethod()]
        public void AsImage8Test()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.AsImage("filename.jpg", 50, 100, "text");

            // Assert
            Assert.AreEqual("{{filename.jpg?50x100|text}}", returnstring);
        }

        [TestMethod()]
        public void AsImage9Test()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.AsImage("filename.jpg", 50);

            // Assert
            Assert.AreEqual("{{filename.jpg?50}}", returnstring);
        }

        [TestMethod()]
        public void AsImageBoxTest()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.AsImageBox("{{filename.jpg}}");

            // Assert
            Assert.AreEqual("[{{filename.jpg}}]", returnstring);
        }

        [TestMethod()]
        public void AsImage10Test()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.AsImage("filename.jpg", 50, "text");

            // Assert
            Assert.AreEqual("{{filename.jpg?50|text}}", returnstring);
        }

        [TestMethod()]
        public void AsImage11Test()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.AsImage("filename.jpg");

            // Assert
            Assert.AreEqual("{{filename.jpg}}", returnstring);
        }

        [TestMethod()]
        public void AsImage12Test()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.AsImage("filename.jpg", "text");

            // Assert
            Assert.AreEqual("{{filename.jpg|text}}", returnstring);
        }

        [TestMethod()]
        public void AlignImageTest()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

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
        public void ForceNewLineTest()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.ForceNewLine();

            // Assert
            Assert.AreEqual("\\\\", returnstring);
        }

        [TestMethod()]
        public void ListItemUnsortedTest()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.ListItemUnsorted();

            // Assert
            Assert.AreEqual("* ", returnstring);
        }

        [TestMethod()]
        public void ListItemSortedTest()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.ListItemSorted();

            // Assert
            Assert.AreEqual("- ", returnstring);
        }

        [TestMethod()]
        public void ListItemIndentTest()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.ListItemIndent();

            // Assert
            Assert.AreEqual("  ", returnstring);
        }

        [TestMethod()]
        public void AsInsertPage1Test()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string[] path = { "path1", "path2" };
            string returnstring = formatter.AsInsertPage(path, "pagename");

            // Assert
            Assert.AreEqual("{{page>path1:path2:pagename}}", returnstring);
        }

        [TestMethod()]
        public void AsInsertPage2Test()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.AsInsertPage("pagename");

            // Assert
            Assert.AreEqual("{{page>pagename}}", returnstring);
        }

        [TestMethod()]
        public void DisableTOCTest()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.DisableTOC();

            // Assert
            Assert.AreEqual("~~NOTOC~~", returnstring);
        }

        [TestMethod()]
        public void DisableCacheTest()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.DisableCache();

            // Assert
            Assert.AreEqual("~~NOCACHE~~", returnstring);
        }

        [TestMethod()]
        public void BeginCommentTest()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.BeginComment();

            // Assert
            Assert.AreEqual("/* ", returnstring);
        }

        [TestMethod()]
        public void EndCommentTest()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.EndComment();

            // Assert
            Assert.AreEqual(" */", returnstring);
        }

        [TestMethod()]
        public void DefineTableTest()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            int[] width = { 10, 20, 30, 40 };
            string returnstring = formatter.DefineTable(500, width);

            // Assert
            Assert.AreEqual("|<   500px   10%   20%   30%   40%   >|", returnstring);
        }

        [TestMethod()]
        public void CellSpanVerticallyTest()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.CellSpanVertically();

            // Assert
            Assert.AreEqual(":::", returnstring);
        }

        [TestMethod()]
        public void AsTableRow3ItemsTest()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

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
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string[] data = { "data1", "data2", null };
            string returnstring = formatter.AsTableRow(data);

            // Assert
            Assert.AreEqual("| data1 | data2 ||", returnstring);
        }

        [TestMethod()]
        public void BeginBoxTest()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.BeginBox(500, Alignment.Left);

            // Assert
            Assert.AreEqual("<WRAP box 500px Left>", returnstring);
        }

        [TestMethod()]
        public void EndBoxTest()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.EndBox();

            // Assert
            Assert.AreEqual("</WRAP>", returnstring);
        }

        [TestMethod()]
        public void BeginDataEntryTest()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.BeginDataEntry("name");

            // Assert
            Assert.AreEqual("---- dataentry name ----", returnstring);
        }

        [TestMethod()]
        public void EndDataEntryTest()
        {
            // Arrange
            ObsidianFormatter formatter = new ObsidianFormatter();

            // Act
            string returnstring = formatter.EndDataEntry();

            // Assert
            Assert.AreEqual("----", returnstring);
        }
    }
}
