﻿using System;
using CompAndDel.Filters;
using CompAndDel.Filters.Pipes;
using twitterPublisher;

namespace CompAndDel {
    class Program {
        static void Main (string[] args) {

            PictureProvider imgProvider = new PictureProvider ();
            IPicture pictureP = imgProvider.GetPicture ("BreakingBad.jpg"); // "Recoge" la imagen 

            IConvolution matrix = new BlurConvolutionMatriz();

            IFilter negativeFilter = new FilterNegative (); // Creación del filtro negativo
            IFilter blurFilter = new FilterConvolution (matrix);
            IFilter twitterFilter = new TwitterFilter (); //Creación del filtro de Twitter para publicar

            IPipe pipeEnd = new PipeNull (); // Pipe donde termina el programa
            //IPipe pipeTwitter = new PipeSerial (twitterPub, pipeEnd); // PipeSerial para publicar en Twitter y llevar la imagen al último Pipe
            IPipe pipeSerial = new PipeSerial (blurFilter, pipeEnd); // PipeSerial para aplicarle el filtro NEGATIVO y pasaje al segundo Pipe 

            imgProvider.SavePicture (pipeSerial.Send (pictureP), "BreakingBadBlur.jpg"); // Guarda la imagen con el nombre que se le adjudica       

        }
    }
}