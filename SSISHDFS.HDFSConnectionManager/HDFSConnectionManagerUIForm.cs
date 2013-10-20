using Microsoft.SqlServer.Dts.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSISHDFS.HDFSConnectionManager
{
  public partial class HDFSConnectionManagerUIForm : Form
  {
    private ConnectionManager connectionManager;
    private IServiceProvider serviceProvider;

    public HDFSConnectionManagerUIForm()
    {
      InitializeComponent();
    }

    public HDFSConnectionManagerUIForm(ConnectionManager connectionManager, IServiceProvider serviceProvider)
      : this()
    {
      this.connectionManager = connectionManager;
      this.serviceProvider = serviceProvider;
    }

    private void HDFSConnectionManagerUIForm_Load(object sender, EventArgs e)
    {
      object hostname = connectionManager.Properties["Host"].GetValue(connectionManager);//.ToString();
      object username = connectionManager.Properties["UserName"].GetValue(connectionManager);//.ToString();
      object port = connectionManager.Properties["Port"].GetValue(connectionManager);//.ToString();

      if (hostname != null && !string.IsNullOrWhiteSpace(hostname.ToString()))
      {
        txtHost.Text = hostname.ToString();
      }
      if (username != null && !string.IsNullOrWhiteSpace(username.ToString()))
      {
        txtUsername.Text = username.ToString();
      }
      if (port != null && !string.IsNullOrWhiteSpace(port.ToString()))
      {
        nmPort.Text = port.ToString();
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      int port = Convert.ToInt32(nmPort.Value);

      connectionManager.Properties["Host"].SetValue(connectionManager, txtHost.Text);
      connectionManager.Properties["UserName"].SetValue(connectionManager, txtUsername.Text);
      connectionManager.Properties["Port"].SetValue(connectionManager, port);

      this.DialogResult = DialogResult.OK;

      this.Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;

      this.Close();
    }
  }
}
