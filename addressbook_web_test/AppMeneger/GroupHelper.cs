using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace AddressbookWebTest
{
    public class GroupHelper : HelperBase
    {
        private List<GroupData> _groupCache = null;

        public GroupHelper(ApplicationManager menager) : base(menager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            _applicationManager.Navigation.GoToGroupsPage();
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int index)
        {
            _applicationManager.Navigation.GoToGroupsPage();
            SelectedGroup(index);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(GroupData group)
        {
            _applicationManager.Navigation.GoToGroupsPage();
            SelectedGroup(group.Id);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Modify(string index, GroupData newData)
        {
            _applicationManager.Navigation.GoToGroupsPage();
            SelectedGroup(index);
            CommonModify(newData);
            return this;
        }

        public GroupHelper Modify(int index, GroupData newData)
        {
            _applicationManager.Navigation.GoToGroupsPage();
            SelectedGroup(index);
            CommonModify(newData);
            return this;
        }

        private GroupHelper CommonModify(GroupData newData)
        {
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper CheckAndCreate(int index, GroupData newData)
        {
            ReturnToGroupsPage();
            if (!IsElementPresent(By.XPath($"//div[@id='content']/form/span[{index + 1}]/input")))
            {
                Create(newData);
            }
            return this;
        }


        public GroupHelper InitNewGroupCreation()
        {
            _driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            _driver.FindElement(By.XPath("//form[@action='/addressbook/group.php']")).Click();
            _driver.FindElement(By.Name("submit")).Click();
            _groupCache = null;
            return this;
        }

        public GroupHelper SelectedGroup(int index)
        {
            _driver.FindElement(By.XPath($"//div[@id='content']/form/span[{index + 1}]/input")).Click();
            return this;
        }
        public GroupHelper SelectedGroup(string id)
        {
            _driver.FindElement(By.XPath($"(//input[@name='selected[]' and @value='{id}'])")).Click();
            return this;
        }
        public GroupHelper RemoveGroup()
        {
            _driver.FindElement(By.Name("delete")).Click();
            _groupCache = null;
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            _driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {

            _driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {

            _driver.FindElement(By.Name("update")).Click();
            _groupCache = null;
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            if (_groupCache != null)
            {
                return _groupCache;
            }
            _groupCache = new List<GroupData>();
            _applicationManager.Navigation.GoToGroupsPage();
            var elements = _driver.FindElements(By.CssSelector("span.group"));
            foreach (var element in elements)
            {
                _groupCache.Add(new GroupData(element.Text)
                {
                    Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                });
            }
            return new List<GroupData>(_groupCache);
        }

        internal int GetGroupCount()
        {
            return _driver.FindElements(By.CssSelector("span.group")).Count;
        }
    }
}
