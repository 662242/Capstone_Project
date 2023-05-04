using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace project
{
    public class Project
    {
        public static int Project_Count=0;
        //Properties
        public int Id { get; set; }
        public int Type { get; set; }

        public List<Project_Transaction>? Transactions { get; set; }
        //Constructor
        //public Project() {

        //    Transactions = new List<Project_Transaction> {
        //        new Project_Transaction(1,520.00f),
        //        new Project_Transaction(0,582.96f),
        //        new Project_Transaction(1,1000.24f),
        //        new Project_Transaction(0,860.20f) };
        //    this.Id = Project_Count++;
        //}
        public Project(int type) //By default it is a new build project
        {
            if (type == 0 || type==1)
            {
                this.Type = type;
            }
            else
            {
                this.Type = 1;
            }
            Transactions = new List<Project_Transaction> ();
            this.Id = Project_Count++;
            //this.Type = type; //1 for build , 0 for renovation
        }
        public Project(int id,int type) //By default it is a new build project
        {
            if (type == 0 || type == 1)
            {
                this.Type = type;
            }
            else
            {
                this.Type = 1;
            }
            Transactions = new List<Project_Transaction>();
            this.Id = id;
            //this.Type = type; //1 for build , 0 for renovation
        }

        //Methods

        //List of Sales Transactions
        public List<Project_Transaction> Sale_Transactions()
        {
            List<Project_Transaction> result = new List<Project_Transaction>();
            for(int i = 0; i < Transactions.Count; i++)
            {
                if (Transactions[i].Type == 1)
                {
                    result.Add(Transactions[i]);
                }
            }
            return result;
        }
        //List of Purchase Transcations
        public List<Project_Transaction> Purchase_Transactions()
        {
            List<Project_Transaction> result = new List<Project_Transaction>();
            for (int i = 0; i < Transactions.Count; i++)
            {
                if (Transactions[i].Type == 0)
                {
                    result.Add(Transactions[i]);
                }
            }
            return result;
        }
        //ADD A NEW TRANSACTION
        //public string AddTransaction(float amount,int type = 0,int pId)//By dedault  0=>Purchase
        //{
        //    if (type<0 ||type>1)
        //    {
        //        return "Type can be either 1->Sales or 0->Purchase";
        //    }
        //    try
        //    {
        //        this.Transactions.Add(new Project_Transaction(type, amount,pId));

        //    }catch(Exception e)
        //    {
        //        return $"Caught an exception : {e.Message}";
        //    }
        //    return $"A new Transaction was added";
        //}
        public string AddTransaction(float amount, int pId,int type = 0)//By dedault  0=>Purchase
        {
            Console.WriteLine(Project_Transaction.count);
            if (type < 0 || type > 1)
            {
                return "Type can be either 1->Sales or 0->Purchase";
            }
            try
            {
                this.Transactions.Add(new Project_Transaction(type, amount, pId));
            }
            catch (Exception e)
            {
                return $"Caught an exception : {e.Message}";
            }
            return $"A new Transaction was added";
        }
        public void AllSalesTransactions()
        {
            Console.WriteLine(">>>All Sales Transactions are as follow:");
            for (int i = 0; i < this.Transactions.Count; i++)
            {
                if (this.Transactions[i].Type == 1)
                {
                    Console.WriteLine($"Id : {this.Transactions[i].Id},Amount: {this.Transactions[i].Amount} , Type:{this.Transactions[i].Type}");
                }
            }
        }
        public float refundAmount()
        {
            if(this.Type == 1)
            {
                return Convert.ToSingle(this.Sum_P_Trans()*0.2);
            }
            else
            {
                return 0.0f;
            }
        }
        public float Sum_S_Trans()
        {
            float sum = 0;
            for(int i =0;i< this.Transactions.Count; i++)
            {
                if (this.Transactions[i].Type == 1)
                {
                    sum += this.Transactions[i].Amount;
                }
            }
            return sum;
        }
        public float Sum_P_Trans()
        {
            float sum = 0;
            for (int i = 0; i < this.Transactions.Count; i++)
            {
                if (this.Transactions[i].Type == 0)
                {
                    sum += this.Transactions[i].Amount;
                }
            }
            return sum;
        }
        public void AllPurchaseTransactions()
        {
            Console.WriteLine(">>>All Purchase Transactions are as follow:");

            for (int i = 0; i < this.Transactions.Count; i++)
            {
                if (this.Transactions[i].Type == 0)
                {
                    Console.WriteLine($"Id : {this.Transactions[i].Id},Amount: {this.Transactions[i].Amount} , Type:{this.Transactions[i].Type}");
                }
            }
        }
        public string Summary()
        {
            float sum_Sales = this.Sum_S_Trans();
            
            float sum_Purchase = this.Sum_P_Trans();
            float refund = 0;
            
            //for(int i =0; i < this.Transactions.Count; i++)
            //{
            //    if (Transactions[i].Type == 0)
            //    {
            //        sum_Purchase += Transactions[i].Amount;
            //    }
            //    else
            //    {
            //        sum_Sales += Transactions[i].Amount;

            //    }
            //}
            if (this.Type == 1)
            {
                refund = (sum_Purchase*20)/100;

            }//1 for build ,0 for Renovation

            return $"Total Amount of Purchase = {sum_Purchase}" +
                   $"\nTotal Amount of Sales = {sum_Sales}" +
                   $"\nTotal Refund value = {refund} due to Type of Project = {this.Type}" +
                   $"\nProject Id : {this.Id}" +
                   $"\nNumber of Transactions : {this.Transactions.Count}";
                   
        }

        //File Save
        //public void SaveData()
        //{
        //    var csv = new StringBuilder();
        //    csv.AppendLine("Project Id,TransCount,Transaction Type,Transaction Amount,Transaction Id");

        //        foreach (var transaction in this.Transactions)
        //        {
        //            var row = string.Format("{1},{2},{3},{4},{5}",this.Id, Project_Transaction.count,
        //                transaction.Type, transaction.Amount, transaction.Id);
        //            csv.AppendLine(row);
        //        }
            
        //    File.WriteAllText("projects.csv", csv.ToString());
        //}

    }
}
