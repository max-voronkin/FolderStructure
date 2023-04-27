using FolderStructure.BLL.Exceptions;
using FolderStructure.DAL;
using FolderStructure.DAL.Entities;
using System.Data.Entity;
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

        public async Task<Folder> GetFolderById(int folderId)
        {
            Folder searchedFolder = await context.Folders.FirstOrDefaultAsync(f => f.Id == folderId);
            if (searchedFolder is null)
                throw new IncorrectPathException("Folder is not found", folderId.ToString());
            return searchedFolder;

        }

        public async Task<Folder> GetParentNode()
        {
            Folder parentFolder = await context.Folders.FirstOrDefaultAsync(f => f.ParrentId == null);
            if (parentFolder is null)
                throw new IncorrectPathException("Cant find parent folder");
            return parentFolder;
        }

    }
}
