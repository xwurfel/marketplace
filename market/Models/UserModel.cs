using market.Models.DataModels;

namespace market.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public Const.UserType UserType { get; set; }

        public List<ProductModel> ProductModels { get; set; }
    }
}
