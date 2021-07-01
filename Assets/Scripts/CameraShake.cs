using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public IEnumerator CamShake(float duration, float magnitude)
    {
        Vector3 startPos = transform.localPosition;

        float timeTaken = 0.0f;

        while(timeTaken < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, startPos.z);
            timeTaken += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = startPos;
    }
}