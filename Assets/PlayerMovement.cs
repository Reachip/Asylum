using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;

    public float speed;
    public float normalSpeed = 8f;
    public float runningSpeed = 12f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public float jumpHeight = 3f;
    private string saveFile = "P:\\save.asylum.txt";

    Vector3 velocity;
    public LayerMask groundMask;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists(saveFile))
        {
            using (StreamReader reader = File.OpenText(saveFile))
            {
                char[] separator = " ".ToCharArray();
                string[] coordinatesSplit = reader.ReadLine().Split(separator);
                transform.position = new Vector3(float.Parse(coordinatesSplit[0]), float.Parse(coordinatesSplit[1]), float.Parse(coordinatesSplit[2]));
            }
        }

        StartCoroutine(DoEvery10Seconds());
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runningSpeed;

        }
        else
        {
            speed = normalSpeed;
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void SaveProgesssion()
    {
        using (StreamWriter writer = File.CreateText(saveFile))
        {
            writer.WriteLine($"{transform.position.x} {transform.position.y} {transform.position.z}");
        }
    }

    IEnumerator DoEvery10Seconds()
    {

        yield return new WaitForSeconds(10);
        SaveProgesssion();
        StartCoroutine(DoEvery10Seconds());
    }
}
