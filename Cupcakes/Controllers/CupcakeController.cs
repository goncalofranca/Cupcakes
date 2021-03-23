using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Cupcakes.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cupcakes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Cupcakes.Controllers
{
    public class CupcakeController : Controller
    {
        private ICupcakeRepository _repository;
        private IWebHostEnvironment _environment;

        private CupcakeController(ICupcakeRepository repository, IWebHostEnvironment environment)
        {
            _repository = repository;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View(_repository.GetCupcakes());
        }

        public IActionResult Details(int id)
        {
            var _ctxCupcake = _repository.GetCupcakeById(id);

            return _ctxCupcake  is null ? NotFound() : View(_ctxCupcake);
        }
        private void PopulateBakeriesDropDownList(int? selectedBakery = null)
        {
            var _ctxBakeries = _repository.PopulateBakeriesDropDownList();

            ViewBag["BakeryID"] = new SelectList(_ctxBakeries.AsNoTracking(), "BakeryID", "BakeryName", selectedBakery);
        }

        [HttpGet]
        public IActionResult Create()
        {
            PopulateBakeriesDropDownList();

            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public IActionResult CreatePost(Cupcake cupcake)
        {
            if(ModelState.IsValid)
            {
                _repository.CreateCupcake(cupcake);
                return RedirectToAction(nameof(Index));
            }

            PopulateBakeriesDropDownList(cupcake.BakeryID);
            return View(cupcake);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var _ctxCupcake = _repository.GetCupcakeById(id);
            if(_ctxCupcake is  null)
            {
                return NotFound();
            }

            PopulateBakeriesDropDownList(_ctxCupcake.BakeryID);
            return View(_ctxCupcake);
        }

        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> EditPost(int id)
        {
            var _ctxCupcakeToUpdate = _repository.GetCupcakeById(id);
            bool _ctxIsUpdated = await TryUpdateModelAsync(_ctxCupcakeToUpdate, "", c => c.BakeryID, c => c.CupcakeType, c => c.Description, c => c.GlutenFree, c => c.Price);

            if(_ctxIsUpdated)
            {
                _repository.SaveChanges();
                return RedirectToAction(nameof(Index));

            }

            PopulateBakeriesDropDownList(_ctxCupcakeToUpdate.BakeryID);
            return View(_ctxCupcakeToUpdate);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var _ctxCupcake = _repository.GetCupcakeById(id);
            if(_ctxCupcake is null)
            {
                return NotFound();
            }

            PopulateBakeriesDropDownList(_ctxCupcake.BakeryID);
            return View(_ctxCupcake);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var _ctxCupcakeToDelete = _repository.GetCupcakeById(id);
            //_repository.DeleteCupcake(_ctxCupcakeToDelete.CupcakeId);
            _repository.DeleteCupcake(id);
            return RedirectToAction(nameof(Index));

         
        }


        public IActionResult GetImage(int id)
        {
            Cupcake _ctxRequestedCupcake = _repository.GetCupcakeById(id);
            if (_ctxRequestedCupcake != null)
            {
                string _ctxWebRootpath = _environment.WebRootPath;
                string _ctxFolderPath = "\\images\\";
                string _ctxFullPath = _ctxWebRootpath + _ctxFolderPath + _ctxRequestedCupcake.ImageName;
                if (System.IO.File.Exists(_ctxFullPath))
                {
                    FileStream _ctxFileOnDisk = new FileStream(_ctxFullPath, FileMode.Open);
                    byte[] _ctxFileBytes;
                    using (BinaryReader _ctxBinaryReader = new BinaryReader(_ctxFileOnDisk))
                    {
                        _ctxFileBytes = _ctxBinaryReader.ReadBytes((int)_ctxFileOnDisk.Length);
                    }
                    return File(_ctxFileBytes, _ctxRequestedCupcake.ImageMimeType);
                }
                else
                {
                    if (_ctxRequestedCupcake.PhotoFile.Length > 0)
                    {
                        return File(_ctxRequestedCupcake.PhotoFile, _ctxRequestedCupcake.ImageMimeType);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}