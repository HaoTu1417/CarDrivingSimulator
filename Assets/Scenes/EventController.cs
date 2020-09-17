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
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        Vector3 startPos = transform.position + transform.forward * 5;
        if (Physics.Raycast(startPos, transform.TransformDirection(Vector3.forward), out hit, 100, layerMask))
        {
            Debug.DrawRay(startPos, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            Debug.Log("Did Hit: "+ hit.transform.gameObject.name);
        }
        else
        {
            Debug.DrawRay(startPos, transform.TransformDirection(Vector3.forward) * 100, Color.green);
            Debug.Log("Did not Hit");
        }
    }


}
