namespace FolderStructure.DAL.Migrations
{
    using FolderStructure.DAL.Entities;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<FolderStructure.DAL.StructureDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FolderStructure.DAL.StructureDBContext context)
        {
            Folder folder = new Folder("Creating Digital Images")
            {
                SubFolders = new List<Folder> { new Folder("Resources") { SubFolders = new List<Folder> { new Folder("Primary Sources"), new Folder("Secondary Sources")}},
                                                new Folder("Evidence"), new Folder("Graphic Products") { SubFolders = new List<Folder> { new Folder("Process"), new Folder("Final Product")}}}
            };
            context.Folders.AddOrUpdate(folder);
        }
    }
}
