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

        public Transform player;

        public void StartFollowing(Transform target)
        {
            StartCoroutine(StartFollowingCO(target));
        }

        public IEnumerator StartFollowingCO(Transform target)
        {

            float t = 0f;
            Vector3 startingPos = vCamera.transform.position;

            vCamera.m_Follow = null;   

            while ((vCamera.transform.position - target.position).sqrMagnitude > 0.001f)
            {
                vCamera.transform.position = Vector3.Lerp(startingPos, target.position, t);
                t += Time.deltaTime;
                yield return null;
            }

            vCamera.m_Follow = target;

        }

        public void Reset()
        {
            StartFollowing(player);
            ZoomOut();
        }

        public void ZoomIn()
        {
            StartCoroutine(ZoomInCO());
        }

        public IEnumerator ZoomInCO()
        {
            float t = 0f;

            while (vCamera.m_Lens.OrthographicSize > zoomInSize)
            {
                vCamera.m_Lens.OrthographicSize = Mathf.Lerp(zoomOutSize, zoomInSize, t);
                t += Time.deltaTime;
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
            float t = 0f;

            while (vCamera.m_Lens.OrthographicSize < zoomOutSize)
            {
                vCamera.m_Lens.OrthographicSize = Mathf.Lerp(zoomInSize, zoomOutSize, t);
                t += Time.deltaTime;
                yield return null;
            }

            vCamera.m_Lens.OrthographicSize = zoomOutSize;
        }
    }

}
