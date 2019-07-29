using System.Threading.Tasks;
using Nethermind.Core.Crypto;
using Nethermind.DataMarketplace.Core;
using Nethermind.DataMarketplace.Core.Domain;
using Nethermind.DataMarketplace.Core.Services;

namespace Nethermind.DataMarketplace.Consumers.Services
{
    public class ConsumerNotifier : IConsumerNotifier
    {
        private readonly INdmNotifier _notifier;

        public ConsumerNotifier(INdmNotifier notifier)
        {
            _notifier = notifier;
        }

        public Task SendDepositConfirmationsStatusAsync(Keccak depositId, uint confirmations,
            uint requiredConfirmations, uint verificationTimestamp)
            => _notifier.NotifyAsync(new Notification("deposit_confirmations",
                new
                {
                    depositId,
                    confirmations,
                    requiredConfirmations,
                    verificationTimestamp
                }));

        public Task SendDataInvalidAsync(Keccak depositId, InvalidDataReason reason)
            => _notifier.NotifyAsync(new Notification("data_invalid",
                new
                {
                    depositId,
                    reason = reason.ToString()
                }));
    }
}