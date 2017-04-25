﻿using HJCS.Infrastructure;
using HJCS.Infrastructure.AdapterExternalServices;
using HJCS.Infrastructure.Repositories;


namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientMapper = new ClientMappper();//TODO: Inject
            var clientRetriever = new ClientsDataRetriever();//TODO: Inject
            var repo = new ClientRepository(clientMapper, clientRetriever);
            var list = repo.List;
            var client = repo.GetById("0178914c-548b-4a4c-b918-47d6a391530c");
        }
    }
}
