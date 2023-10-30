using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerDisplay : MonoBehaviour
{
    [SerializeField] private Camera uiCamera;
    [SerializeField] private RectTransform pointerRectTransform;
    [SerializeField] private GameObject pointerObject;

    private List <HivePointer> hivePointerList = new List<HivePointer>();

    private void Update()
    {
        foreach (HivePointer pointer in hivePointerList)
        {
            pointer.UpdatePointer();
        }
    }


    public HivePointer createPointer(Vector3 targetPosition)
    {
        GameObject pointerGameObject = Instantiate(transform.Find("PointerTemplate").gameObject);
        pointerGameObject.SetActive(true);

        pointerGameObject.transform.SetParent(transform, false);
        HivePointer hivePointer = new HivePointer(targetPosition, pointerGameObject, uiCamera);

        hivePointerList.Add(hivePointer);
        return hivePointer;
    }

    public class HivePointer
    {
        private float border = 15f;


        private Vector3 targetPosition;
        private GameObject pointerGameObject;
        private Camera uiCamera;

        private RectTransform pointerRectTransform;

        public HivePointer(Vector3 targetPosition, GameObject pointerGameObject, Camera uiCamera)
        {
            this.targetPosition = targetPosition;
            this.pointerGameObject = pointerGameObject;
            this.uiCamera = uiCamera;

            pointerRectTransform = pointerGameObject.GetComponent<RectTransform>();
        }

        public void UpdatePointer()
        {
            //Math to find the normalized firection (Target - Origin)
            Vector3 toPosition = targetPosition;
            Vector3 origin = Camera.main.transform.position;
            origin.z = 0;

            //Get the direction of the pointer
            Vector3 direction = (toPosition - origin).normalized;

            float angleRadians = Mathf.Atan2(direction.y, direction.x);
            // Convert radians to degrees.
            float angleDegrees = angleRadians * Mathf.Rad2Deg;

            //Set the angle of the pointer
            pointerRectTransform.localEulerAngles = new Vector3(0, 0, angleDegrees);

            Vector3 targetScreenPos = Camera.main.WorldToScreenPoint(targetPosition);
            if (isOffScreen(targetScreenPos))
            {
                Vector3 pointerWorldPos = uiCamera.ScreenToWorldPoint(getCappedPosition(targetScreenPos));
                pointerRectTransform.position = pointerWorldPos;
                pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, 0f);
            }
            else
            {
                Vector3 pointerWorldPos = uiCamera.ScreenToWorldPoint(getCappedPosition(targetScreenPos));
                pointerRectTransform.position = pointerWorldPos;
                pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, 0f);
            }
        }

        private bool isOffScreen(Vector3 position)
        {
            return
                position.x <= border ||
                position.x >= Screen.width - border ||
                position.y <= border ||
                position.y >= Screen.height - border;
        }

        private Vector3 getCappedPosition(Vector3 position)
        {
            Vector3 cappedTargetPos = position;
            cappedTargetPos.x = Mathf.Clamp(cappedTargetPos.x, border, Screen.width - border);
            cappedTargetPos.y = Mathf.Clamp(cappedTargetPos.y, border, Screen.height - border);

            return cappedTargetPos;
        }
    }
}
