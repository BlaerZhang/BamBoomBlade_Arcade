using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

public class BushHitDetect : MonoBehaviour
{
    private GameObject intoLeavesFeedbackLarge;
    private GameObject intoLeavesFeedbackMedium;
    private GameObject intoLeavesFeedbackLSmall;
    // Start is called before the first frame update
    void Start()
    {
        intoLeavesFeedbackLarge = GameObject.Find("Into Leaves Feedback Large");
        intoLeavesFeedbackMedium = GameObject.Find("Into Leaves Feedback Medium");
        intoLeavesFeedbackLSmall = GameObject.Find("Into Leaves Feedback Small");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // private void OnCollisionEnter2D(Collision2D col)
    // {
    //     print("collision enter");
    //     if (col.gameObject.name == "Body")
    //     {
    //         float hitVelocity = col.GetContact(0).relativeVelocity.magnitude;
    //         
    //         if (hitVelocity >= 10)
    //         {
    //             intoLeavesFeedbackLarge.transform.position = col.GetContact(0).point;
    //             intoLeavesFeedbackLarge.PlayFeedbacks();
    //         }
    //
    //         if (hitVelocity < 10 && hitVelocity >= 5)
    //         {
    //             intoLeavesFeedbackMedium.transform.position = col.GetContact(0).point;
    //             intoLeavesFeedbackMedium.PlayFeedbacks();
    //         }
    //
    //         if (hitVelocity < 5)
    //         {
    //             intoLeavesFeedbackLSmall.transform.position = col.GetContact(0).point;
    //             intoLeavesFeedbackLSmall.PlayFeedbacks();
    //         }
    //         
    //     }
    // }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Body" && GameManager.instance.isInRound)
        {
            float hitVelocity = col.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
            
            if (hitVelocity >= 13)
            {
                intoLeavesFeedbackLarge.transform.position = col.ClosestPoint(transform.position);
                intoLeavesFeedbackLarge.GetComponent<MMF_Player>().PlayFeedbacks();
            }

            if (hitVelocity < 13 && hitVelocity >= 7)
            {
                intoLeavesFeedbackMedium.transform.position = col.ClosestPoint(transform.position);
                intoLeavesFeedbackMedium.GetComponent<MMF_Player>().PlayFeedbacks();
            }

            if (hitVelocity < 7)
            {
                intoLeavesFeedbackLSmall.transform.position = col.ClosestPoint(transform.position);
                intoLeavesFeedbackLSmall.GetComponent<MMF_Player>().PlayFeedbacks();
            }
        }

        if (col.gameObject.name == "Body" && !GameManager.instance.isInRound)
        {
            intoLeavesFeedbackLarge.transform.position = col.ClosestPoint(transform.position);
            intoLeavesFeedbackLarge.GetComponent<MMF_Player>().PlayFeedbacks();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Body" && GameManager.instance.isInRound)
        {
            float hitVelocity = col.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
            
            if (hitVelocity >= 7)
            {
                intoLeavesFeedbackMedium.transform.position = col.ClosestPoint(transform.position);
                intoLeavesFeedbackMedium.GetComponent<MMF_Player>().PlayFeedbacks();
            }

            if (hitVelocity > 4 && hitVelocity < 7)
            {
                intoLeavesFeedbackLSmall.transform.position = col.ClosestPoint(transform.position);
                intoLeavesFeedbackLSmall.GetComponent<MMF_Player>().PlayFeedbacks();
            }
        }
    }
}
