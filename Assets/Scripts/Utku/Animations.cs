using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator anim;

    public bool isAttackingPublic
    {
        get
        {
            return isAttack;
        }
    }

    private bool isAttack;
    public float animWeight = 1;
    public int animLayerIndex = 2;

    public void JumpAnim()
    {
        isAttack = false;
        anim.SetLayerWeight(animLayerIndex, 0);
        //anim.SetTrigger("TriggerUP");
        anim.Play("Air Flip",0,0);
    }

    public void PunchAnim()
    {
        isAttack = true;
        anim.SetLayerWeight(animLayerIndex, 1);
        //anim.SetTrigger("TriggerPunch");
        //anim.Play("Punch",0,0);
        anim.Play("Sword Swing",1,0);
    }

    public void ResetWeight()
    {
        isAttack = false;
        anim.SetLayerWeight(animLayerIndex, animWeight);
    }
}
