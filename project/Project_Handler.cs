using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Project_Handler
    {
        
        public Portfolio _portfolio;

        //constructor
        public Project_Handler()
        {
            _portfolio = new Portfolio();
        }
        

        //Methods
        //adding a project
        public string AddProject(int type)
        {
            
            {
                Project project = new Project(type);
                _portfolio.Projects.Add(project);
                return $"A project with type {type} has been added with id: {project.Id}";
            }
 
        }
        public string AddProject(int id,int type)
        {

            {
                Project project = new Project(id,type);
                _portfolio.Projects.Add(project);
                return $"A project with type {type} has been added with id: {project.Id}";
            }

        }
        public Project GetProjectById(int id)
        {
            Project p = _portfolio.Projects.Find(p => p.Id == id);
            if (p != null)
            {
                return p;
            }
            else return null;
        } 
        public string RemoveProject(int id)
        {
            //Console.WriteLine("length of list : " + _portfolio.Projects.Count);
            if (_portfolio.Projects.Count == 0)
            {
                return "Portfolio is already empty";
            }
            Project? p = _portfolio.Projects.Find(p=> p.Id==id); 
            if (p != null)
            {
                _portfolio.Projects.Remove(p);
                return $"project with id {p.Id} was removed";
            }
            else
            {
                return "No such project available";
            }
        }

        //List all Projects

        public void AllProjects()
        {
            if (_portfolio.Projects.Count == 0)
            {
                Console.WriteLine("No projects in the portfolio");
            }
            else
            {
                for (int i = 0; i < _portfolio.Projects.Count; i++)
                {
                    Console.WriteLine($"Project Type  : {_portfolio.Projects[i].Type} , Project Id : {_portfolio.Projects[i].Id}");
                }
            }
            
        }
        //Summary of all projects Sales and Purchases and Tax Refund

        public void Portfolio_summary()
        {
            float total_portfolio_sales=0;
            float total_portfolio_purcahse=0;
            float total_portfolio_refund = 0;

            for (int i = 0; i < _portfolio.Projects.Count; i++)
            {
                total_portfolio_purcahse += _portfolio.Projects[i].Sum_P_Trans();
                total_portfolio_sales += _portfolio.Projects[i].Sum_S_Trans();
                total_portfolio_refund += _portfolio.Projects[i].refundAmount();
            }
            Console.WriteLine($"Total Sales in All Projects of PortFolio = {total_portfolio_sales}\n" +
                $"Total Purchase in All Projects of PortFolio = {total_portfolio_purcahse}\n" +
                $"Having Total Refund for All New Build Projects : {total_portfolio_refund}\n"+
                $"Total Projects Included: {_portfolio.Projects.Count}");

        }

    }
}
//using (StreamWriter sw = new StreamWriter(new FileStream(friendsPath, FileMode.Open, FileAccess.Write, FileShare.None)))
//{
//    string jsonData = JsonConvert.SerializeObject(friends);
//    sw.WriteLine(jsonData);
//}
//LoadData();