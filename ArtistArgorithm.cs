using System.Collections;

namespace DopLaba1 {
    public class ArtistArgorithm {
        private string[] arrayHeaders;
        private List<ArrayList> listOfDataArrayList;
        private int[] arrayMaxWidthOfData;
        private int countElement;

        public int MenuRendering(List<String> headers_list, int index_cursor)
        {
            index_cursor = 1;
            ConsoleKey KEY_KEYBOARD;
            ShowContent(index_cursor, headers_list);
            while ((KEY_KEYBOARD = Console.ReadKey(true).Key) != ConsoleKey.Enter)
            {
                switch (KEY_KEYBOARD)
                {
                    case ConsoleKey.UpArrow:
                        index_cursor--;
                        if (index_cursor == 0)
                        {
                            index_cursor = headers_list.Count - 1;
                        }
                        Console.Clear();
                        ShowContent(index_cursor, headers_list);
                        break;
                    case ConsoleKey.DownArrow:
                        index_cursor++;
                        if (index_cursor == headers_list.Count) {
                            index_cursor = 1;
                        }
                        Console.Clear();
                        ShowContent(index_cursor, headers_list);
                        break;
                }
            }
            return index_cursor;
        }
        public ArtistArgorithm(Adapter adapter)
        {
            arrayHeaders = adapter.GetArrayHeaders();
            listOfDataArrayList = adapter.GetListOfArrayData();
            arrayMaxWidthOfData = adapter.GetArrayMaxWidthOfData();
            countElement = adapter.GetCountElement();
        }
        public ArtistArgorithm()
        {

        }
        public void SetDataFromAdapter(Adapter adapter)
        {
            arrayHeaders = adapter.GetArrayHeaders();
            listOfDataArrayList = adapter.GetListOfArrayData();
            arrayMaxWidthOfData = adapter.GetArrayMaxWidthOfData();
            countElement = adapter.GetCountElement();
        }

        public static void ShowContent(int index_cursor, List<string> headers_list)
        {
            for (int i = 0; i < headers_list.Count; i++)
            {
                if (i == index_cursor)
                {
                    Console.WriteLine("->"+headers_list[i]);
                }
                else
                {
                    Console.WriteLine("  " +headers_list[i]);
                }
            }
        }

        public void RenderingPage(int idPage, int indexCursor)
        {
            int stop = idPage * 10 + 10;
            if (stop > countElement)
            {
                stop = countElement;
            }

            Console.Write("  -");
            for (int i = 0; i < arrayHeaders.Length; i++)
            {
                Console.Write(string.Join("",Enumerable.Repeat("-" , arrayMaxWidthOfData[i])));
                Console.Write("-");
            }
            Console.WriteLine();

            Console.Write("  |");
            for (int i = 0; i < arrayHeaders.Length; i++)
            {
                Console.Write(string.Format("{{0, -{0}}}|", arrayMaxWidthOfData[i]), arrayHeaders[i]);
            }
            Console.WriteLine();

            for (int i = idPage * 10; i < stop; i++) 
            {
                if (i == indexCursor)
                {
                    Console.Write("->|");
                    for (int j = 0; j < arrayHeaders.Length; j++)
                    {
                        Console.Write(string.Format("{{0, -{0}}}|", arrayMaxWidthOfData[j]),listOfDataArrayList[j][i].ToString());
                    }
                    Console.Write("|");
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("  |");
                    for (int j = 0; j < arrayHeaders.Length; j++)
                    {
                        Console.Write(string.Format("{{0, -{0}}}|", arrayMaxWidthOfData[j]),listOfDataArrayList[j][i].ToString());
                    }
                    Console.WriteLine();
                }

            }
            Console.Write("  -");
            for (int i = 0; i < arrayHeaders.Length; i++)
            {
                Console.Write(string.Join("",Enumerable.Repeat("-" , arrayMaxWidthOfData[i])));
                Console.Write("-");
            }
            Console.WriteLine();
            Console.WriteLine("Страница " + (idPage + 1) + " Всего элементов " + countElement);
        }
        public int SelectElementFromTheStore()
        {
            Console.WriteLine();
            Console.WriteLine("Содержимое хранилища");
            Console.WriteLine();

            bool FLAG_KEY_IS_ESCAPE = false;
            int COUNT_PAGE = countElement/ 10;
            int currectPage = 0;
            int indexCursor = 0;
            ConsoleKey key;
            RenderingPage(currectPage, indexCursor);
            
            while (!FLAG_KEY_IS_ESCAPE && (key = Console.ReadKey(true).Key) != ConsoleKey.Enter)
            {
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        indexCursor--;
                        if (indexCursor == currectPage * 10 - 1)
                        {
                            if (currectPage != 0)
                            {
                                currectPage--;
                            }
                            else {
                                indexCursor++;
                            }

                        }
                        Console.Clear();
                        RenderingPage(currectPage, indexCursor);
                        break;
                    case ConsoleKey.DownArrow:
                        indexCursor++;
                        if ((indexCursor == currectPage * 10 + 10) || (indexCursor == countElement)) {
                            if (currectPage != COUNT_PAGE)
                            {
                                currectPage++;

                            }
                            else
                            {
                                indexCursor--;
                            }
                        }
                        Console.Clear();
                        RenderingPage(currectPage, indexCursor);
                        break;
                    case ConsoleKey.LeftArrow:
                        if (currectPage != 0)
                        {
                            currectPage--;
                            indexCursor -= 10;
                        }
                        Console.Clear();
                        RenderingPage(currectPage, indexCursor);
                        break;
                    case ConsoleKey.RightArrow:
                        int j = indexCursor;
                        if (currectPage != COUNT_PAGE)
                        {
                            currectPage ++;
                            indexCursor += 10;
                        }
                        if(j + 10 > countElement)
                        {
                            indexCursor = countElement - 1;
                        }
                        Console.Clear();
                        RenderingPage(currectPage, indexCursor);
                        break;
                    case ConsoleKey.Escape:
                        FLAG_KEY_IS_ESCAPE = true;
                    break;
                }
            }
            return indexCursor;
        }
}
}