using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float rotateSpeed = 0.5f;
    
    void Update()
    {
        transform.Rotate(new Vector3(0, rotateSpeed, 0));
          
    }
}
