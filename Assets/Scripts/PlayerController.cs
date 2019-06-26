using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// プレイヤー初期位置：X:-3.13 Y:-2.02

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour {

    Rigidbody2D rigidbody;

    public GameObject isTriggerWall;
    public GameObject lifeObject;

    SpriteRenderer MainSpriteRenderer;
    // publicで宣言し、inspectorで設定可能にする
    public Sprite Rocket;
    public Sprite man;

    bool isGround = true;        // 地面と接地しているか管理するフラグ
    public int cameraY = 0;
    public bool isWall = false;
    bool isJump = false;
    bool rocket = false;
    bool space = false;
    bool ufoFlag = false;
    bool binary = false;

    public float jumpForce = 300f;       // ジャンプ時に加える力
    float jumpThreshold = 1f;    // ジャンプ中か判定するための閾値
    public float runSpeed = 0.1f;       // 走っている間の速度
    static float rotation = 180;
    public bool runLimit = false;
    public int life = 4;
    public bool GoalText = false;

    private Renderer renderer;
    public GameController gameController;

    private float noInputDeltaTime;
    public int noInputTime;
    public bool noInput = false;

    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();

        // このobjectのSpriteRendererを取得
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        renderer = GetComponent<Renderer>();
    }

	void Update () {
        if (gameController.gameStart)
        {
            if (!binary)
            {
                // →を押したとき
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.position += new Vector3(runSpeed * Time.deltaTime, 0, 0);  // 右に進む
                    noInputDeltaTime = 0;

                    // プレイヤーが人がロケットか
                    if (rocket)
                    {
                        transform.rotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
                    }
                }
                // ←を押したとき
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.position += new Vector3(-runSpeed * Time.deltaTime, 0, 0);  // 左に進む
                    noInputDeltaTime = 0;

                    // プレイヤーが人がロケットか
                    if (rocket)
                    {
                        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                    }
                }

                // ↑を押したとき
                else if (Input.GetKey(KeyCode.UpArrow) && rocket)
                {
                    noInputDeltaTime = 0;
                    transform.position += new Vector3(0, runSpeed * Time.deltaTime, 0);  // 上に進む
                    transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                }
                // ↓を押したとき
                else if (Input.GetKey(KeyCode.DownArrow) && rocket)
                {
                    noInputDeltaTime = 0;
                    transform.position += new Vector3(0, -runSpeed * Time.deltaTime, 0);  // 下に進む
                    transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
                }

                else if(!(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow)))
                {
                    noInputDeltaTime += Time.deltaTime;
                    if (noInputTime == (int)noInputDeltaTime)
                    {
                        Debug.Log("NoInput");
                        noInput = true;
                    }
                }
            }


            // 地面に接してない状態でSpaceを押したとき
            if (isGround && !isWall)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    rigidbody.AddForce(transform.up * this.jumpForce);  // ジャンプする
                    isGround = false;
                }
            }
        }

        if (Mathf.Abs(rigidbody.velocity.y) > jumpThreshold)
        {
            isGround = false;
        }

        // Debug.Log(cameraY);
        // Debug.Log(life);

        // ジャンプ台
        if (isJump)
        {
            isJump = false;
            Vector2 force = new Vector2(0, 3.0f);
            rigidbody.AddForce(transform.up * 30.0f, ForceMode2D.Impulse);
        }

        // プレイヤーとロケットの時の重力の調整
        if (rocket)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            ChangeStateToHold();
            if (!space)
              cameraY = 10;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 2;
        }

        if (life <= 0)
        {
            life = 0;
            binary = true;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            #if UNITY_EDITOR
              EditorApplication.isPlaying = false;
            #elif UNITY_STANDALONE
              Application.Quit();
            #endif
        }
    }

    // プレイヤーの画像をロケットに変更
    void ChangeStateToHold()
    {
        MainSpriteRenderer.sprite = Rocket;
    }

    void DelayMethod()
    {
        cameraY = 0;
        MainSpriteRenderer.sprite = man;
        transform.position = new Vector3(667.2f, 2.1f, 0);
        ufoFlag = true;
        binary = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            if (!isGround)
              isGround = true;
        }

        if (col.gameObject.tag == "UnderWall")
        {
            cameraY = -5;
        }

        if (col.gameObject.tag == "UpWall")
        {
            cameraY = 5;
        }

        if (col.gameObject.tag == "UpUpWall")
        {
            space = true;
            cameraY = 15;
        }

        if (col.gameObject.tag == "isTriggerFlag")
        {
            isTriggerWall.GetComponent<BoxCollider2D>().isTrigger = false;
            rocket = true;
        }

        if (col.gameObject.tag == "Wall")
        {
            if (!isWall)
                isWall = true;
        }

        if (col.gameObject.tag == "ufo")
        {
            space = false;
            rocket = false;
            cameraY = 5;
            binary = true;
            //DelayMethodを5秒後に呼び出す
            Invoke("DelayMethod", 5.0f);
        }

        //trapとぶつかった時にコルーチンを実行
        if (col.gameObject.tag == "trap")
        {
            life -= 1;
            Debug.Log("Life : " + life);
            StartCoroutine("Damage");
        }

        if (col.gameObject.tag == "Goal")
        {
            binary = true;
            GoalText = true;
        }

        if (col.gameObject.tag == "StartBack")
        {
            transform.position = new Vector3(-3.13f, 3.0f, 0);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            if (!isGround)
              isGround = true;
        }

        if (col.gameObject.tag == "InvisibleWall")
        {
            if(!runLimit)
              runLimit = true;
        }

        if (col.gameObject.tag == "UpAddForce")
        {
            if (!isJump)
                isJump = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "InvisibleWall")
        {
            if (runLimit)
                runLimit = false;
        }

        if (col.gameObject.tag == "Wall")
        {
            if (isWall)
                isWall = false;
        }

        if (col.gameObject.tag == "UnderWall")
        {
            cameraY = 0;
        }
        if (col.gameObject.tag == "UpWall")
        {
            cameraY = 0;
        }
        if (col.gameObject.tag == "UpUpWall" && !ufoFlag)
        {
            space = false;
            cameraY = 10;
        }
    }

    IEnumerator Damage()
    {
        //レイヤーをPlayerDamageに変更
        gameObject.layer = LayerMask.NameToLayer("PlayerDamage");
        //while文を10回ループ
        int count = 10;
        while (count > 0)
        {
            //透明にする
            renderer.material.color = new Color(1, 1, 1, 0);
            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);
            //元に戻す
            renderer.material.color = new Color(1, 1, 1, 1);
            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);
            count--;
        }
        //レイヤーをPlayerに戻す
        gameObject.layer = LayerMask.NameToLayer("Player");
    }
}
