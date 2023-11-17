using MantisTests.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MantisTests.AppManager
{
    public class TaskHelper : HelperBase
    {
        public TaskHelper(ApplicationManager manager) : base(manager)
        {
        }

        public int CreateTask(TaskData task, ProjectData project)
        {
            _applicationManager.Projects.CreateProject(project);
            _applicationManager.Navigation.OpenPage($"{_applicationManager.BaseURL}/bug_report_page.php");
            FillTaskForm(task);
            SubmitConfirmForm("Создать задачу");
            return GetIdTask();
        }
        private void FillTaskForm(TaskData task)
        {
            _driver.FindElement(By.Id("summary")).SendKeys(task.Summary);
            _driver.FindElement(By.Id("description")).SendKeys(task.Description);
        }

        public int RemoveTask(int index)
        {
            var indexRow = CheckAnyTask(index) == 1 ? "" : $"[{index}]";

            _applicationManager.Navigation.OpenPage($"{_applicationManager.BaseURL}/view_all_bug_page.php");

            _driver.FindElement(By.XPath($"//table[@id='buglist']/tbody/tr{indexRow}/td[4]/a")).Click();
            var idTask = GetIdTask();
            SubmitConfirmForm("Удалить");
            SubmitConfirmForm("Удалить задачи");
            return idTask;
        }

        private int GetIdTask()
        {
            var idTask = _driver.FindElement(By.XPath($"//div[@id='main-container']/div[2]/div[2]/div/div/div/div[2]/div[2]/div/table/tbody/tr[2]/td")).Text;
            return int.Parse(idTask);
        }

        public bool CheckTask(int id)
        {
            _applicationManager.Navigation.OpenPage($"{_applicationManager.BaseURL}/view.php?id={id}");
            try
            {
                var element = _driver.FindElement(By.XPath($"//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/p[2]"));
                var text = element.Text;
                return text.Contains($"Задача {id} не найдена.");

            }
            catch (Exception)
            {
                return false;
            }
        }

        public int CheckAnyTask(int index)
        {
            _applicationManager.Navigation.OpenPage($"{_applicationManager.BaseURL}/view_all_bug_page.php");
            var elements = _driver.FindElements(By.XPath($"//table[@id='buglist']/tbody/tr"));

            if (!elements.Any())
            {
                ProjectData project = new ProjectData()
                {
                    Name = "TestProject",
                };
                TaskData task = new TaskData()
                {
                    Summary = "Test",
                    Description = "Test"
                };
                CreateTask(task, project);
                return 1;
            }
            return index;
        }
    }
}
