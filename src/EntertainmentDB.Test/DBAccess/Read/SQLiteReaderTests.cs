using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntertainmentDB.DBAccess.Read;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntertainmentDB.DBAccess.Read.Tests
{
    [TestClass()]
    public class SQLiteReaderTests
    {
        [TestMethod()]
        public void SQLiteReaderTest()
        {
            // Arrange
            SQLiteReader reader = new SQLiteReader();

            // Act
            // Assert
            Assert.IsNotNull(reader);
            Assert.AreEqual("", reader.Query);
            Assert.IsNotNull(reader.Table);
        }

        [TestMethod()]
        [DataRow("Movie")]
        public void RetrieveTest_validID(string value)
        {
            // Arrange
            SQLiteReader reader = new SQLiteReader();
            reader.Query = $"SELECT ID FROM {value} WHERE ID LIKE \"_xxx\"";

            // Act
            reader.Retrieve();

            // Assert
            Assert.AreEqual(1, reader.Table.Columns.Count);
            Assert.AreEqual(1, reader.Table.Rows.Count);
        }
    }
}
