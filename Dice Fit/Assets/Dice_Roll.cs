using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;

public class Dice_Roll : MonoBehaviour
{
    public GameObject dice;
    Rigidbody2D rb2D;
    private SpriteRenderer diceImage;
    private int preNum;
    float posY;

    Sprite[] images;

    private bool isRandom = false;

    // Start is called before the first frame update
    void Start()
    {
        //diceImage = dice.GetComponent<Image>();
        diceImage = dice.GetComponent<SpriteRenderer>();
        rb2D = dice.GetComponent<Rigidbody2D>();
        images = Resources.LoadAll<Sprite>("Image/Dice");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            OnClickDice();
        }

        if (isRandom)
        {
            //�T�C�R���������Ă���Ԃ͏��num���X�V���A�~�܂钼�O�̒l��preNum�Ɋi�[����
            if (!rb2D.IsSleeping())
            {
                int num = Random.Range(0, 6);
                diceImage.sprite = images[num];
                preNum = num;
            }
            else
            {
                Debug.Log(preNum + 1);
                isRandom = false;
            }
        }


    }



    //�N���b�N�ŌĂԊO���X�N���v�g����ł���
    public void OnClickDice()
    {
        if (rb2D.IsSleeping() && !isRandom)
        {
            rb2D.AddForce(new Vector2(0f, 1000f));
            isRandom = true;
        }
    }

}
