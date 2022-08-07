using Newtonsoft.Json;
using YoizenTestApp.Models;

namespace YoizenTestApp.Repo
{
    public class InMemClientRepo : IRepo<Client>
    {
        private List<Client> _clients;

        public InMemClientRepo()
        {
            LoadJson();
        }
        private void LoadJson()
        {
            using (StreamReader r = new StreamReader("./JsonData/Clients.json"))
            {
                string json = r.ReadToEnd();
                var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                if(data != null && data.ContainsKey("clients"))
                {
                    var clients = JsonConvert.DeserializeObject<List<Client>>(data["clients"].ToString());
                    _clients = clients != null ? clients : new List<Client>();
                }
                else
                    _clients = new List<Client>();
            }
        }

        public void Create(Client value)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Client Get(Guid id)
        {
            return _clients.Where(client => client.Id == id).SingleOrDefault();
        }

        public Client GetByName(string name)
        {
            return _clients.Where(client => client.Name == name).SingleOrDefault();
        }

        public IEnumerable<Client> GetAll()
        {
            return _clients;
        }

        public void Update(Guid id, Client value)
        {
            throw new NotImplementedException();
        }

    }
}
