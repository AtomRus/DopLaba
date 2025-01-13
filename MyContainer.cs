
using System.Collections;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace DopLaba1 
{
    public class MyContainer : BoxStorage
    {
        private static Random random = new Random();
        private int maxMass = random.Next(10,100);
        private int countBoxs;
        private string name;
        //Приоритет исключения, чем выше число, тем быстрее этот контейнер заменит новый контейнер
        private int PriorityKick = 1;
        private double sumMassOfBox = 0;
        //private List<BoxOfVegetables> listOfBox;
        public int GetMaxMass() 
        {
            return maxMass;
        }
        public void SetSummMassOfBox(double sumMassOfBox)
        {
            this.sumMassOfBox = sumMassOfBox;
        }
        public double GetSumMassOfBox()
        {
            return sumMassOfBox;
        }
        public void SetName(string name ) 
        {
            this.name = name;
        }
        public string GetName() 
        {
            return name;
        }
        public int GetCountBoxs() 
        {
            return countBoxs;
        }
        public void SetPriority(int i) 
        {
            PriorityKick = i;
        }
        public int GetPriority() 
        {
            return PriorityKick;
        }
        public void SetCountBoxs(int countBoxs) 
        {

            this.countBoxs = countBoxs;

        }
        
        public MyContainer(int countBoxs, List<BoxOfVegetables> listOfBox, string name) 
        {
            this.countBoxs = countBoxs;
            this.name = name;
        }
        public MyContainer() {
            this.countBoxs = 0;
        }
        //Вспомогательный метод для подсчета массы контейнера
        public static double CountSumMass(List<BoxOfVegetables> listOfBox)
        {
            double sum = 0;
            foreach (BoxOfVegetables box in listOfBox) 
            {
                sum = sum + box.GetMass();
            }
            return sum;
        }
        public void AddBox(BoxOfVegetables box)
        {
            listOfBox.Add(box);
        }

        /*private void ShowPage(int idPage, int k)
        {

            int stop = idPage * 10 + 10;
            if (stop > listOfBox.Count)
            {
                stop = listOfBox.Count;
            }

            UpdateDataWitdth();
            string formatString1 = string.Format("{{0, -{0}}}|", maxMasswitdth);
            string formatString2 = string.Format("{{0, -{0}}}|", maxPricewitdth);
            string helpStr1 = string.Join("",Enumerable.Repeat("-" , maxMasswitdth));
            string helpStr2 = string.Join("",Enumerable.Repeat("-" , maxPricewitdth));
            Console.WriteLine("  -" + helpStr1 + "-" + helpStr2 + "-");
            Console.Write("  |");
            Console.Write(formatString1,"Масса");
            Console.Write(formatString2,"Цена за кг");
            Console.WriteLine();
            for (int i = idPage * 10; i < stop; i++) 
            {
                if (i == k)
                {
                    Console.Write("->|");
                    Console.Write(formatString1,listOfBox[i].GetMass().ToString());
                    Console.Write(formatString2,listOfBox[i].GetPrice().ToString());
                    Console.Write("|");
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("  |");
                    Console.Write(formatString1,listOfBox[i].GetMass().ToString());
                    Console.Write(formatString2,listOfBox[i].GetPrice().ToString());
                    Console.Write("|");
                    Console.WriteLine();
                }
            }
            Console.WriteLine("  -" + helpStr1 + "-" + helpStr2 + "-");
            Console.WriteLine();
            Console.WriteLine("Страница " + (idPage + 1) + " Всего элементов " + listOfBox.Count);
        } */
        /*public int ShowContainer() 
        {
            int k;
            //Проверка инициализирована ли коллекция или нет
            if (listOfBox?.Any() != true) 
            {
                Console.WriteLine("На складе ничего нету :(");
                return -1;

            }
            //Проверка есть ли в коллекции конты
            else if (listOfBox.Count == 0) 
            {
                Console.WriteLine("На складе ничего нету :(");
                return -1;
            }
            
            else 
            {
                UpdateDataWitdth();
                Console.WriteLine();
                Console.WriteLine("Содержимое хранилища");
                Console.WriteLine();

                k = 0;
                int countPage = listOfBox.Count / 10;
                int currectPage = 0;
                ConsoleKey key;
                ShowPage(currectPage, k);
                while ((key = Console.ReadKey(true).Key) != ConsoleKey.Enter)
                {
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        k--;
                        if (k == currectPage * 10 - 1)
                        {
                            if (currectPage != 0)
                            {
                                currectPage--;
                            }
                            else {
                                k++;
                            }

                        }
                        Console.Clear();
                        ShowPage(currectPage, k);
                        break;
                    case ConsoleKey.DownArrow:
                        k++;
                        if ((k == currectPage * 10 + 10) || (k == listOfBox.Count)) {
                            if (currectPage != countPage)
                            {
                                currectPage++;

                            }
                            else
                            {
                                k--;
                            }
                        }
                        Console.Clear();
                        ShowPage(currectPage, k);
                        break;
                    case ConsoleKey.LeftArrow:
                        if (currectPage != 0)
                        {
                            currectPage--;
                            k -= 10;
                        }
                        Console.Clear();
                        ShowPage(currectPage, k);
                        break;
                    case ConsoleKey.RightArrow:
                        int j = k;
                        if (currectPage != countPage)
                        {
                            currectPage ++;
                            k += 10;
                        }
                        if(j + 10 > listOfBox.Count)
                        {
                            k = listOfBox.Count - 1;
                        }
                        Console.Clear();
                        ShowPage(currectPage, k);
                        break;
                    case ConsoleKey.Escape:
                        return -2;
                }
            }
        }
        return k;
        }   
    } */
    
    }
    }