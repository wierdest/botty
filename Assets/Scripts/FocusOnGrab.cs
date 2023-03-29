using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarterAssets
{
    public class FocusOnGrab : MonoBehaviour
    {
        private void Update()
        {
            if(Grabber.Instance.Target != null)
            {
                transform.LookAt(Grabber.Instance.Target.transform);
            }
            
        }
    }

}

