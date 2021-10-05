using UnityEngine;
using TMPro; 
using UnityEngine.UI;
//

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timee, brains;
    [SerializeField] Text score;
    [SerializeField] Text Info;
   
    [SerializeField] public Text gameover;
    //[SerializeField] GameObject spark;
    [SerializeField] GameObject sc;
    public float gamest, gplay_time;

    [SerializeField] GameObject spark;
    [SerializeField] Text Info2;
    public int scoreVal, xt, brainc = 4;
    int InVal, valChn;
    float infoST, infoST2;
    [SerializeField] float infoTP;
    bool hasStart=false;

    bool checkbp = false, checkbm = false;
    int x = 0, y = 0, t = 1, n = 1;


    float gameSt;
    int i = 1, j = 1;

    //bool scoreupd=false;
    // Start is called before the first frame update
    void Start()
    {

        brains.text = "BRAINS: " + brainc + "/9";
        
        gplay_time = 20.0f;
        Info2.color = Color.green;
        Info2.text = "Press ENTER to start";
        xt = 0;
        timee.text = "Time - " + xt;
        gameSt = Time.time;
        Info.text = " ";
        scoreVal = 0;
        InVal = scoreVal;
        score.text = "Score - " + scoreVal;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !hasStart)
        {
            gamest = Time.time;
            hasStart = true;
            Info2.text = " ";
        }
        brains.text = "BRAINS: " + brainc + "/9";
        if(hasStart)
        xt = (int)(Time.time - gamest);
        timee.text = "Time: " + xt + " s";

        if (xt >= 20)
        {
            timee.text = "Time: " + 20 + "s";
            if (scoreVal < 150)
            {
                gameover.color = Color.red;
                gameover.text = "Game Over!\n" + scoreVal + "\nPress Enter\nTo Continue";
            }
            else
            {
                gameover.color = Color.blue;
                gameover.text = "Level complete!\n" + scoreVal + "\nPress Enter\nTo Continue";
            }
            if (Input.GetKeyDown(KeyCode.Return))
                sc.GetComponent<SceneSwitch>().scenechange();
        }


        if ((scoreVal >= 150) || (scoreVal <= -50))
        {
            switch (y)
            {
                case 0:
                    y = 1;
                    infoST2 = Time.time;
                    break;
                case 1:
                    {
                        if (Time.time < infoST + infoTP)
                        {

                            if (scoreVal >= t * 150)
                            {
                                Info2.color = Color.green;
                                checkbp = true;
                                Info2.text = "You have gained a brain!!";
                                t++;
                                brainc++;
                            }
                            else if (scoreVal <= -50 * n)
                            {
                                Info2.color = Color.red;
                                checkbm = true;
                                Info2.text = "You have lost a brain!!";
                                n++;
                                brainc--;

                                if (scoreVal >= i * 150)
                                {
                                    i++;
                                    Info2.color = Color.blue;
                                    Info2.text = "You have gained a brain!!";

                                }
                                else if (scoreVal <= j * -50)
                                {
                                    j++;
                                    Info2.color = Color.red;
                                    Info2.text = "You have lost a brain!!";


                                }


                            }
                        }
                        else
                        {
                            Info2.text = "";
                            y = 0;
                        }
                    }
                    break;

            }
        }

        else
        {
            i = 1;
            j = 1;
        }


        score.text = "Score -  " + scoreVal;
        if (InVal != scoreVal)
        {
            switch (x)
            {
                case 0:
                    {
                        infoST = Time.time;
                        valChn = scoreVal - InVal;
                        x = 1;
                    }
                    break;
                case 1:
                    if (Time.time < infoST + infoTP)
                    {
                        if (valChn > 0)
                        {
                            Info.color = Color.green;
                            Info.text = "+" + valChn;

                        }

                        else
                        {
                            Info.color = Color.red;
                            Info.text = "" + valChn;
                        }


                    }
                    else
                    {
                        Info.text = "";
                        InVal = scoreVal;
                        x = 0;
                    }
                    break;
            }
        }

        if (checkbp)
        {
            if (scoreVal < (t - 1) * 150)
            {
                Info2.color = Color.red;
                checkbp = false;
                brainc--; t--;
            }
        }
        if (checkbm)
        {
            if (scoreVal > -50 * (n - 1))
            {
                Info2.color = Color.green;
                checkbm = false;
                brainc++;
                n--;
            }
        }

    }

}

