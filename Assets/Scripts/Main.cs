using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World;

public class Main : MonoBehaviour
{
    private Boss m_boss;
    private Player m_player;
    private UI m_ui;
    private CameraCtrl m_cameraCtrl;

    private void Awake()
    {
        DataMgr.RegisterLoad();
        m_boss = new Boss();
        m_boss.Init("Entity");
        m_player = new Player();
        m_player.Init("Entity");
        m_ui = new UI();
        m_ui.Init();
        m_cameraCtrl = new CameraCtrl();
        m_cameraCtrl.Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_cameraCtrl.SetTarget(m_player.GetObject().transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                m_player.MoveTo(hit.point);
            }
        }
    }

    private void LateUpdate()
    {
        m_cameraCtrl.UpdatePosition();
    }

    private void OnApplicationQuit()
    {
        DataMgr.RegisterSave();
    }
}
