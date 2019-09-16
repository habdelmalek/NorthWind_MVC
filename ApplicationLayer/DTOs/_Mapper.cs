using AutoMapper;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTOs
{
    public static class Mapper
    {
        private static IMapper _mapper = null;
        static Mapper()
        {
            if (_mapper== null)
            {
                MapperConfiguration mapperConfiguration = new MapperConfiguration(cnf =>
                {
                    cnf.CreateMap<Employee, EmployeeDTO>();
                    cnf.CreateMap<EmployeeDTO, Employee>();

                    cnf.CreateMap<Employee, EmployeeDTO1>();
                    cnf.CreateMap<EmployeeDTO1, Employee>();
                });
                _mapper = mapperConfiguration.CreateMapper();
            }
        }


        public static TDestination Map<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }

        public static TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapper.Map(source, destination);
        }
    }
}
