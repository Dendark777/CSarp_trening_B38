using OpenQA.Selenium;
using System;
using System.Reflection;

namespace AddressbookWebTest
{
    public class GroupHelper : HelperBase
    {
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

        internal GroupHelper Modify(int index, GroupData newData)
        {
            _applicationManager.Navigation.GoToGroupsPage();
            SelectedGroup(index);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
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
            return this;
        }

        public GroupHelper SelectedGroup(int index)
        {
            _driver.FindElement(By.XPath($"//div[@id='content']/form/span[{index}]/input")).Click();
            return this;
        }
        public GroupHelper RemoveGroup()
        {
            _driver.FindElement(By.Name("delete")).Click();
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
            return this;
        }
    }
}
