using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

//  https://tools.wwwtyro.net/space-3d/index.html#animationSpeed=0&fov=80&nebulae=true&pointStars=true&resolution=4096&seed=31es78l5m7q0&stars=true&sun=true    3dspace
//  https://sneakydaggergames.medium.com/vr-in-unity-managing-controller-input-and-hand-presence-part-1-controller-set-up-792682dd024d   getcontrollerinfo
//  https://www.youtube.com/watch?v=wwInYfwD7q0&list=PLQMQNmwN3Fvx2d7uNxMkVOs1aUV-vxrlf&index=9&ab_channel=DilmerValecillos UI stuff in here

public class ControllerControl : MonoBehaviour
{
    //  Controller scripts
    [SerializeField] private HandController s_handControllerR;
    [SerializeField] private HandController s_handControllerL;
    
    //  Right hand controller
    private InputDevice rightController;
    [SerializeField] private Vector2 rightJoystickVector;
    [SerializeField] private float rightGripF;
    [SerializeField] private bool rightGripB;
    [SerializeField] private float rightTriggerF;
    [SerializeField] private bool rightTriggerB;

    //  Left hand controller
    private InputDevice leftController;
    [SerializeField] private Vector2 leftJoystickVector;
    [SerializeField] private float leftGripF;
    [SerializeField] private bool leftGripB;
    [SerializeField] private float leftTriggerF;
    [SerializeField] private bool leftTriggerB;

    private void Start()
    {
        //  Setting up controllers and get scripts
        s_handControllerR = GameObject.Find("RightHand Controller").GetComponent<HandController>();
        s_handControllerL = GameObject.Find("LeftHand Controller").GetComponent<HandController>();
        SetupRightController();
        SetupLeftController();
    }

    // Update is called once per frame
    void Update()
    {
        getRightJoystickValue();
        getLeftJoystickValue();

        getRightGripValue();
        getLefttGripValue();

        getRightTriggerValue();
        getLeftTriggerValue();
    }

    //  Trigger value from controllers
    #region Trigger value from controllers
    private void getRightTriggerValue()
    {
        rightController.TryGetFeatureValue(CommonUsages.trigger, out float righttriggerValue);
        rightTriggerF = righttriggerValue;
        if (rightTriggerF > 0.8f)
        {
            rightTriggerB = true;
            s_handControllerR.setTrigger(true);
        }
        else
        {
            rightTriggerB = false;
            s_handControllerR.setTrigger(false);
        }
    }
    private void getLeftTriggerValue()
    {
        leftController.TryGetFeatureValue(CommonUsages.trigger, out float lefttriggerValue);
        leftTriggerF = lefttriggerValue;
        if (leftTriggerF > 0.8f)
        {
            leftTriggerB = true;
            s_handControllerL.setTrigger(true);
        }
        else
        {
            leftTriggerB = false;
            s_handControllerL.setTrigger(false);
        }
    }
    #endregion

    //  Grip value from controllers
    #region Grip value from controllers
    private void getRightGripValue()
    {
        rightController.TryGetFeatureValue(CommonUsages.grip, out float rightgripValue);
        rightGripF = rightgripValue;
        if (rightGripF > 0.8f)
        {
            rightGripB = true;
            s_handControllerR.setGrip(true);
        }
        else
        {
            rightGripB = false;
            s_handControllerR.setGrip(false);
        }
    }
    private void getLefttGripValue()
    {
        leftController.TryGetFeatureValue(CommonUsages.grip, out float leftgripValue);
        leftGripF = leftgripValue;
        if (leftGripF > 0.8f)
        {
            leftGripB = true;
            s_handControllerL.setGrip(true);
        }
        else
        {
            leftGripB = false;
            s_handControllerL.setGrip(false);
        }
    }
    #endregion

    //  Joystick value from controllers
    #region Joystick value from controllers
    private void getRightJoystickValue()
    {
        rightController.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValueRight);
        rightJoystickVector = primary2DAxisValueRight;
    }
    private void getLeftJoystickValue()
    {
        leftController.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValueLeft);
        leftJoystickVector = primary2DAxisValueLeft;
    }
    #endregion

    //  Setup controllers
    #region Setup controllers
    private void SetupRightController()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristic = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristic, devices);
        if (devices.Count > 0)
        {
            rightController = devices[0];
        }
        else
        {
            Debug.Log("ERROR: Right hand controller setup fail.");
        }
    }
    private void SetupLeftController()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics leftControllerCharacteristic = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristic, devices);
        if (devices.Count > 0)
        {
            leftController = devices[0];
        }
        else
        {
            Debug.Log("ERROR: Left hand controller setup fail.");
        }
    }
    #endregion

}
