using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneShotBehaviour : StateMachineBehaviour
{
    public AudioClip soundToPlay;
    public float volume = 2f; // Âm lượng gấp đôi mức mặc định

    public bool playOnEnter = true;
    public bool playOnExit = false;
    public bool playAfterDelay = false;
    public float playDelay = 0.25f;

    private float timeSinceEntered = 0;
    private bool hasDelayedSoundPlayed = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playOnEnter)
        {
            PlayOneShotSound(animator.gameObject.transform.position);
        }
        timeSinceEntered = 0;
        hasDelayedSoundPlayed = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!hasDelayedSoundPlayed && playAfterDelay)
        {
            timeSinceEntered += Time.deltaTime;

            if (timeSinceEntered > playDelay)
            {
                PlayOneShotSound(animator.gameObject.transform.position);
                hasDelayedSoundPlayed = true;
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playOnExit)
        {
            PlayOneShotSound(animator.gameObject.transform.position);
        }
    }

    // Phát âm thanh một lần tại vị trí cụ thể
    private void PlayOneShotSound(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(soundToPlay, position, volume);
    }
}
