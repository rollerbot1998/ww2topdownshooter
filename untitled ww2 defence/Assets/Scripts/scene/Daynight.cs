using UnityEngine;
using System.Collections;

public class Daynight : MonoBehaviour
{

    private float dayLength;   //in minutes
    private float dayStart;
    private float nightStart;   //also in minutes
    private int currentTime;
    private float midDay;
    private float intencityTemp;
    public float cycleSpeed;
    private bool isDay;
    private Vector3 sunPosition;
    public Light sun;
    public GameObject earth;

    // Day and Night Script for 2d,
    // Unity needs one empty GameObject (earth) and one Light (sun)
    // make the sun a child of the earth
    // reset the earth position to 0,0,0 and move the sun to -200,0,0
    // attach script to sun
    // add sun and earth to script publics
    // set sun to directional light and y angle to 90


    void Start()
    {
        dayLength = 1440;
        dayStart = 300;
        nightStart = 1200;
        currentTime = 500;
        StartCoroutine(TimeOfDay());
        earth = gameObject.transform.parent.gameObject;
        midDay = (nightStart - dayStart) / 2;
    }

    void Update()
    {

        if (currentTime > 0 && currentTime < dayStart)
        {
            isDay = false;
            sun.intensity = 0;
        }
        else if (currentTime >= dayStart && currentTime < nightStart)
        {
            isDay = true;
            if (currentTime < dayStart + midDay)
            {
                sun.intensity = currentTime / (dayStart + midDay);
                
            }
            else
            {
                sun.intensity = 1 - ((currentTime - midDay) / (nightStart - midDay));
                
            }
            
        }
        else if (currentTime >= nightStart && currentTime < dayLength)
        {
            isDay = false;
            sun.intensity = 0;
        }
        else if (currentTime >= dayLength)
        {
            currentTime = 0;
        }
        float currentTimeF = currentTime;
        float dayLengthF = dayLength;
        earth.transform.eulerAngles = new Vector3(0, 0, (-(currentTimeF / dayLengthF) * 360) + 90);
    }

    IEnumerator TimeOfDay()
    {
        while (true)
        {
            currentTime += 1;
            int hours = Mathf.RoundToInt(currentTime / 60);
            int minutes = currentTime % 60;
            //Debug.Log(hours + ":" + minutes + " Intencity:" + sun.intensity);
            yield return new WaitForSeconds(1F / cycleSpeed);
        }
    }
}
