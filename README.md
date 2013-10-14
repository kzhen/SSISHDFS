SSISHDFS
========

To build the solution you will need to run Visual Studio as Administrator. This is because as part of the build process VS will add the project output into the GAC, as well as copying them into the folders that SQL Server Data Tools (SSDT) looks for custom components.

In addition to building the solution, you will also need to add a few assemblies to the GAC yourself.

You can do this by running the Visual Studio Developer Command Prompt as administrator then browsing to the directory bin\debug for the HDFSDestination project. Then issue the following commands:

- gacutil /i Microsoft.Hadoop.WebClient.dll
- gacutil /i Microsoft.Hadoop.Client.dll
- gacutil /i System.Net.Http.Formatting.dll

If you've missed anything, or if I have missed anything then you should still see the HDFS Destination in SSDT, however when you add it to your Data Flow task you should see an error about 'unable to load [...] assembly'. If you come acorss this then just follow the steps above.