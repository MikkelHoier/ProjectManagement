using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCorp.DataAccess
{
    internal static class ConnectionsStrings
    {
        private static readonly string megaCorpConnection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MegaCorpDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        internal static string MegaCorpConnection => megaCorpConnection;
    }
}
