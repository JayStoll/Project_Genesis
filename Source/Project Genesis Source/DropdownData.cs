using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Genesis_Source
{
    public class DropdownData
    {
        private ObserverCollection<Dropdowns> drops = new ObserverCollection<Dropdowns>();

        public void CreateDropdownsData()
        {
            drops.Add(new Dropdowns()
            {
                Client = "John"
            });
            drops.Add(new Dropdowns()
            {
                Client = "Jean"
            });
            drops.Add(new Dropdowns()
            {
                Client = "Jay"
            });
        }

        internal IEnumerable<object> GetDrops()
        {
            throw new NotImplementedException();
        }

        //public ObserverCollection<Dropdowns> GetDrops()
        // {
        //     drops.Clear();
        //    CreateDropdownsData();
        //   return drops;
        //}

    }
}
