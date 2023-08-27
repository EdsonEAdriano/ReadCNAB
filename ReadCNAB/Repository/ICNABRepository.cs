using ReadCNAB.Models;

namespace ReadCNAB.Repository
{
    public interface ICNABRepository
    {
        public void Add(CNABModel cNABModel);

        public List<CNABModel> Get();
    }
}
