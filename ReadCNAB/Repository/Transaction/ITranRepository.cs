using ReadCNAB.Models;

namespace ReadCNAB.Repository.Transaction
{
    public interface ITranRepository
    {
        public TranModel getByTran(int id);
    }
}
