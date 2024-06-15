using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gato : MonoBehaviour
{
    private Transform Rato;
    private Animator animator;
    [SerializeField] private float RunRange, Damage; 
    public float AttackRange;
    [SerializeField] public float MaxHealth; 
    public float health {get; private set;}
    private bool attack;
    [SerializeField] GameObject QueijoHubble;

    // Start is called before the first frame update
    void Start()
    {
        Rato = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        health = MaxHealth;   
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Die();   
    }

    public void LookAtPlayer(){ 
        if(Rato.position.x > transform.position.x){
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }else if(Rato.position.x < transform.position.x){
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }

    public void Run(){
        if(Rato.position.x - transform.position.x > RunRange || Rato.position.x - transform.position.x < -RunRange){
            animator.SetBool("run", true);
        }else{
            animator.SetBool("run", false);
        }
    }

    public void Attack(){
        if(attack){
            FindObjectOfType<Rato>().TakeDamage(this.Damage);
        }      
    }

    public void TakeDamage(float damage){
        this.health -= damage;
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            attack = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision){
            attack = false;
    }

    void Die(){
        if(this.health == 0){
            animator.SetTrigger("die");
            StartCoroutine(TurnIntoQueijo());
        }
    }

    void SetQueijo(){
        QueijoHubble.transform.position = transform.position;
        QueijoHubble.transform.eulerAngles = transform.eulerAngles;
    }

    IEnumerator TurnIntoQueijo(){
        yield return new WaitForSeconds(3f);
        SetQueijo();
        QueijoHubble.SetActive(true);
        Destroy(gameObject);
    }
}
