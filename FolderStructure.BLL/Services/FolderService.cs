using FolderStructure.BLL.Exceptions;
using FolderStructure.DAL;
using FolderStructure.DAL.Entities;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FolderStructure.BLL.Services
{
    public class FolderService
    {
        private readonly StructureDBContext context;
        public FolderService()
        {
            context = new StructureDBContext();
        }

        public async Task<Folder> GetFolderById(int? folderId)
        {
            Folder searchedFolder;
            if (folderId == null)
            {
                searchedFolder = await GetParentNode();
            }
            else
            {
                searchedFolder = await context.Folders.FirstOrDefaultAsync(f => f.Id == folderId);
                if (searchedFolder is null)
                    throw new IncorrectPathException("Folder is not found", folderId.ToString());
                searchedFolder.SubFolders = await context.Folders.Where(f => f.ParrentId == searchedFolder.Id).ToListAsync();
            }
            return searchedFolder;

        }

        private async Task<Folder> GetParentNode()
        {
            Folder parentFolder = await context.Folders.Where(f => f.ParrentId == null).FirstOrDefaultAsync();
            if (parentFolder is null)
                throw new IncorrectPathException("Cant find parent folder");
            parentFolder.SubFolders = await context.Folders.Where(f => f.ParrentId == parentFolder.Id).ToListAsync();
            return parentFolder;
        }

        public void SetNewStructure(Folder structure)
        {
            WipeStructureInDB();
            context.Folders.Add(structure);
            context.SaveChanges();
        }

        private void WipeStructureInDB()
        {
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE Folders");
        }
    }
}
