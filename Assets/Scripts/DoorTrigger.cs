using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    private Transform doorTransform;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float duration = 0.5f;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float startTime = 0f;
    private bool isActivated = false;
    private bool hasFinished = false;
    private float threshold = 0.01f;

 
    private void OnTriggerEnter(Collider other)
    {
        if (doorTransform != null && !isActivated)
        {
            startPosition = doorTransform.position;
            endPosition = startPosition + offset;

            isActivated = true;
            startTime = Time.time;
        }
    }

    private void Update()
    {
        if (isActivated && !hasFinished && doorTransform != null)
        {
            doorTransform.position = Vector3.Lerp(startPosition, endPosition, (Time.time - startTime) / duration);
            if ((doorTransform.position - endPosition).magnitude < threshold)
            {
                hasFinished = true;
                doorTransform.position = endPosition;
            }
        }
    }

}
