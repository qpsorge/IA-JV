using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickAndGo : MonoBehaviour
{
    Animator m_Animator;
    private NavMeshAgent _agent;
    private Vector3 _lastHit;
    private Vector3 lastPos;
    private int layerGround = 1<<10;
    private void Start()
    {
        m_Animator = GetComponentInChildren<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        lastPos = transform.position;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000, layerGround) && hit.collider.CompareTag("Ground"))
            {
                _lastHit = hit.point;
                m_Animator.ResetTrigger("idleTrigger");
                m_Animator.SetTrigger("walkingModeTrigger");
                _agent.SetDestination(_lastHit);
                //Debug.Log("x : "+hit.point.x.ToString()+"; y :"+ hit.point.y.ToString());
            }
            /*
            Debug.Log((_agent.transform.position - _agent.destination).magnitude);
            
            if((_agent.transform.position- _agent.destination).magnitude < 2.5F)
            {
                m_Animator.ResetTrigger("walkingModeTrigger");
                m_Animator.SetTrigger("idleTrigger");
            }
            */    
        }
        else
        {
            if ((lastPos - transform.position).magnitude >= 0.008f)
            {
                m_Animator.SetTrigger("walkingModeTrigger");
                m_Animator.ResetTrigger("idleTrigger");
            }
            else
            {
                m_Animator.ResetTrigger("walkingModeTrigger");
                m_Animator.SetTrigger("idleTrigger");
            }
        }
        lastPos = transform.position;
        //Debug.Log("" + (lastPos - transform.position).magnitude);
    }
}
