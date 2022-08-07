namespace YoizenTestApp.Repo
{
    public interface IRepo<T>
    {
        public IEnumerable<T> GetAll();

        public T Get(Guid id);

        public void Create(T value);

        public void Update(Guid id, T value);

        public void Delete(Guid id);
    }
}
