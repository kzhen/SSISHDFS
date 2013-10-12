using Microsoft.SqlServer.Dts.Pipeline.Design;
using Microsoft.SqlServer.Dts.Pipeline.Wrapper;
using Microsoft.SqlServer.Dts.Runtime.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSISHDFS.HDFSDestination
{
  public class HDFSDestinationUI : IDtsComponentUI
  {
    private IServiceProvider serviceProvider;
    private IDTSComponentMetaData100 metaData;
    private IDtsConnectionService connectionService;

    public void Delete(System.Windows.Forms.IWin32Window parentWindow)
    {
    }

    public bool Edit(System.Windows.Forms.IWin32Window parentWindow, Microsoft.SqlServer.Dts.Runtime.Variables variables, Microsoft.SqlServer.Dts.Runtime.Connections connections)
    {
      return ShowUI(parentWindow) == DialogResult.OK;
    }

    public void Help(System.Windows.Forms.IWin32Window parentWindow)
    {
    }

    public void Initialize(Microsoft.SqlServer.Dts.Pipeline.Wrapper.IDTSComponentMetaData100 dtsComponentMetadata, IServiceProvider serviceProvider)
    {
      this.serviceProvider = serviceProvider;
      this.metaData = dtsComponentMetadata;

      this.connectionService = (IDtsConnectionService)serviceProvider.GetService(typeof(IDtsConnectionService));
    }

    public void New(System.Windows.Forms.IWin32Window parentWindow)
    {
      ShowUI(parentWindow);
    }

    private DialogResult ShowUI(IWin32Window parentWindow)
    {
      try
      {
        HDFSDestinationFormUI frm = new HDFSDestinationFormUI(metaData, serviceProvider);
        return frm.ShowDialog(parentWindow);
      }
      catch (Exception)
      {
        return DialogResult.Cancel;
      }
    }
  }
}
