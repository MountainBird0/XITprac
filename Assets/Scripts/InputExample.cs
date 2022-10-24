using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class InputExample : MonoBehaviour
{
    private InputDevice rightDevice;
    private InputDevice leftDevice;

    private void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevices(devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if(devices.Count < 2)
        {
            Debug.Log($"연결실패");
        }
        else
        {
            if (devices[1].name == "Oculus Touch Controller - Left")
            {
                leftDevice = devices[1];
            }
            else
            {
                Debug.Log($"{devices[1].name} 연결실패");
            }

            if (devices[2].name == "Oculus Touch Controller - Right")
            {
                rightDevice = devices[2];
            }
            else
            {
                Debug.Log($"{devices[2].name} 연결실패");
            }
        }

        /*
        List<InputDevice> R_devices = new List<InputDevice>();

        InputDeviceCharacteristics rightControllerCharacteristics =
            InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, R_devices);

        Debug.Log($"devices.Count : {R_devices.Count}");

        if (R_devices.Count > 0)
        {
            rightDevice = R_devices[0];
        }

        List<InputDevice> L_devices = new List<InputDevice>();

        InputDeviceCharacteristics leftControllerCharacteristics =
         InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics, L_devices);

        Debug.Log($"L_devices.Count : {L_devices.Count}");

        if (L_devices.Count > 0)
        {
            leftDevice = L_devices[0];
        }
        */
    }

    private void Update()
    {
        //Right
        rightDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue);
        if (primary2DAxisValue != Vector2.zero)
        {
            Debug.Log("Right Primary Touchpad : " + primary2DAxisValue);
        }

        rightDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
        if (triggerValue > 0.1F)
        {
            Debug.Log("Right Trigger pressed " + triggerValue);
        }

        rightDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue);
        if (gripValue > 0.1F)
        {
            Debug.Log("Right grip pressed " + gripValue);
        }

        rightDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool R_primaryButtonValue);
        if (R_primaryButtonValue)
        {
            Debug.Log("Right Pressing primary button");
        }

        rightDevice.TryGetFeatureValue(CommonUsages.secondaryTouch, out bool R_secondaryTouchValue);
        if (R_secondaryTouchValue)
        {
            Debug.Log("Right touch secondary button");
        }

        //Left
        leftDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool L_primaryButtonValue);
        if (L_primaryButtonValue)
        {
            Debug.Log("Left Pressing primary button");
        }

        leftDevice.TryGetFeatureValue(CommonUsages.secondaryTouch, out bool L_secondaryTouchValue);
        if(L_secondaryTouchValue)
        {
            Debug.Log("Left touch secondary button");
        }

        leftDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool L_gripButtonValue);
        if(L_gripButtonValue)
        {
            Debug.Log("Left grip button");
        }

        leftDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool L_triggerButtonValue);
        if(L_triggerButtonValue)
        {
            Debug.Log("Left trigger button");
        }

        leftDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool L_touchpadClick);
        if(L_touchpadClick)
        {
            Debug.Log("Left Touchpad click");
        }

        leftDevice.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out bool L_touchpadTouch);
        if(L_touchpadTouch)
        {
            Debug.Log("Left Touchpad touch");
        }
    }
}
