using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    public LineRenderer LineRenderer;

    public void Draw(Vector3 a, Vector3 b, float length)
    {
        LineRenderer.enabled = true;

        float interpolant = Vector3.Distance(a, b) / length; // 3 ���������� � Lerp �����. �����������.
        float offset = Mathf.Lerp(length / 2f, 0f, interpolant);

        Vector3 aDown = a + Vector3.down * offset;
        Vector3 bDown = b + Vector3.down * offset;

        LineRenderer.positionCount = 11;
        for (int i = 0; i < 11; i++)
        {
            LineRenderer.SetPosition(i, Bezier.GetPoint(a, aDown, bDown, b, i / 10f));
        }
    }

    public void Hide()
    {
        LineRenderer.enabled = false;
    }
}
