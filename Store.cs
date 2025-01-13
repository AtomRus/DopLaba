

using System.Data;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Security.Principal;

namespace DopLaba1
{
    public class Store : ContainerStorage
    {
        /*Логика хранения состоит в том, что у класска Store есть коллекция List<Container>,
        а уже внутри класса Container есть своя коллекция List<BoxOfVegetables>
        */
        private int MAX_NUMBER_OF_CONTAINERS;
        public static double RENTAL_PRICE;
        public static double STORE_MAXIMUM_WEIGHT;
        public static double TOTAL_MASS_CONTAINERS = 0;
    
        //Сетеры, гетеры
        
        public void SetMaxStoreMass(double maxStoreMass) 
        {
            Store.STORE_MAXIMUM_WEIGHT = maxStoreMass;

        }
        public double GetMaxStoreMass() 
        {
            return STORE_MAXIMUM_WEIGHT;
        }
        public void SetMaxNumOfContainer(int maxNumOfContainer) 
        {
            this.MAX_NUMBER_OF_CONTAINERS = maxNumOfContainer;
            LIST_OF_CONTAINERS = new List<MyContainer>(MAX_NUMBER_OF_CONTAINERS);
        }
        public void SetRentalPrice(double rentalPrice) 
        {
            Store.RENTAL_PRICE = rentalPrice;
        }
        //Расчет повреждения(вспомогательный метод при добавлении конта на склад)
        public static MyContainer CalcDamage(MyContainer list) {
            Random random = new Random();
            double shareOfLoss = random.NextDouble() / 2;
            foreach (BoxOfVegetables box in list.GetList()) { 
                box.SetMass(box.GetMass() * shareOfLoss);
            }
            return list;
        }
        //Расчет стоимости конта(вспомогательный метод при добавлении конта на склад)
        public static double CalcMoney(MyContainer list) 
        {
            double sum = 0;
            foreach (BoxOfVegetables box in list.GetList()) 
            {
                sum = sum + box.GetPriceForKg() * box.GetMass();
            }
            return sum;
        }
        /*Добавление контейнера. Проверяем сможет ли выдержать склад при его добавлении,
        потом проверяем не совпадает ли кол-во контейнеров на складе и максимальное кол-во контейнов в складе,
        если же на складе есть место, то пробуем добавлять контейнер, рассчитывая его рентабельность,
        а затем обновляем список приоритета замены.
        Механика списка проиоритета. При добавлении контейнера на склад все контейнеры до его добавления увеличивают его приоритет,
        это нужно, чтобы если место для контейнера в хранилище закончилось, то один из "старых" контейнеров заменился бы на новый.
        Также проверяем массу
        */
        public void CheckContainerBeforeAddition(MyContainer container)
        {
            if (Store.CountSumMass(LIST_OF_CONTAINERS) + MyContainer.CountSumMass(container.GetList()) > Store.STORE_MAXIMUM_WEIGHT)
                {
                    throw new Exception("Невозможно добавить новый контейнер! Склад не сможет его выдержать");
                }
            else if (Store.CalcMoney(container) < RENTAL_PRICE) 
            {
                throw new Exception("Отказано в добавлении контейнера: нерентабельное хранение");
            }
        }
        public void AddContainer(MyContainer container)
        {
            if (LIST_OF_CONTAINERS.Count != MAX_NUMBER_OF_CONTAINERS)
            {
                container = Store.CalcDamage(container);
                CheckContainerBeforeAddition(container);
                    foreach (MyContainer cont in LIST_OF_CONTAINERS) 
                    {
                        if (cont is null) continue;
                        cont.SetPriority(cont.GetPriority() + 1);
                    }
                    LIST_OF_CONTAINERS.Add(container);
            }
            else 
            {
                List<MyContainer> orderedContainerList = LIST_OF_CONTAINERS;
                orderedContainerList.Sort(new ContainerComparePriority());
                int myIndex = LIST_OF_CONTAINERS.IndexOf(orderedContainerList.First<MyContainer>());
                MyContainer localCont = LIST_OF_CONTAINERS[myIndex];
                container = Store.CalcDamage(container);
                if (Store.TOTAL_MASS_CONTAINERS - MyContainer.CountSumMass(localCont.GetList()) + MyContainer.CountSumMass(container.GetList()) > STORE_MAXIMUM_WEIGHT)
                {
                    Console.WriteLine("Невозможно заменить старый контейнер на новый! Склад не сможет его выдержать");
                }
                else 
                {
                LIST_OF_CONTAINERS.Remove(LIST_OF_CONTAINERS[myIndex]);
                foreach (MyContainer cont in LIST_OF_CONTAINERS) {
                    if (cont is null) continue;
                    cont.SetPriority(cont.GetPriority() + 1);
                }
                LIST_OF_CONTAINERS.Add(container);
                }
                
            }
        }
        //Вспомогательный метод для подсчета суммарной массы списка контейнеров
        public static double CountSumMass(List<MyContainer> listOfBox) 
        {
            double sum = 0;
            foreach (MyContainer container in listOfBox) 
            {
                sum = sum + MyContainer.CountSumMass(container.GetList());
            }
            return sum;
        }
        //Удаление конта со склада
        public void RemoveContainer(int idCont) 
        {
            idCont--;
            if (LIST_OF_CONTAINERS.Count == 0) {
                Console.WriteLine("Ошибка: на складе нету контейнеров");
            } else {
                MyContainer export = LIST_OF_CONTAINERS[idCont];
                LIST_OF_CONTAINERS.Remove(export);
            }
            
        }
        
