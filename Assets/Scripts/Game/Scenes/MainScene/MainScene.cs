using System.IO;
using UnityEngine;

public class MainScene
{
    private readonly Game _game;
    private readonly IHubSceneFactory _hubSceneFactory;
    private MainSceneContext _mainSceneContext;
    private FileLoader _fileLoader;
    private IStaticDataService _staticDataService;
    private ModsStaticData mode1;
    
    public MainScene(Game game, IHubSceneFactory hubSceneFactory, IStaticDataService staticDataService)
    {
        _game = game;
        _hubSceneFactory = hubSceneFactory;
        _staticDataService = staticDataService;
    }

    public void Start()
    {
        LoadHub();
        LoadStaticData();
    }
    
    private void LoadHub()
    {
        _mainSceneContext = _hubSceneFactory.CreateMainHub();
        _mainSceneContext.Init();
        _mainSceneContext.OnClickMod += LoadMode;
    }

    private void LoadStaticData()
    {
        _staticDataService.LoadModeData();
    }

    private void LoadMode()
    {
        Debug.Log(Application.persistentDataPath);
        mode1 = _staticDataService.ForLoadModeData();
        _fileLoader = new FileLoader();
        _fileLoader.Load(mode1.URL, Path.Combine(Application.persistentDataPath, mode1.NameFIle));
        _fileLoader.OnLoad += OpenFile;
    }

    private void OpenFile()
    {
        _mainSceneContext.OpenFile.Open(mode1.NameFIle);
    }
}