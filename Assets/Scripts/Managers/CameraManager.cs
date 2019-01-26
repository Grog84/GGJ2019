using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace GGJ19
{
    public class CameraManager : MonoSingleton<CameraManager>
    {
        public CinemachineVirtualCamera vCamera;

        public float zoomInSize = 4.5f;
        public float zoomOutSize = 10f;

        public void StartFollowing(Transform target)
        {
            vCamera.m_Follow = target;
        }

        public void ZoomIn()
        {
            StartCoroutine(ZoomInCO());
        }

        public IEnumerator ZoomInCO()
        {
            float zoom = vCamera.m_Lens.OrthographicSize;

            while (vCamera.m_Lens.OrthographicSize > zoomInSize)
            {
                vCamera.m_Lens.OrthographicSize = Mathf.Lerp(zoomOutSize, zoomInSize, zoom);
                zoom += 0.5f * Time.deltaTime;
                yield return null;
            }

            vCamera.m_Lens.OrthographicSize = zoomInSize;     
        }

        public void ZoomOut()
        {
            StartCoroutine(ZoomOutCO());
        }

        public IEnumerator ZoomOutCO()
        {
            float zoom = vCamera.m_Lens.OrthographicSize;

            while (vCamera.m_Lens.OrthographicSize > zoomInSize)
            {
                vCamera.m_Lens.OrthographicSize = Mathf.Lerp(zoomInSize, zoomOutSize, zoom);
                zoom += 0.5f * Time.deltaTime;
                yield return null;
            }

            vCamera.m_Lens.OrthographicSize = zoomOutSize;
        }
    }

}
