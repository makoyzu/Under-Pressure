using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject chainManager;
    public GameManager gameManager;
    public AudioSource chainSoundPlayer;
    public AudioClip chainSound;

    [SerializeField] int hp;
    
    [SerializeField] int damageAmount = 1;
    [SerializeField] PanicLevel panic;
    [SerializeField] ChainList chain;

    public void TakeDamage()
    {
        
        hp -= damageAmount;
        chainSoundPlayer.PlayOneShot(chainSound, 1);
        panic.AddPanic();
        if (hp <= 0)
        {
            chainManager.SendMessage("Remove");
            Destroy(gameObject);
            gameManager.chainsBroken++;
        }
        else 
        { 
            transform.localScale *= 1.05f;
            Invoke("DelayedFunction", 0.1f);
        }
    }
    private void DelayedFunction()
    {
        transform.localScale /= 1.05f;
    }
}