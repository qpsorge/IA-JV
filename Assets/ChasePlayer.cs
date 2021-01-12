using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : StateMachineBehaviour
{
    public AudioClip chasing_song;

    private const float PathUpdateInterval = 0.3f;

    private GameObject _player;
    private NavMeshAgent _agent;
    private AudioSource audio;
    

    private float _lastUpdateTime = 0f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_player == null)
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _agent = animator.gameObject.GetComponent<NavMeshAgent>();

            Debug.Log("En chasse !");
            //Musique
            audio = Camera.main.GetComponent<AudioSource>();
            audio.clip = chasing_song;
            audio.Play();
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Time.time > _lastUpdateTime + PathUpdateInterval)
        {
            _lastUpdateTime = Time.time;
            _agent.SetDestination(_player.transform.position);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
