using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Vector3[] corners = {
        new Vector3(-9.45f, 11.46f, 0),
        new Vector3(-4.53f, 11.46f, 0),
        new Vector3(-4.53f, 7.59f, 0),
        new Vector3(-9.38f, 7.59f, 0),
    };

    private int currentCornerIndex = 0;
    private float tweenProgress = 0f; 
    public float speed = 3f;
    public float Duration = 1f;

    Vector3 startPosition;
    Vector3 endPosition;
    float startTime;

      private void Start()
    {
        startPosition = corners[currentCornerIndex];
        endPosition = corners[(currentCornerIndex + 1) % 4]; 
        startTime = Time.time;
    }

    void Update()
    {
      float journeyLength = Vector3.Distance(startPosition, endPosition);
    float distCovered = (Time.time - startTime) * speed;
    float fractionOfJourney = distCovered / journeyLength;

    transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);


    if (fractionOfJourney >= 1f)
    {
        currentCornerIndex = (currentCornerIndex + 1) % 4;
        startPosition = corners[currentCornerIndex];
        endPosition = corners[(currentCornerIndex + 1) % 4]; 
        startTime = Time.time;
    }
    }
}
