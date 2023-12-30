using AutoMapper;
using Demo.DAL.Model;
using Demo.PL.ViewModel;

namespace Demo.PL.Mapper
{
    public class Maperprofile :Profile
    {
        public Maperprofile()
        {

            CreateMap<EmployeeVM, Employee>().ForMember(E => E.CreationTime, opt => opt.Ignore()).ReverseMap();
                  
        }
    }
}
