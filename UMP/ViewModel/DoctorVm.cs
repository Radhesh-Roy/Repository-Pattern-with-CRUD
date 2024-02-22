using AutoMapper;
using UMP.Models;

namespace UMP.ViewModel
{
    [AutoMap(typeof(Doctor),ReverseMap =true)]
    public class DoctorVm
    {
         public int Id { get; set; } 
        public string Name { get; set; }=string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
