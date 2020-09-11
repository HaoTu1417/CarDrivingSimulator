using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public enum TrafficLightSignal
{
    red,
    green,
    yellow
}

public class TrafficLight : MonoBehaviour
{
    [SerializeField] TrafficLightSignal currentLightSignal;
    /// <summary>
    /// how long does it take to change light
    /// </summary>
    [SerializeField] float redLightTime = 20;
    [SerializeField] float greenLightTime = 20;
    [SerializeField] float yellowLightTime = 3;
    [SerializeField] float currentTimer;

    private void Start()
    {
        currentLightSignal = (TrafficLightSignal) Random.Range(0, 3);
        ChangeCurrentTimer(currentLightSignal);
    }

    private void ChangeCurrentTimer(TrafficLightSignal signal)

    {
        switch (signal)
        {
            case TrafficLightSignal.red:
                currentTimer = redLightTime;
                break;
            case TrafficLightSignal.yellow:
                currentTimer = yellowLightTime;
                break;
            case TrafficLightSignal.green:
                currentTimer = greenLightTime;
                break;

        }
    }

   private IEnumerator C_ChangeLight()
    {
        yield return new WaitForSeconds(currentTimer);
        int currentLightState = (int)currentLightSignal + 1;
        if (currentLightState > 2)
        {
            currentLightState = 0;
        }
        currentLightSignal = (TrafficLightSignal)currentLightState;
        ChangeCurrentTimer(currentLightSignal);
        StartCoroutine(C_ChangeLight());

    }

}
