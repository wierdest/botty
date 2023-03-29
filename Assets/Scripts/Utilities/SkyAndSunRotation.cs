using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyAndSunRotation : MonoBehaviour
{
    [SerializeField] private Material sky;
    [SerializeField] private Transform sun;
    [SerializeField] private float speed;
    private Vector3 originalSunPosition;
    private Quaternion originalSunRotation;
    private float originalSkyRotation, skyRate;
    [SerializeField] private bool ascending;

    private void Awake()
    {
        originalSkyRotation = sky.GetFloat("_Rotation");
        originalSunRotation = sun.transform.rotation;
        originalSunPosition = sun.transform.position;
        reset();
    }


    private void Update()
    {
        var sunRate = Time.deltaTime * speed;
        if(sun.localEulerAngles.x >= 170.0f)
        {
            sun.SetPositionAndRotation(originalSunPosition, originalSunRotation);
        }
        sun.RotateAround(sun.position, sun.right, sunRate);
        skyRate += (sunRate - (sunRate * 0.4f)) ;
        sky.SetFloat("_Rotation", skyRate);

        
    }

    private void reset()
    {
        skyRate = 0f;
        sky.SetFloat("_Rotation", skyRate);
        sun.SetPositionAndRotation(originalSunPosition, originalSunRotation);
    }
}
