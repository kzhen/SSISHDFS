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

    public override DTSExecResult Validate(IDTSInfoEvents infoEvents)
    {
      if (string.IsNullOrWhiteSpace(UserName))
      {
        return DTSExecResult.Failure;
      }
      if (string.IsNullOrWhiteSpace(Path))
      {
        return DTSExecResult.Failure;
      }
      if (string.IsNullOrWhiteSpace(ConnectionString))
      {
        return DTSExecResult.Failure;
      }

      return DTSExecResult.Success;
    }

    public override object AcquireConnection(object txn)
    {
      Uri connectionUri = new Uri(ConnectionString);
      WebHDFSClient client = new WebHDFSClient(connectionUri, UserName);

      return client;
    }

    public override void ReleaseConnection(object connection)
    {
    }
  }
}
