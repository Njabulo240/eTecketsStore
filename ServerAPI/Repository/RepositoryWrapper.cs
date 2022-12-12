using ServerAPI.Contracts;

namespace ServerAPI.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        IActorRepository _actor;
        ICinemaRepository _cinema;
       IMovieRepository _movie;
       IOrderRepository _order;
       IProducerRepository _producer;

        public IActorRepository Actor {
            get {
                if(_actor == null)
                {
                    _actor = new ActorRepository(_repoContext);
                }
                return _actor;
            }
        }
        public ICinemaRepository Cinema {
            get {

            
                if(_cinema == null)
                {
                    _cinema= new CinemaRepository(_repoContext);
                }
                return _cinema;
            }
        }

        public IMovieRepository Movie {
            get {
                if(_movie == null)
                {
                    _movie = new MovieRepository(_repoContext);
                }
                return _movie;
            }
        }
       

        public IOrderRepository Order {
            get {
                if(_order == null)
                {
                    _order = new OrderRepository(_repoContext);
                }
                return _order;
            }
        }

        public IProducerRepository Producer {
            get {
                if(_producer == null)
                {
                    _producer = new ProducerRepository(_repoContext);
                }
                return _producer;
            }
        }

 public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
