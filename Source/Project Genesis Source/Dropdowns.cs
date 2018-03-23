using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Genesis_Source
{
    public class Dropdowns
    {
        private string client = String.Empty;

        public string Client
        {
            get { return client; }
            set
            {
                if (client != value)
                {
                    client = value;
                }
            }
        }
    }
}
