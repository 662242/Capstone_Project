0,1			=> Project Id = 0 , Project Type = 1(Build Project)  
0,100,0,0   =>Transaction_Type=0(Purchase),Transaction_Amount=100,ParentProject_Id=0,Transaction_Id=0
0,100,0,1	=>Transaction_Type=0(Purchase),Transaction_Amount=100,ParentProject_Id=0,Transaction_Id=1
1,1			=> Project Id = 1 , Project Type = 1(Build Project)
0,100,1,2	=>Transaction_Type=0(Purchase),Transaction_Amount=100,ParentProject_Id=1,Transaction_Id=2
0,1000,1,3	=>Transaction_Type=1(Sales),Transaction_Amount=1000,ParentProject_Id=1,Transaction_Id=3
0,1000,1,4	=>Transaction_Type=0(Sales),Transaction_Amount=1000,ParentProject_Id=1,Transaction_Id=4
2,0			=> Project Id = 2 , Project Type = 0(Renovation Project)


EXPLANATION HOW DATA IS SAVED IN FILE

