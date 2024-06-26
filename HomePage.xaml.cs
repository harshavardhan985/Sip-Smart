using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace SipSmart
{
    public partial class HomePage : ContentPage
	{
        public HomePage ()
		{
			InitializeComponent ();
            GetLocationDetails();
        }
        private async void GetLocationDetails()
        {
            try
            {
                var location = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Default));

                if (location != null)
                {
                    locationLabel.Text = $"Latitude: {location.Latitude}\n" + $"Longitude: {location.Longitude}\n";

                    // Validate location type using Google Places API
                    GooglePlacesApi placesApi = new GooglePlacesApi();
                    List<string> placeType = await placesApi.GetPlaceType(29.65178597227073, -82.32510976044645);
                    string k = placeType[0].ToString();
                    locationLabel.Text = $"The location type is :{placeType[0]}";
                    if (placeType.Contains("bar"))
                    {
                        // Add the place type to LocationType Label
                        locationType.Text = "Place Type Bar";
                    }
                }
                else
                {
                    locationLabel.Text = "Location not available.";
                    locationType.Text = string.Empty; // Clear locationType if location is not available
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        
    }

    public class GooglePlacesApi
    {
        private const string ApiKey = "AIzaSyCjOuBTiY9V1459fi7fan5NM7p5DTzYFNc";

        public async Task<List<string>> GetPlaceType(double latitude, double longitude)
        {
            double lat = 29.65178597227073;
            double lon = -82.32510976044645;
            try
            {
                using (var client = new HttpClient())
                {
                    string apiUrl = $"https://maps.googleapis.com/maps/api/place/nearbysearch/json" +
                                    $"?location={lat},{lon}" +
                                    $"&radius=10" + // You can adjust the radius as needed
                                    $"&key={ApiKey}";

                    var response = await client.GetStringAsync(apiUrl);
                    var places = ParseApiResponse(response);

                    return places?.types ?? new List<string>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<string> { "Error" };
            }
        }

        private PlaceApiResponse ParseApiResponse(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<PlaceApiResponse>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing response: {ex.Message}");
                return null;
            }
        }

        public class PlaceApiResponse
        {
            public List<string> types { get; set; }
        }
    }
}

