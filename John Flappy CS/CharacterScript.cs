using UnityEngine;
using UnityEngine.Animations;
public class CharacterScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody2D;
    public float flyStrength;
    public LogicScript logic;
    public bool life = true;
    private Animator animator;
    public float fall = -18;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicScript>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && life==true)
        {
            myRigidBody2D.linearVelocity = Vector3.up * flyStrength;
            animator.SetTrigger("jump");
        }

        if (transform.position.y < fall)
        {
            Debug.Log("out of bounds");
            logic.gameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("isDead", true);
        logic.gameOver();
        life = false;
    }
}
