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
        StartCoroutine(ExitRoutine());
    }

    private IEnumerator ExitRoutine()
    {
        animator.SetTrigger("exit");

        // Wait until the exit animation starts
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Exit"));

        // Then wait for the animation to finish
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Now switch scenes
        sceneManager.GoToMenu();
    }


}
