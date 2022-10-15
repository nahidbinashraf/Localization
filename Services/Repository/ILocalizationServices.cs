using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository
{
    public interface ILocalizationServices
    {
        IEnumerable<Resource> GetAllStrings();
        string GetResourceValue(string name);
    }
}
