using UnityEngine;

public class StaticData : IStaticDataService
{
    private ModsStaticData _loadMode;
    
    public void LoadModeData() =>
        _loadMode = Resources.Load<ModsStaticData>(AssetPath.LoadingModePath);
    
    public ModsStaticData ForLoadModeData() => _loadMode;
}