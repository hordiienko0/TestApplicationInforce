using TestApplicationInforce.Data;

namespace TestApplicationInforce.Services
{
    public class DataService
    {
        protected readonly TestApplicationInforceContext _context;

        public DataService(TestApplicationInforceContext context)
        {
            _context = context;
        }
    }
}
