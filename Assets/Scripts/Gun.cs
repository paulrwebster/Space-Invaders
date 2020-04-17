using System;
using System.Collections;
 using UnityEngine;

public class Gun : MonoBehaviour
{


    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float joystickMoveSpeed = 3f;
    [SerializeField] float padding = 1f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject touchLinePrefab;
    [SerializeField] float bulletSpeed = 15f;
    [SerializeField] float bulletPadding = 0.4f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] AudioClip explodeSound;

    GameObject bulletInstance;
    GameObject touchLineInstance;
    GameObject line;
    public Joystick joystick;

    AudioSource myAudioSource;


    float xMin, xMax;


    
    public bool alreadyPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        //for mobiles
        //Screen.orientation = ScreenOrientation.LandscapeLeft;
        SetUpMoveBoundaries();
        myAudioSource = GetComponent<AudioSource>();
        // InvokeRepeating("PlayInvaderSounds", 1.0f, 1.0f);
        line = GameObject.FindWithTag("Line");

    }

    // Update is called once per frame
    void Update()
    {

        Move();

        if (Input.GetButtonDown("Fire1"))
        {
            
            Fire();
        }
        else
        {
            SlideyTouch();
        }

    }

    



    public void Fire()
    {

        if (GameObject.FindWithTag("Bullet") is null)
        {
            //myAudioSource.PlayOneShot(shootSound);
            SoundManager.Instance.Play(shootSound);
            bulletInstance =
            Instantiate(bulletPrefab, transform.position + new Vector3(0, bulletPadding, 0), Quaternion.identity)
            as GameObject;
            bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
        }
    }



    private void Move()
    {
        //deltaTime is the completion time in seconds since the last frame.So if it takes twice as long, we multiply 
        //to double the distance moved
        //GetAxis is set up in Edit- Project settings input. It is between  +1 and -1
        var joystickDeltaX = joystick.Horizontal * Time.deltaTime * joystickMoveSpeed;
        var deltaX = (Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed) + joystickDeltaX;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        transform.position = new Vector2(newXPos, transform.position.y);
    }
    //    private void TappyFire()
    //{
    //    if (Input.touchCount > 1)
    //    {
    //        Fire();
    //    }
    //}
    
      private void SlideyTouch()
    { 
        

        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            Vector3 spritePosition = transform.position;
            //got to swipe below the line top miss the dsshoor buttons
            if(touchPosition.y > line.transform.position.y) { return; }
            Debug.Log("touchPosition.y: " + touchPosition.y);
            Debug.Log("line.transform.position.y: " + line.transform.position.y);
            float deltaX;
            if (touchPosition.x > spritePosition.x)
            {
                deltaX = (1 * Time.deltaTime * moveSpeed);
            }
            else if (touchPosition.x < spritePosition.x)
            {
                deltaX = (-1 * Time.deltaTime * moveSpeed);
            }
            else
            {
                deltaX = 0;
            }
            var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
            transform.position = new Vector2(newXPos, transform.position.y);
            if (GameObject.FindWithTag("TouchLine") is null)
            {
                touchLineInstance =
                Instantiate(touchLinePrefab, touchPosition, Quaternion.identity)
                as GameObject;
            }
            else
            {
                touchLineInstance.transform.position = touchPosition;
            }


        }
        else
        {
            if (GameObject.FindWithTag("TouchLine") != null)
            {
                Destroy(touchLineInstance.gameObject);
            }
        } 
    }
    
    
        

        private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }

    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Invader" || collision.tag == "Bomb")
        {
            SoundManager.Instance.Play(explodeSound);
            Destroy(collision.gameObject);
            //Destroy(this.gameObject);
            this.enabled = false;
            FindObjectOfType<GameStatus>().StartCoroutine("LoseLife");
        }
    }

    public void EnableGun(bool enabled)
    {
        this.enabled = enabled;
    }

}
