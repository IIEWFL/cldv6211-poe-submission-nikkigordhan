namespace CLDV6221_PoE_Part3
{
    public class Loggedin
    {
        public static bool  bLoggedIn { get; set; }

        public static string CheckLoggedIn()
        {
            if (bLoggedIn)
            {
                return  "";
            }
            else
            {
               return "style=\"display:none\"";  //this code is used to not sow the menu if login was unsuccessful

            }

        }
    }
}
// allows me to create a Login object.
