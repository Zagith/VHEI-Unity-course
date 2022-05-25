using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float playerHeight = 2f;

    [SerializeField] Transform orientation;

    [Header("Movement")]
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float airMultiplier = 0.4f;
    float movementMultiplier = 10f;

    [Header("Sprinting")]
    [SerializeField] float walkSpeed = 4f;
    [SerializeField] float sprintSpeed = 6f;
    [SerializeField] float acceleration = 10f;

    [Header("Jumping")]
    public float jumpForce = 5f;

    [Header("Keybinds")]
    [SerializeField] KeyCode jumpKey = KeyCode.Space;
    [SerializeField] KeyCode sprintKey = KeyCode.LeftShift;

    [Header("Drag")]
    // Attrito della fisica quando è a terra
    [SerializeField] float groundDrag = 6f;

    // Attrito della fisica quando il giocatore è in aria e cade
    [SerializeField] float airDrag = 2f;

    float horizontalMovement;
    float verticalMovement;

    [Header("Ground Detection")]
    // Transform dell'oggetto con cui si andrà a fare il check se il giocatore è su un pavimento
    [SerializeField] Transform groundCheck;

    // Layer assegnato agli oggetti su cui il giocatore potrà camminare
    [SerializeField] LayerMask groundMask;

    // Distanza tra l'oggetto groundCheck ed il pavimento
    [SerializeField] float groundDistance = 0.2f;
    private bool isGrounded;

    Vector3 moveDirection;
    Vector3 slopeMoveDirection;

    Rigidbody rb;

    RaycastHit slopeHit;

    // Funzione che ritorna un valore true o false se c'è una pendenza
    private bool OnSlope()
    {
        // Raggio "infrarossi" diretto verso il basso sull'asse y per fare il check di quali oggetti ci sono
        // Approfondisci su: https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight / 2 + 0.5f))
        {
            if (slopeHit.normal != Vector3.up)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Inserisco i costraint sulle rotazioni del rigidbody
        rb.freezeRotation = true;
    }

    private void Update()
    {
        // Check se il giocatore collide con il layer assegnato per il ground
        // CheckSphere perché ho un collider a capsula/sfera
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Richiamo la funzione MyInput per fare il check degli input
        MyInput();

        // Richiamo la funzione ControlDrag per il controllo dell'attrito del rigidbody
        ControlDrag();

        // Richiamo la funzione ControlDrag per il controllo della speed
        ControlSpeed();

        // Se il pulsante premuto è l'input assegnato a jumpKey ed il giocatore è sul terreno allora entra
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            Jump();
        }

        // https://docs.unity3d.com/ScriptReference/Vector3.ProjectOnPlane.html
        slopeMoveDirection = Vector3.ProjectOnPlane(moveDirection, slopeHit.normal);
    }

    void MyInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        // Calcolo della direzione del movimento
        moveDirection = orientation.forward * verticalMovement + orientation.right * horizontalMovement;
    }

    void Jump()
    {
        if (isGrounded)
        {
            // Aggiungo un nuovo vettore alla velocità del rigidbody frezzando la velocità sul'asse y
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

            // Aggiungo una forza di tipo impulso al rigidbody per saltare
            // Approfondisci su: https://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }

    void ControlSpeed()
    {
        // Calcolo per trovare la velocità effettiva
        // https://docs.unity3d.com/ScriptReference/Mathf.Lerp.html
        // https://docs.unity3d.com/ScriptReference/Time-deltaTime.html
        if (Input.GetKey(sprintKey) && isGrounded)
        {
            moveSpeed = Mathf.Lerp(moveSpeed, sprintSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            moveSpeed = Mathf.Lerp(moveSpeed, walkSpeed, acceleration * Time.deltaTime);
        }
    }

    void ControlDrag()
    {
        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = airDrag;
        }
    }

    // FixedUpdate viene richiamato sempre dopo Update
    // In update si fanno tutti i calcoli da attuare alla fisica nel FixedUpdate
    private void FixedUpdate()
    {
        // Richiamo la funzione MovePlayer per muovere il personaggio
        MovePlayer();
    }

    void MovePlayer()
    {
        // https://docs.unity3d.com/ScriptReference/ForceMode.html
        if (isGrounded && !OnSlope())
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
        }
        else if (isGrounded && OnSlope())
        {
            rb.AddForce(slopeMoveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
        }
        else if (!isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier * airMultiplier, ForceMode.Acceleration);
        }
    }
}