using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Project_Transaction
    {
        //variables
        public static int  count =0;
        //Properties
        public int Id { get; set; }
        public int Proj_Id { get; set; }
        public int Type { get; set; } // Type 1 for Sales , Type 0 for Purchase
        public float Amount { get; set; }

        //Constructor
        //public Project_Transaction()
        //{
        //    count++;
        //}
        public Project_Transaction(int type, float amount,int projectId)
        {
            this.Id = count++;//assign the value of count and then add one to it
            if(type <0 || type > 1) 
            {
            this.Type = 0;
            }
            else {
            this.Type = type;
            }
            this.Amount = amount;
            
            this.Proj_Id=projectId;
        }
        public Project_Transaction(int type, float amount, int projectId, int transId)
        {
            this.Id = transId;//assign the value of count and then add one to it
            if (type < 0 || type > 1)
            {
                this.Type = 0;
            }
            else
            {
                this.Type = type;
            }
            this.Amount = amount;
            
            this.Proj_Id = projectId;
        }

        public override string ToString()
        {
            return $"Id:{this.Id} , Type:{this.Type} , Amount:{this.Amount}, projId:{this.Proj_Id}";//To be added
        }
    }
}



