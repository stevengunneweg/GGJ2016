using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuSceneScript : MonoBehaviour {

    RectTransform godmodeNote;
    float targetx = 260;
    float inpos;
    float outpos;

    Transform _camera;
    Vector3 lookatTarget;
    Vector3 startposition;
    Vector3 targetposition;

    void Start()
    {
        _camera = GameObject.Find("Main Camera").GetComponent<Transform>();
        startposition = _camera.position;
        lookatTarget = _camera.position+(_camera.forward*2);
        godmodeNote = transform.Find("GodModeNote").GetComponent<RectTransform>();
        targetx = inpos = godmodeNote.localPosition.x;
        outpos = inpos - 240;
    }

    public void Play(){
        SceneManager.LoadScene("Main");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadMultiply))
            PlayerManager.FreeMode = !PlayerManager.FreeMode;

        LerpNote();

        _camera.LookAt(lookatTarget);

    }
    void LerpNote()
    {
        targetx = PlayerManager.FreeMode ? outpos : inpos;
        godmodeNote.localPosition += (new Vector3(targetx, godmodeNote.localPosition.y, godmodeNote.localPosition.z)- godmodeNote.localPosition) * (Time.deltaTime* 20);
        
        targetposition = PlayerManager.FreeMode ? new Vector3(startposition.x, startposition.y - 0.5f, startposition.z) : startposition;
        _camera.position += (targetposition - _camera.position) * (Time.deltaTime * 20);

    }
}
