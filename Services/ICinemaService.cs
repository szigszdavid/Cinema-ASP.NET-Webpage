using Cinema.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Web.Services
{
    public interface ICinemaService
    {
        public List<List> GetLists(String name = null);
        public List GetListByID(int id);

        public List<Movie> GetMoviesByListID(int id);

        public List GetListDetails(int id);

        public Movie GetMovie(int id);

        //Lista módosító metódusok:

        bool CreateList(List list); //Sikeres volt a létrehozás vagy nem -> ehhez kell a bool

        bool UpdateList(List list);

        bool DeleteList(int id);

        //Movie módosító metódusok:

        bool CreateMovie(Movie movie); //Sikeres volt a létrehozás vagy nem -> ehhez kell a bool

        bool UpdateMovie(Movie movie);

        bool DeleteMovie(int id);

        public Int32 GetSteat(Screening screening, int i, int j);

        public bool SeatClicked(Screening screening, int i, int j);

        public bool PurchaseClicked(Screening screening);

        //Sikeres volt a létrehozás vagy nem -> ehhez kell a bool

        public Screening GetScreening(int id, string time);

        public Screening GetScreeningOnlybyId(int id);

        bool UpdateScreening(Movie movie);

        bool DeleteScreening(int id);
    }
}
