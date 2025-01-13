namespace DopLaba1
{
    public class FacadeStore
    {
        Store store;
        public void SetStore(Store store)
        {
            this.store = store;
        }
        private MyContainer CalcDamage(MyContainer list) {
            Random random = new Random();
            double shareOfLoss = random.NextDouble() / 2;
            foreach (BoxOfVegetables box in list.GetList()) { 
                box.SetMass(box.GetMass() * shareOfLoss);
            }
            return list;
        }
        //Расчет стоимости конта(вспомогательный метод при добавлении конта на склад)
        private double CalcMoney(MyContainer list) 
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
        private void CheckContainerBeforeAddition(MyContainer container)
        {
            if (CountSumMass(store.GetList()) + MyContainer.CountSumMass(container.GetList()) > store.GetMaxStoreMass())
                {
                    throw new Exception("Невозможно добавить новый контейнер! Склад не сможет его выдержать");
                }
            else if (CalcMoney(container) < store.GetRentalPrice()) 
            {
                throw new Exception("Отказано в добавлении контейнера: нерентабельное хранение");
            }
        }
        public void AddContainer(MyContainer container)
        {
            if (store.GetList().Count != store.GetMaxNumberOfContainers())
            {
                container = CalcDamage(container);
                CheckContainerBeforeAddition(container);
                    foreach (MyContainer cont in store.GetList()) 
                    {
                        if (cont is null) continue;
                        cont.SetPriority(cont.GetPriority() + 1);
                    }
                    store.GetList().Add(container);
            }
            else 
            {
                List<MyContainer> orderedContainerList = store.GetList();
                orderedContainerList.Sort(new ContainerComparePriority());
                int myIndex = store.GetList().IndexOf(orderedContainerList.First<MyContainer>());
                MyContainer localCont = store.GetList()[myIndex];
                container = CalcDamage(container);
                if (store.GetTotalMassContainers() - MyContainer.CountSumMass(localCont.GetList()) + MyContainer.CountSumMass(container.GetList()) > store.GetMaxStoreMass() )
                {
                    Console.WriteLine("Невозможно заменить старый контейнер на новый! Склад не сможет его выдержать");
                }
                else 
                {
                store.GetList().Remove(store.GetList()[myIndex]);
                foreach (MyContainer cont in store.GetList()) {
                    if (cont is null) continue;
                    cont.SetPriority(cont.GetPriority() + 1);
                }
                store.GetList().Add(container);
                }
                
            }
        }
        //Вспомогательный метод для подсчета суммарной массы списка контейнеров
        private double CountSumMass(List<MyContainer> listOfBox) 
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
            if (store.GetList().Count == 0) {
                Console.WriteLine("Ошибка: на складе нету контейнеров");
            } else {
                store.RemoveContainer(idCont);
            }
            
        }
        
        /*Этот метод отображает данные в виде такой таблички
        Имя | Кол-во контов
        *   | *
        С проверкой на то, есть ли на складе контейнеры
        */   
        public void GenerateContainers(int k, int lowerBorderMaxCount, int upperBorderMaxCount, double lowerBorderMassBox, double upperBorderMassBox, double lowerBorderPrice, double upperBorderPrice)
        {
            if (store.GetList().Count + k > store.GetMaxNumberOfContainers())
            {
                throw new Exception("Невозможно сгенировать столько контейнеров! Превышено максимальное допустимое кол-во контейнеров на складе!");
            }
            else
            {
            Random random = new Random();
            int temp = store.GetList().Count;
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