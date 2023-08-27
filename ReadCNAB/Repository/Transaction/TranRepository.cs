using ReadCNAB.Data;
using ReadCNAB.Models;

namespace ReadCNAB.Repository.Transaction
{
    public class TranRepository : ITranRepository
    {
        private readonly ConnectionDB _con;

        public TranRepository(ConnectionDB con)
        {
            _con = con;
        }

        public TranModel getByTran(int id)
        {
            return _con.Transaction.FirstOrDefault(t => t.TranType == id);
        }
    }
}
