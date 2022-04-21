using Infoset.Domain;

namespace Infoset.Infrastructure
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Branches.Any()) return;

            var branches = new List<Branche>
            {
                new Branche() {
                        Name = "Branche Isatnbul -Bakırköy",
                        //Isatnbul -Bakırköy
                        Latitude = 40.982235807180615, 
                        Longitude = 28.87290103681618,
                    },
                new Branche() {
                        Name = "Branche Isatnbul -üsküdar",
                        //Isatnbul -üsküdar
                        Latitude = 41.023416250742805,
                        Longitude =  29.012343870703365,
                    },
                new Branche() {
                        Name = "Branche Istanbul - karaköy ",
                        //Istanbul - karaköy 
                        Latitude = 41.030904965533935, 
                        Longitude = 28.98450199824926,
                    },
                new Branche() {
                        Name = "Branche Bursa",
                        //Bursa
                        Latitude = 40.22390868740351,
                        Longitude =  29.020924452664026,
                    },
                new Branche() {
                        Name = "Branche istanbul - Fatih ",
                        //istanbul - Fatih
                        Latitude = 41.011303423962474,
                        Longitude = 28.946283551983345,
                    },

        };

            await context.Branches.AddRangeAsync(branches);
            await context.SaveChangesAsync();
        }
    }
}
