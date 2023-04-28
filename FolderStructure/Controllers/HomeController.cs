using FolderStructure.BLL.Services;
using FolderStructure.DAL.Entities;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
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

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase UploadedFile)
        {
            try
            {
                if (UploadedFile.ContentLength > 0)
                {                 
                    string _path = Path.Combine(Server.MapPath("~/Files"), "newStructure.xml");
                    UploadedFile.SaveAs(_path);
                    SerializationService serService = new SerializationService();
                    var foldersTree = serService.DeserializeStructure();

                    FolderService folderService = new FolderService();
                    folderService.SetNewStructure(foldersTree);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
        public ActionResult UploadFile()
        {
            return View();
        }
    }
}