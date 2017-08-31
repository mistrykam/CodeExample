using System.Linq;
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

        public VideoContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kam\Documents\Visual Studio 2015\Projects\CodeExample\DataLibrary\VideoDatabase.mdf;Integrated Security=True")
        {

        }
    }

    public class VideoStore
    {
        public static void AddVideo(int videoId, string title, string description)
        {
            using (VideoContext db = new VideoContext())
            {
                Video video = new Video() { VideoId = videoId, Description = description, Title = title };

                db.Videos.Add(video);

                db.SaveChanges();
            }
        }

        public static void GetAllVideos()
        {
            using (VideoContext db = new VideoContext())
            {
                var videoList = from v in db.Videos
                                select v;
            }
        }
    }
}
