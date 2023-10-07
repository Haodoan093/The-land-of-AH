using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject ends;
    [SerializeField] PlayerController _player;
    public PlayerController Player => _player;

    public int monster_limit = 0;
    public int killed = 0;
    public int boss_limit = 1;
    public int boss_killed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
