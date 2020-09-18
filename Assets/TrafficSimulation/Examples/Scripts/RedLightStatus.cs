// Traffic Simulation
// https://github.com/mchrbn/unity-traffic-simulation

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TrafficSimulation;

public class RedLightStatus : MonoBehaviour
{

    public int lightGroupId;  // Belong to traffic light 1 or 2?
    public Intersection intersection;

    Light pointLight;

    public GameObject greenLight;
    public GameObject redLight;
    public GameObject yellowLight;

    void Start()
    {
        pointLight = this.transform.GetChild(0).GetComponent<Light>();
        SetTrafficLightColor();
    }

    // Update is called once per frame
    void Update()
    {
        SetTrafficLightColor();
    }

    void SetTrafficLightColor()
    {

        if (intersection == null)
        {

            return;
        }
        if (lightGroupId == intersection.curLightRed)
        {
            //pointLight.color = new Color(1, 0, 0);
            ChangeLightToRed();
        }

        else
        {
            ChangeLightToGreen();
            //pointLight.color = new Color(0, 1, 0);
        }

    }

    void ChangeLightToRed()
    {
        if (greenLight == null || redLight == null || yellowLight == null)
            return;
        greenLight.SetActive(false);
        redLight.SetActive(true);
        yellowLight.SetActive(false);
    }

    void ChangeLightToGreen()
    {
        if (greenLight == null || redLight == null || yellowLight == null)
            return;
        greenLight.SetActive(true);
        redLight.SetActive(false);
        yellowLight.SetActive(false);
    }

    void ChangeLightToYellow()
    {
        if (greenLight == null || redLight == null || yellowLight == null)
            return;
        greenLight.SetActive(false);
        redLight.SetActive(false);
        yellowLight.SetActive(true);
    }
}
