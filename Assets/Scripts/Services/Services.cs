public class Services
{
    public ISceneLoader SceneLoader { get; }
    public HubSceneFactory HubSceneFactory { get; }
    public IAssetsProvider AssetsProvider { get; }
    public IStaticDataService StaticDataService { get; }

    public Services(ICoroutineRunner coroutineRunner)
    {
        AssetsProvider = new AssetsProvider();
        SceneLoader = new SceneLoader(coroutineRunner);
        HubSceneFactory = new HubSceneFactory(AssetsProvider);
        StaticDataService = new StaticData();
    }
}