namespace DopLaba1
{
    public class FabricAdapter
    {
        public static Adapter CreateAdapter(AbstractStore abstractStore)
        {
            if (abstractStore is ContainerStorage)
            {
                return new ContainerStorageAdapter((ContainerStorage) abstractStore); 
            } else if (abstractStore is BoxStorage) 
            {
                return new BoxStorageAdapter((BoxStorage) abstractStore);
            } 
            else 
            {
                return null;
            }
        }
    }
}