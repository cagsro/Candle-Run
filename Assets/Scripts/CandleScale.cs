using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleScale : MonoBehaviour
{
    GameManager gameManager;
    private Touch touch;
    public GameObject Piece;
    public static CandleScale instance;
    public float speed = 5;
    public bool OnGround = false;
    public float meltSpeed = 0.3f;
    public float bridgeMeltSpeed = 0.5f;

    
    private void Awake()
    {
        if (instance == null) 
            instance = this;
    }
    private void start()
    {

    }
    void Update()
    {
        if (!GameManager.isGameStarted || GameManager.isGameEnded) // Oyun baslamadiysa veya bittiyse
        {
            return;
        }
        transform.Translate(Vector3.forward * (speed) * Time.deltaTime);// Ileri doğru hareket

        this.transform.localScale -= Vector3.up * Time.deltaTime * meltSpeed; // Kuculmeye devam et

        if(this.transform.localScale.y <= 0.01f)
        {
            GameManager.instance.OnLevelFailed();
        }
    }
    public void GetPartOfMum()
    {
        this.transform.localScale += Vector3.up * 0.2f; // Y ekseninde yukselme islemi
    }
    public void Cutter()
    {
        SpawnPiece(); //Arkada parca birakma islemi
        this.transform.localScale -= Vector3.up * 0.3f; // Kisalma islemi
    }
    public void bridge()
    {
        this.transform.localScale -= Vector3.up * Time.deltaTime * bridgeMeltSpeed;
    }
    public void FinishPad()
    {
        GameManager.instance.OnLevelCompleted();
    }    
    public void SpawnPiece()
    {
        var PiecePos= new Vector3(MumHareket.instance.transform.position.x,0.3f,this.transform.position.z-0.4f);
        Instantiate(Piece, PiecePos, Quaternion.identity);
    }
}