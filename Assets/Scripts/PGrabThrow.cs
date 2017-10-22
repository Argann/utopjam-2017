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
    [SerializeField]
    private Vector2 positionObjet= new Vector2();

    IEnumerator throwstop()
    {
        _isThrowing = true;
        yield return new WaitForSeconds(0.3f);
        _isThrowing = false;
    }


    // Use this for initialization
    void Start()
        {
            PlayerMain.transform.localPosition = positionObjet;
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
        if (collision.gameObject.tag=="lancez")
        {
            presarme++;
            armeToutPres = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(presarme>0)
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
            armeEnMain.transform.parent = PlayerMain.transform;
            //armeEnMain.transform.position = PlayerMain.transform.position;
            //armeEnMain.transform.rotation = PlayerMain.transform.rotation;
            armeEnMain.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
    void Throw(GameObject objetLances)
        {
        armeEnMain.GetComponent<Collider2D>().enabled = true;
        armeEnMain.GetComponent<Rigidbody2D>().isKinematic = false;
        Rigidbody2D throwing = objetLances.GetComponent<Rigidbody2D>();

        Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = (Input.mousePosition - sp).normalized;
        throwing.AddForce(dir * throwingPower);

        Vector2 mouse =Camera.main.ScreenToWorldPoint(transform.position);
        //throwing.AddRelativeForce(new Vector2((mouse.x/*-transform.position.x*/)* throwingPower, (mouse.y /*-transform.position.y*/) * throwingPower));
        //Debug.Log(new Vector2((mouse.x - transform.position.x) * throwingPower, (mouse.y - transform.position.y) * throwingPower));
        objetLances.transform.parent = null;
        armeEnMain = null;
        possedearme = false;
        }
    }
