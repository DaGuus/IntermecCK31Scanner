using System;
using System.Collections.Generic;
using System.Text;

namespace Stambar
{
    public class ProductCount
    {
        private int product;
        private int count;

        public ProductCount(int product)
        {
            this.product = product;
            count = 0;
        }

        public ProductCount(String str)
        {
            Char[] delimeter = new Char[] { '=' };
            String[] splittedResponse = str.Split(delimeter);
            this.product = Int32.Parse(splittedResponse[0]);
            this.count = Int32.Parse(splittedResponse[1]);
        }

        public int getProduct()
        {
            return product;
        }

        public void add()
        {
            count++;
        }

        public int getCount()
        {
            return count;
        }

        public String toString()
        {
            return product + "=" + count;
        }
    }
}
