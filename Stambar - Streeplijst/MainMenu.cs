using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Intermec.DataCollection;
using System.Net.Sockets;
using System.Net;
using System.IO;
using Intermec.Device.Audio;
using Stambar;

namespace BarcodeReader_ce {
    public partial class Form1 : Form
    {
        //declare barcode reader object
        private Intermec.DataCollection.BarcodeReader bcr;

        private PolyTone succesTone;
        private PolyTone errorTone;
        private String ServerIP;

        private Person[] personArray;
        private Person[] personInListArray;
        private Product[] productArray;
        private Barcode[] barcodeArray;
        private Admin[] adminArray;

        private int updates;
        private int MAX_UPDATES;

        public Form1()
        {
            InitializeComponent();

            readSettings();

            readPersonData();
            readProductData();
            readBarcodes();

            initProductBox();

            succesTone = this.CreatePolyTone2(1);
            errorTone = this.CreatePolyTone1(1);

            updates = 0;
            MAX_UPDATES = 5;
            personInListArray = new Person[0];

            try
            {
                //create a instance of BarcodeReader class
                bcr = new BarcodeReader();
                //set BarcodeRead event
                bcr.BarcodeRead += new BarcodeReadEventHandler(bcr_BarcodeRead);
                //sends the BarcodeRead event after each successful read
                bcr.ThreadedRead(true);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void getPersonData()
        {
            String response = Connect("getPersons");
            Char[] delimeter = new Char[] { ';' };
            String[] splittedResponse = response.Split(delimeter);

            List<Person> persons = new List<Person>();

            int i = 0;
            foreach (string name in splittedResponse)
            {
                Person pe = new Person(name, i);
                persons.Add(pe);
                i++;
            }
            personArray = persons.ToArray();
        }

        private void readSettings()
        {
            String line;

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("\\Application Data\\stambar\\settings.txt");

                //Read the first line of text
                line = sr.ReadLine();
                ServerIP = line;
                //Continue to read until you reach end of file
                /*
                while (line != null) {
                    //write the lie to console window
                    Person person = new Person(line, i);
                    persons.Add(person);
                    //Read the next line
                    line = sr.ReadLine();
                    i++;
                }
                */

                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {

            }
        }

        private void readPersonData()
        {
            String line;
            List<Person> persons = new List<Person>();
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("\\Application Data\\stambar\\persons.txt");

                //Read the first line of text
                line = sr.ReadLine();
                int i = 0;
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the lie to console window
                    Person person = new Person(line, i);
                    persons.Add(person);
                    //Read the next line
                    line = sr.ReadLine();
                    i++;
                }
                personArray = persons.ToArray();

                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {

            }
        }

        private void getProductData()
        {
            String response = Connect("getProducts");
            Char[] delimeter = new Char[] { ';' };
            String[] splittedResponse = response.Split(delimeter);

            List<Product> products = new List<Product>();

            int i = 0;
            foreach (string name in splittedResponse)
            {
                Product pr = new Product(name, i);
                productBox.Items.Add(pr.name + " - 0");
                products.Add(pr);
                i++;
            }
            productArray = products.ToArray();
        }

        private void readProductData()
        {
            String line;
            List<Product> products = new List<Product>();
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("\\Application Data\\stambar\\products.txt");

                //Read the first line of text
                line = sr.ReadLine();
                int i = 0;
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the lie to console window
                    Product product = new Product(line, i);
                    products.Add(product);
                    //Read the next line
                    line = sr.ReadLine();
                    i++;
                }

                productArray = products.ToArray();
                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {

            }
        }

        private void getAdmins()
        {
            String response = Connect("getAdmins");
            Char[] delimeter = new Char[] { ';' };
            String[] splittedResponse = response.Split(delimeter);

            List<Admin> admins = new List<Admin>();

            foreach (string name in splittedResponse)
            {
                Admin admin = new Admin(name);
                admins.Add(admin);
            }
            adminArray = admins.ToArray();
        }

