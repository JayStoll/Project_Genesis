using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Genesis_Source
{
    class ViewModel
    {
        DropdownData source = new DropdownData();
        private ObserverCollection<Dropdowns> dropsList = new ObserverCollection<Dropdowns>();
        public ObserverCollection<Dropdowns> DropsList
        {
            get { return dropsList; }
        }

        public ViewModel()
        {
            foreach(var drop in source.GetDrops())
            {
                dropsList.Add(drop);
            }
        }
    }
}
