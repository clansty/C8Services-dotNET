using System.Web.Http;

namespace C8Api
{
    public class HomeworkController : ApiController
    {
        public Homework Get()
        {
            return new Homework();
        }
    }
}