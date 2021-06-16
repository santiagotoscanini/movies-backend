using System.Collections.Generic;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Config
{
    public static class MovieSeeding
    {
        public static void loadSeedData(DbContext context)
        {
            var seedMovies = new List<Movie>()
            {
                new()
                {
                    MovieName = "Pocahontas",
                    ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_695173-MLU26949356792_032018-O.jpg",
                    GuessedTimes = 1,
                    SelectedTimes = 1
                },
                new()
                {
                    MovieName = "Lion King",
                    ImageUrl =
                        "https://static.wikia.nocookie.net/doblaje/images/e/e0/Lion_king_1.jpg/revision/latest/top-crop/width/360/height/450?cb=20200726001925&path-prefix=es",
                    GuessedTimes = 0,
                    SelectedTimes = 1
                },
                new()
                {
                    MovieName = "Fast and Furious 9",
                    ImageUrl =
                        "https://elbocon.pe/resizer/JOjEqcAnVk-7s3iBTWKg7xLp3TI=/600x360/smart/filters:format(jpeg):quality(75)/cloudfront-us-east-1.images.arcpublishing.com/elcomercio/RSAA2KG5QRB27PZPRIC2EFCF7Y.jpg",
                    GuessedTimes = 1,
                    SelectedTimes = 3
                },
                new()
                {
                    MovieName = "Titanic",
                    ImageUrl = "https://i.pinimg.com/originals/0f/c2/e3/0fc2e34a10057121df194a23fc556d4a.jpg",
                    GuessedTimes = 2,
                    SelectedTimes = 5
                },
                new()
                {
                    MovieName = "American History X",
                    ImageUrl = "https://i0.wp.com/www.tomaprimera.es/wp-content/uploads/2016/06/AmHXpost.jpg",
                    GuessedTimes = 4,
                    SelectedTimes = 4
                },
                new()
                {
                    MovieName = "Beauty And The Beast",
                    ImageUrl =
                        "https://resizing.flixster.com/_sS5KRPtwLqzg4gGci9ZX02hmtY=/ems.ZW1zLXByZC1hc3NldHMvbW92aWVzL2Q1OWQzMzQ0LWY0YTgtNGI1ZS05NjRlLTk5NWMwMjVhYjQ0Yy53ZWJw",
                    GuessedTimes = 1,
                    SelectedTimes = 3
                },
                new()
                {
                    MovieName = "Cinderella",
                    ImageUrl = "https://images1.penguinrandomhouse.com/cover/9781506717463",
                    GuessedTimes = 2,
                    SelectedTimes = 2
                },
                new()
                {
                    MovieName = "101 dalmatians",
                    ImageUrl = "https://cdn.hmv.com/r/w-1280/hmv/files/8e/8e61635e-a713-4caa-b13e-706d350c3670.jpg",
                    GuessedTimes = 2,
                    SelectedTimes = 7
                },
                new()
                {
                    MovieName = "Dear Jhon",
                    ImageUrl = "https://flxt.tmsimg.com/assets/p7820906_p_v10_ax.jpg",
                    GuessedTimes = 2,
                    SelectedTimes = 4
                },
                new()
                {
                    MovieName = "E.T",
                    ImageUrl =
                        "https://faros.hsjdbcn.org/sites/default/files/styles/ficha-contenido/public/et-el-extraterrestre.jpg?itok=aNP75Wjl",
                    GuessedTimes = 1,
                    SelectedTimes = 6
                },
                new()
                {
                    MovieName = "Forrest Gump",
                    ImageUrl =
                        "https://img1.wsimg.com/isteam/ip/6ad550c3-3eef-4c25-a5c9-e68457631998/blob-0010.png/:/cr=t:2.83%25,l:2.83%25,w:94.34%25,h:94.34%25/rs=w:1280",
                    GuessedTimes = 0,
                    SelectedTimes = 2
                },
                new()
                {
                    MovieName = "Greatest Showman",
                    ImageUrl =
                        "https://m.media-amazon.com/images/M/MV5BMjI1NDYzNzY2Ml5BMl5BanBnXkFtZTgwODQwODczNTM@._V1_.jpg",
                    GuessedTimes = 1,
                    SelectedTimes = 2
                },
                new()
                {
                    MovieName = "Aladdin",
                    ImageUrl =
                        "https://static.wikia.nocookie.net/doblaje/images/e/e2/Aladdin.jpg/revision/latest?cb=20200731153827&path-prefix=es",
                    GuessedTimes = 3,
                    SelectedTimes = 6
                },
                new()
                {
                    MovieName = "The Little Mermaid",
                    ImageUrl =
                        "https://static.wikia.nocookie.net/disneyypixar/images/b/b7/The_Little_Mermaid_Poster.jpg/revision/latest?cb=20200803001021&path-prefix=es",
                    GuessedTimes = 2,
                    SelectedTimes = 4
                },
                new()
                {
                    MovieName = "Mulan",
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/81mbLAxqn9L.jpg",
                    GuessedTimes = 1,
                    SelectedTimes = 1
                },
                new()
                {
                    MovieName = "The Princess and the Frog",
                    ImageUrl = "https://m.media-amazon.com/images/I/51JjEt6wtML.jpg",
                    GuessedTimes = 2,
                    SelectedTimes = 4
                },
                new()
                {
                    MovieName = "Brave",
                    ImageUrl = "https://flxt.tmsimg.com/assets/p8740063_p_v13_au.jpg",
                    GuessedTimes = 2,
                    SelectedTimes = 4
                },
                new()
                {
                    MovieName = "Hairspray",
                    ImageUrl =
                        "https://images-na.ssl-images-amazon.com/images/S/pv-target-images/472d19dcecc8776b558058bd136b408ef9ad69586db81bfd25fe7e913a83ea49._RI_V_TTW_.jpg",
                    GuessedTimes = 3,
                    SelectedTimes = 4
                },
                new()
                {
                    MovieName = "Ice Age",
                    ImageUrl =
                        "https://3.bp.blogspot.com/-M7TO4R1kHSM/Tz1j8hlkleI/AAAAAAAAB34/AX8E6Nufa3Q/s1600/Ice+Age.jpg",
                    GuessedTimes = 0,
                    SelectedTimes = 0
                },
                new()
                {
                    MovieName = "Jaws",
                    ImageUrl =
                        "https://kbimages1-a.akamaihd.net/f295ece9-8627-401f-a0d5-47ba7971e879/1200/1200/False/jaws-7.jpg",
                    GuessedTimes = 3,
                    SelectedTimes = 5
                },
                new()
                {
                    MovieName = "Kill Bill",
                    ImageUrl = "https://comoacaba.com/wp-content/uploads/2019/03/lfj709InbmljVqAXgUk2qjnujNN.jpg",
                    GuessedTimes = 3,
                    SelectedTimes = 4
                },
                new()
                {
                    MovieName = "Nanny McPhee",
                    ImageUrl =
                        "https://musicart.xboxlive.com/7/e37a1100-0000-0000-0000-000000000002/504/image.jpg?w=1920&h=1080",
                    GuessedTimes = 0,
                    SelectedTimes = 6
                },
                new()
                {
                    MovieName = "Ratatouille",
                    ImageUrl = "https://i.pinimg.com/originals/7a/bd/32/7abd3237502efcf7505e2b82b7beaee1.jpg",
                    GuessedTimes = 1,
                    SelectedTimes = 1
                },
                new()
                {
                    MovieName = "Pulp Fiction",
                    ImageUrl =
                        "https://img.betaseries.com/m8s87xbR7Q0JttLj4qXc3oEa0Io=/600x900/smart/https%3A%2F%2Fpictures.betaseries.com%2Ffilms%2Faffiches%2Foriginal%2F142.jpg",
                    GuessedTimes = 5,
                    SelectedTimes = 10
                },
                new()
                {
                    MovieName = "Soul Surfer",
                    ImageUrl =
                        "https://images-na.ssl-images-amazon.com/images/S/sgp-catalog-images/boxart_images/d50c3b22-94b7-4b58-a6db-ae96b5fda929-e7cabfb9-83bf-41f0-8058-17f25767f9de_RGB_SD._RI_VxHQABM9GWIpmWkqeBWeDNtvQ2OmQS7_TTW_.jpg",
                    GuessedTimes = 3,
                    SelectedTimes = 5
                },
                new()
                {
                    MovieName = "Toy Story 2",
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/719aV3ujFKL._AC_SY741_.jpg",
                    GuessedTimes = 3,
                    SelectedTimes = 7
                },
                new()
                {
                    MovieName = "Underworld",
                    ImageUrl =
                        "https://cdn.hobbyconsolas.com/sites/navi.axelspringer.es/public/styles/1200/public/media/image/2017/01/underworld-guerras-sangre.jpg?itok=7DKX4xeC",
                    GuessedTimes = 1,
                    SelectedTimes = 2
                },
                new()
                {
                    MovieName = "Venom",
                    ImageUrl = "https://i.blogs.es/0aa698/dbhowryvwaaskyd.jpg-large/450_1000.jpeg",
                    GuessedTimes = 2,
                    SelectedTimes = 5
                }
            };

            context.Set<Movie>().AddRange(seedMovies);
            context.SaveChanges();
        }
    }
}