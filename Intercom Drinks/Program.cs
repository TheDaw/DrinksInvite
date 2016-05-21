using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web.Script.Serialization;

namespace Intercom_Drinks
{
    public class Program
    {
        //define parameters
        static double drinksRadius = 100; //in kilometers
        static double officeLatitude = 53.3381985;
        static double officeLongitude = -6.2592576;
        static List<Customer> customerList = new List<Customer>(); //List of Customer objects
        static List<Customer> drinksList = new List<Customer>(); //List for storing customers within 100km

        static void Main()
        {

            getCustomers();
            checkDistances();
            sortInvites();
            Console.ReadLine();
        }



        static void getCustomers()
        {
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://gist.githubusercontent.com/brianw/19896c50afa89ad4dec3/raw/6c11047887a03483c50017c1d451667fd62a53ca/gistfile1.txt");                //Get the JSON
                var splitt = json.Split('\n'); //Split the Json by line
                foreach (string customerInfo in splitt)
                {
                    customerList.Add(new JavaScriptSerializer().Deserialize<Customer>(customerInfo)); //Generate a Customer object using the JSON format
                }
            }
        }

        static void checkDistances()
        {
            double distanceToOffice = 0; //Ensure distance is initialised to 0
            foreach (Customer customer in customerList)
            {
                distanceToOffice = distance(officeLatitude, officeLongitude, customer.Latitude, customer.Longitude); // Get the distance between current customer and office
                if (distanceToOffice <= drinksRadius)
                {
                    drinksList.Add(customer);
                }
            }
        }

        static void sortInvites()
        {
            Console.WriteLine("Invite Customers: ");
            drinksList = drinksList.OrderBy(x => x.User_id).ToList(); //Perform a list sort on user id
            foreach (Customer invited in drinksList)
            {
                Console.WriteLine(Convert.ToString(invited.User_id) + "  " + invited.Name);
            }
        }


        static public double distance(double lat1, double lon1, double lat2, double lon2)
        {
            //Conversion of formula provided
            double theta = lon1 - lon2;
            double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;
            dist = dist * 1.609344;
            return (dist);
        }

        static public double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        static public double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }



    }
}