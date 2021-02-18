using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float firespeed = 5f;
    private Rigidbody2D rig;
    public GameObject Impacteffect;
    public bool isRight;
    public float timedestroy = 1f;

    // Start is called before the first frame update
    void Start()
    {
        isRight = PlayerCtrl.RightFace;
        rig = GetComponent<Rigidbody2D>();
        Vector3 BulletScale = transform.localScale;
        if (isRight)
        {
            rig.velocity = transform.right * firespeed;
            BulletScale.x = 1;
        }
        else
        {
            rig.velocity = transform.right * -firespeed;
            BulletScale.x = -1;
        }
        transform.localScale = BulletScale;
        Destroy(gameObject, timedestroy);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy")){
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(Impacteffect, transform.position, Quaternion.identity);
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);

        }
    }
}
