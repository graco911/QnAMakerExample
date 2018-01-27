using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using System.Collections.Generic;
using System.Linq;
using QnAMakerAndroidDemo.Services;
using QnAMakerAndroidDemo.Models;
using QnAMakerAndroidDemo.Adapters;
using Android.App;

namespace QnAMakerAndroidDemo
{
    [Activity(Label = "QnAMakerAndroidDemo", MainLauncher = true, Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class MainActivity : AppCompatActivity
    {
        public ListView list_of_messages;
        public EditText user_message;
        FloatingActionButton btn_send;

        public List<ModelMessageData> list_chat = new List<ModelMessageData>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            list_of_messages = FindViewById<ListView>(Resource.Id.list_of_message);
            user_message = FindViewById<EditText>(Resource.Id.user_message);
            btn_send = FindViewById<FloatingActionButton>(Resource.Id.fab);

            btn_send.Click += delegate
            {
                var model = new ModelMessageData();
                model.IsSend = true;
                model.Message = user_message.Text;
                list_chat.Add(model);
                SendMessage(user_message.Text);
            };
        }

        private async void SendMessage(string text)
        {
            var request = await QnAService.Post(text);
            if (request != null)
            {
                var model = new ModelMessageData();
                model.IsSend = false;
                model.Message = request.answers.FirstOrDefault().answer;
                list_chat.Add(model);
                CustomAdapter Adapter = new CustomAdapter(list_chat, this);
                list_of_messages.Adapter = Adapter;
                user_message.Text = "";
            }
        }
    }
}

