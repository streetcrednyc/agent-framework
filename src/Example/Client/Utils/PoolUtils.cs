﻿using Hyperledger.Indy.PoolApi;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Client.Utils
{
    static class PoolUtils
    {
        public const string DEFAULT_POOL_NAME = "ClientPool";

        public static string CreateGenesisTxnFile()
        {
            return new FileInfo(Program.Configuration.GetSection("GenesisFile").Value).FullName;
        }

        public static async Task CreatePoolLedgerConfig()
        {
            var genesisTxnFile = CreateGenesisTxnFile();

            Console.WriteLine($"Genesis file {genesisTxnFile}");

            var path = Path.GetFullPath(genesisTxnFile).Replace('\\', '/');
            var createPoolLedgerConfig = string.Format("{{\"genesis_txn\":\"{0}\"}}", path);

            try
            {
                await Pool.CreatePoolLedgerConfigAsync(DEFAULT_POOL_NAME, createPoolLedgerConfig);
            }
            catch (PoolLedgerConfigExistsException)
            {
                //Swallow expected exception if it happens.
            }
        }

        public static async Task DeletePoolLedgerConfigAsync(string name)
        {
            try
            {
                await Pool.DeletePoolLedgerConfigAsync(name);
            }
            catch (IOException) //TODO: This should be a more specific error when implemented
            {
                //Swallow expected exception if it happens.                
            }
        }
    }
}
