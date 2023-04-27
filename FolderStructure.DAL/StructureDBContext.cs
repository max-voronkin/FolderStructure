using FolderStructure.DAL.Entities;
using System.Data.Entity;

namespace FolderStructure.DAL
{
    public class StructureDBContext : DbContext
    {
        private static readonly string conString = @"
        Server=localhost,11433;
        Database=FoldersStructure;
        User Id=SA;
        Password=Pwd12345!";
        public StructureDBContext() : base(conString)
        {
        }

        public DbSet<Folder> Folders { get; set; }
    }
}
