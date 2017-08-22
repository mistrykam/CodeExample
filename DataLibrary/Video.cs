using System.Data.Entity;

namespace DataLibrary
{
    public class Video
    {
        public int VideoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }

        // Data Source=(LocalDB)\v11.0;AttachDbFileName=C:\Users\Kam\Documents\Visual Studio 2015\Projects\CodeExample\DataLibrary\VideoDatabase.mdf;InitialCatalog=VideoDatabase;Integrated Security=True;MultipleActiveResultSets=True
        // Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kam\Documents\Visual Studio 2015\Projects\CodeExample\DataLibrary\VideoDatabase.mdf;Integrated Security=True

        //public VideoContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kam\Documents\Visual Studio 2015\Projects\CodeExample\DataLibrary\VideoDatabase.mdf;InitialCatalog=VideoDatabase;Integrated Security = True")
        public VideoContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kam\Documents\Visual Studio 2015\Projects\CodeExample\DataLibrary\VideoDatabase.mdf;Integrated Security=True")
        {

        }
    }

    public class Example
    {
        public static void ExampleCode1()
        {
            using (VideoContext videoContext = new VideoContext())
            {
                Video video = new Video() { Title = "Limitless", Description = "Unlimited power via pharam" };

                videoContext.Videos.Add(video);
                videoContext.SaveChanges();
            }
        }
    }

}
