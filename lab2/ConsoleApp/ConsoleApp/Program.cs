using System;

namespace ConsoleApp
{ 
    class Program
    {
        public static void Main(string[] args)
        {
            BaseList arrayList = new ArrayList();
            BaseList linkedList = new LinkedList();
            Random random = new Random();

            linkedList.add(1);
            linkedList.add(2);
            linkedList.add(3);
            linkedList.add(2);
            linkedList.add(3);
            linkedList.add(4);
            linkedList.add(2);
            linkedList.add(2);
            linkedList.add(3);
            linkedList.add(2);
            linkedList.add(5);
            linkedList.print();
            Console.WriteLine();
            linkedList.deleteRepeat();
            linkedList.print();



            /*for (int i = 0; i <= 100; i++)
            {
                int factor = random.Next(1, 5);
                int number = random.Next(0, 1000);
                int index = random.Next(0, 100);

                switch (factor)
                {
                    case 1:
                        arrayList.add(number);
                        linkedList.add(number);
                        break;
                    case 2:
                        arrayList.delete(number);
                        linkedList.delete(number);
                        break;
                    case 3:
                        arrayList.insert(number, index);
                        linkedList.insert(number, index);
                        break;
                    case 4:
                        arrayList.clear();
                        linkedList.clear();
                        break;
                }   
            }
            
            arrayList.sort();
            BaseList cloneList_1 = arrayList.clone();
            

            BaseList cloneList_2 = new LinkedList();
            cloneList_2.assign(linkedList);
            cloneList_2.sort();

            cloneList_1.print();
            cloneList_2.print();

            if (cloneList_1.equals(cloneList_2))
            {
                Console.WriteLine("Accept");
            }
            Console.WriteLine("Jopa");*/
        }
    }
}
