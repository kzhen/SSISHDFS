using Microsoft.Hadoop.WebHDFS;
using Microsoft.SqlServer.Dts.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSISHDFS.HDFSConnectionManager
{
  [DtsConnection(ConnectionType="HDFS", DisplayName="HDFS Connection Manager", 
    Description="Connection Manager for HDFS")]
  public class HDFSConnectionManager : ConnectionManagerBase
  {
    public string UserName { get; set; }
    public string Path { get; set; }

    private string connString;

    public override DTSExecResult Validate(IDTSInfoEvents infoEvents)
    {
      if (string.IsNullOrWhiteSpace(UserName))
      {
        return DTSExecResult.Success;
      }
      if (string.IsNullOrWhiteSpace(Path))
      {
        return DTSExecResult.Success;
      }
      if (string.IsNullOrWhiteSpace(ConnectionString))
      {
        return DTSExecResult.Success;
      }

      return DTSExecResult.Success;
    }

    public override string ConnectionString
    {
      get
      {
        return connString;
      }
      set
      {
        connString = value;
      }
    }

    public override object AcquireConnection(object txn)
    {
      if (string.IsNullOrWhiteSpace(connString))
      {
        connString = "http://192.168.56.101:50070";
      }

      Uri connectionUri = new Uri(connString);
      WebHDFSClient client = new WebHDFSClient(connectionUri, UserName);

      return client;
    }

    public override void ReleaseConnection(object connection)
    {
    }
  }
}
