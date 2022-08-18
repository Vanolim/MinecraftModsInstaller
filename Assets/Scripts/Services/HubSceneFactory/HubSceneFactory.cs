public class HubSceneFactory : IHubSceneFactory
{
    private readonly IAssetsProvider _assetsProvider;
    
    public HubSceneFactory(IAssetsProvider assetsProvider)
    {
        _assetsProvider = assetsProvider;
    }

    public MainSceneContext CreateMainHub() =>
        _assetsProvider.Instantiate(AssetPath.MainHubPath).GetComponent<MainSceneContext>();

    public LoadingScreenContext LoadingScreenHub() => _assetsProvider.Instantiate(AssetPath.LoadingScreenHubPath)
        .GetComponent<LoadingScreenContext>();
}