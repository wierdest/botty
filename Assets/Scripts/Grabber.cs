using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarterAssets
{
    public class Grabber : MonoBehaviour
    {
        public static Grabber Instance;
        [SerializeField] private StarterAssetsInputs input;
        [SerializeField] private float dragSpeed = 2.0f;
        public GameObject Target;
        private Vector3 offset, worldToScreenPos, currentScreenPosition, originalWorldPosition;
        private bool dragging;
        
        private void Awake()
        {
            if(Instance)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            if(input.grab)
            {
                RaycastHit hit;
                getClickedObject(out hit);
                if(Target)
                {
                    originalWorldPosition = Target.transform.position;
                    worldToScreenPos = Camera.main.WorldToScreenPoint(originalWorldPosition);
                    updateCurrentScreenPosition();
                    offset = originalWorldPosition - Camera.main.ScreenToWorldPoint(currentScreenPosition);
                    dragging = true;
                }
            }
           
            if(input.letGo && Target != null)
            {
                Target = null;
            }
        }

        public void FixedUpdate()
        {
            if(dragSpeed > 0f && Target && dragging)
            {
                updateCurrentScreenPosition();
                Target.transform.position = Vector3.MoveTowards(Target.transform.position, Camera.main.ScreenToWorldPoint(currentScreenPosition) + offset, dragSpeed * Time.deltaTime);
                // Target.transform.position = Camera.main.ScreenToWorldPoint(currentScreenPosition) + offset;
                // Debug.LogFormat("Position {0}", Target.transform.position);
            }
        }


        private void updateCurrentScreenPosition()
        {
            currentScreenPosition.x = input.mousePosition.x;
            currentScreenPosition.y = input.mousePosition.y;
            currentScreenPosition.z = worldToScreenPos.z;
        }

        private void getClickedObject(out RaycastHit hit)
        {
            Ray ray = Camera.main.ScreenPointToRay(input.mousePosition);
            if(Physics.Raycast(ray.origin, ray.direction * 2, out hit))
            {
                if(hit.collider.gameObject.tag == "Movable")
                {
                    Target = hit.collider.gameObject;
                }
                else
                {
                    Target = null;
                    dragging = false;
                }
            }
            
        }
    }
}
    

