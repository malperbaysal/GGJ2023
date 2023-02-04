using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator anim;

    public void JumpAnim()
    {
        //anim.ResetTrigger("TriggerUP");
        anim.SetTrigger("TriggerUP");
        print("jump");
    }

    public void PunchAnim()
    {

        //anim.ResetTrigger("TriggerPunch");
        anim.SetTrigger("TriggerPunch");
        print("punch");
    }

}
