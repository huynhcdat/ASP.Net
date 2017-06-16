using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using Assignment3.Models;

namespace Assignment3.Controllers
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
                cfg.CreateMap<Models.Employee, Controllers.EmployeeBase>();
                cfg.CreateMap<Controllers.EmployeeBase, Controllers.EmployeeEditForm>();

                cfg.CreateMap<Controllers.EmployeeAdd, Models.Employee>();

                cfg.CreateMap<Models.Track, Controllers.TrackBase>();
              
            });

            mapper = config.CreateMapper();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }

        // Add methods below
        // Controllers will call these methods
        // Ensure that the methods accept and deliver ONLY view model objects and collections
        // The collection return type is almost always IEnumerable<T>

        public IEnumerable<EmployeeBase> EmployeeGetAll()
        {
            var c = ds.Employees.OrderBy(s => s.LastName);

            return mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeBase>>(c);
        }

        public EmployeeBase EmployeeGetById(int id)
        {
            var e = ds.Employees.Find(id);

            return (e == null) ? null : mapper.Map<Employee, EmployeeBase>(e);
        }

        public EmployeeBase EmployeeEdit(EmployeeEdit newItem)
        {
            var o = ds.Employees.Find(newItem.EmployeeId);
            if (o == null)
            {
                return null;
            }
            else
            {
                ds.Entry(o).CurrentValues.SetValues(newItem);
                ds.SaveChanges();
                return mapper.Map<EmployeeBase>(o);
            }
        }

        public IEnumerable<TrackBase> TrackGetAll()
        {
            var t = ds.Tracks.OrderBy(o => o.AlbumId).ThenBy(o => o.Name);
            return mapper.Map<IEnumerable<TrackBase>>(t);
        }


        public IEnumerable<TrackBase> TrackGetAllPop()
        {
            var t = ds.Tracks.Where(o => o.GenreId == 9).OrderBy(o => o.Name);
            return mapper.Map<IEnumerable<TrackBase>>(t);
        }


        public IEnumerable<TrackBase> TrackGetAllDeepPurple()
        {
            var t = ds.Tracks.Where(o => o.Composer.Contains("Jon Lord")).OrderBy(o => o.TrackId);
            return mapper.Map<IEnumerable<TrackBase>>(t);
        }



        public IEnumerable<TrackBase> TrackGetAllTop100Longest()
        {
            var t = ds.Tracks.OrderByDescending(o => o.Milliseconds).Take(100);
            return mapper.Map<IEnumerable<TrackBase>>(t);
        }



        // Suggested naming convention: Entity + task/action
        // For example:
        // ProductGetAll()
        // ProductGetById()
        // ProductAdd()
        // ProductEdit()
        // ProductDelete()






    }
}