using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator anim;
    public bool isAttack;
    public float animWeight;
    public int animLayerIndex = 2;

    public void JumpAnim()
    {
        anim.SetLayerWeight(animLayerIndex, 0);
        anim.SetTrigger("TriggerUP");
        print("jump");
    }

    public void PunchAnim()
    {
        anim.SetLayerWeight(animLayerIndex, animWeight);
        anim.SetTrigger("TriggerPunch");

        //anim.SetTrigger("TriggerRun");
        print("punch");
    }

    public void ResetWeight()
    {
        anim.SetLayerWeight(animLayerIndex, animWeight);
    }
}
