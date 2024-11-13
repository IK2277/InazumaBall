using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPText : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Text hpText;

    int hp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gameObject.name == "User(Clone)")
        {
            hp = player.GetComponent<UserModel_C>().hp;
        }
        else if (player.gameObject.name == "Enemy(Clone)")
        {
            hp = player.GetComponent<EnemyModel_C>().hp;
        }
        else if (player.gameObject.name == "Keeper")
        {
            hp = player.GetComponent<KeeperModel_C>().hp;
        }

        hpText.text = "HP: " + hp;
    }
}
