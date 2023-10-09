using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHand : MonoBehaviour
{
    Animator animator;
    [SerializeField] bool isRight;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float grip;
        float trigger;
        if (isRight)
        {
            grip = VRInput.GetInput(UnityEngine.XR.XRNode.RightHand, UnityEngine.XR.CommonUsages.grip);
            trigger = VRInput.GetInput(UnityEngine.XR.XRNode.RightHand, UnityEngine.XR.CommonUsages.trigger);
        }
        else
        {
            grip = VRInput.GetInput(UnityEngine.XR.XRNode.LeftHand, UnityEngine.XR.CommonUsages.grip);
            trigger = VRInput.GetInput(UnityEngine.XR.XRNode.LeftHand, UnityEngine.XR.CommonUsages.trigger);
        }

        animator.SetFloat("Pinch", trigger);
        animator.SetFloat("Flex", grip);
    }
}
