using PetaPoco.Providers;
using System;
using Xunit;

namespace PetaPoco.UnitTest
{
    /// <summary>
    /// 
    /// </summary>
    public class DatabaseTest : IDisposable
    {
        IDatabase _db = null;
        /// <summary>
        /// 
        /// </summary>
        public DatabaseTest()
        {
            // create db
            _db = new Database<SQLiteDatabaseProvider>("Data Source=UnitTest.db;");
            _db.BeginTransaction();
            _db.Execute("drop table if exists Dicts;");
            _db.Execute("CREATE TABLE Dicts (ID INTEGER PRIMARY KEY, Category VARCHAR(50) NOT NULL, Name VARCHAR(50) NOT NULL, Code VARCHAR(2000) NOT NULL, Define INT NOT NULL DEFAULT(1));");
            _db.CompleteTransaction();
        }

        [Fact]
        public void IsNew_StringType()
        {
            _db.BeginTransaction();
            _db.Insert(new Dicts() { Category = "UnitTest", Name = "Test1", Code = "Value" });
            var data = _db.Fetch<Dicts>();
            _db.CompleteTransaction();
            Assert.Single(data);
        }

        public void Dispose()
        {
            if(_db != null)
            {
                _db.Dispose();
                _db = null;
            }
        }

        class Dicts
        {
            public string Id { get; set; }

            public string Category { get; set; }

            public string Name { get; set; }

            public string Code { get; set; }
        }
    }
}
