using System.Collections.Generic;

namespace FolderStructure.DAL.DTO
{
    public class SerializableFolder
    {
        public string Name { get; set; }
        public List<SerializableFolder> SubFolders { get; set; }
    }
}
