using AddressBookTestsWhite.ApplicationManаgers;
using AddressBookTestsWhite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TableItems;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;

namespace AddressBookTestsWhite.ApplicationManаgers
{
    public class ContactHelper : HelperBase
    {
        public static string CONTACTWINTITLE = "Contact Editor";
        private readonly Window _mainWindow;
        public ContactHelper(ApplicationManаger applicationManаger) : base(applicationManаger)
        {
            _mainWindow = _applicationManаger.MainWindow;
        }

        public void Add(ContactData newContact)
        {
            Window dialog = OpenContactsDialog();
            FillContactEditor(dialog, newContact);
            CloseContactsDialog(dialog);
        }

        private void FillContactEditor(Window dialog, ContactData newContact)
        {
            dialog.Get<TextBox>("ueIdentifierAddressTextBox").Enter(newContact.Id);
            dialog.Get<TextBox>("ueFirstNameAddressTextBox").Enter(newContact.FirstName);
            dialog.Get<TextBox>("ueLastNameAddressTextBox").Enter(newContact.LastName);
            dialog.Get<TextBox>("ueCityAddressTextBox").Enter(newContact.City);
            dialog.Get<TextBox>("ueAddressAddressTextBox").Enter(newContact.Address);
            if (!string.IsNullOrEmpty(newContact.Company))
            {
                dialog.Get<CheckBox>("uxIsCompanyGasCheckBox").Checked = true;
                dialog.Get<TextBox>("ueCompanyAddressTextBox").Enter(newContact.Company);
            }
        }

        public List<ContactData> GetContactsList()
        {
            var list = new List<ContactData>();
            Table table = _mainWindow.Get<Table>("uxAddressGrid");
            foreach (var row in table.Rows)
            {
                list.Add(new ContactData() 
                {
                    FirstName = row.Cells[0].Value.ToString(),
                    LastName = row.Cells[1].Value.ToString(),
                    Company = row.Cells[2].Value.ToString(),
                    City = row.Cells[3].Value.ToString(),
                    Address = row.Cells[4].Value.ToString(),
                });
            }
            return list;
        }

        public void Remove(int index)
        {
            Table table = _mainWindow.Get<Table>("uxAddressGrid");
            table.Rows[index].Click();
            _mainWindow.Get<Button>("uxDeleteAddressButton").Click();
            _mainWindow.ModalWindow("Question")
                       .Get<Button>(SearchCriteria.ByText("Yes")).Click();
        }
        private Window OpenContactsDialog()
        {
            _mainWindow.Get<Button>("uxNewAddressButton").Click();
            return _mainWindow.ModalWindow(CONTACTWINTITLE);
        }

        private void CloseContactsDialog(Window dialog)
        {
            dialog.Get<Button>("uxSaveAddressButton").Click();
        }

    }
}
