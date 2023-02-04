using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator anim;

    public bool isAttackingUpPublic
    {
        get
        {
            return isAttackUp;
        }
    }
    public bool isAttackingDownPublic
    {
        get
        {
            return isAttackDown;
        }
    }

    private bool isAttackUp;
    private bool isAttackDown;
    public float animWeight = 1;
    public int animLayerIndex = 2;

    public void JumpAnim()
    {
        isAttackUp = true;
        isAttackDown = false;
        anim.SetLayerWeight(animLayerIndex, 0);
        anim.CrossFade("Air Flip",0.1f,0,0.07f);
    }

    public void PunchAnim()
    {
        isAttackUp = false;
        isAttackDown = true;
        anim.SetLayerWeight(animLayerIndex, 1);       
        anim.CrossFade("Sword Swing",0.1f,1,0.37f);
    }

    public void ResetWeight()
    {
        isAttackUp = false;
        isAttackDown = false;
        anim.SetLayerWeight(animLayerIndex, animWeight);
    }
}
