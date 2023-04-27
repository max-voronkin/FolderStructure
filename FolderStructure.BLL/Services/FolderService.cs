using FolderStructure.DAL;

namespace FolderStructure.BLL.Services
{
    public class FolderService
    {
        private readonly StructureDBContext context;
        public FolderService()
        {
            context = new StructureDBContext();
        }

    }
}
