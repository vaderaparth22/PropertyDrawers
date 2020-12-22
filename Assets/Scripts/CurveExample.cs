using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CurveExample : MonoBehaviour
{
    public AnimationCurve animCurve;
    public float maxTime;
    public Button myButton;

    float timer;
    public Vector3Event v3Events;
    public ColorEvent clrEvents;

    public void PressButton()
    {
        StartCoroutine(AnimateButton());
    }

    IEnumerator AnimateButton()
    {
        timer = 0;

        while(timer < maxTime)
        {
            timer += Time.deltaTime;
            //myButton.transform.localScale = Vector3.one * animCurve.Evaluate(Mathf.Clamp01(timer / maxTime));

            float y = animCurve.Evaluate(Mathf.Clamp01(timer / maxTime));
            v3Events.Invoke(Vector3.one * y);

            Color clr = Color.Lerp(Color.white, Color.black, y);
            clrEvents.Invoke(clr);

            yield return null;
        }
    }
}

[System.Serializable]
public class Vector3Event : UnityEvent<Vector3> { }

[System.Serializable]
public class ColorEvent : UnityEvent<Color> { }
