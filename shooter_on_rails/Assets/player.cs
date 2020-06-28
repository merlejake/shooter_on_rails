using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class player : MonoBehaviour


{
    [Tooltip("In ms^-1")] [SerializeField] float Speed = 50f;
    [Tooltip("x-axis restriction")] [SerializeField] float xRestraint = 30f;
    [Tooltip("y-axis restriction")] [SerializeField] float yRestraint = 30f;
    
    [SerializeField] float positionPitchFactor = -1f;
    [SerializeField] float positionYawFactor = -1f;
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float controlRollFactor = -15f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessTanslation();
        ProcessRotation();

    }

    private void ProcessTanslation()
    {
        float xthrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xoffset = xthrow * Speed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xoffset;
        float xPosClamped = Mathf.Clamp(rawXPos, -xRestraint, xRestraint);
        float ythrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yoffset = ythrow * Speed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yoffset;
        float yPosClamped = Mathf.Clamp(rawYPos, -yRestraint, yRestraint);
        transform.localPosition = new Vector3(xPosClamped, yPosClamped, transform.localPosition.z);
    }
    private void ProcessRotation()
    {
        float xthrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float ythrow = CrossPlatformInputManager.GetAxis("Vertical");

        float pitchDuetoPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDuetoRotation = ythrow * controlPitchFactor;

        float yawDuetoPosition = transform.localPosition.x * positionYawFactor;
        float rollDuetoRotation = xthrow * controlRollFactor;

        float pitch = pitchDuetoPosition + pitchDuetoRotation;
        float yaw = yawDuetoPosition;
        float roll = rollDuetoRotation;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
   
}
