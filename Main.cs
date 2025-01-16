using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace DopLaba1 
{ 
    public class Programm
    {
        public static void Main(string[] args) 
        {
            Console.WriteLine("Дополнительная лабораторная работа");
            Console.WriteLine("Выполнил Иванов Иван 6101-020302D");
            string TASK_TEXT = """
            В программе должны быть реализованы три вида сущностей:
            1) склад (есть ровно один в программе, его характеристики - кроме списка
            контейнеров - неизменны);
            2) контейнер с ящиками;
            3) ящик с овощами.
            Описание сущностей
            1) Склад:
             является хранилищем контейнеров;
             склад может содержать ограниченное число контейнеров (это
            число определяется пользователем);
             содержимое склада может меняться. На склад могут поступать
            новые контейнеры и удаляться старые. Если происходит добавление нового
            контейнера в заполненный склад, то он заменяет собой тот, что был
            добавлен не позднее всех остальных;
             склад взимает фиксированную плату за хранение контейнера
            одинаковую для каждого контейнера (определяется пользователем);
             контейнеры, хранение которых нерентабельно, не принимаются
            на хранение. При поступлении контейнера на склад рассчитывается степень
            его повреждения (случайная величина в диапазоне [0; 0.5)) - такую долю
            стоимости теряет каждый ящик внутри контейнера. Если суммарная
            стоимость содержимого контейнера после этого не превосходит стоимость
            хранения, то такой контейнер на склад не помещается.
            2) Контейнер:
             является хранилищем ящиков.
             максимальная суммарная масса хранимых ящиков ограничена
            (ограничение это случайное целое число в диапазоне [10, 100]);
            2
             при создании контейнера в него помещаются ящики с овощами.
            Количество и список помещаемых в контейнер ящиков задается
            пользователем;
             суммарная масса ящиков не может превосходить максимально
            допустимую массу контейнера, то есть если добавление ящика может
            привести к превышению максимальной допустимой массы, то такой ящик
            не добавляется в контейнер.
            3) Ящик овощей:
             описывается двумя параметрами - массой в килограммах и
            ценой за килограмм. Оба параметра указываются при создании, при этом
            масса не может быть изменена позднее.
            Ввод данных
            Действие 1: создаѐтся склад - он должен быть единственный.
            Пользователем указываются его характеристики - вместимость и цена хранения.
            Следующие N действий: Пользователь вводит одну из двух команд:
            1. Добавление контейнера на склад (после этого считываются данные о
            контейнере).
            2. Удаление контейнера со склада (указывается идентификатор удаляемого
            контейнера. Разработчик сам определяет что является идентификатором).
            """;

            Console.WriteLine(TASK_TEXT);

            GraphEngine graphEngine = new GraphEngine();
            Facade MAIN_FACADE = new Facade();
            ConsoleKey KEY_FROM_KEYBOARD;
            bool EXISTENCE_STORE = false;
            ContainerStorage LIST_GROUND_CONTAINERS = new ContainerStorage();
            BoxStorage LIST_GROUND_BOXES = new BoxStorage();
            //List<MyContainer> LIST_OF_CONTAINERS_ON_THE_GROUND = new List<MyContainer>();
            //List<BoxOfVegetables> LIST_OF_BOXS_ON_THE_GROUND = new List<BoxOfVegetables>();
            bool MAIN_MENU_FLAG = true;
            int INDEX_CURSOR = 1;
            List<string> LIST_HEADERS_MAIN_MENU = new List<string>(6);
            
            LIST_HEADERS_MAIN_MENU.Add("Главное меню");
            LIST_HEADERS_MAIN_MENU.Add("1 - Работа со складом");
            LIST_HEADERS_MAIN_MENU.Add("2 - Работа с контейнерами");
            LIST_HEADERS_MAIN_MENU.Add("3 - Работа с ящиками");
            LIST_HEADERS_MAIN_MENU.Add("4 - Показ задания");
            LIST_HEADERS_MAIN_MENU.Add("5 - Выход");
            while (MAIN_MENU_FLAG) 
            {
            INDEX_CURSOR = graphEngine.ShowMenuAndSelectItem(LIST_HEADERS_MAIN_MENU, INDEX_CURSOR);
            switch (INDEX_CURSOR)
            {
                case 1:
                INDEX_CURSOR = 1;
                List<string> LIST_HEADERS_CASE_1 = new List<string>(9);
                LIST_HEADERS_CASE_1.Add("Меню работы со складом");
                LIST_HEADERS_CASE_1.Add("1 - Создать склад");
                LIST_HEADERS_CASE_1.Add("2 - Добавить контейнер");
                LIST_HEADERS_CASE_1.Add("3 - Удалить контейнер");
                LIST_HEADERS_CASE_1.Add("4 - Просмотр склада");
                LIST_HEADERS_CASE_1.Add("5 - Сортировка склада");
                LIST_HEADERS_CASE_1.Add("6 - Генерация содержимого");
                LIST_HEADERS_CASE_1.Add("7 - Изменить содержимое");
                LIST_HEADERS_CASE_1.Add("8 - Выход в меню");
                bool dopFlag1 = true;
                while (dopFlag1)
                {
                INDEX_CURSOR = graphEngine.ShowMenuAndSelectItem(LIST_HEADERS_CASE_1, INDEX_CURSOR);
                switch (INDEX_CURSOR)
                {
                    case 1:
                        if (EXISTENCE_STORE)
                        {
                            Console.WriteLine("Отклонение запроса! Склад уже создан");
                            break;
                        }
                        Console.WriteLine("Создание склада!");
                        Store MAIN_STORE = new Store();
                        int capacityStore;
                        double maxStoreMass;
                        double rentalPriceStore;
                        do 
                        {

                            Console.WriteLine("Введите объем склада(кол-во ящиков)");
                            string userData0 = Console.ReadLine();
                            while (!Int32.TryParse(userData0, out capacityStore))
                            {
                                Console.WriteLine("Введите число!");
                                userData0 = Console.ReadLine();
                            }
                            if (capacityStore < 0) 
                            {
                                Console.WriteLine("Объем склада не может быть отрицательным");
                            }
                        }
                        while (capacityStore < 0);
                        string userData;
                        do 
                        {
                            Console.WriteLine("Введите максимальную массу, которую сможет выдержать склад(в кг)");
                            userData = Console.ReadLine();
                            while (!Double.TryParse(userData, out maxStoreMass))
                            {
                                Console.WriteLine("Введите число!");
                                userData = Console.ReadLine();
                            }
                            if (maxStoreMass < 0) 
                            {
                            Console.WriteLine("Объем склада не может быть отрицательным");
                            }
                        } 
                        while (maxStoreMass < 0);
                        do {
                            Console.WriteLine("Введите цену хранения(может быть с плавающей точкой)(в рублях)");
                            string userData1 = Console.ReadLine();
                            while (!Double.TryParse(userData1, out rentalPriceStore))
                            {
                                Console.WriteLine("Введите число!");
                                userData1 = Console.ReadLine();
                            }
                            if (maxStoreMass < 0) 
                            {
                                Console.WriteLine("Цена за аренду не может быть отрицательной!");
                            }

                        } while (rentalPriceStore < 0);
                        MAIN_STORE.SetMaxNumOfContainer(capacityStore);
                        MAIN_STORE.SetMaxStoreMass(maxStoreMass);
                        MAIN_STORE.SetRentalPrice(rentalPriceStore);
                        MAIN_FACADE.SetStore(MAIN_STORE);
                        Console.WriteLine("Склад успешно создан!\nОбъем склада: " + capacityStore + "(шт)\nМаксимальная масса: " + maxStoreMass + "(кг)\nЦена аренду: " + rentalPriceStore + "(руб)");
                        EXISTENCE_STORE = true;
                        break;
                    case 2:
                        if (!EXISTENCE_STORE)
                        {
                            Console.WriteLine("Отклонение запроса! Не был создан склад!");
                            break;
                        } else if (LIST_GROUND_CONTAINERS.GetList().Count < 1)
                        {
                            Console.WriteLine("Отклонение запроса! На земле не контейнеров!");
                            break;
                        }
                        Console.WriteLine("Выберите контейнер, который вы хотите добавить");
                        Console.WriteLine();
                        INDEX_CURSOR = graphEngine.SelectElementFromTheStore(LIST_GROUND_CONTAINERS);
                        try
                        {
                            MAIN_FACADE.TryAddContainer(LIST_GROUND_CONTAINERS.GetList()[INDEX_CURSOR]);
                            LIST_GROUND_CONTAINERS.GetList().Remove(LIST_GROUND_CONTAINERS.GetList()[INDEX_CURSOR]);
                            MAIN_FACADE.UpdateData();

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case 3:
                        if (!EXISTENCE_STORE)
                        {
                            Console.WriteLine("Отклонение запроса! Не был создан склад!");
                            break;
                        }
                        Console.WriteLine("Выберите контейнер, который вы хотите удалить");
                        Console.WriteLine();
                        INDEX_CURSOR = graphEngine.SelectElementFromTheStore(LIST_GROUND_CONTAINERS);
                        MAIN_FACADE.RemoveContainer(INDEX_CURSOR);
                        break;
                    case 4:
                        if (!EXISTENCE_STORE)
                        {
                            Console.WriteLine("Отклонение запроса! Не был создан склад!");
                            break;
                        }
                        if (MAIN_FACADE.GetList().Count == 0)
                        {
                            Console.WriteLine("Отклонение запроса! На складе ничего нету!");
                            break;
                        }
                        INDEX_CURSOR = 1;
                        int n4= 6;
                        ContainerStorage storeSelectedContainer = new ContainerStorage();
                        List<string> LIST_HEADERS_CASE_1_CASE_4 = new List<string>(n4);
                        LIST_HEADERS_CASE_1_CASE_4.Add("Как будем искать?");
                        LIST_HEADERS_CASE_1_CASE_4.Add("1 - Вручную");
                        LIST_HEADERS_CASE_1_CASE_4.Add("2 - По имени");
                        LIST_HEADERS_CASE_1_CASE_4.Add("3 - По максимальному кол-ву ящиков");
                        LIST_HEADERS_CASE_1_CASE_4.Add("4 - По приоритету");
                        LIST_HEADERS_CASE_1_CASE_4.Add("5 - По массе контейнера?");
                        INDEX_CURSOR = graphEngine.ShowMenuAndSelectItem(LIST_HEADERS_CASE_1_CASE_4, INDEX_CURSOR);
                        switch (INDEX_CURSOR)
                        {
                            case 1:
                            if (MAIN_FACADE.GetList().Count == 0)
                            {
                                Console.WriteLine("На складе ничего нет!");
                                break;
                            }
                            bool flag;
                            do
                            {
                                
                                flag = false;
                                int j = graphEngine.SelectElementFromTheStore(MAIN_FACADE.GetStore());
                                if (j >= 0)
                                {
                                    Console.WriteLine(j);
                                    int id = graphEngine.SelectElementFromTheStore(MAIN_FACADE.GetStore().GetContainer(j));
                                    if (id == -2)
                                    {
                                        flag = true;
                                    }
                                }
                            } while (flag);
                            break;
                            case 2:
                            Console.WriteLine("Введите имя контейнера");
                            string userData6 = Console.ReadLine();
                            List<MyContainer> sortList = new List<MyContainer>();
                            foreach (MyContainer myContainer in MAIN_FACADE.GetList())
                            {
                                if (myContainer.GetName() == userData6)
                                {
                                    sortList.Add(myContainer);
                                }
                            }
                            if (sortList.Count == 0)
                            {
                                Console.WriteLine("Контейнеров с таким именем нет");
                            }
                            else
                            {
                                storeSelectedContainer.SetList(sortList);
                                graphEngine.SelectElementFromTheStore(storeSelectedContainer);
                            }
                            break;
                            case 3:
                            string userData7;
                            int countFind;
                            do 
                            {
                                Console.WriteLine("Введите кол-во ящиков");
                                userData7 = Console.ReadLine();
                                while (!Int32.TryParse(userData7, out countFind))
                                {
                                    Console.WriteLine("Введите число!");
                                    userData7 = Console.ReadLine();
                                }
                                if (countFind < 0) 
                                {
                                    Console.WriteLine("Кол-во не может быть отрицательным!");
                                }
                            }
                            while (countFind < 0);
                            List<MyContainer> sortList1 = new List<MyContainer>();
                            foreach (MyContainer myContainer in MAIN_FACADE.GetList())
                            {
                                if (myContainer.GetCountBoxs() == countFind)
                                {
                                    sortList1.Add(myContainer);
                                }
                            }
                            if (sortList1.Count == 0)
                            {
                                Console.WriteLine("Контейнеров с таким максимальным числом нет");
                            }
                            else
                            {

                                storeSelectedContainer.SetList(sortList1);
                                graphEngine.SelectElementFromTheStore(storeSelectedContainer);
                            }
                            break;
                            case 4:
                            string userData8;
                            int priorityFind;
                            do 
                            {
                                Console.WriteLine("Введите номер приоритета");
                                userData8 = Console.ReadLine();
                                while (!Int32.TryParse(userData8, out priorityFind))
                                {
                                    Console.WriteLine("Введите число!");
                                    userData8 = Console.ReadLine();
                                }
                                if (priorityFind < 0) 
                                {
                                    Console.WriteLine("Приоритет не может быть отрицательным!");
                                }
                            }
                            while (priorityFind < 0);
                            List<MyContainer> sortList2 = new List<MyContainer>();
                            foreach (MyContainer myContainer in MAIN_FACADE.GetList())
                            {
                                if (myContainer.GetPriority() == priorityFind)
                                {
                                    sortList2.Add(myContainer);
                                }
                            }
                            if (sortList2.Count == 0)
                            {
                                Console.WriteLine("Контейнеров с таким приоритетом нет");
                            }
                            else
                            {
                                storeSelectedContainer.SetList(sortList2);
                                graphEngine.SelectElementFromTheStore(storeSelectedContainer);
                            }
                            break;
                            case 5:
                            string userData9;
                            double massFind;
                            do 
                            {
                                Console.WriteLine("Введите массу");
                                userData9 = Console.ReadLine();
                                while (!Double.TryParse(userData9, out massFind))
                                {
                                    Console.WriteLine("Введите число!");
                                    userData9 = Console.ReadLine();
                                }
                                if (massFind < 0) 
                                {
                                    Console.WriteLine("Масса не может быть отрицательным!");
                                }
                            }
                            while (massFind < 0);
                            List<MyContainer> sortList3 = new List<MyContainer>();
                            foreach (MyContainer myContainer in MAIN_FACADE.GetList())
                            {
                                if (myContainer.GetSumMassOfBox() == massFind)
                                {
                                    sortList3.Add(myContainer);
                                }
                            }
                            if (sortList3.Count == 0)
                            {
                                Console.WriteLine("Контейнеров с такой массой нет");
                            }
                            else
                            {
                                storeSelectedContainer.SetList(sortList3);
                                graphEngine.SelectElementFromTheStore(storeSelectedContainer);
                            }
                            break;
                        }
                        break;
                        
                    case 5:
                        if (!EXISTENCE_STORE)
                        {
                            Console.WriteLine("Отклонение запроса! Не был создан склад!");
                            break;
                        }
                        List<string> LIST_HEADERS_CASE_1_CASE_5 = new List<string>(6);
                        LIST_HEADERS_CASE_1_CASE_5.Add("Выберете столбец, по которому нужно отсоритровать таблицу");
                        LIST_HEADERS_CASE_1_CASE_5.Add("1 - Имя");
                        LIST_HEADERS_CASE_1_CASE_5.Add("2 - Максимальное кол-во ящиков");
                        LIST_HEADERS_CASE_1_CASE_5.Add("3 - Приоритет");
                        LIST_HEADERS_CASE_1_CASE_5.Add("4 - Масса контейнера");
                        INDEX_CURSOR = 1;
                        INDEX_CURSOR = graphEngine.ShowMenuAndSelectItem(LIST_HEADERS_CASE_1_CASE_5,INDEX_CURSOR);
                        List<string> LIST_WAYS_SORTING_CASE_1_CASE_5 = new List<string>(3);
                        LIST_WAYS_SORTING_CASE_1_CASE_5.Add("Как сортируем?");
                        LIST_WAYS_SORTING_CASE_1_CASE_5.Add("1 - По убыванию");
                        LIST_WAYS_SORTING_CASE_1_CASE_5.Add("2 - По возрастанию");
                        int LocalIndexCursor_CASE_1_CASE_5 = 1;
                        LocalIndexCursor_CASE_1_CASE_5 = graphEngine.ShowMenuAndSelectItem(LIST_WAYS_SORTING_CASE_1_CASE_5, LocalIndexCursor_CASE_1_CASE_5);
                        switch (LocalIndexCursor_CASE_1_CASE_5)
            {
                case 1:
                switch (INDEX_CURSOR)
                {
                    case 1:
                    MAIN_FACADE.GetList().Sort(new ContainerCompareAlphabetRevers());
                    graphEngine.SelectElementFromTheStore(MAIN_FACADE.GetStore());
                    break;
                    case 2:
                    MAIN_FACADE.GetList().Sort(new ContainerCompareCountBoxRevers());
                    graphEngine.SelectElementFromTheStore(MAIN_FACADE.GetStore());
                    break;
                    case 3:
                    MAIN_FACADE.GetList().Sort(new ContainerComparePriorityRevers());
                    graphEngine.SelectElementFromTheStore(MAIN_FACADE.GetStore());
                    break;
                    case 4:
                    MAIN_FACADE.GetList().Sort(new ContainerCompareDoubleRevers());
                    graphEngine.SelectElementFromTheStore(MAIN_FACADE.GetStore());
                    break;
                }
                break;
                case 2:
                switch (INDEX_CURSOR)
                {
                    case 1:
                    MAIN_FACADE.GetList().Sort(new ContainerCompareAlphabet());
                    graphEngine.SelectElementFromTheStore(MAIN_FACADE.GetStore());
                    break;
                    case 2:
                    MAIN_FACADE.GetList().Sort(new ContainerCompareCountBox());
                    graphEngine.SelectElementFromTheStore(MAIN_FACADE.GetStore());
                    break;
                    case 3:
                    MAIN_FACADE.GetList().Sort(new ContainerComparePriority());
                    graphEngine.SelectElementFromTheStore(MAIN_FACADE.GetStore());
                    break;
                    case 4:
                    MAIN_FACADE.GetList().Sort(new ContainerCompareDouble());
                    graphEngine.SelectElementFromTheStore(MAIN_FACADE.GetStore());
                    break;
                }
                break;
            }

                    break;
                    case 6:
                    if (!EXISTENCE_STORE)
                    {
                        Console.WriteLine("Склада нет. Генерация отклонена");
                        break;
                    }
                    int countGenerate;
                    do 
                        {
                            Console.WriteLine("Сколько контейнеров нужно сгенерировать?(в шт)");
                            string userData2 = Console.ReadLine();
                            while (!Int32.TryParse(userData2, out countGenerate))
                            {
                                Console.WriteLine("Введите число!");
                                userData2 = Console.ReadLine();
                            }
                            if (countGenerate < 0) 
                            {
                                Console.WriteLine("Кол-во не может быть отрицательным!");
                            }
                        }
                        while (countGenerate < 0);
                        string userData3;
                            Console.WriteLine("Введите диапозон значений для максимального кол-ва ящиков, которые могут быть в контейнере");
                            Console.WriteLine("Введите в такой формате a;b(например чтобы задать [10;50] нужно ввести в консоль 10;50)");
                            int lowerBorderMaxCount;
                            int upperBorderMaxCount;
                            userData3 = Console.ReadLine();
                            string[] userDates3 = new string[2]; 
                            userDates3 = userData3.Split(";");
                            while (userDates3.Length != 2)
                            {
                                Console.WriteLine("Некорретно задан диапазон!");
                                userData3 = Console.ReadLine();
                                userDates3 = userData3.Split(";");
                            }
                            while ((!Int32.TryParse(userDates3[0], out lowerBorderMaxCount)) & (!Int32.TryParse(userDates3[1], out upperBorderMaxCount)) & (lowerBorderMaxCount > upperBorderMaxCount) & (lowerBorderMaxCount < 0) & (upperBorderMaxCount < 0))
                            {
                                Console.WriteLine("Некорретные введеные данные!");
                                userData3 = Console.ReadLine();
                                userDates3 = userData3.Split(";");
                            }
                            Console.WriteLine("Введите диапозон значений для массы ящиков");
                            Console.WriteLine("Введите в такой формате a;b(например чтобы задать [10;50] нужно ввести в консоль 10;50)");
                            double lowerBorderMassBox;
                            double upperBorderMassBox;
                            string userData4 = Console.ReadLine();
                            string[] userDates4 = new string[2]; 
                            userDates4 = userData4.Split(";");
                            while (userDates4.Length != 2)
                            {
                                Console.WriteLine("Некорретно задан диапазон!");
                                userData4 = Console.ReadLine();
                                userDates4 = userData4.Split(";");
                            }
                            while (!Double.TryParse(userDates4[0], out lowerBorderMassBox) & !Double.TryParse(userDates4[1], out upperBorderMassBox) & (lowerBorderMassBox > upperBorderMassBox) & (lowerBorderMassBox < 0) & (upperBorderMassBox < 0))
                            {
                                Console.WriteLine("Некорретные введеные данные!");
                                userData4 = Console.ReadLine();
                                userDates4 = userData4.Split(";");
                            }
                            Console.WriteLine("Введите диапозон значений для цены за кг содержимого в ящиках");
                            Console.WriteLine("Введите в такой формате a;b(например чтобы задать [10;50] нужно ввести в консоль 10;50)");
                            double lowerBorderPrice;
                            double upperBorderPrice;
                            string userData5 = Console.ReadLine();
                            string[] userDates5 = new string[2]; 
                            userDates5 = userData5.Split(";");
                            while (userDates5.Length != 2)
                            {
                                Console.WriteLine("Некорретно задан диапазон!");
                                userData5 = Console.ReadLine();
                                userDates5 = userData5.Split(";");
                            }
                            while (!Double.TryParse(userDates5[0], out lowerBorderPrice) & !Double.TryParse(userDates5[1], out upperBorderPrice) & (lowerBorderPrice > upperBorderPrice) & (lowerBorderPrice < 0) & (upperBorderPrice < 0))
                            {
                                Console.WriteLine("Некорретные введеные данные!");
                                userData5 = Console.ReadLine();
                                userDates5 = userData5.Split(";");
                            }
                            try 
                            {
                                MAIN_FACADE.GenerateContainers(countGenerate, lowerBorderMaxCount, upperBorderMaxCount, lowerBorderMassBox, upperBorderMassBox, lowerBorderPrice, upperBorderPrice);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                    break;
                    case 7:
                        if (!EXISTENCE_STORE)
                        {
                            Console.WriteLine("Отклонение запроса! Не был создан склад!");
                            break;
                        }
                        bool flagCase7;
                        do
                        {
                            flagCase7 = false;
                            List<string> LIST_REPLACEMENT_CASE_1_CASE_7 = new List<string>(3);
                            LIST_REPLACEMENT_CASE_1_CASE_7.Add("Что меняем?");
                            LIST_REPLACEMENT_CASE_1_CASE_7.Add("1 - Контейнер");
                            LIST_REPLACEMENT_CASE_1_CASE_7.Add("2 - Ящик");
                            int LocalIndexCursor_CASE_1_CASE_7 = 1;
                            LocalIndexCursor_CASE_1_CASE_7 = graphEngine.ShowMenuAndSelectItem(LIST_REPLACEMENT_CASE_1_CASE_7, LocalIndexCursor_CASE_1_CASE_7);
                            switch (LocalIndexCursor_CASE_1_CASE_7)
                            {
                                case 1:
                                int j = graphEngine.SelectElementFromTheStore(MAIN_FACADE.GetStore());
                                if (j >= 0)
                                {

                                    MyContainer mycontainer = MAIN_FACADE.GetList()[j];
                                    MAIN_FACADE.GetList().Remove(mycontainer);
                                    List<string> LIST_REPLACEMENT_CONTAINER_CASE_1_CASE_7_CASE_1 = new List<string>(3);
                                    LIST_REPLACEMENT_CONTAINER_CASE_1_CASE_7_CASE_1.Add("Что меняем в контейнере?");
                                    LIST_REPLACEMENT_CONTAINER_CASE_1_CASE_7_CASE_1.Add("1 - Имя");
                                    LIST_REPLACEMENT_CONTAINER_CASE_1_CASE_7_CASE_1.Add("2 - Максимальное кол-во контов");
                                    int p = 1;
                                    p = graphEngine.ShowMenuAndSelectItem(LIST_REPLACEMENT_CONTAINER_CASE_1_CASE_7_CASE_1, p);
                                    switch (p)
                                    {
                                        case 1:
                                        Console.WriteLine("Введите имя!");
                                        bool flagName;
                                        string name;
                                        do
                                        {
                                            flagName = false;
                                            name = Console.ReadLine();
                                        while (name == "")
                                        {
                                            Console.WriteLine("Введите корректное имя");
                                            name = Console.ReadLine();
                                        }
                                        foreach (MyContainer myContainer1 in LIST_GROUND_CONTAINERS.GetList())
                                        {
                                            if (myContainer1.GetName() == name)
                                            {
                                                flagName = true;
                                            }
                                        }
                                        foreach (MyContainer myContainer1 in MAIN_FACADE.GetList())
                                        {
                                            if (myContainer1.GetName() == name)
                                            {
                                                flagName = true;
                                            }
                                        }
                                        if (flagName)
                                        {
                                            Console.WriteLine("Такое имя уже занято!");
                                        }
                                        } while (flagName);
                                        mycontainer.SetName(name);
                                        MAIN_FACADE.GetList().Add(mycontainer);
                                        break;
                                        case 2:
                                            Console.WriteLine("Введите максимальное кол-во ящиков");
                                            string userData6;
                                            int count;
                                        do 
                                        {
                                            Console.WriteLine("Введите максимальное кол-во ящиков(шт)");
                                            userData6 = Console.ReadLine();
                                            while (!Int32.TryParse(userData6, out count))
                                            {
                                                Console.WriteLine("Введите число!");
                                                userData6 = Console.ReadLine();
                                            }
                                            if (count < 0) 
                                            {
                                            Console.WriteLine("Максимальное кол-во ящиков не может быть отрицательным");
                                            }
                                            if (count < mycontainer.GetList().Count)
                                            {
                                                Console.WriteLine("Максимальное кол-во ящиков не может быть меньше, чем кол-во уже имеющихся ящиков");
                                            }
                                        } 
                                        while (count < 0 | (count < mycontainer.GetList().Count));
                                        mycontainer.SetCountBoxs(count);
                                        MAIN_FACADE.GetList().Add(mycontainer);
                                        break;
                                    }
                                }
                            break;
                            case 2:
                                if (!EXISTENCE_STORE)
                                {
                                    Console.WriteLine("Отклонение запроса! Не был создан склад!");
                                    break;
                                }
                                bool flagCase2;
                                int id = -1;
                                int b;
                                do
                                {
                                    flagCase2 = false;
                                    b = graphEngine.SelectElementFromTheStore(MAIN_FACADE.GetStore());
                                    if (b >= 0)
                                    {
                                        id = graphEngine.SelectElementFromTheStore(MAIN_FACADE.GetList()[b]);
                                    if (id == -2)
                                    {
                                        flagCase2 = true;
                                    }
                                    }
                                } while (flagCase2);
                                if (id >=0)
                                {
                                    List<string> LIST_REPLACEMENT_BOX_CASE_1_CASE_7_CASE_2 = new List<string>(3);
                                    LIST_REPLACEMENT_BOX_CASE_1_CASE_7_CASE_2.Add("Что меняем в ящике?");
                                    LIST_REPLACEMENT_BOX_CASE_1_CASE_7_CASE_2.Add("1 - Массу");
                                    LIST_REPLACEMENT_BOX_CASE_1_CASE_7_CASE_2.Add("2 - Цену за кг");
                                    int p = 1;
                                    p = graphEngine.ShowMenuAndSelectItem(LIST_REPLACEMENT_BOX_CASE_1_CASE_7_CASE_2, p);
                                    switch (p)
                                    {
                                        case 1:
                                        string userData7;
                                        double mass;
                                        BoxOfVegetables boxOfVegetables = MAIN_FACADE.GetList()[b].GetList()[id];
                                        do 
                                        {
                                            Console.WriteLine("Введите массу");
                                            userData7 = Console.ReadLine();
                                            while (!Double.TryParse(userData7, out mass))
                                            {
                                                Console.WriteLine("Введите число!");
                                                userData7 = Console.ReadLine();
                                            }
                                            if (mass < 0) 
                                            {
                                            Console.WriteLine("Масса не может быть отрицательным");
                                            }
                                        } 
                                        while (mass < 0);
                                        try
                                        {
                                            MAIN_FACADE.ChangeMassBox(mass,boxOfVegetables, MAIN_FACADE.GetList()[b]);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e);
                                        }
                                        break;
                                        case 2:
                                        
                                        string userData8;
                                        double price;
                                        do 
                                        {
                                            Console.WriteLine("Введите максимальное кол-во ящиков(шт)");
                                            userData8 = Console.ReadLine();
                                            while (!Double.TryParse(userData8, out price))
                                            {
                                                Console.WriteLine("Введите число!");
                                                userData8 = Console.ReadLine();
                                            }
                                            if (price < 0) 
                                            {
                                            Console.WriteLine("Цена не может быть отрицательной");
                                            }
                                        } 
                                        while (price < 0);
                                        BoxOfVegetables boxOfVegetables1 = MAIN_FACADE.GetList()[b].GetList()[id];
                                        try
                                        {
                                            MAIN_FACADE.ChangePriceBox(price,boxOfVegetables1, MAIN_FACADE.GetList()[b]);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e);
                                        }
                                        break;
                                    }
                                }
                            break;
                            }
                            
                        } while (flagCase7);
                    break;
                    case 8:
                        dopFlag1 = false;
                        break;
                    }
                }
                    

                break;
                case 2:
                    INDEX_CURSOR = 1;
                    List<string> LIST_HEADERS_CASE_2 = new List<string>(7);
                    LIST_HEADERS_CASE_2.Add("Меню работы с контейнерами");
                    LIST_HEADERS_CASE_2.Add("1 - Создать контейнер на земле");
                    LIST_HEADERS_CASE_2.Add("2 - Добавить ящик в контейнер на земле");
                    LIST_HEADERS_CASE_2.Add("3 - Удалить контейнер на земле");
                    LIST_HEADERS_CASE_2.Add("4 - Редактировать контейнер на земле");
                    LIST_HEADERS_CASE_2.Add("5 - Просмотр контов на земле");
                    LIST_HEADERS_CASE_2.Add("6 - Выход в меню");
                    bool dopFlag2 = true;
                    while (dopFlag2)
                    {
                    INDEX_CURSOR = graphEngine.ShowMenuAndSelectItem(LIST_HEADERS_CASE_2, INDEX_CURSOR);
                    switch (INDEX_CURSOR)
                    {
                        case 1:
                            Console.WriteLine("Введите имя!");
                            bool flagName;
                            string name;
                            do
                            {
                                flagName = false;
                                name = Console.ReadLine();
                            while (name == "")
                            {
                                Console.WriteLine("Введите корректное имя");
                                name = Console.ReadLine();
                            }
                            foreach (MyContainer myContainer1 in LIST_GROUND_CONTAINERS.GetList())
                            {
                                if (myContainer1.GetName() == name)
                                {
                                    flagName = true;
                                }
                            }
                            if (EXISTENCE_STORE)
                            {
                                foreach (MyContainer myContainer1 in MAIN_FACADE.GetList())
                                {
                                    if (myContainer1.GetName() == name)
                                    {
                                        flagName = true;
                                    }
                                }
                            }
                            if (flagName)
                            {
                                Console.WriteLine("Такое имя уже занято!");
                            }
                            } while (flagName);
                            Console.WriteLine("Введите максимальное кол-во ящиков, которые могут в вашем контейнере одновременно!");
                            string userData1 = Console.ReadLine();
                            int countBox;
                            while (!Int32.TryParse(userData1, out countBox))
                            {
                                Console.WriteLine("Введите число!");
                                userData1 = Console.ReadLine();
                            }
                            MyContainer myContainer = new MyContainer();
                            myContainer.SetName(name);
                            myContainer.SetCountBoxs(countBox);
                            LIST_GROUND_CONTAINERS.AddMyContainer(myContainer);
                            LIST_GROUND_CONTAINERS.UpdateDataWitdth();
                        break;
                        case 2:
                            if (LIST_GROUND_BOXES.GetList().Count == 0)
                            {
                                Console.WriteLine("Свободных ящиков нет");
                                break;
                            }
                            
                            Console.WriteLine("Выберете контейнер, в который Вы хотите добавить ящик");
                            int j = graphEngine.SelectElementFromTheStore(LIST_GROUND_CONTAINERS);
                            Console.WriteLine("Выберете желаемый ящик");
                            INDEX_CURSOR = graphEngine.SelectElementFromTheStore(LIST_GROUND_BOXES);
                            try
                            {
                            LIST_GROUND_CONTAINERS.GetList()[j].AddBox(LIST_GROUND_BOXES.GetList()[INDEX_CURSOR]);
                            LIST_GROUND_CONTAINERS.UpdateDataWitdth();
                            LIST_GROUND_CONTAINERS.UpdateData();
                            LIST_GROUND_BOXES.GetList().Remove(LIST_GROUND_BOXES.GetList()[INDEX_CURSOR]);

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                        break;
                        case 3:
                        if (LIST_GROUND_CONTAINERS.GetList().Count == 0)
                        {
                            Console.WriteLine("На земле ничего нету");
                            break;
                        }
                            Console.WriteLine("Выберете контейнер, который Вы хотите удалить");
                            INDEX_CURSOR = graphEngine.SelectElementFromTheStore(LIST_GROUND_CONTAINERS);
                            LIST_GROUND_CONTAINERS.GetList().Remove(LIST_GROUND_CONTAINERS.GetList()[INDEX_CURSOR]);
                            LIST_GROUND_CONTAINERS.UpdateDataWitdth();
                        break;
                        case 4:
                            if (LIST_GROUND_CONTAINERS.GetList().Count == 0)
                            {
                                Console.WriteLine("На земле ничего нету");
                                break;
                            }
                            Console.WriteLine("Выберете контейнер, который вы хотите поменять");
                            j = graphEngine.SelectElementFromTheStore(LIST_GROUND_CONTAINERS);
                            if (j >= 0)
                            {
                                MyContainer mycontainer = LIST_GROUND_CONTAINERS.GetContainer(j);
                                LIST_GROUND_CONTAINERS.GetList().Remove(mycontainer);
                                List<string> LIST_REPLACEMENT_CASE_2_CASE_4 = new List<string>(3);
                                LIST_REPLACEMENT_CASE_2_CASE_4.Add("Что меняем в контейнере?");
                                LIST_REPLACEMENT_CASE_2_CASE_4.Add("1 - Имя");
                                LIST_REPLACEMENT_CASE_2_CASE_4.Add("2 - Максимальное кол-во контов");
                                int p = 1;
                                p = graphEngine.ShowMenuAndSelectItem(LIST_REPLACEMENT_CASE_2_CASE_4, p);
                                switch (p)
                                {
                                    case 1:
                                    Console.WriteLine("Введите имя!");
                                    bool flagName1;
                                    string name1;
                                    do
                                    {
                                        flagName1 = false;
                                        name1 = Console.ReadLine();
                                    while (name1 == "")
                                    {
                                        Console.WriteLine("Введите корректное имя");
                                        name1 = Console.ReadLine();
                                    }
                                    foreach (MyContainer myContainer1 in LIST_GROUND_CONTAINERS.GetList())
                                    {
                                        if (myContainer1.GetName() == name1)
                                        {
                                            flagName1 = true;
                                        }
                                    }
                                    if (EXISTENCE_STORE)
                                    {
                                        foreach (MyContainer myContainer1 in MAIN_FACADE.GetList() )
                                        {
                                            if (myContainer1.GetName() == name1)
                                            {
                                                flagName1 = true;
                                            }
                                        }
                                    }
                                    if (flagName1)
                                    {
                                        Console.WriteLine("Такое имя уже занято!");
                                    }
                                    } while (flagName1);
                                    mycontainer.SetName(name1);
                                    LIST_GROUND_CONTAINERS.GetList().Add(mycontainer);
                                    LIST_GROUND_CONTAINERS.UpdateDataWitdth();
                                    break;
                                    case 2:
                                        string userData6;
                                        int count;
                                    do 
                                    {
                                        Console.WriteLine("Введите максимальное кол-во ящиков(шт)");
                                        userData6 = Console.ReadLine();
                                        while (!Int32.TryParse(userData6, out count))
                                        {
                                            Console.WriteLine("Введите число!");
                                            userData6 = Console.ReadLine();
                                        }
                                        if (count < 0) 
                                        {
                                        Console.WriteLine("Максимальное кол-во ящиков не может быть отрицательным");
                                        }
                                        if (count < mycontainer.GetList().Count)
                                        {
                                            Console.WriteLine("Максимальное кол-во ящиков не может быть меньше, чем кол-во уже имеющихся ящиков");
                                        }
                                    } 
                                    while (count < 0 | (count < mycontainer.GetList().Count));
                                    mycontainer.SetCountBoxs(count);
                                    LIST_GROUND_CONTAINERS.GetList().Add(mycontainer);
                                    LIST_GROUND_CONTAINERS.UpdateDataWitdth();
                                    break;
                                }
                            }
                        break;
                        case 5:
                        if (LIST_GROUND_CONTAINERS.GetList().Count == 0)
                        {
                            Console.WriteLine("На земле нет контейнеров!");
                            break;
                        }
                        graphEngine.SelectElementFromTheStore(LIST_GROUND_CONTAINERS);
                        break;
                        case 6:
                        dopFlag2 = false;
                        break;
                    }
                    }
                break;
                case 3:
                    MyContainer myHelpContainer = new MyContainer();
                    INDEX_CURSOR = 1;
                    List<string> LIST_HEADERS_CASE_3 = new List<string>(6);
                    LIST_HEADERS_CASE_3.Add("Меню работы с ящиками");
                    LIST_HEADERS_CASE_3.Add("1 - Создать ящик на земле");
                    LIST_HEADERS_CASE_3.Add("2 - Удалить ящик на земле");
                    LIST_HEADERS_CASE_3.Add("3 - Редактировать ящики на земле");
                    LIST_HEADERS_CASE_3.Add("4 - Просмотр ящиков");
                    LIST_HEADERS_CASE_3.Add("5 - В меню");
                    bool dopFlag3 = true;
                    while (dopFlag3)
                    {
                    INDEX_CURSOR = graphEngine.ShowMenuAndSelectItem(LIST_HEADERS_CASE_3, INDEX_CURSOR);
                        switch (INDEX_CURSOR)
                        {
                            case 1:
                                Console.WriteLine("Введите массу!");
                                string userData1 = Console.ReadLine();
                                double mass;
                                while (!Double.TryParse(userData1, out mass))
                                {
                                    Console.WriteLine("Введите число!");
                                    userData1 = Console.ReadLine();
                                }
                                Console.WriteLine("Введите цену за кг!");
                                string userData2 = Console.ReadLine();
                                double price;
                                while (!Double.TryParse(userData2, out price))
                                {
                                    Console.WriteLine("Введите число!");
                                    userData2 = Console.ReadLine();
                                }
                                BoxOfVegetables boxOfVegetables = new BoxOfVegetables();
                                boxOfVegetables.SetMass(mass);
                                boxOfVegetables.SetPrice(price);
                                LIST_GROUND_BOXES.GetList().Add(boxOfVegetables);
                                LIST_GROUND_BOXES.UpdateDataWitdth();
                            break;
                            case 2:
                            if (LIST_GROUND_BOXES.GetList().Count == 0)
                                {
                                    Console.WriteLine("Ящиков на земле нет");
                                    break;
                                }
                                Console.WriteLine("Выберете ящик, который Вы хотите удалить");
                                INDEX_CURSOR = graphEngine.SelectElementFromTheStore(LIST_GROUND_BOXES);
                                LIST_GROUND_BOXES.GetList().Remove(LIST_GROUND_BOXES.GetList()[INDEX_CURSOR]);
                                LIST_GROUND_BOXES.UpdateDataWitdth();
                            break;
                            case 3:
                            if (LIST_GROUND_BOXES.GetList().Count == 0)
                                {
                                    Console.WriteLine("Ящиков на земле нет");
                                    break;
                                }
                                Console.WriteLine("Выберете ящик, который Вы хотите поменять");
                                Console.WriteLine();
                                myHelpContainer.SetList(LIST_GROUND_BOXES.GetList());
                                INDEX_CURSOR = graphEngine.SelectElementFromTheStore(myHelpContainer);
                                List<string> LIST_REPLACEMENT_BOX_CASE_3_CASE_3 = new List<string>(3);
                                LIST_REPLACEMENT_BOX_CASE_3_CASE_3.Add("Что меняем в ящике?");
                                LIST_REPLACEMENT_BOX_CASE_3_CASE_3.Add("1 - Массу");
                                LIST_REPLACEMENT_BOX_CASE_3_CASE_3.Add("2 - Цену за кг");
                                int p = 1;
                                p = graphEngine.ShowMenuAndSelectItem(LIST_REPLACEMENT_BOX_CASE_3_CASE_3, p);
                                switch (p)
                                {
                                    case 1:
                                    string userData7;
                                    double mass1;
                                    BoxOfVegetables boxOfVegetables1 = LIST_GROUND_BOXES.GetList()[INDEX_CURSOR];
                                    LIST_GROUND_BOXES.GetList().Remove(boxOfVegetables1);
                                    do 
                                    {
                                        Console.WriteLine("Введите массу");
                                        userData7 = Console.ReadLine();
                                        while (!Double.TryParse(userData7, out mass1))
                                        {
                                            Console.WriteLine("Введите число!");
                                            userData7 = Console.ReadLine();
                                        }
                                        if (mass1 < 0) 
                                        {
                                        Console.WriteLine("Масса не может быть отрицательным");
                                        }
                                    } 
                                    while (mass1 < 0);
                                    boxOfVegetables1.SetMass(mass1);
                                    LIST_GROUND_BOXES.GetList().Add(boxOfVegetables1);
                                    break;
                                    case 2:
                                    string userData8;
                                    double price1;
                                    do 
                                    {
                                        Console.WriteLine("Введите максимальное кол-во ящиков(шт)");
                                        userData8 = Console.ReadLine();
                                        while (!Double.TryParse(userData8, out price1))
                                        {
                                            Console.WriteLine("Введите число!");
                                            userData8 = Console.ReadLine();
                                        }
                                        if (price1 < 0) 
                                        {
                                        Console.WriteLine("Цена не может быть отрицательной");
                                        }
                                    } 
                                    while (price1 < 0);
                                    BoxOfVegetables boxOfVegetables2 = LIST_GROUND_BOXES.GetList()[INDEX_CURSOR];
                                    LIST_GROUND_BOXES.GetList().Remove(boxOfVegetables2);
                                    boxOfVegetables2.SetPrice(price1);
                                    LIST_GROUND_BOXES.GetList().Add(boxOfVegetables2);
                                    LIST_GROUND_BOXES.UpdateDataWitdth();
                                    break;
                                    }
                            break;
                            case 4:
                            if (LIST_GROUND_BOXES.GetList().Count == 0)
                            {
                                Console.WriteLine("На земле нет контейнеров!");
                                break;
                            }
                            graphEngine.SelectElementFromTheStore(LIST_GROUND_BOXES);
                            break;
                            case 5:
                            dopFlag3 = false;
                            break;
                        }
                    }
                break;
                case 4:
                Console.WriteLine("Дополнительная лабораторная работа");
                Console.WriteLine("Выполнил Иванов Иван 6101-020302D");
                Console.WriteLine(TASK_TEXT);
                break;
                case 5:
                MAIN_MENU_FLAG = false;
                break;
            }
            }
                
        }
    }
}

                
            
            
        


