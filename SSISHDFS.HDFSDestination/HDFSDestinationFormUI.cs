using Microsoft.SqlServer.Dts.Pipeline.Wrapper;
using Microsoft.SqlServer.Dts.Runtime;
using Microsoft.SqlServer.Dts.Runtime.Design;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SSISHDFS.HDFSDestination
{
  public partial class HDFSDestinationFormUI : Form
  {
    private IDTSComponentMetaData100 metaData;
    private IServiceProvider serviceProvider;
    private CManagedComponentWrapper designTimeInstance;
    private IDtsConnectionService connectionService;

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

    private class SourceColumnItem
    {
      public int Index { get; set; }
      public string Name { get; set; }
      public IDTSVirtualInputColumn100 ColumnInfo { get; set; }

      public override string ToString()
      {
        return Name;
      }
    }

    public HDFSDestinationFormUI()
    {
      InitializeComponent();
    }

    public HDFSDestinationFormUI(IDTSComponentMetaData100 metaData, IServiceProvider serviceProvider)
      : this()
    {
      this.metaData = metaData;
      this.serviceProvider = serviceProvider;
      this.connectionService = (IDtsConnectionService)serviceProvider.GetService(typeof(IDtsConnectionService));
      this.designTimeInstance = metaData.Instantiate();
    }

    private void HDFSDestinationUI_Load(object sender, EventArgs e)
    {
      var connections = connectionService.GetConnections();
      var connectionManagerId = string.Empty;

      if (metaData.CustomPropertyCollection[Constants.HDFS_PATH_PROPERTY] != null ||
        !string.IsNullOrWhiteSpace(metaData.CustomPropertyCollection[Constants.HDFS_PATH_PROPERTY].Value))
      {
        txtDestinationPath.Text = metaData.CustomPropertyCollection[Constants.HDFS_PATH_PROPERTY].Value;
      }

      IDTSVirtualInput100 vInput = metaData.InputCollection[0].GetVirtualInput();
      Dictionary<string, int> columnLineage = new Dictionary<string, int>(vInput.VirtualInputColumnCollection.Count);

      int itemIndex = 0;

      foreach (IDTSVirtualInputColumn100 item in vInput.VirtualInputColumnCollection)
      {
        cbSourceColumns.Items.Add(new SourceColumnItem() { Name = item.Name.Trim(), Index = itemIndex++, ColumnInfo = item });
        columnLineage.Add(item.Name, item.LineageID);
      }

      var currentConnectionManager = this.metaData.RuntimeConnectionCollection[0];
      if (currentConnectionManager != null)
      {
        connectionManagerId = currentConnectionManager.ConnectionManagerID;
      }

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
      if (!string.IsNullOrWhiteSpace(txtDestinationPath.Text))
      {
        designTimeInstance.SetComponentProperty(Constants.HDFS_PATH_PROPERTY, txtDestinationPath.Text);
      }

      if (cbConnectionList.SelectedItem != null)
      {
        var item = (ConnectionManagerItem)cbConnectionList.SelectedItem;
        this.metaData.RuntimeConnectionCollection[0].ConnectionManagerID = item.ID;
      }

      if (cbSourceColumns.SelectedItem != null)
      {
        var item = (SourceColumnItem)cbSourceColumns.SelectedItem;
        designTimeInstance.SetComponentProperty(Constants.SOURCE_COLUMN_INDEX, item.Index);
      }

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
    }

    private void btnNewConnectionManager_Click(object sender, EventArgs e)
    {
      System.Collections.ArrayList created = connectionService.CreateConnection(Constants.HDFS_CONNECTION_MANAGER);

      foreach (ConnectionManager cm in created)
      {
        var item = new ConnectionManagerItem()
        {
          Name = cm.Name,
          ConnManager = cm.InnerObject as HDFSConnectionManager.HDFSConnectionManager,
          ID = cm.ID
        };

        cbConnectionList.Items.Insert(0, item);
      }
    }
  }
}
