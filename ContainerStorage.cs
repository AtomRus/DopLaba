namespace DopLaba1
{
    public class ContainerStorage : AbstractStore
    {
        /*Task 06.01.2025
        Внедрить зависимости хранилищ в адаптеры, в художнике должен быть только адаптер
        */
        public static List<MyContainer> LIST_OF_CONTAINERS = new List<MyContainer>();
        private int maxNamewitdth = 0;
        private int maxCountBoxwitdth = 0;
        private int maxPrioritywitdth = 0;
        private int maxMasswitdth = 0;
        public MyContainer GetContainer(int idCont) 
        {
            return LIST_OF_CONTAINERS[idCont];
        }
        public void SetList(List<MyContainer> list)
        {
            LIST_OF_CONTAINERS = list; 
        }
        public List<MyContainer> GetList()
        {
            return LIST_OF_CONTAINERS;
        }
        public int[] GetDataWidth() 
        {
            return new int[]{maxNamewitdth, maxCountBoxwitdth, maxPrioritywitdth, maxMasswitdth};
        }
        public void AddMyContainer(MyContainer myContainer)
        {
            LIST_OF_CONTAINERS.Add(myContainer);
        }
        public void UpdateDataWitdth()
        {
        maxNamewitdth = LIST_OF_CONTAINERS.Max(s => s.GetName().Length);
        if (maxNamewitdth < 3)
        {
            maxNamewitdth = 3;
        }

        maxCountBoxwitdth = LIST_OF_CONTAINERS.Max(s => s.GetCountBoxs().ToString().Length);
        if (maxCountBoxwitdth < 26)
        {
            maxCountBoxwitdth = 26;
        }

        maxPrioritywitdth = LIST_OF_CONTAINERS.Max(s => s.GetPriority().ToString().Length);
        if (maxPrioritywitdth < 9)
        {
            maxPrioritywitdth = 9;
        }

        maxMasswitdth = LIST_OF_CONTAINERS.Max(s => MyContainer.CountSumMass(s.GetList()).ToString().Length);
        if (maxMasswitdth < 16)
        {
            maxMasswitdth = 16;
        }

    }

    /*private void ShowPage(int idPage, int k)
    {

        int stop = idPage * 10 + 10;
        if (stop > LIST_OF_CONTAINERS.Count)
        {
            stop = LIST_OF_CONTAINERS.Count;
        }

        UpdateDataWitdth();
        string formatString1 = string.Format("{{0, -{0}}}|", maxNamewitdth);
        string formatString2 = string.Format("{{0, -{0}}}|", maxCountBoxwitdth);
        string formatString3 = string.Format("{{0, -{0}}}|", maxPrioritywitdth);
        string formatString4 = string.Format("{{0, -{0}}}|", maxMasswitdth);
        string helpStr1 = string.Join("",Enumerable.Repeat("-" , maxNamewitdth));
        string helpStr2 = string.Join("",Enumerable.Repeat("-" , maxCountBoxwitdth));
        string helpStr3 = string.Join("",Enumerable.Repeat("-" , maxPrioritywitdth));
        string helpStr4 = string.Join("",Enumerable.Repeat("-" ,maxMasswitdth));
        Console.WriteLine("  -" + helpStr1 + "-" + helpStr2 + "-" + helpStr3 + "-" + helpStr4 + "-");
        Console.Write(formatString1,"  |Имя");
        Console.Write(formatString2,"Максимальное кол-во ящиков");
        Console.Write(formatString3,"Приоритет");
        Console.Write(formatString4,"Масса контейнера");
        Console.WriteLine();
        for (int i = idPage * 10; i < stop; i++) 
        {
            if (i == k)
            {
                Console.Write("->|");
                Console.Write(formatString1,LIST_OF_CONTAINERS[i].GetName());
                Console.Write(formatString2,LIST_OF_CONTAINERS[i].GetCountBoxs().ToString());
                Console.Write(formatString3,LIST_OF_CONTAINERS[i].GetPriority().ToString());
                Console.Write(formatString4,MyContainer.CountSumMass(LIST_OF_CONTAINERS[i].GetList()).ToString());
                Console.Write("|");
                Console.WriteLine();
            }
            else
            {
                Console.Write("  |");
                Console.Write(formatString1,LIST_OF_CONTAINERS[i].GetName());
                Console.Write(formatString2,LIST_OF_CONTAINERS[i].GetCountBoxs().ToString());
                Console.Write(formatString3,LIST_OF_CONTAINERS[i].GetPriority().ToString());
                Console.Write(formatString4,MyContainer.CountSumMass(LIST_OF_CONTAINERS[i].GetList()).ToString());
                Console.WriteLine();
            }
        }
        Console.WriteLine("  -" + helpStr1 + "-" + helpStr2 + "-" + helpStr3 + "-" + helpStr4 + "-");
        Console.WriteLine();
        Console.WriteLine("Страница " + (idPage + 1) + " Всего элементов " + LIST_OF_CONTAINERS.Count);
    }
        private bool ReadinessList()
        {
            if (LIST_OF_CONTAINERS?.Any() != true) 
            {
                Console.WriteLine("Ничего нету :(");
                return false;
            }
            //Проверка есть ли в коллекции конты
            else if (LIST_OF_CONTAINERS.Count == 0) 
            {
                Console.WriteLine("Ничего нету :(");
                return false;
            }
            else {
                return true;
            }
        }
        public int ShowContent() 
        {
            int k = 0;
            //Проверка инициализирована ли коллекция или нет
            if (!ReadinessList()) 
            {
                return -1;
            }
            
            else 
            {
                UpdateDataWitdth();
                Console.WriteLine();
                Console.WriteLine("Содержимое хранилища");
                Console.WriteLine();

                bool FLAG_KEY_IS_ESCAPE = false;
                int COUNT_PAGE = LIST_OF_CONTAINERS.Count / 10;
                int currectPage = 0;
                ConsoleKey key;
                ShowPage(currectPage, k);
                
                while (!FLAG_KEY_IS_ESCAPE && (key = Console.ReadKey(true).Key) != ConsoleKey.Enter)
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
                        if ((k == currectPage * 10 + 10) || (k == LIST_OF_CONTAINERS.Count)) {
                            if (currectPage != COUNT_PAGE)
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
                        if (currectPage != COUNT_PAGE)
                        {
                            currectPage ++;
                            k += 10;
                        }
                        if(j + 10 > LIST_OF_CONTAINERS.Count)
                        {
                            k = LIST_OF_CONTAINERS.Count - 1;
                        }
                        Console.Clear();
                        ShowPage(currectPage, k);
                        break;
                    case ConsoleKey.Escape:
                        FLAG_KEY_IS_ESCAPE = true;
                    break;
                }
            }
            if (FLAG_KEY_IS_ESCAPE)
            {
                return -1;
            }
            else
            {
                return k;
            } 
            
        }
    }*/
}
}