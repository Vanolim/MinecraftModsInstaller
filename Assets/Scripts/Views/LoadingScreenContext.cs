using System;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenContext : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Slider _slider;

    private float _counter;
    private bool _isLoad;

    private const float BOOTLOADER_TIME = 6;

    public event Action OnLoaded;
    
    public void Init() => _canvas.worldCamera = Camera.main;

    public void StartLoad() => _isLoad = true;

    private void Update()
    {
        if (_isLoad)
        {
            _counter += Time.deltaTime;
            if (_counter < BOOTLOADER_TIME)
            {
                SetSlider();
            }
            else
            {
                _isLoad = false;
                OnLoaded?.Invoke();
            }
        }
    }

    private void SetSlider() => _slider.value = Mathf.InverseLerp(0, BOOTLOADER_TIME, _counter);
}