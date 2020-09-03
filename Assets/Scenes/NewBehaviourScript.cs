using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public static EventController instance;

    private Dictionary<string, Action> events;

    public bool RegisteNewEvent(string name, Action action)
    {
        if (events.ContainsKey(name))
            
        {
            return false;
        }
        events.Add(name, action);
        return true;

    }

    public bool UnRegisteEvent(string name)
    {
        if (events.ContainsKey(name))
        {
            events.Remove(name);
            return true;
        }
        return false;
    }
}