        private void getBarcodes()
        {
            String response = Connect("getBarcodes");
            Char[] delimeter = new Char[] { ';' };
            String[] splittedResponse = response.Split(delimeter);

            List<Barcode> barcodes = new List<Barcode>();

            foreach (string name in splittedResponse)
            {
                Barcode barcode = new Barcode(name);
                barcodes.Add(barcode);
            }
            barcodeArray = barcodes.ToArray();
        }

        private void readBarcodes()
        {
            String line;
            List<Barcode> barcodes = new List<Barcode>();
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("\\Application Data\\stambar\\barcodes.txt");

                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the lie to console window
                    Barcode barcode = new Barcode(line);
                    barcodes.Add(barcode);
                    //Read the next line
                    line = sr.ReadLine();
                }

                barcodeArray = barcodes.ToArray();
                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {

            }
        }

        private void initProductBox() {
            int i = 0;
            foreach (Product product in productArray) {
                productBox.Items.Add(product.name);
                product.index = i;
                i++;
            }
        }

        private String Connect(string toSend)
        {
            try
            {
                IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(ServerIP), 6066);

                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(serverAddress);

                // Sending
                int toSendLen = System.Text.Encoding.ASCII.GetByteCount(toSend);
                byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(toSend);
                byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
                clientSocket.Send(toSendLenBytes);
                clientSocket.Send(toSendBytes);

                // Receiving
                byte[] rcvLenBytes = new byte[4];
                clientSocket.Receive(rcvLenBytes);
                int rcvLen = System.BitConverter.ToInt32(rcvLenBytes, 0);
                byte[] rcvBytes = new byte[rcvLen];
                clientSocket.Receive(rcvBytes);
                String rcv = System.Text.Encoding.ASCII.GetString(rcvBytes, 0, rcvLen);

                clientSocket.Close();
                return rcv;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        void bcr_BarcodeRead(object sender, BarcodeReadEventArgs bre){
            try{
                //Barcode Read Event Handling
                String scannedCode = bre.strDataBuffer;

                foreach (Barcode barcode in barcodeArray){
                    if (barcode.code.Equals(scannedCode)){
                        int targetId = barcode.targetId;
                        int type = barcode.type;

                        if (type == 1){
                            //Person
                            for (int i = 0; i < personArray.Length; i++){
                                if (personArray[i].id == targetId){
                                    Person person = personArray[i];
                                    Person[] temp = new Person[personInListArray.Length];
                                    for (int j = 0; j < personInListArray.Length; j++) {
                                        temp[j] = personInListArray[j];
                                    }
                                    temp[temp.Length - 1] = person;
                                    personInListArray = temp;
                                    return;
                                }
                            }
                        }
                        else if (type == 2){
                            //Product
                            for (int i = 0; i < productArray.Length; i++)
                            {
                                if (productArray[i].id == targetId)
                                {
                                    Product product = productArray[i];
                                    Person person = personInListArray[(personBox.SelectedIndex)];

                                    buy(person, product);
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void buy(Person person, Product product)
        {
            person.buy(product);
            updates++;
            if (updates > MAX_UPDATES)
            {
                saveFile();       
            }
        }

        private void saveFile()
        {
            try
            {

                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("\\Application Data\\stambar\\streeplijst.txt");

                foreach (Person person in personArray)
                {
                    sw.WriteLine(person.id + ":" + person.getCountString());
                }

                //Close the file
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        private void loadFile()
        {
            String line;
            List<Person> pList = new List<Person>();
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("\\Application Data\\stambar\\streeplijst.txt");

                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                Char[] delimeter = new Char[] { ':' };
                while (line != null)
                {
                    String[] splittedResponse = line.Split(delimeter);
                    int personId = Int32.Parse(splittedResponse[0]);

                    foreach (Person p in personArray)
                    {
                        p.setCounts(splittedResponse[1]);
                        pList.Add(p);
                    }

                    line = sr.ReadLine();
                }
                personInListArray = pList.ToArray();
                

                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        private void refreshPersonList()
        {
            personBox.Items.Clear();
            foreach (Person p in personInListArray)
            {
                personBox.Items.Add(p.name);
            }
        }

        private void personBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Person person = personInListArray[personBox.SelectedIndex];
            productBox.Items.Clear();
            ProductCount[] counts = person.getCounts();
            foreach (ProductCount p in counts)
            {
                int pId = p.getProduct();
                foreach (Product pr in productArray)
                {
                    if (pr.id == pId)
                    {
                        productBox.Items.Add(pr.name + " - " + p.getCount());
                        break;
                    }
                }
            }
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            //Refresh Persons
            getPersonData();

            try
            {

                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("\\Application Data\\stambar\\persons.txt");

                foreach (Person person in personArray)
                {
                    sw.WriteLine(person.id + "=" + person.name + "=" + person.categoryId);
                }

                //Close the file
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            //Refresh Admins
            getAdmins();

            try
            {

                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("\\Application Data\\stambar\\admins.txt");

                foreach (Admin admin in adminArray)
                {
                    sw.WriteLine(admin.id + "=" + admin.name + "=" + admin.pin + "=" + admin.writeDebt);
                }

                //Close the file
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            //Refresh Products
            getProductData();

            try
            {

                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("\\Application Data\\stambar\\products.txt");

                foreach (Product product in productArray)
                {
                    sw.WriteLine(product.id + "=" + product.name);
                }

                //Close the file
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        internal PolyTone CreatePolyTone1(int speed_factor)
        {
            int time = 100 / speed_factor;
            return new PolyTone(
                200, time, Tone.VOLUME.LOUD,
                150, time, Tone.VOLUME.LOUD,
                250, time, Tone.VOLUME.LOUD,
                200, time, Tone.VOLUME.LOUD,
                400, time, Tone.VOLUME.LOUD,
                350, time * 3, Tone.VOLUME.LOUD
                );
        }

        internal PolyTone CreatePolyTone2(int speed_factor)
        {
            int time = 100 / speed_factor;
            return new PolyTone(
                600, time, Tone.VOLUME.LOUD,
                450, time, Tone.VOLUME.LOUD,
                750, time, Tone.VOLUME.LOUD
                );
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            //Refresh Barcodes
            getBarcodes();

            try
            {

                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("\\Application Data\\stambar\\barcodes.txt");

                foreach (Barcode barcode in barcodeArray)
                {
                    sw.WriteLine(barcode.code + "=" + barcode.targetId + "=" + barcode.type);
                }

                //Close the file
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        private void menuItem10_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void addPersonButton_Click(object sender, EventArgs e)
        {
            AddPerson add = new AddPerson(personArray);
            if(add.ShowDialog() == DialogResult.OK){
                if (personInListArray.Length == 0)
                {
                    personInListArray = new Person[1];
                    personInListArray[1] = add.getPerson();
                }
                else
                {
                    Person[] temp = new Person[personInListArray.Length + 1];
                    for (int i = 0; i < personInListArray.Length; i++)
                    {
                        temp[i] = personInListArray[i];
                    }
                    temp[temp.Length - 1] = add.getPerson();
                    personInListArray = temp;
                }
                refreshPersonList();
            }
        }
    }

    class Category
    {
        public String name = "";
        public int id = -1;
        public int index = -1;

        public Category(int id, String name)
        {
            this.name = name;
            this.id = id;
        }

        public Category(String init, int index)
        {
            Char[] delimeter = new Char[] { '=' };
            String[] nameSplit = init.Split(delimeter);
            this.index = index;
            this.id = Int32.Parse(nameSplit[0]);
            this.name = nameSplit[1];
        }
    }

    class Barcode
    {
        public String code = "";
        public int targetId = -1;
        public int type = -1;

        public Barcode(String init)
        {
            Char[] delimeter = new Char[] { '=' };
            String[] nameSplit = init.Split(delimeter);
            code = nameSplit[0];
            targetId = Int32.Parse(nameSplit[1]);
            type = Int32.Parse(nameSplit[2]);
        }
    }
}