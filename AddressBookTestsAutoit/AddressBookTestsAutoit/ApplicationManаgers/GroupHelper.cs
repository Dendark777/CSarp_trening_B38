using AddressBookTestsAutoit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookTestsAutoit.ApplicationManаgers
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public GroupHelper(ApplicationManаger applicationManаger) : base(applicationManаger)
        {
        }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialog();
            _autoItX3.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            _autoItX3.Send(newGroup.Name);
            _autoItX3.Send("{ENTER}");
            CloseGroupsDialog();

        }

        public List<GroupData> GetGroupsList()
        {
            var list = new List<GroupData>();
            OpenGroupsDialog();
            string count = _autoItX3.ControlTreeView(GROUPWINTITLE, "",
                                      "WindowsForms10.SysTreeView32.app.0.2c908d51",
                                      "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = _autoItX3.ControlTreeView(GROUPWINTITLE, "",
                                      "WindowsForms10.SysTreeView32.app.0.2c908d51",
                                      "GetText", "#0|#" + i, "");
                list.Add(new GroupData() { Name = item });
            }
            CloseGroupsDialog();
            return list;
        }
        private void CloseGroupsDialog()
        {
            _autoItX3.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        private void OpenGroupsDialog()
        {
            _autoItX3.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            _autoItX3.WinWait(GROUPWINTITLE);
        }

    }
}
