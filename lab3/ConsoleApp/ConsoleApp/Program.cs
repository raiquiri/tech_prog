using System;

namespace ConsoleApp
{ 
    internal class Program
    {
        static int arrayActionCount = 0;
        static int linkedActionCount = 0;
        static int arrayIndexExceptionCount = 0;
        static int linkedIndexExceptionCount = 0;
        static int arrayFileExceptionCount = 0;
        static int linkedFileExceptionCount = 0;

        static string filePath = "test.txt";

        static void arrayCounter()
        {
            arrayActionCount++;
        }
        
        static void linkedCounter() 
        { 
            linkedActionCount++; 
        }

        
        public static void Main(string[] args) 
        {
            BaseList<int> arrayList = new ArrayList<int>();
            BaseList<int> linkedList = new ArrayList<int>();
            Random random = new Random();

            arrayList.active += arrayCounter;
            linkedList.active += linkedCounter;

            int end = 100;
            for (int i = 0; i <= end; i++)
            {
                int factor = random.Next(1, 5);
                int number = random.Next(0, 1000);
                int index = random.Next(0, end);

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
                        try
                        {
                            arrayList[end] = number;
                        } catch (Exceptions.BadIndexException)
                        {
                            arrayIndexExceptionCount++;
                        }
                        try
                        {
                            linkedList[end] = number;
                        } catch (Exceptions.BadIndexException)
                        {
                            linkedIndexExceptionCount++;
                        }
                        break;
                    /*case 4:
                        arrayList.clear();
                        linkedList.clear();
                        break;*/
                }
            }

            if (arrayList == linkedList)
            {
                Console.WriteLine("Accept #1");
            } else
            {
                Console.WriteLine("Error #1");
            }

            if (arrayActionCount == linkedActionCount)
            {
                Console.WriteLine("Accept #2");
            } else
            {
                Console.WriteLine("Error #2");
            }
            
            if (arrayIndexExceptionCount == linkedIndexExceptionCount)
            {
                Console.WriteLine("Accept #3");
            } else
            {
                Console.WriteLine("Error #3");
            }

            for (int i = 0; i < 10; i++)
            {
                int factor = random.Next(1, 3);

                switch (factor)
                {
                    case 1:
                        try
                        {
                            arrayList.loadToFile(filePath);
                        }
                        catch (Exceptions.BadFileException)
                        {
                            arrayFileExceptionCount++;
                        }
                        try
                        {
                            linkedList.loadToFile(filePath);
                        }
                        catch (Exceptions.BadFileException)
                        {
                            linkedIndexExceptionCount++;
                        }
                        break;
                    case 2:
                        arrayList.saveToFile(filePath);
                        linkedList.saveToFile(filePath);
                        break;
                }
            }

            if (arrayFileExceptionCount == linkedFileExceptionCount)
            {
                Console.WriteLine("Accept #4");
            } else
            {
                Console.WriteLine(arrayFileExceptionCount + " " +  linkedIndexExceptionCount);
                Console.WriteLine("Error #4");
            }

            BaseList<int> baseList = arrayList + linkedList;
            baseList.sort();
            foreach (int number in baseList)
            {
                Console.Write(number + " ");
            }
        }
    }
}
