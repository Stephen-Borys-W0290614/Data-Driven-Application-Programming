using NSCCApplicationFormDataLayer;
using NSCCApplicationFormDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSCCApplicationFormDbConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            Country newCountry = new Country();
            newCountry.Code = "CA";
            newCountry.Name = "Canada";

            NSCCApplicationDbContext context = new NSCCApplicationDbContext();

            context.Countrys.Add(newCountry);

            context.SaveChanges();


        }
    }
}
