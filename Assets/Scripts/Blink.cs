using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] private Renderer[] Renderers;
    [SerializeField] private float _blinkingTime = 1;

    public void StartBlink()
    {
        StartCoroutine(BlinkEffect(_blinkingTime));
    }

    public void StartBlinking(float blinkingTime)
    {
        StartCoroutine(BlinkEffect(blinkingTime));
    }

    private IEnumerator BlinkEffect(float blinkingTime)
    {
        for (float t = 0; t < blinkingTime; t += Time.deltaTime)
        {
            for (int i = 0; i < Renderers.Length; i++)
            {
                for(int m = 0; m < Renderers[i].materials.Length; m++)
                {
                    Renderers[i].materials[m].SetColor("_EmissionColor", new Color(Mathf.Sin(t * 30) * 0.5f + 0.5f, 0, 0, 0));
                }
            }
            yield return null;
        }
    }
}
