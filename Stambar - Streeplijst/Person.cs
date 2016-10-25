using System;
using System.Collections.Generic;
using System.Text;

namespace Stambar {
    public class Person {
        public String name = "";
        public int id = -1;
        public int categoryId = -1;
        public int index = -1;

        private ProductCount[] counts;

        public Person(int id, String name, int category) {
            this.name = name;
            this.id = id;
            this.categoryId = category;
            counts = new ProductCount[0];
        }

        public Person(String initializer, int index) {
            Char[] delimeter = new Char[] { '=' };
            String[] splittedResponse = initializer.Split(delimeter);
            this.name = splittedResponse[1];
            this.id = Int32.Parse(splittedResponse[0]);
            this.categoryId = Int32.Parse(splittedResponse[2]);
            counts = new ProductCount[0];
        }

        public void buy(Product product)
        {
            if (counts.Length == 0) {
                addProduct(product);
            }

            foreach(ProductCount p in counts){
                if (p.getProduct() == product.id)
                {
                    p.add();
                    return;
                }
            }
            addProduct(product);
        }

        private void addProduct(Product product)
        {
            ProductCount[] temp = new ProductCount[counts.Length + 1];
            for (int j = 0; j < counts.Length; j++)
            {
                temp[j] = counts[j];
            }
            temp[temp.Length - 1] = new ProductCount(product.id);
            counts = temp;
        }

        public ProductCount[] getCounts()
        {
            return counts;
        }

        public String getCountString()
        {
            String result = "";
            foreach (ProductCount p in counts)
            {
                result = result + p.toString() + ";";
            }
            return result.Substring(0, result.Length - 1);
        }

        public void setCounts(String line)
        {
            List<ProductCount> counts = new List<ProductCount>();
            Char[] delimeter = new Char[] { ';' };
            String[] splittedResponse = line.Split(delimeter);
            foreach (String s in splittedResponse)
            {
                counts.Add(new ProductCount(s));
            }
            this.counts = counts.ToArray();
        }
    }
}
