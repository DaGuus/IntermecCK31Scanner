using System;
using System.Collections.Generic;
using System.Text;

namespace Stambar
{
    public class Product
    {
        public String name = "";
        public int id = -1;
        public int index = -1;

        public Product(int id, String name)
        {
            this.name = name;
            this.id = id;
        }

        public Product(String init, int index)
        {
            Char[] delimeter = new Char[] { '=' };
            String[] nameSplit = init.Split(delimeter);
            this.index = index;
            this.id = Int32.Parse(nameSplit[0]);
            this.name = nameSplit[1];
        }
    }
}
