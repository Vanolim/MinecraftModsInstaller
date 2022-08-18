public class LoadingScreenScene
{
    private readonly Game _game;
    private readonly IHubSceneFactory _hubSceneFactory;
    private LoadingScreenContext _loadingScreen;

    public LoadingScreenScene(Game game, IHubSceneFactory hubSceneFactory)
    {
        _game = game;
        _hubSceneFactory = hubSceneFactory;
    }
    
    public void Start()
    {
        LoadHub();
    }

    private void LoadHub()
    {
        _loadingScreen = _hubSceneFactory.LoadingScreenHub();
        _loadingScreen.Init();
        _loadingScreen.StartLoad();
        _loadingScreen.OnLoaded += LoadMainScene;
    }

    private void LoadMainScene()
    {
        _loadingScreen.OnLoaded -= LoadMainScene;
        _game.LoadScene(Scenes.Main);
    }
}