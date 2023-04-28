using System.Collections.Generic;

namespace FolderStructure.DAL.Entities
{
    public class Folder
    {
        public Folder() { }
        public Folder(string folderName)
        {
            Name = folderName;
        }
        public int Id { get; set; }
        public int? ParrentId { get; set; }
        public virtual Folder Parrent { get; set; }
        public virtual ICollection<Folder> SubFolders { get; set; }
        public string Name { get; set; }
    }
}
