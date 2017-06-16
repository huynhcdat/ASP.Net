using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using Assignment2.Models;

namespace Assignment2.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private DataContext ds = new DataContext();

        // AutoMapper instance
        public IMapper mapper;

        public Manager()
        {
            // If necessary, add more constructor code here...

            // Configure the AutoMapper components
            var config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Employee, EmployeeBase>();

            });

            mapper = config.CreateMapper();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;

            

        }

        public IEnumerable<EmployeeBase> EmployeeGetAll()
        {
            var c = ds.Employees.OrderBy(s => s.LastName);

            return Mapper.Map<IEnumerable<EmployeeBase>>(c);
        }

        public EmployeeBase EmployeeGetById(int id)
        {
            var e = ds.Employees.Find(id);

            return (e == null) ? null : Mapper.Map<EmployeeBase>(e);
        }

        public EmployeeBase EmployeeAdd(EmployeeAdd newItem)
        {
            var addedItem = ds.Employees.Add(Mapper.Map<EmployeeAdd, Employee>(newItem));
            ds.SaveChanges();

            return (addedItem == null) ? null : Mapper.Map<Employee, EmployeeBase>(addedItem);
        }
    }
    // Add methods below
    // Controllers will call these methods
    // Ensure that the methods accept and deliver ONLY view model objects and collections
    // The collection return type is almost always IEnumerable<T>

    // Suggested naming convention: Entity + task/action
    // For example:
    // ProductGetAll()
    // ProductGetById()
    // ProductAdd()
    // ProductEdit()
    // ProductDelete()






}
