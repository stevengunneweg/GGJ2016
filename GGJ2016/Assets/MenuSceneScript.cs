using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuSceneScript : MonoBehaviour {

    RectTransform godmodeNote;
    float targetx = 260;
    float inpos;
    float outpos;

    void Start()
    {
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

    }
    void LerpNote()
    {
        targetx = PlayerManager.FreeMode ? outpos : inpos;
        godmodeNote.localPosition += (new Vector3(targetx, godmodeNote.localPosition.y, godmodeNote.localPosition.z)- godmodeNote.localPosition) * (Time.deltaTime* 20);
    }
}
