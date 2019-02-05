using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class Flashlight : MonoBehaviour {

    // use this key to toggle flashlight on/off
    [SerializeField]
    private string toggleKey = "f";

    // reference to Light component
    private Light flashlight;

    // delay between toggling on/off
    private float delay = 0.5f;
    private float nextToggleTime = 0f;

    // cache the Light component
    private void Awake()
    {
        flashlight = gameObject.GetComponent<Light>();
    }

    // check each frame if user toggles the light
    private void Update () {
        if (Input.GetKey(toggleKey) && Time.time > nextToggleTime)
        {
            ToggleLight();
        }
    }

    // enable or disable the Light component with cooldown period in between
    private void ToggleLight()
    {
        bool currentState = flashlight.isActiveAndEnabled;
        flashlight.enabled = !currentState;
        nextToggleTime = Time.time + delay;
    }
}
