using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace World
{
    public class CameraCtrl
    {
        Camera m_camera;
        Transform m_target;
        Vector3 m_targetPos;

        float m_distanceAway;
        float m_distanceUp;
        float m_smooth;

        public void Init()
        {
            m_camera = Camera.main;
            SetParam(3.5f, 3, 2);
        }

        public void SetTarget(Transform transform)
        {
            m_target = transform;
        }

        public void SetParam(float distanceAway, float distanceUp, float smooth)
        {
            m_distanceAway = distanceAway;
            m_distanceUp = distanceUp;
            m_smooth = smooth;
        }

        public void UpdatePosition()
        {
            if (m_target == null)
                return;
            m_targetPos = m_target.position + Vector3.up * m_distanceUp - m_target.forward * m_distanceAway;
            m_camera.transform.position = Vector3.Lerp(m_camera.transform.position, m_targetPos, Time.deltaTime * m_smooth);
            m_camera.transform.LookAt(m_target);
        }
    }
}
