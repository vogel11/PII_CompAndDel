using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using CompAndDel;
using twitterPublisher;

namespace CompAndDel.Filters {
    public class FilterTwitter : IFilter {
        /// <summary>
        /// Recibe una imagen y la retorna con un filtro del tipo negativo aplicado
        /// </summary>
        /// <param name="image">Imagen a la cual se le va a plicar el filtro.</param>
        /// <returns>Imagen con el filtro aplicado</returns>
        public IPicture Filter (IPicture image) {
            
            string consumerKey = "dtOgpyjBBXglAzMEjMMZtFf73";
            string consumerKeySecret = "Qzm0FxotJ9YyoXiGLJ4JI9IZFWmYvB4LWpteWPGVYofxSG4FnN";
            string accessToken = "1396065818-13uONd7FgFVXhW1xhUCQshKgGv4UOnKeDipg4cz";
            string accessTokenSecret = "HXtlP1SRnJCL5a37R98hFrIRlEIouZX3Ra4s6JuFOpXZF";

            PictureProvider pictureProvider = new PictureProvider ();
            
            var twitterPub = new TwitterImage (consumerKey, consumerKeySecret, accessToken, accessTokenSecret);
            Console.WriteLine (twitterPub.PublishToTwitter ("Last check, I promise", @"tmpFace.jpg"));

            return image;
        }
    }
}
