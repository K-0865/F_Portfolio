using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class Fox_Move : MonoBehaviour
{

	/*[SerializeField] float jumpForce;
	[SerializeField] float speed;
	[SerializeField] float cooldownHit;*/

	[SerializeField] private float speed;
	[SerializeField] private float runspeed;
	[SerializeField] private float jumpForce;
	[SerializeField] private float specialTime;
	[SerializeField] private float specialcool;
	[SerializeField] GameObject Player;
	private float specialDelta = 0f;
	private float coolDelta = 0f;

	[SerializeField]
	private float m_maxSpeed = 5f;
	[SerializeField]
	private float m_jumpPower = 1000f;
	[SerializeField]
	private Vector2 m_backwardForce = new Vector2(-4.5f, 5.4f);

	[SerializeField] private float AttackDis;
	[SerializeField] GameObject ATK;

	public LayerMask whatIsGround;

	private Animator m_animator;
	private BoxCollider2D m_boxCollider2D;
	private Rigidbody2D m_rigidbody2D;
	private bool m_isGround;
	private State m_state = State.Normal;

	public GameObject debugSprite = null;

	public bool running, up, down, jumping, crouching, dead, attacking, special;
	private Rigidbody2D rb;
	private Animator anim;
	private SpriteRenderer sp;
	private float rateOfHit;
	private GameObject[] life;
	private int qtdLife;
	private int jumpcon = 0;
	private int Itemcon = 0;
	private int Breakcon = 0;
	
	[SerializeField] private bool specialActive = true;

	private int cooldownHit;

	private bool clear = false;

	public GameObject Continue;
	public GameObject GameOver;
	public GameObject Restart;
	public GameObject Chery;

	string SceneName;

	// Use this for initialization

	void Awake()
	{
		m_animator = GetComponent<Animator>();
		m_boxCollider2D = GetComponent<BoxCollider2D>();
		m_rigidbody2D = GetComponent<Rigidbody2D>();

		cooldownHit = 0;
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		sp = GetComponent<SpriteRenderer>();
		running = false;
		up = false;
		down = false;
		jumping = false;
		crouching = false;
		rateOfHit = Time.time;
		life = GameObject.FindGameObjectsWithTag("Life");
		qtdLife = life.Length;

		m_boxCollider2D = GetComponent<BoxCollider2D>();
	}

	void Update()
	{

		// 水平方向の入力
		float x = Input.GetAxis("Horizontal");
		bool jump = Input.GetButtonDown("Jump");

		if (clear) return;

		if (dead) return;

		// 移動処理
		Movement(x, jump);

	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (clear) return;

		if (dead) return;

		if (dead == false)
		{

			//Character doesnt choose direction in Jump									//If you want to choose direction in jump
			if (attacking == false)
			{                                                   //just delete the (jumping==false)
				if (jumping == false && crouching == false)
				{
					//tack();
					Special();
					
				}
				Jump();
				Crouch();
			}
			Dead();
		}

			Vector2 pos = transform.position;
			// 地面判定の範囲
			Vector2 groundArea = new Vector2((m_boxCollider2D.bounds.size.x + m_boxCollider2D.edgeRadius * 2) / 2, m_boxCollider2D.bounds.size.y * 0.02f);

			// 地面判定の中心
			Vector2 groundCheck = new Vector2(
				pos.x + m_boxCollider2D.offset.x * ((transform.rotation.y == 0) ? 1 : -1),
				pos.y - m_boxCollider2D.bounds.size.y / 2 + m_boxCollider2D.offset.y - groundArea.y - m_boxCollider2D.edgeRadius);

			// 指定した範囲(第一引数ー第二引数の間)に指定したレイヤーのオブジェクトがあるかどうか
			m_isGround = Physics2D.OverlapArea(groundCheck + groundArea, groundCheck - groundArea, whatIsGround);
			m_animator.SetBool("isGround", m_isGround);
		//Debug.Log(m_isGround);
#if UNITY_EDITOR
		if (debugSprite)
			{
				debugSprite.transform.position = groundCheck;
				debugSprite.transform.localScale = new Vector2(groundArea.x * 2, groundArea.y * 2);
			}
#endif
		
	}

	private bool isGround()
    {
        var result = false;
        // 四角の四隅を取得する
        var bb = m_boxCollider2D.bounds;
        Vector2 left, right;
        left = right = Vector2.zero;
        var offsetX = 0.1f;
        var offsetY = 0.3f;

		offsetY *= -1;
		right = new Vector2(bb.center.x + bb.extents.x + offsetX, bb.center.y - bb.extents.y + offsetY);
		left = new Vector2(bb.center.x - bb.extents.x - offsetX, bb.center.y - bb.extents.y + offsetY);

        var rObj = Physics2D.OverlapPoint(right, whatIsGround);
        var lObj = Physics2D.OverlapPoint(left, whatIsGround);

        if( rObj != null && lObj != null)
        {
            result = true;
        }
		else
        {
            result = false;
        }

		// デバッグ処理
        var val = "rObj = " + rObj + ", lObj = " + lObj;
       // Debug.Log(val);
        Debug.DrawLine(left, right, Color.blue);

        return result;
    }

	void Movement(float move, bool jump)
	{
		// moveが0以外なら回転させる
		if (Mathf.Abs(move) > 0)
		{
			Quaternion rot = transform.rotation;
			// Y軸をMoveが正の数値なら0度、負の数値なら180度回転する
			transform.rotation = Quaternion.Euler(rot.x, Mathf.Sign(move) == 1 ? 0 : 180, rot.z);
			anim.SetBool("Running", true);
		}
        else
        {
			anim.SetBool("Running",false);
        }

		// 加速
		m_rigidbody2D.velocity = new Vector2(move * m_maxSpeed, m_rigidbody2D.velocity.y);

		// アニメーターに値の設定
		m_animator.SetFloat("Horizontal", move);
		m_animator.SetFloat("Vertical", m_rigidbody2D.velocity.y);
		m_animator.SetBool("isGround", m_isGround);

		//Jump();

		// 以下ジャンプ処理
		if (jump && m_isGround)
		{
			//m_animator.SetTrigger("Jump");
			//m_rigidbody2D.AddForce(Vector2.up * m_jumpPower);

			// 速度をクリアして2回目のジャンプも1回目と同じ挙動にする。
			rb.velocity = Vector2.zero;
			jumping = false;
			//Debug.Log(jumpcon);
			rb.AddForce(new Vector2(0, jumpForce));
			jumpcon++;
			Debug.Log("JumpTrue");

			if (rb.velocity.y > 0 && up == false)
			{
				up = true;
				jumping = true;
				anim.SetTrigger("Up");
			}
			else if (rb.velocity.y < 0 && down == false)
			{
				down = true;
				jumping = true;
				anim.SetTrigger("Down");
			}
			else if (rb.velocity.y == 0 && (up == true || down == true))
			{
				up = false;
				down = false;
				jumping = false;
				anim.SetTrigger("Ground");
			}
		}
	}

	void Jump()
	{
		//Jump1回目

		//Jump Animation
		if (rb.velocity.y > 0.5 && up == false)
		{
			up = true;
			jumping = true;
			anim.SetTrigger("Up");
		}
		else if (rb.velocity.y < -0.5 && down == false)
		{
			down = true;
			jumping = true;
			anim.SetTrigger("Down");
		}
		else if (rb.velocity.y == 0 && (up == true || down == true))
		{
			up = false;
			down = false;
			jumping = false;
			anim.SetTrigger("Ground");
		}

		// ジャンプリセット処理
		if(isGround() == true && jumpcon > 0)
		{
            jumpcon = 0;
        }
    }

	/*void Attack()
	{

		// transformを取得
		Transform myTransform = this.transform;

		Vector2 pos2 = myTransform.position;

		Vector2 pos = new Vector2(pos2.x - 1, pos2.y - 1);
		Collider2D col = Physics2D.OverlapPoint(pos);

		//I activated the attack animation and when the
		//Atacking																//animation finish the event calls the AttackEnd()
		if (Input.GetKeyDown(KeyCode.C))
		{
			rb.velocity = new Vector2(0, 0);
			anim.SetTrigger("Attack");
			attacking = true;

			float x = ATK.transform.position.x;
			float y = ATK.transform.position.y;
			float z = ATK.transform.position.z;

			Debug.Log(col+"col");
		}
	}*/

	void AttackEnd()
	{
		attacking = false;
	}

	void Special()
	{
		special = false;
		if (Input.GetKey(KeyCode.Space) && specialActive)
		{
			
			specialDelta += Time.deltaTime;
			Debug.Log(specialDelta);
			if (specialDelta > specialTime)
            {
				specialDelta = 0;
				specialActive = false;
				special = false;
				ATK.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
				anim.SetBool("notSpecial", false);
				Debug.Log("-------------");
			}
			else
            {
				ATK.transform.localScale = new Vector3(2, 0.1f, 0.1f);
				special = true;
				anim.SetBool("Special", true);
				Debug.Log("special!");
				Debug.Log("*********************");
			}
		}
		else
		{
			coolDelta += Time.deltaTime;
			if (coolDelta > specialcool)
			{
				coolDelta = 0;
				specialActive = true;
				special = false;
			}
			ATK.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
			anim.SetBool("Special", false);
		}
	}

	void Crouch()
	{
		//Crouch
		if (Input.GetKey(KeyCode.DownArrow))
		{
			anim.SetBool("Crouching", true);
		}
		else
		{
			anim.SetBool("Crouching", false);
		}
	}

	void OnCollisionStay2D(Collision2D other)
	{
		// 地面との当たり
		if (other.gameObject.tag == "Floor")
		{
			jumpcon = 0;
			jumping = false;
			//Debug.Log("Jumping!!!!");
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Goal")
		{
			clear = true;
		}
		if (clear) return;


		if (dead) return;

		//敵との接触判定
		if (other.gameObject.tag == "Enemy")
		{
			if (special) { Breakcon++; }else
			{ 
				anim.SetTrigger("Damage");
				Hurt();
			}
		}
		//弾との接触判定
		if (other.gameObject.tag == "Bullet")
		{
            if (special) { } else
            {
				anim.SetTrigger("Damage");
				other.gameObject.SetActive(false);
				Hurt();
			}
		}

		if (other.gameObject.tag == "Bullet" && special)
		{
		/*	Vector2 Force; // 弾にかける力
			Force = transform.forward * -10000; // 弾にかける力を砲台の前方向にする
			Rigidbody2D rigit = other.GetComponent<Rigidbody2D>();
			rigit.AddForce(Force); // 弾に力をかける
			rigit.angularVelocity = 0;
			other.transform.rotation = Quaternion.identity;*/
		}

		if (other.gameObject.tag == "Item")
        {
			other.gameObject.SetActive(false);
			Itemcon++;
			healing(other);
		}

		if (other.gameObject.tag == "healer")
		{

		}

		if (other.gameObject.tag == "Kill")
        {
			other.gameObject.SetActive(false);
			qtdLife = -1;

		}

		/*// 地面との当たり。
		if (other.gameObject.name == "Floor")
		{
			jumpcon = 0;
			jumping = false;
			Debug.Log("Jumping!!!!");
		}*/
	}

	void Hurt()
	{
		if (rateOfHit < Time.time)
		{
			rateOfHit = Time.time + cooldownHit;
			life[qtdLife - 1].gameObject.SetActive(false);
			//Destroy(life[qtdLife - 1]);
			qtdLife -= 1;
		}
		Debug.Log("a");
	}

	void healing(Collision2D name) 
    {
		if (rateOfHit < Time.time)
		{
			rateOfHit = Time.time + cooldownHit;
			Debug.Log("b");
			if (qtdLife < 3)
			{
				life[qtdLife].gameObject.SetActive(true);
				qtdLife += 1;
			}
			name.gameObject.SetActive(false);

		}

	}

	void Dead()
	{
		if (qtdLife <= 0)
		{
			Continue.SetActive(true);
			GameOver.SetActive(true);
			Restart.SetActive(true);

			anim.SetTrigger("Dead");
			dead = true;

		}
	}

	public void OnclickRestart()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void OnclickContinue()
    {
		SceneManager.LoadScene("Title");
	}

	public void TryAgain()
	{                                                       //Just to Call the level again
		SceneManager.LoadScene(0);
	}

	public int GetItemCount()
    {
		return Itemcon;
	}
	enum State
	{
		Normal,
		Damaged,
		Invincible,
	}
}
