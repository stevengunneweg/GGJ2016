using UnityEngine;
using System.Collections;

public class PlingManager : MonoBehaviour {

    [SerializeField]
    private GameObject plingPrefab;

    public void ShowPlings(int amount, Enemy enemy){
        for(int i = 0; i < amount; i++){
            GameObject go = Instantiate(plingPrefab);
            go.transform.SetParent(transform, false);
            Vector2 viewportPoint = Camera.main.WorldToViewportPoint(enemy.transform.position);
            go.GetComponent<RectTransform>().anchorMin = viewportPoint;
            go.GetComponent<RectTransform>().anchorMax = viewportPoint;

            float percentageAmount = PlayerManager.instance.PercentageAmount;

            LeanTween.move(go.GetComponent<RectTransform>(), new Vector3(100 * percentageAmount, 0, -200), 1.2f).setEase(LeanTweenType.easeInBack);
        }
    }
}
