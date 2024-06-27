using UnityEngine;

public class Boolbutton : MonoBehaviour
{
    private bool movable = false;
    private bool soundPlayed = false;

    public AudioSource audioSource;

    private bool colliding = false;
    public float MoveSpeed = 5f;
    public Rigidbody2D RigidBodyLink;
    public float startPosX = 0;
    private float startPosY = 0;
    Vector2 movement;
    public GameObject waterObject;

    [SerializeField] GameObject WaterpeilBoolLayer;
    [SerializeField] BoxCollider2D WaterLevel;
    public bool isWaterObjectDeactivated = false;

    //Check of layer aanstaat
    public bool LayerAan = true;

    //Script links met Bool en Int Layer
    [SerializeField] LegeSchuifknopScript floatScript;
    [SerializeField] minMaxerInt minMaxerint;
    [SerializeField] GameObject intLayerGo;

    [SerializeField] GameObject BoolSchuif;

    [SerializeField] SpriteRenderer spriteRenderer;

    public bool EersteKeerAangezet = false;

    public bool status = false;


    void Start()
    {
        startPosX = startPosX + gameObject.transform.position.x;
        startPosY = startPosY + gameObject.transform.position.y;

        floatScript.GetComponent<LegeSchuifknopScript>();
        minMaxerint.GetComponent<minMaxerInt>();

        spriteRenderer = BoolSchuif.GetComponent<SpriteRenderer>();

        spriteRenderer.color = Color.white;

        waterObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void MoveLeft()
    {
        if (colliding == false && gameObject.transform.position.x > startPosX)
        {
            gameObject.transform.position -= new Vector3(0.025f, 0, 0);
        }
    }

    private void MoveRight()
    {
        if (colliding == false && gameObject.transform.position.x < startPosX)
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(0.025f, 0, 0);
        }
    }

    public void posLimiter()
    {
        if (gameObject.transform.position.x > (startPosX + 0.715f) || transform.position.x < (startPosX - 0.715f))
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            movable = false;

        }
        else
        {
            if (colliding == true)
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                movable = true;
            }
        }
    }

    public void posLimitRight()
    {
        if (gameObject.transform.position.x > (startPosX + 0.715f))
        {
            if (colliding == false)
            {
                gameObject.transform.position = new Vector3(startPosX + 0.71f, startPosY, -3.24f);
            }
            if (!isWaterObjectDeactivated && minMaxerint.LayerAan == false && floatScript.LayerAan == false && intLayerGo.transform.localScale.x == 0)
            {
                LayerAan = false;
                spriteRenderer.color = Color.green;
                EersteKeerAangezet = true;

                WaterLevel.size = WaterLevel.size - new Vector2(1, 1);
                waterObject.SetActive(false);
                WaterpeilBoolLayer.SetActive(false);
                isWaterObjectDeactivated = true;
            }

            if (minMaxerint.LayerAan == true || floatScript.LayerAan == true)
            {
                spriteRenderer.color = Color.red;
            }

            if (EersteKeerAangezet == true)
            {
                spriteRenderer.color = Color.green;

                if (!soundPlayed)
                {
                    audioSource.Play();
                    soundPlayed = true;
                }
            }
        }
    }

    public void posLimitLeft()
    {
        if (gameObject.transform.position.x < (startPosX - 0.715f))
        {
            if (colliding == false)
            {
                gameObject.transform.position = new Vector3(startPosX - 0.71f, startPosY, -3.24f);
            }
            status = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        colliding = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        colliding = false;
    }

    private void WaterGrow()
    {
        if (minMaxerint.LayerAan == false && floatScript.LayerAan == false && intLayerGo.transform.localScale.x <= 0)
        {
            waterObject.transform.localScale += new Vector3(0.1f, 0.01f, 0);
        }

        if (waterObject.transform.localScale.y >= 7.05f)
        {
            waterObject.transform.localScale = new Vector3(waterObject.transform.localScale.x, 7.05f, waterObject.transform.localScale.z);
        }

        if (waterObject.transform.localScale.x >= 33.5f)
        {
            waterObject.transform.localScale = new Vector3(33.5f, waterObject.transform.localScale.y, waterObject.transform.localScale.z);
        }
    }

    void FixedUpdate()
    {
        if (spriteRenderer.color == Color.red || spriteRenderer.color == Color.white)
        {
            MoveLeft();
            MoveRight();
        }

        if (floatScript.LayerAan == false && minMaxerint.LayerAan == false)
        {
            waterObject.GetComponent<BoxCollider2D>().enabled = true;
        }

        WaterGrow();
        posLimiter();
        posLimitRight();
        posLimitLeft();
        if (colliding == true)
        {
            RigidBodyLink.MovePosition(RigidBodyLink.position + movement * MoveSpeed * Time.fixedDeltaTime);
            Debug.Log("Movable...");
        }
        else
        {
            Debug.Log("Not Movable...");
        }
    }
}
