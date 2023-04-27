using FolderStructure.DAL;
using FolderStructure.DAL.DTO;
using FolderStructure.DAL.Entities;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace FolderStructure.BLL.Services
{
    public class SerializationService
    {
        private static readonly string fileName = "structure.xml";
        string baseDirecory = AppDomain.CurrentDomain.BaseDirectory;

        public void SerializeStructure()
        {
            if (!Directory.Exists($"{baseDirecory}\\Files"))
            {
                Directory.CreateDirectory($"{baseDirecory}\\Files");
            }
            SerializableFolder structure = GetSerializibleStructure();
            XmlSerializer xmlFromat = new XmlSerializer(typeof(SerializableFolder));
            using (Stream fStream = new FileStream($"{baseDirecory}\\Files\\{fileName}", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFromat.Serialize(fStream, structure);
            }
        }

        private SerializableFolder GetSerializibleStructure()
        {
            using (var context = new StructureDBContext())
                return ConvertToSerializible(context.Folders.Where(f => f.ParrentId == null).Include(s => s.SubFolders).FirstOrDefault());
        }
        private SerializableFolder ConvertToSerializible(Folder folder)
        {
            var dto = new SerializableFolder()
            {
                Name = folder.Name,
                SubFolders = folder.SubFolders?.Select(s => ConvertToSerializible(s)).ToList()
            };
            return dto;
        }
    }
}
