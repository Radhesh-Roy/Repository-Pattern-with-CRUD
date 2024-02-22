using AutoMapper;
using UMP.Data;
using UMP.Models;
using UMP.Service;
using UMP.ViewModel;

namespace UMP.Repository;

public class DoctorRepository : RepositoryService<Doctor, DoctorVm> ,IDoctorRepository
{
    public DoctorRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {
    }
}