        public Store() 
        {
            this.MAX_NUMBER_OF_CONTAINERS = 0;
            Store.RENTAL_PRICE = 0;
            Store.STORE_MAXIMUM_WEIGHT = 0;
            LIST_OF_CONTAINERS = new List<MyContainer>();
        }
        /*Этот метод отображает данные в виде такой таблички
        Имя | Кол-во контов
        *   | *
        С проверкой на то, есть ли на складе контейнеры
        */   
        public void GenerateContainers(int k, int lowerBorderMaxCount, int upperBorderMaxCount, double lowerBorderMassBox, double upperBorderMassBox, double lowerBorderPrice, double upperBorderPrice)
        {
            if (LIST_OF_CONTAINERS.Count + k > MAX_NUMBER_OF_CONTAINERS)
            {
                throw new Exception("Невозможно сгенировать столько контейнеров! Превышено максимальное допустимое кол-во контейнеров на складе!");
            }
            else
            {
            Random random = new Random();
            int temp = LIST_OF_CONTAINERS.Count;
            for (int h = temp; h < k + temp; h++)
            {
                int f = random.Next(lowerBorderMaxCount, upperBorderMaxCount);
                List<BoxOfVegetables> listBoxOfVegetables = new List<BoxOfVegetables>(f);
                double randomMassBox;
                double randomPrice;
                for (int i = 0; i < f; i++)
                {
                    do 
                    {
                    int spread = Math.Abs((int)(upperBorderMassBox - lowerBorderMassBox));
                    int part = random.Next(spread);
                    double incrementDouble = Convert.ToDouble(part) + random.NextDouble();
                    randomMassBox = lowerBorderMassBox + incrementDouble;
                    } while (randomMassBox < lowerBorderMassBox);
                    do 
                    {
                    int spread = Math.Abs((int)(lowerBorderMassBox - upperBorderMassBox));
                    int part = random.Next(spread);
                    double incrementDouble = Convert.ToDouble(part) + random.NextDouble();
                    randomPrice = lowerBorderPrice + incrementDouble;
                    } while (randomPrice < lowerBorderPrice);
                    listBoxOfVegetables.Add(new BoxOfVegetables(randomMassBox, randomPrice));
                }
                AddContainer(new MyContainer(f, listBoxOfVegetables, h.ToString()));
            }
            }
        }
        }

}