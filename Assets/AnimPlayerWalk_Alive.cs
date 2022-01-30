using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayerWalk_Alive : StateMachineBehaviour
{
    [SerializeField] private float tiempoDer, tiempoIzq;
    [SerializeField] private AudioClip footSteps;
    private AudioSource audioSource;
    private float porcentaje;
    private bool pieDer, pieIzq;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(!audioSource)
            audioSource = animator.gameObject.GetComponent<AudioSource>();
        pieDer = pieIzq = true;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        porcentaje = stateInfo.normalizedTime % 1;
        //Debug.Log(porcentaje);

        
        if (porcentaje <= 0.05f)
            pieDer = pieIzq = true;

        if (porcentaje >= tiempoDer && pieDer)
        {
            //Debug.Log("Derecho");
            audioSource.PlayOneShot(footSteps, ConfigSounds.Instance.volume);
            pieDer = false;
        }
        if (porcentaje >= tiempoIzq && pieIzq)
        {
            //Debug.Log("Izquierdo");
            audioSource.PlayOneShot(footSteps, ConfigSounds.Instance.volume);
            pieIzq = false;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //audioSource.Pause();
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
