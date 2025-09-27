using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;
    public  SceneManager sceneManager;

    private void Start()    
    {
        
    }

    public void Exit()
    {
        sceneManager.GoToMenu();
    }

}
