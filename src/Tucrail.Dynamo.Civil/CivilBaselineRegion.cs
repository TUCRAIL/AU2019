using Autodesk.Civil.DynamoNodes;
using Dynamo.Graph.Nodes;
using Corridor = Autodesk.Civil.DatabaseServices.Corridor;


public class CivilBaselineRegion
{
    private CivilBaselineRegion()
    {
    }

    /// <summary>
    /// Create a baseline region based on an asset
    /// </summary>
    public static int CreateFromAsset(Baseline baseline, string assetName, string assemblyName, double assetStartStation, double assetEndStation)
    {
        if (string.IsNullOrEmpty(assetName)) return -1;
        if (string.IsNullOrEmpty(assemblyName)) return -1;
        if (baseline == null) return -1;

        var corridor = (Corridor)baseline.Corridor.InternalDBObject;
        var baseBaseline = corridor.Baselines[baseline.Name];
        baseBaseline.BaselineRegions.Add(assetName, assemblyName, assetStartStation, assetEndStation);
        return baseBaseline.BaselineRegions.IndexOf(baseBaseline.BaselineRegions[assetName]);
    }
}
