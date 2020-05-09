using ProjectLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace AirportSimulator
{
    /// <summary>
    /// This is a Helper Class that is resposible for drawing and clearing images of planes from a canvas.
    /// </summary>
    public class PlaneDrawer
    {
        public Canvas AirportCanvas { get; set; }
        public List<Image> PlaneImages { get; set; }

        /// <summary>
        /// Clears all images of planes from the canvas.
        /// </summary>
        public void ClearPlainsImages()
        {
            if (PlaneImages != null)
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    foreach (var image in PlaneImages)
                    {
                        AirportCanvas.Children.Remove(image);
                    }

                    PlaneImages = null;
                }); 
            }
        }
        /// <summary>
        /// Creating the images and add them to the PlaneImages list.
        /// </summary>
        /// <param name="flights">List of flights</param>
        public void AddPlainImages(List<Flight> flights)
        {
            PlaneImages = new List<Image>();
            foreach (Flight flight in flights)
            {
                Image image = new Image() { Width = 72, Height = 72};

                if (flight.FlightStateType == StateType.Landing)
                    image.Source = new BitmapImage(new Uri("pack://application:,,,/Images/AirplaneL.png"));
                else
                    image.Source = new BitmapImage(new Uri("pack://application:,,,/Images/airplaneD.png"));

                AddToCanvas(flight, image);
                PlaneImages.Add(image);
            }
        }
        /// <summary>
        /// Adding the images to the canvas in the a specific position.
        /// </summary>
        /// <param name="flight">Current flight</param>
        /// <param name="img">The image to add to the canvas.</param>
        public void AddToCanvas(Flight flight, Image img)
        {
            if (flight.CurrentStation == null)
                return;

            switch (flight.CurrentStation.Id)
            {
                case 10:
                    Canvas.SetLeft(img, 630);
                    Canvas.SetTop(img, 68);
                    AirportCanvas.Children.Add(img);
                    break;
                case 1:
                    Canvas.SetLeft(img, 627);
                    Canvas.SetTop(img, 203);
                    AirportCanvas.Children.Add(img);
                    break;
                case 2:
                    Canvas.SetLeft(img, 450);
                    Canvas.SetTop(img, 126);
                    AirportCanvas.Children.Add(img);
                    break;
                case 3:
                    Canvas.SetLeft(img, 286);
                    Canvas.SetTop(img, 124);
                    AirportCanvas.Children.Add(img);
                    break;
                case 4:
                    Canvas.SetLeft(img, 112);
                    Canvas.SetTop(img, 125);
                    AirportCanvas.Children.Add(img);
                    break;
                case 5:
                    Canvas.SetLeft(img, 108);
                    Canvas.SetTop(img, 272);
                    AirportCanvas.Children.Add(img);
                    break;
                case 6:
                    Canvas.SetLeft(img, 164);
                    Canvas.SetTop(img, 464);
                    AirportCanvas.Children.Add(img);
                    break;
                case 7:
                    Canvas.SetLeft(img, 389);
                    Canvas.SetTop(img, 461);
                    AirportCanvas.Children.Add(img);
                    break;
                case 8:
                    Canvas.SetLeft(img, 350);
                    Canvas.SetTop(img, 267);
                    AirportCanvas.Children.Add(img);
                    break;
            }
        }
    }
}
