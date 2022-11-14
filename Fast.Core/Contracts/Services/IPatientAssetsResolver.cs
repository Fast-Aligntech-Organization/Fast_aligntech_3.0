using System.Collections.Generic;

namespace Fast.Core;

public interface IPatientAssetsResolver
{
    Dictionary<string, string> Files
    {
        get;
    }
    List<string> Folders
    {
        get;
    }
    List<string> Orders
    {
        get;
    }
    string Pid
    {
        get; set;
    }
    string SelectedFolder
    {
        get;
    }
    string SelectedOrder
    {
        get; set;
    }
    List<string> Subfolders
    {
        get;
    }
    public string BasePath {
        get;
    }

    Dictionary<string, string> GetPatientAssetFiles(string path);
    List<string> GetPatientAssets(string pid, string order);
    List<string> GetPatientAssetsFolders(string pid);
    string GetPatientOrder(string path);
    List<string> GetPatientOrders(List<string> paths);
}
