using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator anim;
    public bool isAttack;
    public float animWeight = 1;
    public int animLayerIndex = 2;

    public void JumpAnim()
    {
        isAttack = false;
        anim.SetLayerWeight(animLayerIndex, 0);
        anim.SetTrigger("TriggerUP");
        print("jump");
    }

    public void PunchAnim()
    {
        isAttack = true;
        anim.SetLayerWeight(animLayerIndex, 0);
        anim.SetTrigger("TriggerPunch");
        print("punch");
    }

    public void ResetWeight()
    {
        isAttack = false;
        anim.SetLayerWeight(animLayerIndex, animWeight);
    }
}
