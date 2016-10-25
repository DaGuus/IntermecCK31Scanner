using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Stambar
{
    public partial class AddPerson : Form {

        private Person[] persons;

        public AddPerson(Person[] persons) {
            this.persons = persons;
            InitializeComponent();
        }

        private void AddPerson_Load(object sender, EventArgs e) {
            foreach (Person p in persons) {
                personBox.Items.Add(p.name);
            }
        }

        public Person getPerson()
        {
            return persons[personBox.SelectedIndex];
        }
    }
}