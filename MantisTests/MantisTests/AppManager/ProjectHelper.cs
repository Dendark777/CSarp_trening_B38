﻿using MantisTests.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTests.AppManager
{
    internal class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager)
        {
        }


        public void CreateProject(ProjectData project)
        {
            if (CheckProjectExist(project))
            {
                return;
            }
            _applicationManager.Navigation.OpenPage($"{_applicationManager.BaseURL}/manage_proj_create_page.php");
            _driver.FindElement(By.Id("project-name")).SendKeys(project.Name);
            SubmitConfirmForm("Добавить проект");
            SelectProject(project.Name);
        }

        public void RemoveProject(ProjectData project)
        {
            if (!CheckProjectExist(project))
            {
                CreateProject(project);
            }
            _applicationManager.Navigation.OpenPage($"{_applicationManager.BaseURL}/manage_proj_page.php");
            OpenProjectDialog(project);
            _driver.FindElement(By.XPath($"//form[@id='manage-proj-update-form']/div/div[3]/button[2]")).Click();
            SubmitConfirmForm("Удалить проект");
        }

        private void OpenProjectDialog(ProjectData project)
        {
            var table = _driver.FindElement(By.TagName("table"));
            table.FindElement(By.LinkText(project.Name)).Click();
        }


        public bool CheckProjectExist(ProjectData project)
        {
            try
            {
                _driver.FindElement(By.Id("dropdown_projects_menu")).Click();
                _driver.FindElement(By.XPath("//ul[@id='projects-list']/li[3]/div/ul/li/a")).Click();
                SelectProject(project.Name);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void SelectProject(string projectName)
        {
            _driver.FindElement(By.LinkText("Все проекты")).Click();
            _driver.FindElement(By.LinkText(projectName)).Click();
        }

        public List<ProjectData> GetProjectsFromApi(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            var projects = client.mc_projects_get_user_accessible(account.Name, account.Password);
            return projects.Select(x => new ProjectData { Name = x.name }).ToList();
        }

        public void CreateProjectFromApi(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData mProject = new Mantis.ProjectData()
            {
                name = project.Name
            };
            client.mc_project_add(account.Name, account.Password, mProject);
        }
    }
}
