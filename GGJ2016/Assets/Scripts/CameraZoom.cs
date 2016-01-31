using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

    private int level;
    private PlayerManager playerManager;
    private float defaultZoom;

    private bool _isZooming = false;

    private void Start(){
        playerManager = FindObjectOfType<PlayerManager>();
        level = 3;
    }

    private void Update(){
        if(level != playerManager.CurrentLevel){
            UpdateZoom();
        }
    }

    private void UpdateZoom(){
        _isZooming = true;
        int amount = level - playerManager.CurrentLevel;
        LeanTween.moveLocalZ(gameObject, transform.localPosition.z + amount * 2.9f, 0.6f).setEase(LeanTweenType.easeOutExpo).onComplete+=DoneZoom;
        level = playerManager.CurrentLevel;
    }
    void DoneZoom()
    {
        _isZooming = false;
    }

    public bool IsZooming
    {
        get { return _isZooming; }
    }

}
