using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : StateMachineBehaviour
{
    private const float PathUpdateInterval = 0.3f;

    public GameObject _wp1;
    private bool cp1 = true;
    public GameObject _wp2;
    private bool cp2 = false;
    private NavMeshAgent _agent;

    private float _lastUpdateTime = 0f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent = animator.gameObject.GetComponent<NavMeshAgent>();
        if (_wp1 == null)
        {
            _wp1 = GameObject.FindGameObjectWithTag("WayPoint1");
        }
        if (_wp2 == null)
        {
            _wp2 = GameObject.FindGameObjectWithTag("WayPoint2");
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent = animator.gameObject.GetComponent<NavMeshAgent>();
        //update parameters
        if (cp1 && (_agent.transform.position - _wp1.transform.position).magnitude < 1.5)
        {
            cp1 = false;
            cp2 = true;
        }
        else if (cp2 && (_agent.transform.position - _wp2.transform.position).magnitude < 1.5)
        {
            cp1 = true;
            cp2 = false;
        }

        if (Time.time > _lastUpdateTime + PathUpdateInterval)
        {
            _lastUpdateTime = Time.time;
            if (cp1)
            {
                _agent.SetDestination(_wp1.transform.position);
            }
            else
            {
                _agent.SetDestination(_wp2.transform.position);
            }
            
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
