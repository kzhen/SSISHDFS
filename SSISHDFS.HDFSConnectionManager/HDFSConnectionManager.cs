using Microsoft.Hadoop.WebHDFS;
using Microsoft.SqlServer.Dts.Runtime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSISHDFS.HDFSConnectionManager
{
  [DtsConnection(ConnectionType = "HDFS", DisplayName = "HDFS Connection Manager",
    Description = "Connection Manager for HDFS")]
  public class HDFSConnectionManager : ConnectionManagerBase
  {
    public override string ConnectionString
    {
      get { return String.Format("http://{0}:{1}", Host, Port); }
      set
      {
        Uri uri = new Uri(value);
        Host = uri.Host;
        Port = uri.Port;
      }
    }

    public string UserName { get; set; }
    public string Host { get; set; }
    public int Port { get; set; }

    private string connString;

    public override DTSExecResult Validate(IDTSInfoEvents infoEvents)
    {
      if (string.IsNullOrWhiteSpace(UserName))
      {
        return DTSExecResult.Success;
      }
      if (string.IsNullOrWhiteSpace(Host))
      {
        return DTSExecResult.Failure;
      }
      if (Port <= 0)
      {
        return DTSExecResult.Success;
      }
      if (string.IsNullOrWhiteSpace(ConnectionString))
      {
        return DTSExecResult.Success;
      }

      return DTSExecResult.Success;
    }

    public override object AcquireConnection(object txn)
    {
#if DEBUG
      Debugger.Launch();
#endif

      Uri connectionUri = new Uri(ConnectionString);
      WebHDFSClient client = new WebHDFSClient(connectionUri, UserName);

      return client;
    }

    public override void ReleaseConnection(object connection)
    {
    }
  }
}
