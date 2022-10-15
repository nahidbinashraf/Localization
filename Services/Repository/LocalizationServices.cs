using Microsoft.EntityFrameworkCore;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository
{
    public class LocalizationServices : ILocalizationServices
    {
        private readonly MyDBContext _db = new MyDBContext();
        //public LocalizationServices(MyDBContext db)
        //{
        //   // _db = db;
        //}
        public IEnumerable<Resource> GetAllStrings()
        {
            return _db.Resources
               .Include(r => r.Culture)
               .Where(r => r.Culture.Name == CultureInfo.CurrentCulture.Name)
               .Select(r => new Resource
               {
                   Key = r.Key,
                   Value = r.Value
               });
        }
        public string GetResourceValue(string name)
        {
            return _db.Resources
              .Include(r => r.Culture)
              .Where(r => r.Culture.Name == CultureInfo.CurrentCulture.Name)
              .FirstOrDefault(r => r.Key == name)?.Value;
        }
    }
}
