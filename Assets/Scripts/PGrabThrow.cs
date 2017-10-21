using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGrabThrow : MonoBehaviour {

        private GameObject armeEnMain;
        private GameObject armeToutPres;
        public GameObject Player;
        public GameObject PlayerMain;
        private bool possedearme;
        private int presarme;

    [SerializeField]
    private float throwingPower;
    [SerializeField]
    private bool _isThrowing;

    IEnumerator throwstop()
    {
        _isThrowing = true;
        yield return new WaitForSeconds(0.3f);
        _isThrowing = false;
    }


    // Use this for initialization
    void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
        if (Input.GetAxisRaw("Jump") > 0 && possedearme && !_isThrowing)
        {
            Throw(armeEnMain);
            StartCoroutine(throwstop());
        }
        else if (Input.GetAxisRaw("Jump")>0 && presarme>0 && !_isThrowing)
        {
            grab(armeToutPres);
            StartCoroutine(throwstop());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        presarme++;
        armeToutPres = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        presarme--;
        if (armeToutPres==collision.gameObject)
        {
            armeToutPres = null;
        }

    }

    void grab(GameObject objetGrab)
        {
            possedearme = true;
            armeEnMain = objetGrab;
            armeToutPres = null;
            armeEnMain.GetComponent<Collider2D>().enabled=false;
            armeEnMain.GetComponent<Rigidbody2D>().isKinematic = true;
            armeEnMain.transform.parent = Player.transform;
            armeEnMain.transform.position = PlayerMain.transform.position;
            armeEnMain.transform.rotation = PlayerMain.transform.rotation;
        }
    void Throw(GameObject objetLances)
        {
        armeEnMain.GetComponent<Collider2D>().enabled = true;
        armeEnMain.GetComponent<Rigidbody2D>().isKinematic = false;
        Rigidbody2D throwing = objetLances.GetComponent<Rigidbody2D>();
            throwing.AddRelativeForce(new Vector2(throwingPower, 0));
        objetLances.transform.parent = null;
        armeEnMain = null;
        possedearme = false;
        }
    }
