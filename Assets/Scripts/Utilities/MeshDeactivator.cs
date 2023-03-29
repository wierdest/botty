using UnityEngine;

public class MeshDeactivator : MonoBehaviour
{
   private void OnEnable()
   {
       gameObject.GetComponent<MeshRenderer>().enabled = false;
   }
}
