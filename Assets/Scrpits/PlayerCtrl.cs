
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [Header("Movement")]
    public float MovementSpeed = 10f;
    private Rigidbody2D RigCharacter;
    public float JumpForce = 10f;
    public bool IsJumping;
    public float JumpingFactor = 0.5f;

    [Header("Sprite")]
    public bool RightFace = true;


    // Start is called before the first frame update
    private void Start()
    {
        RigCharacter = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        SpriteRenderer();
        Move();
        Jump();
    }
    private void Move()
    {
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += Movement * Time.deltaTime * MovementSpeed;
        if (IsJumping == true) {
            transform.position -= Movement * Time.deltaTime * MovementSpeed * JumpingFactor;
        }
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && !IsJumping)
        {
            RigCharacter.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            IsJumping = true;
        }
    }
    void SpriteRenderer() {
        Vector3 CharacterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") > 0)
        {
            RightFace = true;
            CharacterScale.x = 1;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            RightFace = false;
            CharacterScale.x = -1;
        }
        transform.localScale = CharacterScale;
    }
    void OnCollisionEnter2D(Collision2D other) {
        /* Logica para o pulo - Verifica se o outro gameobject esta na tag ground, se sim, o isjumping é nulo */
        if (other.gameObject.CompareTag("Ground")) {
            IsJumping = false;
        }
    }
}   
