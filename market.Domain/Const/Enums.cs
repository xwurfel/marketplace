namespace market.Domain.Const
{
    public enum UserType 
    { User = 0,
      Seller = 1 << 1, 
      Moderator = 1 << 2, 
      Administrator = 1 << 3,
    }

}