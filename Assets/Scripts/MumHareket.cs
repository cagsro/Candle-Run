using UnityEngine;

public class MumHareket : MonoBehaviour
{
    
    public static MumHareket instance;
    private Touch touch;
    private float speedModifier;
    public float speed = 5;
    public float minCandlePos;
    public float maxCandlePos;
    public bool OnGround = false;
    private void Awake()
    {
        if (instance == null) 
            instance = this;
    }
    void Start()
    {
        speedModifier = 0.01f;
        minCandlePos = -4.5f;
        maxCandlePos = 4.5f;
    }
    private void Update()
    {
            //transform.Translate(Vector3.forward * (speed) * Time.deltaTime);// Ileri doğru hareket
 
        if (Input.touchCount > 0) // Dokunma varsa;
        {
            touch = Input.GetTouch(0); // Degiskeni atama atama

            if (touch.phase == TouchPhase.Moved) // Dokunma basladiginda;
            {
                //Yeni koordinatlar bunlar olsun.
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * speedModifier,
                    transform.position.y,
                    transform.position.z);
            }
        }
        // Mumun yoldan disari cikmaması icin gereken kod (clamp islemi)
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,minCandlePos,maxCandlePos),Mathf.Clamp(transform.position.y,0f,200f),transform.position.z);
    }
}
