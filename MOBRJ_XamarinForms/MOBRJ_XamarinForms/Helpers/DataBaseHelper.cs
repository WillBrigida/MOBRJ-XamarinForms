using MOBRJ_XamarinForms.DataBase;
using MOBRJ_XamarinForms.Models;
using MOBRJ_XamarinForms.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MOBRJ_XamarinForms.Helpers
{
    public class DataBaseHelper
    {
        ApiService _apiService;
        public static List<Record> ListaApi { get; set; }
        RepositoryRealm<Record> _repositoryRealm;


        public DataBaseHelper()
        {
            _apiService = new ApiService();
            _repositoryRealm = new RepositoryRealm<Record>();
            ListaApi = new List<Record>();
        }

        public async Task<List<Record>> GetApi()
        {
            var records = await _apiService.Get<Estados>("https://api.airtable.com",
               "/v0/app0RCW0xYP8RT3U9/Estados?api_key=keyhS9s7U3bGKSuml");
            foreach (var record in records.Records)
            {
                ListaApi.Add(record);
            }
            return ListaApi;
        }

        public void SalvarNoBancoLocalHelper()
        {
            foreach (var item in ListaApi)
            {
                _repositoryRealm.Insert(item);
            }
        }


        public List<Record> GetListaLocalHelper()
        {
            return _repositoryRealm.GetAll();
        }


        public void DeletarListaLocalHelper()
        {
            var list = GetListaLocalHelper();

            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    _repositoryRealm.Remove(item.Id);
                }
            }
        }
    }
}
