using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TyAnimation : MonoBehaviour
{
    static Animator anim;
    public GameObject Player;
    private Vector3 curr_pos;
    private Vector3 prev_pos;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        curr_pos = Player.transform.position;
        prev_pos = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (curr_pos != prev_pos)
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }
        prev_pos = curr_pos;
        curr_pos = Player.transform.position;

        // Decided correct animation to apply to "Ty"
        // depending on type of movement detected
        // float translation = Input.GetAxis("Vertical");
        // float rotation = Input.GetAxis("Horizontal");

        // if (translation != 0 || rotation != 0)
        //     anim.SetBool("IsRunning", true);
        // else
        //     anim.SetBool("IsRunning", false);

        if (Input.GetKeyDown(KeyCode.Space))
            anim.SetBool("IsJumping", true);
        else
            anim.SetBool("IsJumping", false);

        if (Player.transform.position.y < -10)
            anim.SetBool("Falling", true);

        if (Player.transform.position.y > 0 && Player.transform.position.y < 1)
        {
            anim.SetTrigger("Grounded");
            anim.SetBool("Falling", false);
        }
    }
}
