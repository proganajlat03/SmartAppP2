using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SQLite;

namespace SmartWaterApp.Pages
{
    public class DeleteModel : PageModel
    {
        public void OnPost()
        {
            string activity = Request.Form["activity"];
            string waterConsumed = Request.Form["water_consumed"];

            string sqlQuery = "DELETE FROM water_usage WHERE activity = @Activity AND water_consumed = @WaterConsumed";

            try
            {
                using (var connection = new SQLiteConnection("Data Source=SmartWaterDB.db"))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Activity", activity);
                        command.Parameters.AddWithValue("@WaterConsumed", waterConsumed);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log error or handle appropriately
                Console.WriteLine($"Error during deletion: {ex.Message}");
            }
        }
    }
}
