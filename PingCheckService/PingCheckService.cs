using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace PingCheckService
{
    public partial class PingCheckService : ServiceBase
    {
        public PingCheckService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }

        //コンソールから起動・停止するためのメソッド
        public void OnStartConsole(string[] args)
        {
            OnStart(args);
        }

        public void OnStopConsole()
        {
            OnStop();
        }
    }
}
