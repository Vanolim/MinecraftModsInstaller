using UnityEngine;

public interface IHubSceneFactory
{
    public MainSceneContext CreateMainHub();
    public LoadingScreenContext LoadingScreenHub();
}