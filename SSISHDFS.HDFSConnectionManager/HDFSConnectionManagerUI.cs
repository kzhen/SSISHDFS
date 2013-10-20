using Microsoft.SqlServer.Dts.Design;
using Microsoft.SqlServer.Dts.Runtime;
using Microsoft.SqlServer.Dts.Runtime.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSISHDFS.HDFSConnectionManager
{
  public class HDFSConnectionManagerUI : IDtsConnectionManagerUI
  {
    private IServiceProvider serviceProvider;
    private ConnectionManager connectionManager;

    public void Delete(System.Windows.Forms.IWin32Window parentWindow)
    {
    }

    public bool Edit(System.Windows.Forms.IWin32Window parentWindow, Microsoft.SqlServer.Dts.Runtime.Connections connections, ConnectionManagerUIArgs connectionUIArg)
    {
      return ShowUI(parentWindow);
    }

    private bool ShowUI(System.Windows.Forms.IWin32Window parentWindow)
    {
      HDFSConnectionManagerUIForm frm = new HDFSConnectionManagerUIForm(connectionManager, serviceProvider);

      var result = frm.ShowDialog();

      if (result == DialogResult.OK)
        return true;

      return false;
    }

    public void Initialize(Microsoft.SqlServer.Dts.Runtime.ConnectionManager connectionManager, IServiceProvider serviceProvider)
    {
      this.connectionManager = connectionManager;
      this.serviceProvider = serviceProvider;
    }

    public bool New(System.Windows.Forms.IWin32Window parentWindow, Microsoft.SqlServer.Dts.Runtime.Connections connections, ConnectionManagerUIArgs connectionUIArg)
    {
      IDtsClipboardService clipboardService;

      clipboardService = (IDtsClipboardService)serviceProvider.GetService(typeof(IDtsClipboardService));
      if (clipboardService != null)
      // If connection manager has been copied and pasted, take no action.
      {
        if (clipboardService.IsPasteActive)
        {
          return true;
        }
      }

      return ShowUI(parentWindow);
    }
  }
}
