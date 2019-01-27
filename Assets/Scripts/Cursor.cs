using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ19
{
    public class Cursor : MonoBehaviour
    {
        RectTransform rectTransform;

        Vector3 startingPosition;
        Vector3 parkingPosition;

        bool isActive = false;
        public bool IsActive { get { return isActive; } }

        int currentPosition;
        int nextPosDelta = 0;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            startingPosition = rectTransform.position;

            parkingPosition = startingPosition + Vector3.up * 1000;

            currentPosition = 0;
        }

        private void Update()
        {
            
            if (isActive)
            {
                nextPosDelta = 0;

                if (Input.GetButtonDown("Horizontal"))
                {
                    if (Input.GetAxis("Horizontal") > 0f)
                    {
                        nextPosDelta = 1;
                    }
                    else
                    {
                        nextPosDelta = -1;
                    }
                }
                else if (Input.GetButtonDown("Vertical"))
                {
                    if (Input.GetAxis("Vertical") > 0f)
                    {
                        nextPosDelta = 3;
                    }
                    else
                    {
                        nextPosDelta = -3;
                    }
                }
                else if (Input.GetButtonDown("Jump"))
                {
                    UIItemList.I.Select(currentPosition);
                }

                if (nextPosDelta != 0)
                {
                    var pos = UIItemList.I.GetItemPosition(currentPosition + nextPosDelta);
                    if (pos != null)
                    {
                        currentPosition += nextPosDelta;
                        rectTransform.position = pos.position;
                    }
                }
            }
        }

        public void Show()
        {
            rectTransform.position = startingPosition;
            currentPosition = 0;
        }

        public void Hide()
        {
            rectTransform.position = parkingPosition;
            isActive = false;
        }

        public void SetActive()
        {
            isActive = true;
        }

    }

}

