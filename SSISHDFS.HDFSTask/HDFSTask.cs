using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Dts.Runtime;
using System.Diagnostics;
using System.IO;
using Microsoft.Hadoop.WebHDFS;

namespace SSISHDFS.HDFSTask
{

  [DtsTask(DisplayName = "HDFS Directory Transfer", TaskType = "Something",
    UITypeName = "SSISHDFS.HDFSTask.HDFSTaskUI, SSISHDFS.HDFSTask, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a22a06ea3c77d390",
    TaskContact = "Ken Ross", RequiredProductLevel = DTSProductLevel.None)]
  public class HDFSTask : Microsoft.SqlServer.Dts.Runtime.Task
  {
    public string ConnectionManagerId { get; set; }
    public string SourceDirectory { get; set; }
    public string RemoteDirectory { get; set; }
    public string ConnectionManagerName { get; set; }

    public override void InitializeTask(Connections connections, VariableDispenser variableDispenser, IDTSInfoEvents events, IDTSLogging log, EventInfos eventInfos, LogEntryInfos logEntryInfos, ObjectReferenceTracker refTracker)
    {
      base.InitializeTask(connections, variableDispenser, events, log, eventInfos, logEntryInfos, refTracker);
    }
    public override DTSExecResult Validate(Connections connections, VariableDispenser variableDispenser, IDTSComponentEvents componentEvents, IDTSLogging log)
    {
      if (string.IsNullOrWhiteSpace(SourceDirectory))
      {
        componentEvents.FireError(0, "HDFSTask", "Directoy value not specfied", "", 0);
        return DTSExecResult.Failure;
      }

      try
      {
        var cm = connections[ConnectionManagerName];
        if ((cm.InnerObject as SSISHDFS.HDFSConnectionManager.HDFSConnectionManager) != null)
        {
          return DTSExecResult.Success;
        }
        else
        {
          componentEvents.FireError(0, "HDFSTask", "No HDFS Connection Manager specfied", "", 0);
          return DTSExecResult.Failure;
        }
      }
      catch (Exception)
      {
        componentEvents.FireError(0, "HDFSTask", "No HDFS Connection Manager specfied", "", 0);
        return DTSExecResult.Failure;
      }
    }

    public override DTSExecResult Execute(Connections connections, VariableDispenser variableDispenser, IDTSComponentEvents componentEvents, IDTSLogging log, object transaction)
    {
      Debugger.Launch();

      var filesToTransfer = Directory.GetFiles(SourceDirectory);
      WebHDFSClient client;

      if (filesToTransfer.Length == 0)
      {
        return DTSExecResult.Success;
      }

      try
      {
        ConnectionManager cm = connections[this.ConnectionManagerName];
        client = cm.AcquireConnection(transaction) as WebHDFSClient;
      }
      catch (Exception)
      {
        componentEvents.FireError(0, "HDFSTask", "Unable to create HDFS Connection Manager", "", 0);
        return DTSExecResult.Failure;
      }

      foreach (var file in filesToTransfer)
      {
        string fileName = Path.GetFileName(file);

        string remoteFileName = RemoteDirectory + "/" + fileName;

        try
        {
          client.CreateFile(file, remoteFileName).Wait();
        }
        catch (Exception)
        {
          componentEvents.FireError(0, "HDFSTask", "Unable to transfer file...", "", 0);
          return DTSExecResult.Failure;
        }
      }
      return DTSExecResult.Success;
    }
  }
}
