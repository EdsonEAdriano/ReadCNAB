using ReadCNAB.Data;
using ReadCNAB.Models;

namespace ReadCNAB.Repository
{
    public class CNABRepository : ICNABRepository
    {
        private readonly ConnectionDB _con;
        public CNABRepository(ConnectionDB con) 
        {
            _con = con;
        }
        public void Add(CNABModel cNABModel)
        {
            _con.CNABs.Add(cNABModel); 
            _con.SaveChanges();
        }

        public List<CNABModel> Get()
        {
            return _con.CNABs.ToList();
        }
    }
}
