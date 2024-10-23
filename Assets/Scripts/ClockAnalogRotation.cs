using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClockAnalogRotation : MonoBehaviour
{
    [SerializeField]
    private AnalogClockPointer clockPointer;

    private DateTime lastTime;

    // Start is called before the first frame update
    void Start()
    {
        lastTime = DateTime.Now;
        lastTime = lastTime.Subtract(new TimeSpan(0, 0, 0, 0, lastTime.Millisecond));

        switch (clockPointer)
        {
            case AnalogClockPointer.SECONDS:
                transform.Rotate(new Vector3(0, lastTime.Second * 6, 0));
                break;
            case AnalogClockPointer.MINUTES:
                transform.Rotate(new Vector3(0, lastTime.Minute * 6, 0));
                break;
            case AnalogClockPointer.HOURS:
                transform.Rotate(new Vector3(0, lastTime.Hour * 30, 0));
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        DateTime currentTime = DateTime.Now;
        currentTime = currentTime.Subtract(new TimeSpan(0, 0, 0, 0, currentTime.Millisecond));

        switch (clockPointer)
        {
            case AnalogClockPointer.SECONDS:
                transform.Rotate(new Vector3(0, (float)currentTime.Subtract(lastTime).TotalSeconds * 6, 0));
                break;
            case AnalogClockPointer.MINUTES:
                DateTime currentTimeMinutes = currentTime.Subtract(new TimeSpan(0, 0, currentTime.Second));
                DateTime lastTimeMinutes = lastTime.Subtract(new TimeSpan(0, 0, lastTime.Second));

                transform.Rotate(new Vector3(0, (float)currentTimeMinutes.Subtract(lastTimeMinutes).TotalMinutes * 6, 0));
                break;
            case AnalogClockPointer.HOURS:
                DateTime currentTimeHours = currentTime.Subtract(new TimeSpan(0, currentTime.Minute, currentTime.Second));
                DateTime lastTimeHours = lastTime.Subtract(new TimeSpan(0, lastTime.Minute, lastTime.Second));

                transform.Rotate(new Vector3(0, (float)currentTimeHours.Subtract(lastTimeHours).TotalHours * 30, 0));
                break;
            default:
                break;
        }

        lastTime = currentTime;
    }
}

public enum AnalogClockPointer
{
    SECONDS,
    MINUTES,
    HOURS
}
