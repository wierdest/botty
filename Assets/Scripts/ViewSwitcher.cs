using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace StarterAssets {
    
    public class ViewSwitcher : MonoBehaviour
    {
        
        [SerializeField] private GameObject playerFollowCamera, clearShotCamera, player;
        // private NavMeshAgent agent;
        private StarterAssetsInputs inputs;

        private void Awake()
        {
            // agent = player.GetComponent<NavMeshAgent>();
            inputs = player.GetComponent<StarterAssetsInputs>();

        }

        private void Update()
        {
            if(inputs.changeView)
            {
                playerFollowCamera.SetActive(!playerFollowCamera.activeInHierarchy);
                clearShotCamera.SetActive(!clearShotCamera.activeInHierarchy);
                inputs.cursorInputForLook = !inputs.cursorInputForLook;
                inputs.LockCursor(!inputs.cursorLocked);
                // agent.enabled = !agent.enabled;
                // consume the click
                inputs.changeView = false;
            }
        }

    }
}
