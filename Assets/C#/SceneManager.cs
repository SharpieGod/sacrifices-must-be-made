using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void GoToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
