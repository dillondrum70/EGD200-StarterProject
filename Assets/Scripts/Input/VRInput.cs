using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRInput : MonoBehaviour
{
    public static ActionBasedController leftHand;
    public ActionBasedController leftHandStart;
    public static ActionBasedController rightHand;
    public ActionBasedController rightHandStart;

    private void Awake()
    {
        leftHand = leftHandStart;
        rightHand = rightHandStart;
    }

    public static bool GetInput(UnityEngine.XR.XRNode node, UnityEngine.XR.InputFeatureUsage<bool> usage)
    {
        var devices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(node, devices);

        if (devices.Count > 0)
        {
            UnityEngine.XR.InputDevice device = devices[0];

            bool pressed;
            if(device.TryGetFeatureValue(usage, out pressed) && pressed)
            {
                return true;
            }
        }

        return false;
    }

    public static float GetInput(UnityEngine.XR.XRNode node, UnityEngine.XR.InputFeatureUsage<float> usage)
    {
        var devices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(node, devices);

        if (devices.Count > 0)
        {
            UnityEngine.XR.InputDevice device = devices[0];

            float val;
            if (device.TryGetFeatureValue(usage, out val))
            {
                return val;
            }
        }

        return 0;
    }
}
