using Codesanook.EFCore.Models;
using OrchardCore.Data.Migration;

namespace Codesanook.EFCore
{
    public class Migrations : DataMigration
    {
        public int Create()
        {
            // SELECT Content
            // FROM [Document]
            // WHERE [Type] = 'OrchardCore.Data.Migration.Records.DataMigrationRecord, OrchardCore.Data'
            SchemaBuilder.CreateTable(nameof(Book), table => table
                .Column<int>(nameof(Book.Id), col => col.PrimaryKey().Identity())
                .Column<string>(nameof(Book.Title), col => col.NotNull().WithLength(255))
            );

            return 1;
        }
    }
}
