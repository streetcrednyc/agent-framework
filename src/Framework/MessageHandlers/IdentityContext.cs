﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hyperledger.Indy.PoolApi;
using Hyperledger.Indy.WalletApi;

namespace AgentFramework.MessageHandlers
{
    /// <summary>
    /// Agent context.
    /// </summary>
    public class IdentityContext : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Streetcred.AgentFramework.MessageHandlers.IdentityContext"/> class.
        /// </summary>
        public IdentityContext()
        {
            State = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets or sets the pool.
        /// </summary>
        /// <value>The pool.</value>
        public Pool Pool
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the wallet.
        /// </summary>
        /// <value>The wallet.</value>
        public Wallet Wallet
        {
            get;
            set;
        }

        public string MyPublicDid
        {
            get;
            set;
        }

        public string MyPublicVerkey
        {
            get;
            set;
        }

        public string TheirPublicDid
        {
            get;
            set;
        }

        /// <summary>
        /// Dictionary used to pass object state down the pipeline
        /// </summary>
        /// <value>The state.</value>
        public IDictionary<string, object> State
        {
            get;
            set;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    //Task.WhenAll(Wallet.CloseAsync(), Pool.CloseAsync());
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~IdentityContext()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}