using Data.DownLoadFile.Interface;
using Entities;
using Utils;

namespace Data.DownLoadFile.Implementation
{
    public class DataFileDownLoad : UResult, IDataFileDownLoad
    {
        private readonly ContexMain _contexMain;
        public DataFileDownLoad(ContexMain contexMain)
        {
            _contexMain = contexMain;
        }
        public Task<Result<List<Client>>> GetFileData()
        {
            var result = new Result<List<Client>>();

            
                List<Client>? clientList = [];

                clientList = [.. (from client in _contexMain.Clients
                                   select new Client
                                   {
                                        IdClient = client.IdClient,
                                        NumberDocument = client.NumberDocument,
                                        FirstName = client.FirstName,
                                        LastName = client.LastName,
                                        Email = client.Email
                                   })];
            result.Values = clientList;

            return Task.FromResult(result);
        }
    }
}
