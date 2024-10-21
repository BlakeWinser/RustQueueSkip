using Oxide.Core.Plugins;
using Network;

namespace Oxide.Plugins
{
    [Info("QueueSkip", "Blake Winser", "1.0.0")]
    [Description("A plugin that allows VIP players to skip the queue.")]
    public class QueueSkip : RustPlugin
    {
        private const string QueueSkipPermission = "queueskip.vip";

        // Called when the plugin is loaded
        private void Init()
        {
            permission.RegisterPermission(QueueSkipPermission, this);
        }

        // Hook for queue skipping
        private object CanBypassQueue(Connection connection)
        {
            string userId = connection.userid.ToString();

            if (permission.UserHasPermission(userId, QueueSkipPermission))
            {
                Puts($"VIP Player {connection.username} is skipping the queue.");
                return true; // Allow VIP player to skip the queue
            }

            return null; // Proceed with the default queue behavior for non-VIP players
        }
    }
}
