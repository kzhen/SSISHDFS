using Microsoft.SqlServer.Dts.Runtime;
using Microsoft.SqlServer.Dts.Runtime.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSISHDFS.HDFSTask
{
  public class HDFSTaskUI : IDtsTaskUI
  {
    private TaskHost taskHost;
    private Connections connections;
    private IServiceProvider serviceProvider;

    public void Delete(System.Windows.Forms.IWin32Window parentWindow)
    {
    }

    public System.Windows.Forms.ContainerControl GetView()
    {
      return new HDFSTaskUIForm(this.taskHost, this.connections, this.serviceProvider);
    }

    public void Initialize(TaskHost taskHost, IServiceProvider serviceProvider)
    {
      this.taskHost = taskHost;
      this.serviceProvider = serviceProvider;
      IDtsConnectionService connectionService = serviceProvider.GetService(typeof(IDtsConnectionService)) as IDtsConnectionService;
      this.connections = connectionService.GetConnections();
    }

    public void New(System.Windows.Forms.IWin32Window parentWindow)
    {
      HDFSTaskUIForm frm = new HDFSTaskUIForm(this.taskHost, this.connections, this.serviceProvider);
      frm.ShowDialog(parentWindow);
    }
  }
}
