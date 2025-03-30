using UnityEngine;

public class SwordControl : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Ground"))
        {
            var swordRigidbody = gameObject.GetComponent<Rigidbody>();
            swordRigidbody.isKinematic = true; 
        }
    }
}
