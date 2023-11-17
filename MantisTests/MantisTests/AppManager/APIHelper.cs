using MantisTests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTests.AppManager
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager)
        {
        }

        internal void CreatNewTask(AccountData account, TaskData task)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData()
            {
                summary = task.Summary,
                description = task.Description,
                category =  task.Category,
            };
            client.mc_issue_add(account.Name,account.Password, issue);
            var issues = client.mc_issues_get(account.Name, account.Password,new string[] { "0000023" });
            Console.WriteLine(IssueToString(issues[0]));
        }

        public string IssueToString(Mantis.IssueData issue)
        {
            return $"{issue.summary} {issue.description} {issue.category} {issue.project}";
        }
    }
}
