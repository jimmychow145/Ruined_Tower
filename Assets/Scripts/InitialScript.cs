using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Schepens.UtilScripts;



public class InitialScript : MonoBehaviour
{
    public ArrayList initialOneArray;
    public ArrayList initialTwoArray;
    public ArrayList initialThreeArray;


    public GameObject sceneChanger;
    public static string currentInitial = "";
    public bool initialOne;
    public bool initialTwo;
    public bool initialThree;
    public Transform InitialOneHolder;
    public Transform InitialTwoHolder;
    public Transform InitialThreeHolder;
    public string initialOnePlaceholder;
    public string initialTwoPlaceholder;
    public string initialThreePlaceholder;







    // Start is called before the first frame update
    void Start()
    {
        currentInitial = "";
        initialOne = true;
        initialTwo = false;
        initialThree = false;
        initialOnePlaceholder = "";
        initialTwoPlaceholder = "";
        initialThreePlaceholder = "";
        initialOneArray = new ArrayList() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        initialTwoArray = new ArrayList() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        initialThreeArray = new ArrayList() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    }

    // Update is called once per frame
    void Update()
    {
        chooseInitial();
        setupInitialBoxes();
        if(currentInitial.Length == 3)
        {
            StartCoroutine(ExecuteAfterTime(2f));
        }

    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        sceneChanger.GetComponent<SceneChanger>().ChangeScene("End Scene");

    }


    void setupInitialBoxes()
    {
        InitialOneHolder.Find("InitialOneBox1").GetComponent<Text>().text = (string) initialOneArray[24];
        InitialOneHolder.Find("InitialOneBox2").GetComponent<Text>().text = (string)initialOneArray[25];
        InitialOneHolder.Find("InitialOneBox3").GetComponent<Text>().text = (string)initialOneArray[0];
        InitialOneHolder.Find("InitialOneBox4").GetComponent<Text>().text = (string)initialOneArray[1];
        InitialOneHolder.Find("InitialOneBox5").GetComponent<Text>().text = (string)initialOneArray[2];

        InitialTwoHolder.Find("InitialTwoBox1").GetComponent<Text>().text = (string)initialTwoArray[24];
        InitialTwoHolder.Find("InitialTwoBox2").GetComponent<Text>().text = (string)initialTwoArray[25];
        InitialTwoHolder.Find("InitialTwoBox3").GetComponent<Text>().text = (string)initialTwoArray[0];
        InitialTwoHolder.Find("InitialTwoBox4").GetComponent<Text>().text = (string)initialTwoArray[1];
        InitialTwoHolder.Find("InitialTwoBox5").GetComponent<Text>().text = (string)initialTwoArray[2];

        InitialThreeHolder.Find("InitialThreeBox1").GetComponent<Text>().text = (string)initialThreeArray[24];
        InitialThreeHolder.Find("InitialThreeBox2").GetComponent<Text>().text = (string)initialThreeArray[25];
        InitialThreeHolder.Find("InitialThreeBox3").GetComponent<Text>().text = (string)initialThreeArray[0];
        InitialThreeHolder.Find("InitialThreeBox4").GetComponent<Text>().text = (string)initialThreeArray[1];
        InitialThreeHolder.Find("InitialThreeBox5").GetComponent<Text>().text = (string)initialThreeArray[2];





    }

    void chooseInitial()
    {
        if(initialOne)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                initialOnePlaceholder = (string) initialOneArray[25];
                initialOneArray.RemoveAt(25);
                initialOneArray.Insert(0, initialOnePlaceholder);
            }
            else if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                initialOnePlaceholder = (string)initialOneArray[0];
                initialOneArray.RemoveAt(0);
                initialOneArray.Insert(25, initialOnePlaceholder);
            }
            else if(Input.GetKeyDown(KeyCode.Space))
            {
                currentInitial += (string)initialOneArray[0];
                initialOne = false;
                initialTwo = true;
                InitialOneHolder.Find("InitialOneBox3").GetComponent<BlinkingText>().StopBlinking();
                InitialTwoHolder.Find("InitialTwoBox3").GetComponent<BlinkingText>().StartBlinking();

            }
        }
        else if (initialTwo)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                initialTwoPlaceholder = (string)initialTwoArray[25];
                initialTwoArray.RemoveAt(25);
                initialTwoArray.Insert(0, initialTwoPlaceholder);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                initialTwoPlaceholder = (string)initialTwoArray[0];
                initialTwoArray.RemoveAt(0);
                initialTwoArray.Insert(25, initialTwoPlaceholder);
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                currentInitial += (string)initialTwoArray[0];
                initialTwo = false;
                initialThree = true;
                InitialTwoHolder.Find("InitialTwoBox3").GetComponent<BlinkingText>().StopBlinking();
                InitialThreeHolder.Find("InitialThreeBox3").GetComponent<BlinkingText>().StartBlinking();
            }
        }
        else if (initialThree)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                initialThreePlaceholder = (string)initialThreeArray[25];
                initialThreeArray.RemoveAt(25);
                initialThreeArray.Insert(0, initialThreePlaceholder);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                initialThreePlaceholder = (string)initialThreeArray[0];
                initialThreeArray.RemoveAt(0);
                initialThreeArray.Insert(25, initialThreePlaceholder);
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                currentInitial += (string)initialThreeArray[0];
                initialThree = false;
                InitialThreeHolder.Find("InitialThreeBox3").GetComponent<BlinkingText>().StopBlinking();

            }
        }
    }

    void resetInitial()
    {
        initialOneArray = new ArrayList() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        initialTwoArray = new ArrayList() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        initialThreeArray = new ArrayList() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    }

    public string getInitial()
    {
        return currentInitial;
    }
}
