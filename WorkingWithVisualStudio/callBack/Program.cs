using System;

namespace callBack
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }

        public delegate void CallBack();

        static void DoWork(int e, CallBack callback)
        {
            for (int i = 0; i < 1000000; i++)
            {
                e += i;
            }

            callBack.Invoke();
        }
        static void DoCallBack()
        {
            Console.WriteLine("I am a call back");
        }


    }
}
