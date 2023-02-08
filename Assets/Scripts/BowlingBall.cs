using UnityEngine;
using UnityEngine.Serialization;

public class BowlingBall : MonoBehaviour
{
    [FormerlySerializedAs("audioSource")] [SerializeField] private AudioSource collisionAudioSource;
    [SerializeField] private AudioSource rollingAudioSource;
    private Rigidbody ballRigidbody;
    private float speed;
    public float maxForce = 3;
    void OnCollisionEnter(Collision collision)
    {
        float force = collision.relativeVelocity.magnitude;
        float volume = 1;
        if (force <= maxForce)
        {
            volume = force / maxForce;
        }

        if(collision.gameObject.CompareTag("Ground") ||
           collision.gameObject.CompareTag("BowlingBall")) collisionAudioSource.PlayOneShot(collisionAudioSource.clip, volume);
    }
    
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody>();
    }
 
    void FixedUpdate()
    {
        speed = ballRigidbody.velocity.magnitude;
    }
 
    void OnCollisionStay(Collision collision)
    {
        if (!rollingAudioSource.isPlaying && speed >= 0.1f && collision.gameObject.CompareTag("Ground"))
        {
            rollingAudioSource.volume = speed;
            rollingAudioSource.Play();
        }
        if (rollingAudioSource.isPlaying && speed < 0.1f)
        {
            rollingAudioSource.Pause();
        }
        else if (rollingAudioSource.isPlaying && collision.gameObject.GetComponent<Pin>() != null)
        {
            rollingAudioSource.Pause();
        }
    }
 
    void OnCollisionExit(Collision collision)
    {
        if (rollingAudioSource.isPlaying && collision.gameObject.CompareTag("Ground"))
        {
            rollingAudioSource.Pause();
        }
    }
}

