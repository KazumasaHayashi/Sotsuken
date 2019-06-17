using System;

using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;
public class DisplayPresentation : MonoBehaviour
{
    public Sprite[] Slide;

    Image SlideImage;

    int i = 0;

    public void NextSlide()

    {

        i = i + 1;

        SlideImage.sprite = Slide[i];

    }

    public void BackSlide()

    {

        i = i - 1;

        SlideImage.sprite = Slide[i];

    }


    void Start()

    {

        i = 0;

        SlideImage = GetComponent<Image>();

        SlideImage.sprite = Slide[i];

    }



    void Update()

    {

        if (Input.GetMouseButtonDown(0))

        {

            NextSlide();

        }

        if (Input.GetMouseButtonDown(1))

        {

            BackSlide();

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))

        {

            NextSlide();

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))

        {

            BackSlide();

        }

        if (Input.GetKeyDown(KeyCode.Space))

        {

            NextSlide();

        }

    }

}