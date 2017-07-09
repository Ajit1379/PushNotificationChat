using Android.App;
using Android.Util;
using Firebase.Messaging;

namespace PushNotificationChat.Droid.Services
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class ClientFirebaseMessaging : FirebaseMessagingService
    {
        public override void OnMessageReceived(RemoteMessage message)
        {
            Log.Debug("From: ", message.From);
            Log.Debug("Notification Message Body: ", message.GetNotification().Body);
        }
    }
}