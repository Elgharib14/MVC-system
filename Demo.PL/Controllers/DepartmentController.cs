using Demo.BLL.Interface;
using Demo.BLL.Reposatory;
using Demo.DAL.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
            
        public async Task<IActionResult> Index()
        {

            //ViewData["Message"] = "Hello View Data";
            //ViewData["Count"] = 22;
            //ViewBag.ff = "Hello View Bage";
            //ViewBag.ss = 22.3;

            var data =await unitOfWork.Department.GetAll();
            return View(data);
        }
        [HttpGet]
        public IActionResult Creat()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Creat(Department obj)
        {
            if(ModelState.IsValid)
            {
               await unitOfWork.Department.Create(obj);
               await unitOfWork.complit();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
                return BadRequest();
          var data = await unitOfWork.Department.GetById(id);

            return View(data);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var data =await unitOfWork.Department.GetById(id);
            if (data == null)
                return NotFound();
            return View(data);

           
        }

        [HttpPost]
        //ther i add thr id for Security to mack the user can't change in teh id from html code in the browsser 
        public async Task<IActionResult> Edit([FromRoute]int id, Department obj) 
        {
            if(id != obj.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.Department.Update(obj);
                   await unitOfWork.complit();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(String.Empty, ex.Message);
                }
               
            } 
              
            return View(obj);
           
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id) 
        {
            if (id == null)
                return BadRequest();
            var data =await unitOfWork.Department.GetById(id);

            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Department obj)
        {
            try
                {
                unitOfWork.Department.Delet(obj);
                await unitOfWork.complit();
                return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(String.Empty, ex.Message);
                    return View(obj);
                }
        }

    }
}
