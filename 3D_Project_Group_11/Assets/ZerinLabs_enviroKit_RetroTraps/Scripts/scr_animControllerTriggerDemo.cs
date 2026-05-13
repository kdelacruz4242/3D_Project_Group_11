/*
 DESCRIPTION:
 ---------------------------------------------------------------------------------------------
 Mini-script used to swap a animation (bool) parameter from one state to another (true/false)
 periodically.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_animControllerTriggerDemo : MonoBehaviour
{
    Animator anim;

    public string param_name = "enabled";
    public bool param_ini_value = true;
    public float param_period = 0f;
    public float param_offset = 0f;

    public AudioSource spikeSound;   // sound to play when spikes move

    private float periodCounter = 0f;

    void Start()
    {
        anim = GetComponent<Animator>();

        if (param_period == 0f)
        {
            param_period = Random.Range(1, 3);
        }

        updateAnimator(param_offset);
    }

    void Update()
    {
        if (Time.time >= periodCounter)
        {
            param_ini_value = swapBool(param_ini_value);

            updateAnimator(0f);

            if (spikeSound != null)
            {
                spikeSound.Play();
            }
        }
    }

    void updateAnimator(float timeOffset)
    {
        anim.SetBool(param_name, param_ini_value);

        periodCounter = Time.time + param_period + timeOffset;
    }

    bool swapBool(bool boolVal)
    {
        return !boolVal;
    }
}