using System.Collections;
using TMPro;
using UnityEngine;

public class MovinglPlatform : MonoBehaviour
{
    public Button button;
    public GameObject pointB;
    public GameObject platform;
    bool moving = false;

    void Start()
    {
        button.callback += Move;
    }

    private void Update()
    {
        if (!moving) return;

        float smoothing = 5f; // Higher = faster
        var targetPosition = pointB.transform.position;
        platform.transform.position = Vector2.Lerp(platform.transform.position, targetPosition, 1 - Mathf.Exp(-smoothing * Time.deltaTime));
    }

    void Move()
    {
       moving = true;
    }
}
