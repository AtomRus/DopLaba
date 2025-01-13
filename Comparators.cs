namespace DopLaba1
{
    public class ContainerComparePriorityRevers : IComparer<MyContainer> 
    {
        public int Compare(MyContainer? container, MyContainer? container1) 
        {
            if (container is null || container1 is null) throw new ArgumentException("Некорректное значение аргумента");
            return container.GetPriority() - container1.GetPriority();
        }
    }
    public class ContainerComparePriority : IComparer<MyContainer> 
    {
        public int Compare(MyContainer? container, MyContainer? container1) 
        {
            if (container is null || container1 is null) throw new ArgumentException("Некорректное значение аргумента");
            return container1.GetPriority() - container.GetPriority();
        }
    }
    public class ContainerCompareCountBoxRevers : IComparer<MyContainer> 
    {
        public int Compare(MyContainer? container, MyContainer? container1) 
        {
            if (container is null || container1 is null) throw new ArgumentException("Некорректное значение аргумента");
            return container.GetCountBoxs() - container1.GetCountBoxs();
        }
    }
    public class ContainerCompareCountBox : IComparer<MyContainer> 
    {
        public int Compare(MyContainer? container, MyContainer? container1) 
        {
            if (container is null || container1 is null) throw new ArgumentException("Некорректное значение аргумента");
            return container1.GetCountBoxs() - container.GetCountBoxs();
        }
    }
    public class ContainerCompareDoubleRevers : IComparer<MyContainer> 
    {
        public int Compare(MyContainer container1, MyContainer container) 
        {
            if (MyContainer.CountSumMass(container.GetList()) > MyContainer.CountSumMass(container1.GetList()))
            {
                return 1;
            }
            else if (MyContainer.CountSumMass(container.GetList()) < MyContainer.CountSumMass(container1.GetList()))
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
    public class ContainerCompareDouble : IComparer<MyContainer> 
    {
        public int Compare(MyContainer container1, MyContainer container) 
        {
            if (MyContainer.CountSumMass(container.GetList()) > MyContainer.CountSumMass(container1.GetList()))
            {
                return -1;
            }
            else if (MyContainer.CountSumMass(container.GetList()) < MyContainer.CountSumMass(container1.GetList()))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
    public class ContainerCompareAlphabet : IComparer<MyContainer> 
    {
        public int Compare(MyContainer container, MyContainer container1) 
        {
            if (container.GetName() == null && container1.GetName() == null) throw new Exception();
            int temp;
            int temp1;
            if (Int32.TryParse(container.GetName(), out temp) &(Int32.TryParse(container1.GetName(), out temp1)))
            {
                return temp - temp1;
            }
            string firstWord = container.GetName();
            string secondWord = container1.GetName();
            return string.Compare(firstWord, secondWord);
            
        }
    }
    public class ContainerCompareAlphabetRevers : IComparer<MyContainer> 
    {
        public int Compare(MyContainer container, MyContainer container1) 
        {
            if (container.GetName() == null && container1.GetName() == null) throw new Exception();
            int temp;
            int temp1;
            if (Int32.TryParse(container.GetName(), out temp) &(Int32.TryParse(container1.GetName(), out temp1)))
            {
                return temp1 - temp;
            }
            string firstWord = container.GetName();
            string secondWord = container1.GetName();
            return string.Compare(firstWord, secondWord);
            
        }
    }
}