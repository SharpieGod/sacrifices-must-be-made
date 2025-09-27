using UnityEngine;

public class ButtonUser : MonoBehaviour
{
    public Button button;

    void Start()
    {
        button.callback += Test;
    }

    void Test()
    {
        Debug.Log("Test");
    }
}
