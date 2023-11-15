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
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;

namespace AddressBookTestsWhite.ApplicationManаgers
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public GroupHelper(ApplicationManаger applicationManаger) : base(applicationManаger)
        {
        }

        public void Add(GroupData newGroup)
        {
            Window dialog = OpenGroupsDialog();
            dialog.Get<Button>("uxNewAddressButton").Click();
            var textBox = (TextBox)dialog.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            CloseGroupsDialog(dialog);
        }

        public List<GroupData> GetGroupsList()
        {
            var list = new List<GroupData>();
            Window dialog = OpenGroupsDialog();
            Tree tree = dialog.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach (var item in root.Nodes)
            {
                list.Add(new GroupData() { Name = item.Text });
            }
            CloseGroupsDialog(dialog);
            return list;
        }

        internal void Remove(int index)
        {
            Window dialog = OpenGroupsDialog();
            Tree tree = dialog.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            root.Nodes[index].Click();
            dialog.Get<Button>("uxDeleteAddressButton").Click();
            dialog.ModalWindow("Delete group").Get<Button>("uxOKAddressButton").Click();
            CloseGroupsDialog(dialog);
        }

        private void CloseGroupsDialog(Window dialog)
        {
            dialog.Get<Button>("uxCloseAddressButton").Click();
        }

        private Window OpenGroupsDialog()
        {
            _applicationManаger.MainWindow.Get<Button>("groupButton").Click();
            return _applicationManаger.MainWindow.ModalWindow(GROUPWINTITLE);
        }

    }
}
