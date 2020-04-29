using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public GameObject p;
    public GameObject t;
    public Animator pAnim;
    public Animator lAnim;
    public Animator sAnim;

    [SerializeField] AudioClip sus;

    public bool isFree;
    bool hit = false;
    float time;
    public Material material;
    Renderer rend;
    public AudioSource audio;
    Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        t.active = false;
        isFree = false;
        rend = GetComponent<Renderer>();

        p = GameObject.Find("Player");
        //pAnim = p.GetComponent<Animator>();

        rend.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(isFree)
        {
            t.active = true;
            moveDirection = p.transform.position;
            Vector3 target = transform.position;
            target.y = moveDirection.y;
            float reload = moveDirection.y;

            if ((p.transform.position.x != target.x) && (p.transform.position.z != target.z) && !hit)
            {
                Debug.Log("Touching Lift!");
                pAnim.SetInteger("speed", 5);
                moveDirection = Vector3.MoveTowards(moveDirection, target, 5f * Time.deltaTime);
                moveDirection.y = reload;
                p.GetComponent<Rigidbody>().MovePosition(moveDirection);
            }
            else
            {
                hit = true;
                pAnim.SetInteger("speed", 0);
                lAnim.SetBool("up", true);
            }
        }
    }

    public void removeCivilian()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player") && !isFree)
        {
            rend.sharedMaterial = material;
            sAnim.SetBool("grounded", true);
            sAnim.SetBool("canJump", true);
            audio.Stop();
            audio.clip = sus;
            audio.Play();
            audio.loop = false;
            //other.GetComponent<Rigidbody>().useGravity = true;
            other.GetComponent<PlayerMovement>().speed = 0f;
            other.GetComponent<PlayerMovement>().doMove = false;
            isFree = true;
        }
    }
}
