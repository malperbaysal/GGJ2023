using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator anim;
    public int animSelector = 1;
    public bool isAttackingPublic
    {
        get
        {
            return isAttack;
        }
    }
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

    private bool isAttack;
    private bool isAttackUp;
    private bool isAttackDown;
    public float animWeight = 1;
    public int animLayerIndex = 2;

    public void JumpAnim()
    {
        isAttack = true;
        isAttackUp = true;
        isAttackDown = false;
       //anim.SetLayerWeight(animLayerIndex, 0);
        anim.CrossFade("Air Flip",0.1f,0,0.07f);

        anim.SetLayerWeight(animLayerIndex, 1);

        animSelector += 1;
        if (animSelector % 2 == 0)
        {
            anim.CrossFade("Sword Swing", 0.1f, 1, 0.37f);
        }
        else
        {
            anim.CrossFade("Sword Swing left", 0.1f, 1, 0.37f);
        }
    }

    public void PunchAnim()
    {
        isAttack = true;
        isAttackUp = false;
        isAttackDown = true;
        anim.SetLayerWeight(animLayerIndex, 1);

        animSelector += 1;
        if (animSelector % 2 == 0)
        {
            anim.CrossFade("Sword Swing", 0.1f, 1, 0.37f);
        }
        else
        {
            anim.CrossFade("Sword Swing left", 0.1f, 1, 0.37f);
        }

    }

    public void ResetWeight()
    {
        isAttack = false;
        isAttackUp = false;
        isAttackDown = false;
        anim.SetLayerWeight(animLayerIndex, animWeight);
    }
}
