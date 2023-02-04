using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator anim;

    public void JumpAnim()
    {
        anim.ResetTrigger("TriggerPunch");
        anim.SetTrigger("TriggerUp");
    }

    public void PunchAnim()
    {
        anim.ResetTrigger("TriggerUp");
        anim.SetTrigger("TriggerPunch");
    }

}
