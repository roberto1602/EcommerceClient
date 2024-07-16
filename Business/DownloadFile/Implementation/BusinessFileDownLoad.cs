using Business.DownloadFile.Interface;
using Data.DownLoadFile.Interface;
using Entities;
using Entities.ModelDto;
using Microsoft.AspNetCore.Http;
using Utils;

namespace Business.DownloadFile.Implementation
{
    public class BusinessFileDownLoad : UResult, IBusinessFileDownLoad
    {
        private readonly IDataFileDownLoad  _dataFileDownLoad;
        public BusinessFileDownLoad(IDataFileDownLoad dataFileDownLoad)
        {
            _dataFileDownLoad = dataFileDownLoad;
        }

        public async Task<Result<List<ClientDto>>> GetFile()
        {
            var result = new Result<List<ClientDto>>();

            List<ClientDto> clientList = [];

            var clients = await _dataFileDownLoad.GetFileData();

            if (clients.Values!.Count == 0)
                return Error<List<ClientDto>>(StatusCodes.Status404NotFound.ToString("clients no found"), null!);

            foreach (Client client in clients.Values!)
            {
                clientList.Add(new ClientDto()
                {
                    IdClient = client.IdClient,
                    NumberDocument = client.NumberDocument,
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    Email = client.Email
                });
            }

            FileUtil.FileExcelCSV(clients.Values);
            result.Values = MapClient(clients.Values!);
            result = Ok(StatusCodes.Status200OK.ToString(), result.Values);

            return result;
        }


        private static List<ClientDto> MapClient(List<Client> clientList) 
        {
            return clientList.Select(client => new ClientDto()
            {
                IdClient = client.IdClient,
                NumberDocument = client.NumberDocument,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email
            }).ToList();
        }
    }
}