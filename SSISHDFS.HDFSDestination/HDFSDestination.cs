using Microsoft.Hadoop.WebHDFS;
using Microsoft.SqlServer.Dts.Pipeline;
using Microsoft.SqlServer.Dts.Pipeline.Wrapper;
using Microsoft.SqlServer.Dts.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSISHDFS.HDFSDestination
{
  [DtsPipelineComponent(DisplayName="HDFS Destination", ComponentType = ComponentType.DestinationAdapter,
    Description="Destination component for HDFS")]
  public class HDFSDestination : PipelineComponent
  {
    public override void ProvideComponentProperties()
    {
      base.RemoveAllInputsOutputsAndCustomProperties();
      ComponentMetaData.RuntimeConnectionCollection.RemoveAll();

      IDTSInput100 input = ComponentMetaData.InputCollection.New();
      input.Name = "Input";
      input.HasSideEffects = true;

      IDTSRuntimeConnection100 connection = ComponentMetaData.RuntimeConnectionCollection.New();
      connection.Name = "SOMETHING";
      connection.ConnectionManagerID = "SOMETHING";
    }

    private WebHDFSClient client;

    public override void AcquireConnections(object transaction)
    {
      if (ComponentMetaData.RuntimeConnectionCollection[0] != null)
      {
        ConnectionManager cm = Microsoft.SqlServer.Dts.Runtime.DtsConvert.GetWrapper(ComponentMetaData.RuntimeConnectionCollection[0].ConnectionManager);
        //ConnectionManagerAdoNet cmado = cm.InnerObject as ConnectionManagerAdoNet;
        HDFSConnectionManager.HDFSConnectionManager connManager = cm.InnerObject as HDFSConnectionManager.HDFSConnectionManager;

        if (connManager != null)
        {
          client = connManager.AcquireConnection(transaction) as WebHDFSClient;
        }
      }
    }

    public override DTSValidationStatus Validate()
    {
      return DTSValidationStatus.VS_ISVALID;
    }

    public override void ReleaseConnections()
    {
      
    }

    public override IDTSInputColumn100 SetUsageType(int inputID, IDTSVirtualInput100 virtualInput, int lineageID, DTSUsageType usageType)
    {
      IDTSInputColumn100 inputColumn = base.SetUsageType(inputID, virtualInput, lineageID, usageType);
      IDTSCustomProperty100 custProp;

      custProp = inputColumn.CustomPropertyCollection.New();
      custProp.Name = "FileName";
      custProp.Value = string.Empty;

      return inputColumn;
    }

    private string m_DestDir;
    private int m_FileNameColumnIndex = -1;
    private int m_BlobColumnIndex = -1;

    public override void PreExecute()
    {
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
      while (buffer.NextRow())
      {
        string strFileName = buffer.GetString(m_FileNameColumnIndex);
        int blobLength = (int)buffer.GetBlobLength(m_BlobColumnIndex);
        byte[] blobData = buffer.GetBlobData(m_BlobColumnIndex, 0, blobLength);
        string remoteFileName = strFileName;

        //strFileName = TranslateFileName(strFileName);
        client.CreateFile(strFileName, remoteFileName).Wait();

      }

    }
  }
}
