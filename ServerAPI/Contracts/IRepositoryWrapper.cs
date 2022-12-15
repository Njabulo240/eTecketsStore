namespace ServerAPI.Contracts
{
    public interface IRepositoryWrapper
    {
        IActorRepository Actor { get; }
        ICinemaRepository Cinema { get; }
       IMovieRepository Movie { get; }
       IOrderRepository Order { get; }
       IProducerRepository Producer { get; }
        void Save();
    }
}