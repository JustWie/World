using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World;

public class Main : MonoBehaviour
{
    private Boss _boss;
    private Player _player;
    private GameObject _go;
    private UI _ui;

    private void Awake()
    {
        Lib.Load();
        _boss = new Boss();
        _boss.Init("Entity");
        _player = new Player();
        _player.Init("Entity");
        _ui = new UI();
        _ui.Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        _go = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (_go)
        {
            float ver = Input.GetAxis("Vertical") * 3;
            float hor = Input.GetAxis("Horizontal") * 3;

            ver *= Time.deltaTime;
            hor *= Time.deltaTime;

            _go.transform.Translate(hor, 0, ver);

        }
    }

    private void OnApplicationQuit()
    {
        Lib.Save();
    }
}
