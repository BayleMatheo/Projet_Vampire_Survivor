using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationù : MonoBehaviour
{
    private Animator am;
    private PlayerMovement playerMove;
    private SpriteRenderer sr;

    void Start()
    {
        am = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove.moveDir.x != 0 || playerMove.moveDir.y != 0)
        {
            am.SetBool("Move", true);
            SpriteDirectionCheck();
        }
        else
        {
            am.SetBool("Move", false);
        }
    }

    void SpriteDirectionCheck()
    {
        if (playerMove.lastHorizontalVector < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}
