using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderRay : MonoBehaviour
{
    public float m_MaxDistance;
    public Animator m_Animator;

    bool m_HitDetect;

    Collider m_Collider;
    RaycastHit m_Hit;

    void Start()
    {
        m_Collider = GetComponent<Collider>();
        m_Animator = transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
   
   

    void FixedUpdate()
    {
        //Test to see if there is a hit using a BoxCast
        //Calculate using the center of the GameObject's Collider(could also just use the GameObject's position), half the GameObject's size, the direction, the GameObject's rotation, and the maximum distance as variables.
        //Also fetch the hit data
        m_HitDetect = Physics.BoxCast(m_Collider.bounds.center, transform.localScale * 0.5f, transform.forward, out m_Hit, transform.rotation, m_MaxDistance);
        if (m_HitDetect && m_Hit.collider.CompareTag("Pedra"))
        {
            m_Animator.SetLayerWeight(3, 1);
            m_Animator.SetBool("Empurrar", true);
        }
        else
        {
            m_Animator.SetLayerWeight(0, 1);
            m_Animator.SetBool("Empurrar", false);

        }
    }

    //Draw the BoxCast as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Check if there has been a hit yet
        if (m_HitDetect)
        {
            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(transform.position, transform.forward * m_Hit.distance);
            //Draw a cube that extends to where the hit exists
            Gizmos.DrawWireCube(transform.position + transform.forward * m_Hit.distance, transform.localScale);
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(transform.position, transform.forward * m_MaxDistance);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireCube(transform.position + transform.forward * m_MaxDistance, transform.localScale);
        }
    }
}
