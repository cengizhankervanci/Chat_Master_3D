using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Level[] levels;
    public int whichlevel = 0;
    GameStatus status = GameStatus.initilaze;
    GameObject Situation;
    GameObject Active;
    GameObject Herimage;
    GameObject LevelName;

    GameObject answer1text;
    GameObject answer2text;

    GameObject myanswer;
    GameObject myanswer2;
    GameObject myanswer3;
    GameObject Firsttext;
    GameObject secondtext;
    GameObject thirdtext;

    GameObject heranswer;
    GameObject heranswer2;
    GameObject heranswer3;
    GameObject herfirst;
    GameObject hersecond;
    GameObject herthird;

    GameObject Answer1;
    GameObject Answer2;

    public int answercount;

    public GameObject Startanim;
    public GameObject WinPanel;
    public GameObject LosePanel;

    GameObject WinText;
    GameObject LoseText;
    void Start()
    {
        
    }

    void Update()
    {
        switch (status)
        {
            case GameStatus.initilaze:
                LevelName = GameObject.Find("LevelName");
                Herimage = GameObject.Find("Image");
                Situation = GameObject.Find("Situation");
                Active = GameObject.Find("Active");
                Answer1 = GameObject.Find("Answer1");
                answer1text = GameObject.Find("answer1text");
                Answer2 = GameObject.Find("Answer2");
                answer2text = GameObject.Find("answer2text");
                Firsttext = GameObject.Find("Firsttext");
                secondtext = GameObject.Find("secondtext");
                thirdtext = GameObject.Find("thirdtext");
                myanswer = GameObject.Find("myanswer");
                myanswer2 = GameObject.Find("myanswer2");
                myanswer3 = GameObject.Find("myanswer3");
                heranswer = GameObject.Find("heranswer");
                heranswer2 = GameObject.Find("heranswer2");
                heranswer3 = GameObject.Find("heranswer3");
                herfirst = GameObject.Find("herfirst");
                hersecond = GameObject.Find("hersecond");
                herthird = GameObject.Find("herthird");
                WinText = GameObject.Find("WinText");
                LoseText = GameObject.Find("LoseText");
                myanswer.SetActive(false);
                myanswer2.SetActive(false);
                myanswer3.SetActive(false);

                heranswer.SetActive(false);
                heranswer2.SetActive(false);
                heranswer3.SetActive(false);

                WinPanel.SetActive(false);
                LosePanel.SetActive(false);

                status = GameStatus.start;
                break;
            case GameStatus.start:
                LevelName.GetComponent<TextMeshPro>().text = levels[whichlevel].LevelName;
                Herimage.GetComponent<Image>().sprite = levels[whichlevel].Chatphoto;
                myanswer.GetComponent<Image>().sprite = levels[whichlevel].myphoto;
                myanswer2.GetComponent<Image>().sprite = levels[whichlevel].myphoto;
                myanswer3.GetComponent<Image>().sprite = levels[whichlevel].myphoto;
                heranswer.GetComponent<Image>().sprite = levels[whichlevel].Chatphoto;
                heranswer2.GetComponent<Image>().sprite = levels[whichlevel].Chatphoto;
                heranswer3.GetComponent<Image>().sprite = levels[whichlevel].Chatphoto;
                Situation.GetComponent<Text>().text = levels[whichlevel].namegirlorman;
                Active.GetComponent<Text>().text = levels[whichlevel].Activenow;
                WinText.GetComponent<Text>().text = levels[whichlevel].winpaneltext;
                LoseText.GetComponent<Text>().text = levels[whichlevel].losepaneltext;
                WinPanel.SetActive(false);
                LosePanel.SetActive(false);
                Startanim.SetActive(true);
                Answer1.SetActive(true);
                Answer2.SetActive(true);
                myanswer.SetActive(false);
                myanswer2.SetActive(false);
                myanswer3.SetActive(false);

                heranswer.SetActive(false);
                heranswer2.SetActive(false);
                heranswer3.SetActive(false);

                answer1text.SetActive(true);
                answer2text.SetActive(true);

                Startanim.SetActive(true);
                status = GameStatus.stay;
                break;
            case GameStatus.stay:
                
                if (answercount < 6)
                {
                    Invoke("openques", 3);
                    answer1text.GetComponent<Text>().text = levels[whichlevel].MyAnswers[answercount];
                    answer2text.GetComponent<Text>().text = levels[whichlevel].MyAnswers[answercount + 1];
                    status = GameStatus.nextques;
                }

                if (herthird.GetComponent<Text>().text == levels[whichlevel].HerAnswers[4])
                {
                    WinPanel.SetActive(true);
                }

                if (herthird.GetComponent<Text>().text != levels[whichlevel].HerAnswers[4] && answercount>=6)
                {
                    Debug.Log("Lose");
                    LosePanel.SetActive(true);
                }
                break;
            case GameStatus.nextques:
                
                break;
            case GameStatus.fail:
                break;
            case GameStatus.win:
                break;
            default:
                break;
        }

        if (answercount == 6)
        {
            answer1text.SetActive(false);
            answer2text.SetActive(false);
        }
    }

    public void Clickers1()
    {
        Startanim.SetActive(false);
        if (answercount == 0)
        {
            myanswer.SetActive(true);
            Firsttext.GetComponent<Text>().text = answer1text.GetComponent<Text>().text;
            heranswer.SetActive(true);
            if (Firsttext.GetComponent<Text>().text == levels[whichlevel].MyAnswers[answercount])
            {
                herfirst.GetComponent<Text>().text = levels[whichlevel].HerAnswers[answercount];
            }
            else
            {
                herfirst.GetComponent<Text>().text = levels[whichlevel].HerAnswers[answercount + 1];
            }
        }
        if (answercount == 2)
        {
            myanswer2.SetActive(true);
            secondtext.GetComponent<Text>().text = answer1text.GetComponent<Text>().text;
            heranswer2.SetActive(true);
            if (secondtext.GetComponent<Text>().text == levels[whichlevel].MyAnswers[answercount])
            {
                hersecond.GetComponent<Text>().text = levels[whichlevel].HerAnswers[answercount];
            }
            else
            {
                hersecond.GetComponent<Text>().text = levels[whichlevel].HerAnswers[answercount + 1];
            }
        }

        if (answercount == 4)
        {
            myanswer3.SetActive(true);
            thirdtext.GetComponent<Text>().text = answer1text.GetComponent<Text>().text;
            heranswer3.SetActive(true);
            if (thirdtext.GetComponent<Text>().text == levels[whichlevel].MyAnswers[answercount])
            {
                herthird.GetComponent<Text>().text = levels[whichlevel].HerAnswers[answercount];
            }
            else
            {
                herthird.GetComponent<Text>().text = levels[whichlevel].HerAnswers[answercount + 1];
            }
        }
        Answer1.SetActive(false);
        Answer2.SetActive(false);
        if (answercount < 5)
        {
            answercount = answercount + 2;
            status = GameStatus.stay;
        }
    }

    public void Clickers2()
    {
        Startanim.SetActive(false);
        if (answercount == 0)
        {
            myanswer.SetActive(true);
            Firsttext.GetComponent<Text>().text = answer2text.GetComponent<Text>().text;
            heranswer.SetActive(true);
            if (Firsttext.GetComponent<Text>().text == levels[whichlevel].MyAnswers[answercount])
            {
                herfirst.GetComponent<Text>().text = levels[whichlevel].HerAnswers[answercount];
            }
            else
            {
                herfirst.GetComponent<Text>().text = levels[whichlevel].HerAnswers[answercount + 1];
            }
        }

        if (answercount == 2)
        {
            myanswer2.SetActive(true);
            secondtext.GetComponent<Text>().text = answer2text.GetComponent<Text>().text;
            heranswer2.SetActive(true);
            if (secondtext.GetComponent<Text>().text == levels[whichlevel].MyAnswers[answercount])
            {
                hersecond.GetComponent<Text>().text = levels[whichlevel].HerAnswers[answercount];
            }
            else
            {
                hersecond.GetComponent<Text>().text = levels[whichlevel].HerAnswers[answercount + 1];
            }
        }

        if (answercount == 4)
        {
            myanswer3.SetActive(true);
            thirdtext.GetComponent<Text>().text = answer2text.GetComponent<Text>().text;
            heranswer3.SetActive(true);
            if (thirdtext.GetComponent<Text>().text == levels[whichlevel].MyAnswers[answercount])
            {
                herthird.GetComponent<Text>().text = levels[whichlevel].HerAnswers[answercount];
            }
            else
            {
                herthird.GetComponent<Text>().text = levels[whichlevel].HerAnswers[answercount + 1];
            }
        }
        Answer1.SetActive(false);
        Answer2.SetActive(false);

        if (answercount < 5)
        {
            answercount = answercount + 2;
            status = GameStatus.stay;
        }
    }

    public void NextLevel()
    {
        WinPanel.SetActive(false);
        whichlevel++;
        answercount = 0;
        if (whichlevel >=levels.Length)
        {
            whichlevel = 0; 
        }
        status = GameStatus.start;
    }

    public void Restart()
    {
        LosePanel.SetActive(false);
        answercount = 0;
        status = GameStatus.start;
    }

    void openques()
    {
        Answer1.SetActive(true);
        Answer2.SetActive(true);
    }
}
