using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public static EventController instance;

    private Dictionary<string, Action> events;

    private void Update()
    {
        //int layerMask = 1 << 8;

        //// This would cast rays only against colliders in layer 8.
        //// But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        //layerMask = ~layerMask;

        //RaycastHit hit;
        //// Does the ray intersect any objects excluding the player layer
        //Vector3 startPos = transform.position + transform.forward * 5;
        //if (Physics.Raycast(startPos, transform.TransformDirection(Vector3.forward), out hit, 100, layerMask))
        //{
        //    Debug.DrawRay(startPos, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        //    Debug.Log("Did Hit: "+ hit.transform.gameObject.name);
        //}
        //else
        //{
        //    Debug.DrawRay(startPos, transform.TransformDirection(Vector3.forward) * 100, Color.green);
        //    Debug.Log("Did not Hit");
        //}new Vector3(-67.5f, 1.2f, 87.8f)
        
        GameObject hitgo;
        float distance;
        //CastRay(new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z), 0, Vector3.forward, 10, out hitgo, out distance);
        Debug.Log(Input.GetAxis("Fire1"));
    }

    void CastRay(Vector3 anchor, float angle, Vector3 dir, float length, out GameObject outCarAI, out float outHitDistance)
    {

        outCarAI = null;
        outHitDistance = -1f;
        Debug.Log("h");
        //Draw raycast
        Debug.DrawRay(anchor, Quaternion.Euler(0, angle, 0) * dir * length, new Color(1, 0, 0, 0.5f));

        //Detect hit only on the autonomous vehicle layer
        int layer = 1 << LayerMask.NameToLayer("AutonomousVehicle");
        RaycastHit hit;
        if (Physics.Raycast(anchor, Quaternion.Euler(0, angle, 0) * dir, out hit, length, layer))
        {
            outCarAI = hit.collider.gameObject;
            outHitDistance = hit.distance;
            Debug.Log("hit");
        }
        else
        {
            Debug.Log(" not hit");

        }
    }


}
