using System;

namespace CustomRandomList
{
   public class StartUp
    {
        static void Main(string[] args)
        {
          RandomList list=new RandomList();
          list.Add("Pesho");
          list.Add("Miki");
          list.Add("Gigi");
          list.Add("Koko");
          list.Add("Ceci");
          list.Add("Banana");

          for (int i = 0; i < 10; i++)
          {
              Console.WriteLine(list.RandomString());
          }
        }
    }
}
