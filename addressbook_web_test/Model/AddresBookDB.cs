using AddressbookWebTest.Model;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AddressbookWebTest
{
    internal class AddresBookDB : LinqToDB.Data.DataConnection
    {
        public AddresBookDB():base("AddressBook") { }

        public ITable<GroupData> Groups { get { return this.GetTable<GroupData>(); } }
        public ITable<ContactData> Contacts { get { return this.GetTable<ContactData>(); } }
        public ITable<GroupContactRelation> GCR { get { return this.GetTable<GroupContactRelation>(); } }
    }
}
