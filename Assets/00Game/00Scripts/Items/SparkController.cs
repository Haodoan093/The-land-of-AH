using UnityEngine;

public class SparkController : MonoBehaviour
{
  
    Animator animator;
    public float timerMax = 2f;
     float timer = 2f;
    public float timerFireMax = 0f;
     float timerFire = 1f;
    private bool isDisabled = false;

    private void Awake()
    {
        animator = this.GetComponentInChildren<Animator>();
    }

   

    void OnDisable()
    {
        // Khi đối tượng bị tắt, đánh dấu nó đã bị tắt.
        isDisabled = true;
        timer = timerMax;
        timerFire=timerFireMax;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timerFire -= Time.deltaTime;
        if (timer < 0)
        {
            gameObject.SetActive(false);
        }
        if (timerFire < 0)
        {
            animator.SetTrigger(AnimationStrings.hitTrigger);
        }
    }
}
