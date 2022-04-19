using Infoset.Domain;

namespace Infoset.Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Branches.Any()) return;

            var branches = new List<Branche>
            {
                new Branche() {
                        Name = "Branche 1",
                        //Isatnbul -Bakırköy
                        Latitude = 40.982235807180615, 
                        Longitude = 28.87290103681618,
                    },
                new Branche() {
                        Name = "Branche 2",
                        //Isatnbul -üsküdar
                        Latitude = 41.023416250742805,
                        Longitude =  29.012343870703365,
                    },
                new Branche() {
                        Name = "Branche 3",
                        //Istanbul - karaköy 
                        Latitude = 41.030904965533935, 
                        Longitude = 28.98450199824926,
                    },
                new Branche() {
                        Name = "Branche 4",
                        //Bursa
                        Latitude = 40.22390868740351,
                        Longitude =  29.020924452664026,
                    },
                new Branche() {
                        Name = "Branche 5",
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
