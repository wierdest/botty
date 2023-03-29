using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace StarterAssets
{
    public class GrabFollower : MonoBehaviour
    {
        [SerializeField] private GameObject destination;
        [SerializeField] private float distanceToStop;
        private readonly string idleParam = "hasArrived";
        private NavMeshAgent agent;
        private CharacterController controller;
        private FirstPersonController fpsController;
        private StarterAssetsInputs inputs;
        [SerializeField] private Animator animator;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            controller = GetComponent<CharacterController>();
            fpsController = GetComponent<FirstPersonController>();
            inputs = GetComponent<StarterAssetsInputs>();
            if(distanceToStop == 0.0f)
            {
                distanceToStop = 0.5f;
            }
        }

        private void Update()
        {
            destination = Grabber.Instance.Target;
            if(destination == null)
            {
                controller.enabled = true;
                fpsController.enabled = true;
                agent.enabled = false;
                if(!inputs.isViewChanged && animator != null && !animator.GetBool(idleParam))
                {
                    animator.SetBool(idleParam, true);
                }
                return;
            }
            if(!agent.enabled)
            {
                agent.enabled = true;
            }

            if(Vector3.Distance(agent.transform.position, destination.transform.position) <= distanceToStop)
            {
                agent.isStopped = true;
                if(animator != null)
                {
                    animator.SetBool(idleParam, true);
                }
                
            }
            else
            {
                agent.SetDestination(destination.transform.position);
                agent.isStopped = false;
                controller.enabled = false;
                fpsController.enabled = false;
                if(animator != null)
                {
                    if(animator.GetBool(idleParam))
                    {
                        animator.SetBool(idleParam, false);
                    }
                }
            }
        }
    }


}
