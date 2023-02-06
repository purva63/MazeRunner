using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class cannon : MonoBehaviour
{
    public GameObject cannonball;
    public float cannonballSpeed = 20;
    public Transform pof;
    public Transform barrel;
    public float scrollIncrements = 10;
    private Animator animation_controller;
    private CharacterController character_controller;
    public Vector3 movement_direction;
    public float velocity;
    public float walking_velocity;
    public float health;
    public float maxHealth;
    public HealthBar healthBar;
    public AudioClip cannonballShoot;
    private AudioSource source;
    public AudioClip safeZoneEntry;
    public AudioClip grenadeSound;
    public AudioClip hitQuestionSound;
    public AudioClip endGameSound;
    public AudioClip overallGameSound;
    public List<GameObject> listGrenades = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        animation_controller = GetComponent<Animator>();
        character_controller = GetComponent<CharacterController>();
        movement_direction = new Vector3(0f, 0f, 0f);
        velocity = 0.0f;
        walking_velocity = 2f;
        health = 5f;
        maxHealth = 5f;
        source = GameObject.Find("Small_Cannon").AddComponent<AudioSource>();
        source.PlayOneShot(overallGameSound);
    }

    // Update is called once per frame
    void Update()
    {
        float rotateCannon = Input.GetAxis("Mouse X");
        transform.Rotate(0, rotateCannon, 0);
        barrel.Rotate(Input.mouseScrollDelta.y * scrollIncrements, 0, 0);

        if (Input.GetButtonDown("Fire1")){
            FireCannonball();
            source.PlayOneShot(cannonballShoot);
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            animation_controller.SetBool("isGoingForward", true);
            animation_controller.SetBool("isGoingBackward", false);
            animation_controller.SetBool("NoKey", false);

            if (velocity < 0.0f)
            {
                velocity = 0.0f;
            }
            velocity += 0.1f;
            velocity = Mathf.Min(velocity, walking_velocity / 2.0f);
            transform.Translate(Vector3.forward * velocity * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            animation_controller.SetBool("isGoingForward", false);
            animation_controller.SetBool("isGoingBackward", true);
            animation_controller.SetBool("NoKey", false);

            if (velocity > 0.0f)
            {
                velocity = 0.0f;
            }
            velocity -= 0.1f;
            velocity = Mathf.Max(velocity, -1.0f * walking_velocity / 2.0f);
            transform.Translate(Vector3.forward * velocity * Time.deltaTime);
        }
        else
        {

            velocity = 0.0f;

            animation_controller.SetBool("isGoingForward", false);
            animation_controller.SetBool("isGoingBackward", false);
            animation_controller.SetBool("NoKey", false);
            transform.Translate(new Vector3(0, 0, 0) * velocity * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0.0f, -0.6f, 0.0f));
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0.0f, 0.6f, 0.0f));
        }

        if (health <= 1.0f)
        {
            MazeR.completed = false;
            SceneManager.LoadScene("Outro", LoadSceneMode.Single);
        }


    }
    void FireCannonball(){
        GameObject ball = Instantiate(cannonball, pof.position, Quaternion.identity);
        Rigidbody rb = ball.AddComponent<Rigidbody>();
        rb.velocity = cannonballSpeed * pof.forward;
        StartCoroutine(RemoveCannonball(ball));
    }

    IEnumerator RemoveCannonball(GameObject ball) {
        yield return new WaitForSeconds(1f);
        Destroy(ball);
    }

    public void IncreaseHealth()
    {
        Debug.Log(health);
        if (health <= maxHealth)
        {
            health += 0.5f;
            healthBar.UpdateHealthBar();
        }

    }

    public void TakeDamage()
    {
        if (health == 0.0f)
        {
            MazeR.completed = false;
            SceneManager.LoadScene("Outro", LoadSceneMode.Single);
        }
        else
        {
            health -= health / 4f;
            healthBar.UpdateHealthBar();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "SafeZone")
        {
            Debug.Log("Cannon in safezone");
            IncreaseHealth();
            source.PlayOneShot(safeZoneEntry);
        }
        if (collision.gameObject.name == "Grenade")
        {
            GameObject temp = collision.gameObject;
            Debug.Log("Cannon hit Grenade");
            TakeDamage();
            Destroy(temp);
            source.PlayOneShot(grenadeSound);
            listGrenades.Remove(temp); 
        }
    }

}
