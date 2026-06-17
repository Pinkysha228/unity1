using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float speed = 5f;
    public float jumpVolume = 8f;
    public int coins;
    public int hp = 100;
    public int maxHp = 100;
    public UIHealthText uiHealth;
    [SerializeField] Animator animator;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (uiHealth != null)
        {
            uiHealth.UpdateHealthText(hp, maxHp);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Border"))
        {
            coins = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _rb.linearVelocity = new Vector2(-speed, _rb.linearVelocity.y);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _rb.linearVelocity = new Vector2(speed, _rb.linearVelocity.y);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            _rb.linearVelocity = new Vector2(0, _rb.linearVelocity.y);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector2.up * jumpVolume, ForceMode2D.Impulse);
        }

        if (coins == 3)
        {
            Debug.Log("You Win!");
            SceneManager.LoadScene("lvl2");
            coins = 0;
        }
        if (hp <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("you lose");
        }
        uiHealth.UpdateHealthText(hp, maxHp);
        float input =  Input.GetAxis("Horizontal");
        if (input != 0f)
        {
            animator.SetBool("iswalking", true);
            Debug.Log("Walking");
        }
        else {
            animator.SetBool("iswalking", false);}
    }
}
