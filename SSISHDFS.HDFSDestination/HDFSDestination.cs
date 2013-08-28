using Microsoft.SqlServer.Dts.Pipeline;
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
  }
}
