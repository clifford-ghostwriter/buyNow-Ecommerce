using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buyNow.BAL.Models
{
    internal class SidebarLinks
    {
        public int id;
        public string name;
        public string link;
        public string icon;

        public SidebarLinks(int _id, string _name, string _link, string _icon)
        {
            id = _id;
            name = _name;
            link = _link;
            icon = _icon;
            
            

        }

    }
}
