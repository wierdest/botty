using UnityEngine;

public class Hover : MonoBehaviour
{

    [SerializeField] private float height, speed, waveCut, maxSpikeTime;
    private Vector3 hover;
    private float reverse = -1.0f, originalSpeed;
    public bool Spike;

    private void Start()
    {
        originalSpeed = speed;

    }

    private void OnEnable()
    {
        hover = transform.position;
        hover.y += height;
        maxSpikeTime = Random.Range(0.3f, 0.8f);
    }
    private void FixedUpdate()
    {
        
        if(Vector3.Distance(transform.position, hover) <= waveCut)
        {
            // reverse direction
            height *= reverse;
            hover.y += height;
        }
        if(Spike)
        {
            
            speed += 0.02f;
            if(Vector3.Distance(transform.position, hover) <= 0.2f)
            {
                Spike = false;
                speed = originalSpeed;
            }
            
        }

        transform.position = Vector3.MoveTowards(transform.position, hover, speed * Time.deltaTime);
    
    }

    
}
