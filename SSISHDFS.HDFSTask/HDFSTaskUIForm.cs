using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSISHDFS.HDFSTask
{
  public partial class HDFSTaskUIForm : Form
  {
    private Microsoft.SqlServer.Dts.Runtime.TaskHost taskHost;
    private Microsoft.SqlServer.Dts.Runtime.Connections connections;
    private IServiceProvider serviceProvider;

    private string sourceDirectory;
    private string remoteDirectory;

    private class ConnectionManagerItem
    {
      public string ID;
      public string Name { get; set; }
      public HDFSConnectionManager.HDFSConnectionManager ConnManager { get; set; }

      public override string ToString()
      {
        return Name;
      }
    }

    public HDFSTaskUIForm()
    {
      InitializeComponent();
    }

    public HDFSTaskUIForm(Microsoft.SqlServer.Dts.Runtime.TaskHost taskHost, Microsoft.SqlServer.Dts.Runtime.Connections connections, IServiceProvider serviceProvider)
      : this()
    {
      this.taskHost = taskHost;
      this.connections = connections;
      this.serviceProvider = serviceProvider;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      var result = directoryBrowser.ShowDialog();

      if (result == System.Windows.Forms.DialogResult.OK)
      {
        txtSourceDirectory.Text = directoryBrowser.SelectedPath;
      }
    }

    private void HDFSTaskUIForm_Load(object sender, EventArgs e)
    {
      var connectionManagerId = string.Empty;
      
      int diff = 0;

      for (int i = 0; i < connections.Count; i++)
      {
        var conn = connections[i].InnerObject as HDFSConnectionManager.HDFSConnectionManager;

        if (conn != null)
        {
          var item = new ConnectionManagerItem()
          {
            Name = connections[i].Name,
            ConnManager = conn,
            ID = connections[i].ID
          };
          cbConnectionList.Items.Add(item);

          if (connections[i].ID.Equals(connectionManagerId))
          {
            cbConnectionList.SelectedIndex = i - diff;
          }
        }
        else
        {
          diff++;
        }
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      remoteDirectory = txtRemoteDirectory.Text;
      sourceDirectory = txtSourceDirectory.Text;

      var main = this.taskHost.InnerObject as HDFSTask;

      if (main != null)
      {
        main.RemoteDirectory = remoteDirectory;
        main.SourceDirectory = sourceDirectory;
        
        if (cbConnectionList.SelectedItem != null)
        {
          var selectedItem = (ConnectionManagerItem)cbConnectionList.SelectedItem;
          main.ConnectionManagerName = selectedItem.Name;
          main.ConnectionManagerId = selectedItem.ID;
        }
      }

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Close();
    }
  }
}
