using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    public float _timer = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        
    }

}
