using System;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Action callback;
    Vector2 targetPosition;
    bool triggered = false;

    private void Start()
    {
        targetPosition = transform.position;
    }

    public void TriggerButton()
    {
        if (triggered) return;
           
        if (callback != null) callback.Invoke();
        targetPosition = new Vector2(transform.position.x, transform.position.y - 0.4f);
        triggered = true;
    }

    private void Update()
    {
        float smoothing = 5f;
        transform.position = Vector2.Lerp(transform.position, targetPosition, 1 - Mathf.Exp(-smoothing * Time.deltaTime));

    }
}
