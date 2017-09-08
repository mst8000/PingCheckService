using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace PingCheckService
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        static void Main(string[] args)
        {
            var service = new PingCheckService();

            if (Environment.UserInteractive)
            {
                //コマンドライン引数解析
                if (args.Length > 0)
                {
                    string mode = args[0].ToLower();
                    string path = System.Reflection.Assembly.GetExecutingAssembly().Location;

                    switch (mode)
                    {
                        //サービスインストール
                        case "/i":
                            if (IsServiceRegistered(service.ServiceName))
                            {
                                Console.WriteLine("Already Registered.");
                            }
                            else
                            {
                                ManagedInstallerClass.InstallHelper(new string[] { path });
                                Console.WriteLine("Succeed Register.");
                            }
                            break;

                        //サービスアンインストール
                        case "/u":
                            if (IsServiceRegistered(service.ServiceName))
                            {
                                ManagedInstallerClass.InstallHelper(new string[] { "/u", path });
                                Console.WriteLine("Succeed Unregister.");
                            }
                            else
                            {
                                Console.WriteLine("Not Registered.");
                            }
                            break;
                    }
                    return;
                }

                //コンソール実行
                service.OnStartConsole(args);
                Console.WriteLine("Press any key to stop program");
                Console.ReadKey();
                service.OnStopConsole();

            }
            else
            {
                ServiceBase.Run(service);

                //ServiceBase[] ServicesToRun;
                //ServicesToRun = new ServiceBase[]
                //{
                //new PingCheckService()
                //};
                //ServiceBase.Run(ServicesToRun);
            }
        }

        //サービスがインストールされているかチェック
        public static bool IsServiceRegistered(string name)
        {
            return ServiceController.GetServices().Any(s => s.ServiceName == name);
        }


    }
}
