using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZF.DesignPatterns.SingletonDemo
{
    class Singleton
    {
        private static Singleton instance;

        private static readonly object syncLock = new object();

        public static Singleton Instance
        {
            get
            {
                lock (syncLock)
                {
                    if (instance == null)
                    {
                   
                        instance = new Singleton();
                    }
                }

                return instance;
            }
        }


        protected Singleton()
        { }
    }
}
