using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public static class Utilities
    {
        public static void Save(Portfolio _portfolio)
        {
            string path = "F:\\Self Work\\FREELANCE\\Abdullah Projects\\Land Management\\project\\project\\data.txt";
            using (StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.Truncate, FileAccess.Write, FileShare.None)))
            {
                for (int i = 0; i < _portfolio.Projects.Count; i++)
                {
                    sw.WriteLine($"{_portfolio.Projects[i].Id},{_portfolio.Projects[i].Type}");
                    for (int j = 0; j < _portfolio.Projects[i].Transactions.Count; j++)
                    {
                        //Console.WriteLine($"Trans:Id:{_portfolio.Projects[i].Transactions[j].Id}, Trans Type:{_portfolio.Projects[i].Transactions[j].Type},Trans Amount: {_portfolio.Projects[i].Transactions[j].Amount},Proje ID: {_portfolio.Projects[i].Transactions[j].Proj_Id}");
                        sw.WriteLine($"{_portfolio.Projects[i].Transactions[j].Type},{_portfolio.Projects[i].Transactions[j].Amount},{_portfolio.Projects[i].Id},{_portfolio.Projects[i].Transactions[j].Id}");
                    }
                }
            }

        }
        public static void LoadData(Portfolio _portfolio)
        {
            string path = "data.txt";
            string data = "";
            string[] x;
            using (StreamReader sr = new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None)))
            {
        
                _portfolio.Projects.Clear();
                List<Project_Transaction> temp_transactions = new List<Project_Transaction>();
                while (!sr.EndOfStream)
                {
                    
                    data = sr.ReadLine();
                    string[] splitted = data.Trim().Split(",");
                    
                    if (splitted.Length == 2)
                    {

                        _portfolio.Projects.Add(new Project(Convert.ToInt32(splitted[0]),Convert.ToInt32(splitted[1])));//Project type as input

                    }
                    else if (splitted.Length == 4)
                    {
                        float amount = Convert.ToSingle(splitted[1]);
                        int type = Convert.ToInt32(splitted[0]);
                        int Proj_Id = Convert.ToInt32(splitted[2]);
                        int transId = Convert.ToInt32(splitted[3]);
                        Project_Transaction p = new Project_Transaction(type,amount,Proj_Id,transId);
                        temp_transactions.Add(p);
                    }
                }

                //for (int i = 0; i < _portfolio.Projects.Count; i++)
                //{
                //    Console.WriteLine(_portfolio.Projects[i].Summary());
                //}
                //Console.WriteLine("##########################################");
                Project_Transaction.count = 0;
                for (int i = 0; i < _portfolio.Projects.Count; i++)
                {
                    for (int j = 0; j < temp_transactions.Count; j++)
                    {
                        if (temp_transactions[j].Proj_Id == _portfolio.Projects[i].Id)
                        {
                            //float amount, int pId,int type = 0
                            _portfolio.Projects[i].AddTransaction(temp_transactions[j].Amount, temp_transactions[j].Proj_Id, temp_transactions[j].Type);
                        }


                    }
                }
                int max = _portfolio.Projects.Count;
                for (int i = 1; i < _portfolio.Projects.Count; i++)
                {
                    if (_portfolio.Projects[i].Id > max)
                    {
                        max = _portfolio.Projects[i].Id + 1;
                    }
                }

                Project.Project_Count = max;

                //Console.WriteLine("##########################################");

                //for (int i = 0; i < _portfolio.Projects.Count; i++)
                //{
                //    Console.WriteLine(_portfolio.Projects[i].Summary());
                //}
            }
        }
    }
}
