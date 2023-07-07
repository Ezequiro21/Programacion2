using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerControlller : MonoBehaviour
{
    public static event System.Action OnDesplazamientoTerminado;

    public AudioSource helicopterAudioSource;
    public AudioSource planearAudioSource;
    public AudioSource ahhhhAudioSource;

    public BoolValue logro1;
    public BoolValue logro2;
    public BoolValue logro3;
    public BoolValue logro4;
    public GameObject UIlogro1;
    public GameObject UIlogro2;
    public GameObject Premiologro2;
    public GameObject UIlogro3;
    public GameObject UIlogro4;

    public bool isAhhh= false;


    public MessageController messageController;



    public Slider slider;
    public GameObject umbrella;
    public GameObject UIUmbrella;
    public bool IsUmbrella = false;
    public bool Helicopter = false;
    public bool isPlaning = false;

    public TMP_Text heightText;
    public TMP_Text velocityText;
    public TMP_Text wuu;
    public TMP_Text huu;

    GenerarSonidoSalto generarSonido;


    public float umbrellaDuration = 10f;
    private float currentUmbrellaDuration;

    public Rigidbody rb;
    private float originalGravity; // Variable para almacenar la gravedad original
    private float originalDrag;
    public float speed;
    public float forcejump;
    public Animator anim;
    float speedrun;
    bool isjump = false;
    public bool isjumping = false;
    bool floorDetected = false;
    public bool reachedMaxHeight = false;
    public bool groundDetected = false;
    public bool walkingOnWalls = false;
    public float rotationSpeed = 5f;                    
    
    public bool reachedMixHeight = false;

    public ParticleSystem aterrizajeParticles;

    public AudioClip eventRespuestaWuuuu;
    public AudioClip eventRespuestaHuuuu;
    public AudioClip eventRespuestAterrizaje;
    public AudioClip eventRespuestaJumpHook;
    public AudioClip eventRespuestaPlanear;
    public AudioClip eventRespuestaHelicopter;
    public AudioClip eventRespuestaAhhhhh;

    private GameObject caminoCementoObject;


    private void Start()
    {
        originalGravity = Physics.gravity.y; // Guardar el valor original de la gravedad
        originalDrag = rb.drag;
        generarSonido = FindObjectOfType<GenerarSonidoSalto>();

        caminoCementoObject = GameObject.FindGameObjectWithTag("caminoCemento");


        speedrun = 1;
        rb = GetComponent<Rigidbody>();
        aterrizajeParticles = GetComponentInChildren<ParticleSystem>();
        UIUmbrella.SetActive(false);
        umbrella.SetActive(false);
        wuu.gameObject.SetActive(false);
        huu.gameObject.SetActive(false);

        if(logro1.RuntimeValue == true)
        {
            UIlogro1.SetActive(true);
        }
        else
        {
            UIlogro1.SetActive(false);
        }

        if(logro2.RuntimeValue == true)
        {
            UIlogro2.SetActive(true);
            
        }
        else
        {
            UIlogro2.SetActive(false);
        }

        if(logro3.RuntimeValue == true)
        {
            UIlogro3.SetActive(true);
        }
        else
        {
            UIlogro3.SetActive(false);
        }

        if(logro4.RuntimeValue == true)
        {
            UIlogro4.SetActive(true);
            
        
        }
        else
        {
            UIlogro4.SetActive(false);
        }
        

        Premiologro2.SetActive(false);
        
        slider.maxValue = 1;
        

    }

    private void FixedUpdate()
    {
        
    }

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        //Umbrella();//Obtiene el bool de WalkingOnWalls
        if (IsUmbrella)
        {
            currentUmbrellaDuration -= Time.deltaTime;
            if (currentUmbrellaDuration <= 0f)
            {
                // Tiempo del power-up agotado, desactivar el paraguas
                IsUmbrella = false;
                umbrella.SetActive(false);
                UIUmbrella.SetActive(false);
            }
        }
        if (walkingOnWalls)
        {
            Vector3 surfaceNormal = GetSurfaceNormal();
            Physics.gravity = -surfaceNormal * 9.81f;

            // Rotación del personaje en -90 grados en el eje X
            Quaternion targetRotation = Quaternion.Euler(-90f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
        else
        {
            transform.position += transform.forward * vertical * speed * speedrun * Time.deltaTime;
            anim.SetFloat("Vertical", vertical);
            transform.position += transform.right * horizontal * speed * speedrun * Time.deltaTime;
            anim.SetFloat("Horizontal", horizontal);
            Vector3 floor = transform.TransformDirection(Vector3.down); //apunta hacia el suelo
            if (Physics.Raycast(transform.position, floor, 1.03f))
            {
                floorDetected = true;
            }
            else
            {
                floorDetected = false;
            }

            //salto
            isjump = Input.GetButtonDown("Jump");
            
            if (isjump && floorDetected)
            {
                AudioSource audioSource = GetComponent<AudioSource>();
                rb.AddForce(new Vector3(0, forcejump, 0), ForceMode.Impulse);

                //anim.SetTrigger("Jump");

                anim.SetBool("Salte", true);

                audioSource.clip = eventRespuestaJumpHook;
                audioSource.Play();


                isjumping = true;

            }


            if (floorDetected)
            {
                anim.SetBool("Suelo", true);
            }
            else
            {
                anim.SetBool("Suelo", false);
                anim.SetBool("Salte", false);
            }

            if (vertical > 0)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    speedrun = 2;
                    anim.SetBool("Run", true);
                }
                else
                {
                    speedrun = 1;
                    anim.SetBool("Run", false);
                }
            }



        }
        if (rb.velocity.y < -100f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (transform.position.y < -10f && !isAhhh)
        {

            Debug.Log("Ahhhh");
            isAhhh = true;
            ahhhhAudioSource.clip = eventRespuestaAhhhhh;
            ahhhhAudioSource.Play();

        }
    }
   /* void Umbrella()
    {
        Helicopter=true;
        AudioSource audioSource = GetComponent<AudioSource>();
        if(!floorDetected)
        {
            if (Input.GetKeyDown(KeyCode.Q) )
            {
                IsUmbrella = !IsUmbrella;
                if(IsUmbrella)
                {
                    
                    umbrella.SetActive(true);
                    UIUmbrella.SetActive(true);
                    currentUmbrellaDuration = umbrellaDuration; // Reiniciar el tiempo restante al activar el paraguas
                    if(Helicopter)
                    {
                        Physics.gravity = new Vector3(Physics.gravity.x, originalGravity, Physics.gravity.z);
                        rb.drag = originalDrag;
                        helicopterAudioSource.clip = eventRespuestaHelicopter;
                        helicopterAudioSource.Play();
                        Debug.Log("Verdadero");
                    }
                    else
                    {
                        
                        Physics.gravity = new Vector3(Physics.gravity.x, originalGravity / 3f, Physics.gravity.z);
                        rb.drag *= 10f;
                        planearAudioSource.clip = eventRespuestaPlanear;
                        planearAudioSource.Play();
                    }
                }
                else
                {
                    Physics.gravity = new Vector3(Physics.gravity.x, originalGravity, Physics.gravity.z);
                    rb.drag = originalDrag;
                    umbrella.SetActive(false);
                    UIUmbrella.SetActive(false);
                    helicopterAudioSource.Stop(); // Detener el sonido de helicopter
                    planearAudioSource.Stop();
                }
            }
        }
        else
        {
            Physics.gravity = new Vector3(Physics.gravity.x, originalGravity, Physics.gravity.z);
            rb.drag = originalDrag;
            umbrella.SetActive(false);
            UIUmbrella.SetActive(false);
            helicopterAudioSource.Stop(); // Detener el sonido de helicopter
            planearAudioSource.Stop();
        }
        float umbrellaPercentage = currentUmbrellaDuration / umbrellaDuration;
         slider.value = umbrellaPercentage;
    }*/



    void OnTriggerEnter(Collider other)
    {
        //AudioSource audioSource = GetComponent<AudioSource>();
        if (other.gameObject.CompareTag("umbrella"))
        {
            logro1.RuntimeValue = true;
                    UIlogro1.SetActive(true);
                    messageController.ShowMessage("Obsequio de regalo");
                    other.gameObject.SetActive(false);
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (collision.gameObject.CompareTag("SuperSalto"))
        {
            Debug.Log("LLego");
            ActivateJumpEvent();
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("Aterrizó");
            groundDetected= true;
            
        }

        if (collision.gameObject.CompareTag("caminoCemento") && isjumping)
        {
            Debug.Log("Aterrizó");
            audioSource.clip = eventRespuestAterrizaje;
            audioSource.Play();
            //messageController.ShowMessage("¡Aterrizaje exitoso!");
        }
    }
    void OnCollisionExit(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundDetected= false;
        }
    }

    void ActivateJumpEvent()
    {
        float currentHeight = transform.position.y;
        float currentVelocity = rb.velocity.y;
        heightText.text = "Altura: " + currentHeight.ToString("F2") + " m";
        velocityText.text = "Velocidad: " + currentVelocity.ToString("F2") + " m/s";
        wuu.gameObject.SetActive(true);
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = eventRespuestaWuuuu;
        audioSource.Play();
        rb.AddForce(new Vector3(0, 25, 0), ForceMode.Impulse);
        //anim.SetTrigger("Jump");

        StartCoroutine(CheckMaxHeight());
        StartCoroutine(UpdateVelocity());
    }
    IEnumerator UpdateVelocity()
    {
        while (true)
        {
            float currentVelocity = rb.velocity.y;
            velocityText.text = "Velocidad: " + currentVelocity.ToString("F2") + " m/s";
            yield return null;
        }
    }

    IEnumerator CheckMaxHeight()
    {
        
        AudioSource audioSource = GetComponent<AudioSource>();
        float previousHeight = transform.position.y;
        float currentHeight = previousHeight;
        float initialHeight=  currentHeight ;

        while (currentHeight >= previousHeight)
        {
            currentHeight = transform.position.y;

            // Calcula la altura relativa respecto a la altura inicial
            float relativeHeight = currentHeight - initialHeight;

            // Muestra la altura en metros y centímetros
            heightText.text = "Altura: " + relativeHeight.ToString("F2") + " m";
            //velocityText.text = "Velocidad: " + currentVelocity.ToString("F2") + " m/s";
                if (relativeHeight > 10)
                {
                    Debug.Log("EventoActivado");
                    logro1.RuntimeValue = true;
                    UIlogro1.SetActive(true);
                    //messageController.ShowMessage("Obsequio de regalo");
                }
                if (relativeHeight > 17)
                {
                    Debug.Log("EventoActivado");
                    logro2.RuntimeValue = true;
                    UIlogro2.SetActive(true);
                    Premiologro2.SetActive(true);
                    messageController.ShowMessage("Super Salto Desbloqueado");
                }
                if (relativeHeight > 22)
                {
                    Debug.Log("EventoActivado");
                    logro3.RuntimeValue = true;
                    UIlogro3.SetActive(true);
                    messageController.ShowMessage("Helicóptero Activado");
                }
                if (relativeHeight > 30)
                {
                    Debug.Log("EventoActivado");
                    logro4.RuntimeValue = true;
                    UIlogro4.SetActive(true);
                    messageController.ShowMessage("Gran Super Salto Final");
                        //messageController.ShowMessage("You Win");
                }
              

            if (currentHeight < previousHeight)
            {
                wuu.gameObject.SetActive(false);
                huu.gameObject.SetActive(true);
                reachedMaxHeight = true;
                Debug.Log("¡Altura máxima alcanzada!");
                audioSource.clip = eventRespuestaHuuuu;
                audioSource.Play();
                OnDesplazamientoTerminado?.Invoke();
                break;

            }

            previousHeight = currentHeight;

            yield return null;
        }
        StartCoroutine(CheckMinHeight());
    }

    IEnumerator CheckMinHeight()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        float previousHeight = transform.position.y;
        float currentHeight;
        bool landed = false;

        while (true)
        {
            //previousHeight = currentHeight; 
            currentHeight = transform.position.y;
            if (currentHeight < previousHeight && !reachedMixHeight)
            {
                if (Mathf.Abs(rb.velocity.y) < 0.1f && floorDetected)
                {
                    
                    reachedMixHeight = true;
                    reachedMaxHeight = false;
                    Debug.Log("¡Altura mínima alcanzada!");
                    audioSource.clip = eventRespuestAterrizaje;
                    aterrizajeParticles.Play();
                    DeactivateCloudParticles();
                    audioSource.Play();
                    landed = true;
                    huu.gameObject.SetActive(false);
                    OnDesplazamientoTerminado?.Invoke();
                }        
            }

            if (landed)
            {
                break; // Salir del bucle una vez que hayas aterrizado
            }
            previousHeight = currentHeight;
            reachedMixHeight = false;
            landed = false;

            yield return null;
        }
    }
    Vector3 GetSurfaceNormal()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {
            return hit.normal;
        }
        else
        {
            return transform.up;
        }
    }

    void DeactivateCloudParticles()
    {
        StartCoroutine(StopCloudParticlesAfterDelay());
    }

    IEnumerator StopCloudParticlesAfterDelay()
    {
        yield return new WaitForSeconds(1.5f);
        aterrizajeParticles.Stop();
    }
}