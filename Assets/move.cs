using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private bool walkMode;
    private Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        walkMode = true;
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update :
        if (walkMode && transform.position.x < 8)
            walkMode = true;
        else if (walkMode && transform.position.x > 8)
        {
            walkMode = false;
            transform.rotation = Quaternion.Euler(transform.rotation.x, (transform.rotation.y - 45), transform.rotation.z);
        }
        else if (!walkMode && transform.position.x > -8)
            walkMode = false;
        else if ((!walkMode && transform.position.x < -8))
        {
            walkMode = true;
            transform.rotation = Quaternion.Euler( transform.rotation.x, (transform.rotation.y + 45) , transform.rotation.z);
        }
            


        // Apply motion
        if (walkMode)
        {
            transform.position += new Vector3(0.05f, 0, 0);
            m_Animator.SetFloat("Speed", 0.2f);
        }
        else
        {
            transform.position -= new Vector3(0.05f, 0, 0);
            m_Animator.SetFloat("Speed", 0.2f);

        }
        

    }
}
