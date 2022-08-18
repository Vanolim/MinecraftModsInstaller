using UnityEngine;

public class GameBotstrapper : MonoBehaviour, ICoroutineRunner
{
    [SerializeField] private NamesLogicScenes _namesLogicScenes;
    
    private Game _game;
    private Services _services;

    private void Awake()
    {
        _services = new Services(this);
        
        _game = new Game(_namesLogicScenes, _services);
        _game.LoadScene(Scenes.LoadingScreen);
        DontDestroyOnLoad(this);
    }
}
