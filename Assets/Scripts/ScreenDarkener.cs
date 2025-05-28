using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenDarkener : MonoBehaviour
{
    public Image darkImage; // Ссылка на Image, который затемняет экран
    public float darkDuration = 2f;
    public float interval = 5f;
    public float fadeSpeed = 2f;

    private void Start()
    {
        if (darkImage != null)
        {
            darkImage.raycastTarget = false;
            darkImage.color = new Color(0, 0, 0, 0); // Убедиться, что изначально прозрачно
            StartCoroutine(DarkeningLoop());
        }
        else
        {
            Debug.LogError("Dark Image is not assigned!");
        }
    }

    IEnumerator DarkeningLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            yield return StartCoroutine(FadeTo(1f));  // затемнение
            yield return new WaitForSeconds(darkDuration);
            yield return StartCoroutine(FadeTo(0f));  // осветление
        }
    }

    IEnumerator FadeTo(float targetAlpha)
    {
        Color color = darkImage.color;
        float startAlpha = color.a;
        float time = 0f;

        while (!Mathf.Approximately(color.a, targetAlpha))
        {
            time += Time.deltaTime * fadeSpeed;
            color.a = Mathf.Lerp(startAlpha, targetAlpha, time);
            darkImage.color = color;
            yield return null;
        }

        color.a = targetAlpha;
        darkImage.color = color;
    }
}
