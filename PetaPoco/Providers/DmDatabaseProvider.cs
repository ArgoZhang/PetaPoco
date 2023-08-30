using System;
using System.Data.Common;
using PetaPoco.Core;

namespace PetaPoco.Providers
{
    public class DmDatabaseProvider : DatabaseProvider
    {
        public override DbProviderFactory GetFactory()
            => GetFactory("Dm.DmClientFactory, DmProvider, Version=1.1.0.0, Culture=neutral,PublicKeyToken = 7a2d44aa446c6d01");

        public override string GetParameterPrefix(string connectionString)
            => ":";

        public override string EscapeSqlIdentifier(string sqlIdentifier)
            => $"\"{sqlIdentifier}\"";

        public override string GetExistsSql()
            => "SELECT COUNT(1) FROM {0} WHERE {1}";
    }
}
