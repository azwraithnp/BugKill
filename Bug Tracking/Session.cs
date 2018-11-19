namespace Bug_Tracking
{
    /// <summary>
    /// Class to store static variables that can be used as session or storage variables,
    /// to be used in different parts of the app
    /// </summary>
    public class Session
    {
        public static string session_name = null;   //Creates a variable to store the active user's name
        public static string id = null;             //Creates a variable to store the active bug id                 
        public static string code = null;           //Creates a varibale to store the source code
        public static string writtencode = null;    //Creates a variable to store the provided code
        public static byte[] imageData = null;      //Creates a variable to store the screenshot's image data
        public static string fixedstatus = "no";    //Creates a variable to store the bug's fixed status
        public static string solutionExists = "no"; //Creates a variable to store the bug's solution status
        public static string searchBy = null;       //Creates a variable to store the search keyword    
        public static string searchTerm = null;     //Creates a variable to store the search term
    }
}
