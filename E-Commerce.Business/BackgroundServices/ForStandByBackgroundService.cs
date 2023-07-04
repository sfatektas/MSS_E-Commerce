using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.BackgroundServices
{
    public class ForStandByBackgroundService : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            while(true)
            {
                await Task.Delay(10000);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
