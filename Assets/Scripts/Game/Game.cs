public class Game
{
    private readonly NamesLogicScenes _namesLogicScenes;
    private readonly MainScene _mainScene;
    private readonly Services _services;
    public Game(NamesLogicScenes namesLogicScenes, Services services)
    {
        _namesLogicScenes = namesLogicScenes;
        _services = services;
    }
    
    public void LoadScene(Scenes scene)
    {
        switch (scene)
        {
            case Scenes.LoadingScreen:
                LoadLoadingScreenScene();
                break;
                
            case Scenes.Main:
                LoadMainScene();
                break;
        }
    }

    private void LoadLoadingScreenScene()
    {
        LoadingScreenScene loadingScreenScene = new LoadingScreenScene(this, _services.HubSceneFactory);
        
        _services.SceneLoader.Load(_namesLogicScenes.NameLoadingScreenScene, loadingScreenScene.Start);
    }

    private void LoadMainScene()
    {
        MainScene mainScene = new MainScene(this, _services.HubSceneFactory, _services.StaticDataService);
        
        _services.SceneLoader.Load(_namesLogicScenes.NameMainScene, mainScene.Start);
    }
}