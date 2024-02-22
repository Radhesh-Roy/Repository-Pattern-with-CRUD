using Microsoft.AspNetCore.Mvc;
using UMP.Models;
using UMP.Repository;
using UMP.Service;
using UMP.ViewModel;

namespace UMP.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorRepository _repository;

        public DoctorController(IDoctorRepository repository)
        {
            _repository = repository;
        }


        public async Task<ActionResult<DoctorVm>> Index(CancellationToken cancellationToken)
        {
            return View(await _repository.GetAllAsync(cancellationToken));
        }

        public async Task<ActionResult<DoctorVm>> CreateOrEdit(int id,CancellationToken cancellationToken)
        {
            if (id==0)
            {
                return View (new DoctorVm());
                
            }
            else
            {
                return View( await _repository.GetByIdAsync(id,cancellationToken));
            }

        }

        [HttpPost]
        public async Task<ActionResult<DoctorVm>> CreateOrEdit(int id,DoctorVm doctorVm ,CancellationToken cancellationToken)
        {
            if (id==0)
            {
                
                   await _repository.InsertAsync(doctorVm, cancellationToken);
                    return RedirectToAction("Index");
 
            }
            else
            {
                await _repository.UpdateAsync(id, doctorVm, cancellationToken);
                return RedirectToAction("Index");
            }

        }


        public async Task<ActionResult<DoctorVm>> Delete(int id,CancellationToken cancellationToken)
        {
            var data=await _repository.GetByIdAsync(id,cancellationToken);
            if (data is not null)
            {
                await _repository.Delete(id, cancellationToken);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


        public async Task<ActionResult<DoctorVm>> Details(int id,CancellationToken cancellationToken)
        {
            return View(await _repository.GetByIdAsync(id,cancellationToken)); 

        }

    }
}
