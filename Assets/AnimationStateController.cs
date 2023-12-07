using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{

    // isWalking parameter is stored in Animator Componet
    Animator animator; // declare Animator referense variable, now we have acccess to boolian parameter via code
    //int isWalkingHash; // to increase performance
    //int isRunningHash; // to increase performance

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // Unity built-in Get-Component func - searches through the Game Object that our script is attached to for whatever component passed as parameter (in this case Animator is parameter and Xbot is Game Object)
        // Debug.Log(animator);
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool("isRunning");
        bool isWalking = animator.GetBool("isWalking");
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");

        // ------------ WALKING --------------------

        // if player press "w"
        if (!isWalking && forwardPressed)
        {
            // then set isWalking bool to true
            animator.SetBool("isWalking", true);
        }

        // if player is not pressing "w"
        if (isWalking && !forwardPressed)
        {
            // then set isWalking bool to false
            animator.SetBool("isWalking", false);
        }

        // ------------ RUNNING --------------------

        // if player is walking and not running and presses "left shift"
        if (!isRunning && (forwardPressed && runPressed))
        {
            // than set isRunning bool to true
            animator.SetBool("isRunning", true);
        }

        // if player is running and stops running or stops wlaking
        if (isRunning && (!forwardPressed || !runPressed))
        {
            // than set isRunning bool to false
            animator.SetBool("isRunning", false);
        }
    }
}
