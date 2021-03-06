﻿using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {
	
    private const LeanTweenType tweenType = LeanTweenType.easeOutQuad;
    private const float time = 0.2f;
    CameraZoom _cameraZoom;

    private bool tweening = false;
    Quaternion _targetRot;
    float _lerpTime = 0.3f;
    float _startLerpTime = 0;

    void Start()
    {
        tweening = false;
        _targetRot = transform.rotation;
        _cameraZoom = transform.Find("GameObject/Main Camera").GetComponent<CameraZoom>();
    }

    private void Update()
    {
        if (_cameraZoom != null)
        {
            if (!_cameraZoom.IsZooming)
            {
                //Debug.Log(transform.rotation.eulerAngles);
                if (!tweening)
                {
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        MoveRight();
                    }
                    else if (Input.GetKeyDown(KeyCode.D))
                    {
                        MoveLeft();
                    }
                }
            }
            if (tweening)
            {
                float t = (Time.time - _startLerpTime) / _lerpTime;
                t = t * t * t * (t * (6f * t - 15f) + 10f);

                float diff = (_targetRot.eulerAngles.y - transform.rotation.eulerAngles.y);
                if (diff > 270)
                    diff = -90;
                else if (diff < -270)
                    diff = 90;
                float angle = (diff) * t;
                if (diff > 0.05 || diff < -0.05)
                    transform.rotation *= Quaternion.Euler(0, angle, 0);
                else {
                    transform.rotation = _targetRot;
                    tweening = false;
                }
            }
            
        }
        //Debug.Log(transform.rotation.eulerAngles);
    }


    private void MoveRight()
    {
        //Debug.Log(transform.rotation.eulerAngles);
        new Sound (transform.root.gameObject.GetComponent<AudioSource> (), "SFX/" + "woosh", 0.5f);
        _targetRot = transform.rotation * Quaternion.Euler(0, 90, 0);
        tweening = true;
        _startLerpTime = Time.time;
    }

    private void MoveLeft()
    {
        //Debug.Log(transform.rotation.eulerAngles);
        new Sound (transform.root.gameObject.GetComponent<AudioSource> (), "SFX/" + "woosh", 0.5f);
        _targetRot = transform.rotation * Quaternion.Euler(0, -90, 0);
        tweening = true;
        _startLerpTime = Time.time;
    }
}
