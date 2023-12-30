using AutoMapper;
using Demo.BLL.Interface;
using Demo.DAL.Model;
using Demo.PL.Helper;
using Demo.PL.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Demo.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
           
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index(string SearchValue)
        {
            if (string.IsNullOrEmpty(SearchValue))
            {
                var data = await unitOfWork.Employee.GetAll();
                var map = mapper.Map<IEnumerable<EmployeeVM>>(data);
                return View(map);
            }
            else
            {
                var data = unitOfWork.Employee.SearchEmployees(SearchValue);
                var map = mapper.Map<IEnumerable<EmployeeVM>>(data);
                return View(map);
            }
           
        }
        [HttpGet]
        public async Task<IActionResult> Creat()
        {
            ViewBag.data =  new SelectList(await unitOfWork.Department.GetAll(), "Id", "Name");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Creat(EmployeeVM obj)
        {
            if (ModelState.IsValid)
            {
                obj.ImageName = DecoumentSetting.UploadFile(obj.Image, "Images");
                var data = mapper.Map<Employee>(obj);
               await unitOfWork.Employee.Create(data);

               await unitOfWork.complit();
               
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
                return BadRequest();
            var data =await unitOfWork.Employee.GetById(id);
            var map = mapper.Map<EmployeeVM>(data); 
            return View(map);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var data = await unitOfWork.Employee.GetById(id);
            var map = mapper.Map<EmployeeVM>(data);
            if (data == null)
                return NotFound();
            return View(map);


        }

        [HttpPost]
        //ther i add thr id for Security to mack the user can't change in teh id from html code in the browsser 
        public async Task<IActionResult> Edit([FromRoute] int id, EmployeeVM obj)
        {
            if (id != obj.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var data = mapper.Map<Employee>(obj);
                    unitOfWork.Employee.Update(data);
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
            return await Details(id);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeVM obj)
        {
            try
            {
                var data = mapper.Map<Employee>(obj);
                unitOfWork.Employee.Delet(data);
                await unitOfWork.complit();
                DecoumentSetting.DeledFile(data.ImageName, "Images");
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
