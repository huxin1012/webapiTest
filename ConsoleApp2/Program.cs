using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public delegate double Handler(double basicWages);

    public class Manager
    {
        public double GetWages(double basicWages)
        {
            double totalWages = 1.5 * basicWages;
            Console.WriteLine("Manager's wages is : " + totalWages);
            return totalWages;
        }
    }

    public class Assistant
    {
        public double GetWages(double basicWages)
        {
            double totalWages = 1.2 * basicWages;
            Console.WriteLine("Assistant's wages is : " + totalWages);
            return totalWages;
        }
    }

    public class WageManager
    {
        private Handler wageHandler;

        //加入观察者
        public void Attach(Handler wageHandler1)
        {
            wageHandler += wageHandler1;
        }

        //删除观察者
        public void Detach(Handler wageHandler1)
        {
            wageHandler -= wageHandler1;
        }

        //通过GetInvodationList方法获取多路广播委托列表，如果观察者数量大于0即执行方法
        public void Execute(double basicWages)
        {
            if (wageHandler != null)
                if (wageHandler.GetInvocationList().Count() != 0)
                    wageHandler(basicWages);
        }

        static void Main(string[] args)
        {
            WageManager wageManager = new WageManager();
            //加入Manager观察者
            Manager manager = new Manager();
            //Handler managerHandler = new Handler(manager.GetWages);
            //wageManager.Attach(managerHandler);
            wageManager.Attach(manager.GetWages);

            //加入Assistant观察者
            Assistant assistant = new Assistant();
            //Handler assistantHandler = new Handler(assistant.GetWages);
            //wageManager.Attach(assistantHandler);
            wageManager.Attach(assistant.GetWages);

            //同时加入底薪3000元，分别进行计算
            wageManager.Execute(3000);
            Console.ReadKey();
        }
    }
}
