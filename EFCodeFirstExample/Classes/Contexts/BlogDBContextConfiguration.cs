using EFCache;
using System;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.Entity.SqlServer;

namespace EFCodeFirstExample.Classes.Contexts
{
    public partial class BlogDbContext
    {
        public class BlogDBContextConfiguration : DbConfiguration
        {
            public BlogDBContextConfiguration()
            {
                try
                {
                    SetProviderServices("System.Data.SqlClient", SqlProviderServices.Instance);

                    CacheTransactionHandler transactionHandler = new CacheTransactionHandler(new InMemoryCache());

                    AddInterceptor(transactionHandler);

                    CachingPolicy cachingPolicy = new CachingPolicy();

                    Loaded += (sender, args) => args.ReplaceService<DbProviderServices>((s, _) => new CachingProviderServices(s, transactionHandler, cachingPolicy));
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("+++++ ERROR - Hiba! Hiba a kontextus felépítése közben! " +
                        "Hiba az Adatbázis Modell létrehozása közben! " +
                        $"\tContext Name: {nameof(BlogDbContext)}.\n\n" +
                        $"Exception Message: {ex.Message}");
                }
            }
        }
    }
}
