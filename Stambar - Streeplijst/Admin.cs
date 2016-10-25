using System;
using System.Collections.Generic;
using System.Text;

namespace Stambar {
    public class Admin {

        public String name = "";
        public int id = -1;
        public String pin = "";
        public bool writeDebt = false;

        public Admin(int id, String name, String pin, bool writeDebt) {
            this.id = id;
            this.name = name;
            this.pin = pin;
            this.writeDebt = writeDebt;
        }

        /**
         * Init String "id=name=pin=writedebt"
         */
        public Admin(String initializer) {
            Char[] delimeter = new Char[] { '=' };
            String[] splittedResponse = initializer.Split(delimeter);
            this.name = splittedResponse[1];
            this.id = Int32.Parse(splittedResponse[0]);
            this.pin = splittedResponse[2];
            int w = Int32.Parse(splittedResponse[3]);
            if (w == 1) {
                writeDebt = true;
            } else {
                writeDebt = false;
            }
        }
    }
}
