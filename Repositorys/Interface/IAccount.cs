namespace API.Repository.Interface
{
    public interface IAccount <Entity, Key> where Entity : class
    {
        public int Login(Entity Entity);

        public int Register(Entity Entity);
        public int ChangePasword(Entity Entity);
        public int ForgotPasword(Entity Entity);
    }
}
