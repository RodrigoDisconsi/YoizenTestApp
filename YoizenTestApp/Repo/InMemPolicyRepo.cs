using Newtonsoft.Json;
using YoizenTestApp.Models;

namespace YoizenTestApp.Repo
{
    public class InMemPolicyRepo : IRepo<Policy>
    {
        private List<Policy> _policies;
        public InMemPolicyRepo()
        {
            LoadJson();
        }
        private void LoadJson()
        {
            using (StreamReader r = new StreamReader("./JsonData/Policies.json"))
            {
                string json = r.ReadToEnd();
                var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                if (data != null && data.ContainsKey("policies"))
                {
                    var policies = JsonConvert.DeserializeObject<List<Policy>>(data["policies"].ToString());
                    _policies = policies != null ? policies : new List<Policy>();
                }
                else
                    _policies = new List<Policy>();
            }
        }
        public void Create(Policy value)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Policy Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Policy> GetAll()
        {
            return _policies;
        }
        public IEnumerable<Policy> GetByClient(Guid clientId)
        {
            return _policies.Where(policy => policy.ClientId == clientId);
        }

        public void Update(Guid id, Policy value)
        {
            throw new NotImplementedException();
        }
    }
}
