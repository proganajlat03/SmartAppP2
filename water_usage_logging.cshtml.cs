using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SQLite;
namespace SmartWaterApp.Pages
{
    public class water_usage_loggingModel : PageModel
    {
        public void OnPost()
        {
            string activity = Request.Form["activity"];
            string water_consumed = Request.Form["water_consumed"];
            string sqlQuery = "INSERT INTO water_usage (activity, water_consumed) VALUES(" + "'" + activity + "'" + ", " + "'" + water_consumed + "'" + ")";
            var connection = new SQLiteConnection("Data Source=SmartWaterDB.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @sqlQuery;
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
