using FolderStructure.BLL.Services;
using FolderStructure.DAL.Entities;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FolderStructure.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index(int? id)
        {
            FolderService service = new FolderService();
            Folder folder;
            try
            {
                folder = await service.GetFolderById(id);
                ViewBag.Title = folder.Name;
                ViewBag.Node = folder;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
            return View();
        }

        public FilePathResult DownloadStructure()
        {
            SerializationService serializationService = new SerializationService();
            serializationService.SerializeStructure();
            string filePath = Server.MapPath("~/Files/structure.xml");
            return File(filePath, "application/octet-stream", "structure.xml");
        }
    }
}