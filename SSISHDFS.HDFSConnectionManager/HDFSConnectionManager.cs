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
        infoEvents.FireError(0, "HDFS", "No UserName specified", string.Empty, 0);
        return DTSExecResult.Failure;
      }
      if (string.IsNullOrWhiteSpace(Host))
      {
        infoEvents.FireError(0, "HDFS", "No Host specified", string.Empty, 0);
        return DTSExecResult.Failure;
      }
      if (Port <= 0)
      {
        infoEvents.FireError(0, "HDFS", "No Port specified", string.Empty, 0);
        return DTSExecResult.Failure;
      }
      if (string.IsNullOrWhiteSpace(ConnectionString))
      {
        infoEvents.FireError(0, "HDFS", "Invalid ConnectionString", string.Empty, 0);
        return DTSExecResult.Failure;
      }

      return DTSExecResult.Success;
    }

    public override object AcquireConnection(object txn)
    {
#if DEBUG
      Debugger.Launch();
#endif

      try
      {
        Uri connectionUri = new Uri(ConnectionString);
        WebHDFSClient client = new WebHDFSClient(connectionUri, UserName);

        return client;
      }
      catch (UriFormatException)
      {
        throw new Exception("HDFS Connection Manager - Invalid Connection String, check Host and Port");
      }
    }

    public override void ReleaseConnection(object connection)
    {
    }
  }
}
