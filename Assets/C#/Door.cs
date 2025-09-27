using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;

    private void Start()    
    {
        
    }

    public void Exit()
    {
        animator.SetTrigger("exit");
    }
}
