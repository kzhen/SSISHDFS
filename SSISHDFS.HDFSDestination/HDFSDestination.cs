using Microsoft.Hadoop.WebHDFS;
using Microsoft.SqlServer.Dts.Pipeline;
using Microsoft.SqlServer.Dts.Pipeline.Wrapper;
using Microsoft.SqlServer.Dts.Runtime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSISHDFS.HDFSDestination
{
  [DtsPipelineComponent(DisplayName = "HDFS Destination", ComponentType = ComponentType.DestinationAdapter,
    UITypeName = "SSISHDFS.HDFSDestination.HDFSDestinationUI, SSISHDFS.HDFSDestination, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a22a06ea3c77d390",
    Description = "Destination component for HDFS")]
  public class HDFSDestination : PipelineComponent
  {
    private WebHDFSClient client;
    private string m_DestDir;
    private int m_FileNameColumnIndex = -1;
    private int m_BlobColumnIndex = -1;

    public override void ProvideComponentProperties()
    {
      //clear base implementations
      base.RemoveAllInputsOutputsAndCustomProperties();
      this.ComponentMetaData.RuntimeConnectionCollection.RemoveAll();
      this.ComponentMetaData.InputCollection.RemoveAll();
      this.ComponentMetaData.OutputCollection.RemoveAll();

      //add custom properties
      AddProperty(Constants.HDFS_PATH_PROPERTY, "The path to store the files in HDFS", "/user/hue/somepath", true);
      AddProperty(Constants.SOURCE_COLUMN_INDEX, "The name of the source column", "", true);

      //add the input into the destination
      IDTSInput100 input = ComponentMetaData.InputCollection.New();
      input.Name = "HDFS Input";
      input.Description = "Input for the HDFS Destination";
      input.HasSideEffects = true;

      IDTSRuntimeConnection100 connection = ComponentMetaData.RuntimeConnectionCollection.New();
      connection.Name = Constants.HDFS_CONNECTION_MANAGER;
      connection.Description = "Connection to HDFS";
    }

    private void AddProperty(string name, string description, object value, bool supportsExpressions)
    {
      IDTSCustomProperty100 customProperty = this.ComponentMetaData.CustomPropertyCollection.New();
      customProperty.Name = name;
      customProperty.Description = description;
      customProperty.Value = value;

      if (supportsExpressions)
      {
        customProperty.ExpressionType = DTSCustomPropertyExpressionType.CPET_NOTIFY;
      }
    }

    public override void AcquireConnections(object transaction)
    {
      if (ComponentMetaData.RuntimeConnectionCollection[0] != null)
      {
        ConnectionManager cm = Microsoft.SqlServer.Dts.Runtime.DtsConvert.GetWrapper(ComponentMetaData.RuntimeConnectionCollection[0].ConnectionManager);
        
        HDFSConnectionManager.HDFSConnectionManager connManager = cm.InnerObject as HDFSConnectionManager.HDFSConnectionManager;

        if (connManager != null)
        {
          client = connManager.AcquireConnection(transaction) as WebHDFSClient;
        }
      }
    }

    public override DTSValidationStatus Validate()
    {
      if (this.ComponentMetaData.CustomPropertyCollection[Constants.HDFS_PATH_PROPERTY].Value == null || this.ComponentMetaData.CustomPropertyCollection[Constants.HDFS_PATH_PROPERTY].Value == string.Empty)
      {
        FireEvent(EventType.Error, "HDFSPath is invalid");
        return DTSValidationStatus.VS_ISBROKEN;
      }
      return DTSValidationStatus.VS_ISVALID;
    }

    public override void ReleaseConnections()
    {
      this.client = null;
    }

    public override void PreExecute()
    {
      Debugger.Launch();

      IDTSInput100 input = ComponentMetaData.InputCollection[0];
      IDTSInputColumnCollection100 inputColumns = input.InputColumnCollection;
      IDTSCustomProperty100 custProp;

      foreach (IDTSInputColumn100 column in inputColumns)
      {
        custProp = column.CustomPropertyCollection["IsFileName"];
        if ((bool)custProp.Value == true)
        {
          m_FileNameColumnIndex = (int)BufferManager.FindColumnByLineageID(input.Buffer, column.LineageID);
        }
      }
    }

    public override void ProcessInput(int inputID, PipelineBuffer buffer)
    {
#if DEBUG
      Debugger.Launch();
#endif

      int columnIndex = ComponentMetaData.CustomPropertyCollection[Constants.SOURCE_COLUMN_INDEX].Value;
      string remotePath = ComponentMetaData.CustomPropertyCollection[Constants.HDFS_PATH_PROPERTY].Value;

      while (buffer.NextRow())
      {
        string strFullFileName = buffer.GetString(columnIndex);
        string fileName = Path.GetFileName(strFullFileName);

        string remoteFileName = remotePath + "/" + fileName;

        client.CreateFile(strFullFileName, remoteFileName).Wait();          
      }
    }

    private void FireEvent(EventType eventType, string eventDescription)
    {

      bool cancel = false;

      switch (eventType)
      {
        case EventType.Information:
          this.ComponentMetaData.FireInformation(0, this.ComponentMetaData.Name, eventDescription, string.Empty, 0, ref cancel);
          break;
        case EventType.Warning:
          this.ComponentMetaData.FireWarning(0, this.ComponentMetaData.Name, eventDescription, string.Empty, 0);
          break;
        case EventType.Error:
          this.ComponentMetaData.FireError(0, this.ComponentMetaData.Name, eventDescription, string.Empty, 0, out cancel);
          break;
        default:
          break;
      }
    }

    private enum EventType
    {
      Information,
      Warning,
      Error
    }
  }
}
