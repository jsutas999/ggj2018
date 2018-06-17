using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneFade : MonoBehaviour {
    public GameObject image;
    Image img;
    public float fadeTime;
    public AnimationCurve curve;

    private void Start() {
        img = image.GetComponent<Image>();
        FadeIn();
    }
    public void FadeIn() {
        StartCoroutine(FadeImage(true));
    }
    public void FadeOut() {
        StartCoroutine(FadeImage(false));
    }

    IEnumerator FadeImage(bool fadeAway) {
        if (fadeAway) {
            for (float i = fadeTime; i >= 0; i -= Time.deltaTime)
            {
                img.color = new Color(1, 1, 1, curve.Evaluate(i));
                yield return null;
            }
            image.SetActive(false);
        }
        else {
            image.SetActive(true);
            for (float i = 0; i <= fadeTime; i += Time.deltaTime)
            {
                img.color = new Color(1, 1, 1, curve.Evaluate(i));
                yield return null;
            }
        }
    }
}