using UnityEngine;

public class NamesLogicScenes : MonoBehaviour
{
    [SerializeField] private string _nameMainScene;
    [SerializeField] private string _nameLoadingScreenScene;

    public string NameMainScene => _nameMainScene;
    public string NameLoadingScreenScene => _nameLoadingScreenScene;
}