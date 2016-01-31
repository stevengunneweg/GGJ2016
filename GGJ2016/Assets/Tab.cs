using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tab : MonoBehaviour {

    private const int MOVE_AMOUNT = 35;

    public Element element;

    private Vector3 defaultPosition;
    private RectTransform rect;
    private Button button;

    [SerializeField]
    private Text text;

    private void Start(){
        rect = transform.GetComponent<RectTransform>();
        defaultPosition = rect.localPosition;
        rect.localPosition += new Vector3(0, MOVE_AMOUNT, 0);
        button = GetComponent<Button>();
    }

    private void Update () {
        button.interactable = element.Available;
        text.text = element.Available ? "" : Mathf.Ceil(element.CurrentCooldown).ToString();
    }

    public void Select(){
        LeanTween.moveLocalY(gameObject, defaultPosition.y, 0.13f).setEase(LeanTweenType.easeInCubic);
    }

    public void Deselect(){
        LeanTween.moveLocalY(gameObject, defaultPosition.y + MOVE_AMOUNT, 0.13f).setEase(LeanTweenType.easeOutCubic);
    }

}
