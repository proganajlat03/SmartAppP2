using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SQLite;

namespace SmartWaterApp.Pages
{
    public class UpdateModel : PageModel
    {
        public void OnPost()
        {
            string activity = Request.Form["activity"];
            string currentWaterConsumed = Request.Form["current_water_consumed"];
            string newWaterConsumed = Request.Form["new_water_consumed"];

            string sqlQuery = "UPDATE water_usage SET water_consumed = @NewWaterConsumed WHERE activity = @Activity AND water_consumed = @CurrentWaterConsumed";

            try
            {
                using (var connection = new SQLiteConnection("Data Source=SmartWaterDB.db"))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Activity", activity);
                        command.Parameters.AddWithValue("@CurrentWaterConsumed", currentWaterConsumed);
                        command.Parameters.AddWithValue("@NewWaterConsumed", newWaterConsumed);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log error or handle appropriately
                Console.WriteLine($"Error during update: {ex.Message}");
            }
        }
    }
}
