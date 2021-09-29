using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("Ground")) //Mum yolun ustunde mi?
        {
            CandleScale.instance.OnGround = true;
            MumHareket.instance.OnGround = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag.Equals("Ground")) //Mum yolun ustunde mi?
        {
            CandleScale.instance.OnGround = true;
            MumHareket.instance.OnGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag.Equals("Ground")) //Mum yolun ustunde mi?
        {
            CandleScale.instance.OnGround = false;
            MumHareket.instance.OnGround = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Yem")) //Mum yem'e carpti mi?
        {
            FindObjectOfType<AudioManager>().PlaySound("PickUpPart");
            Destroy(other.gameObject); // yem'i yok et
            CandleScale.instance.GetPartOfMum(); //fonk. cagir
        }
        if (other.transform.tag.Equals("cutter")) //Mum kesiciye carpti mi?
        {
            other.transform.GetComponent<Collider>().enabled = false;
            CandleScale.instance.Cutter(); //fonk. cagir
        }
        if (other.transform.tag.Equals("FinishPad")) //Mum bitis noktasina geldi mi?
        {
            CandleScale.instance.FinishPad(); //fonk. cagir
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag.Equals("bridge")) //Mum koprude mi?
        {
            if(CandleScale.instance.transform.localScale.y>=0.01f)
                CandleScale.instance.bridge(); //fonk. cagir
        }
    }
}